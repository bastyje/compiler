using System.Text;
using Antlr4.Runtime;
using Polski.Compiler.Common;
using Polski.Compiler.Error;
using Polski.Compiler.Generator;
using Polski.Compiler.LanguageDefinition;

namespace Polski.Compiler.Visitor;

/// <summary>
/// This partial class covers arithmetic expressions
/// </summary>
public partial class PolskiVisitor
{
    public override NodeResult VisitAdditiveExpression(PolskiParser.AdditiveExpressionContext context)
    {
        var expressions = context.multiplicativeExpression();

        if (expressions.Length == 1)
        {
            return Visit(expressions[0]);
        }

        var sb = new StringBuilder();
        var previousResult = Visit(expressions[0]);
        for (var i = 0; i < expressions.Length - 1; i++)
        {
            var right = Visit(expressions[i + 1]);

            if (previousResult.PolskiMember.Type != right.PolskiMember.Type)
            {
                throw new SemanticErrorException(
                    $"Cannot add not matching types: {previousResult.PolskiMember.Type} and {right.PolskiMember.Type}",
                    context);
            }
            
            sb.Append(previousResult.Code);
            sb.Append(right.Code);

            var leftOperand = PrepareForOperation(previousResult, sb, context);
            var rightOperand = PrepareForOperation(right, sb, context);
            var resultMember = _scopeContext.AddMember(previousResult.PolskiMember.Type);

            if (context.GetToken(PolskiParser.PLUS, i) is not null)
            {
                sb.Append(LlvmGenerator.CallAdd(resultMember, leftOperand, rightOperand));
            }
            else if (context.GetToken(PolskiParser.MINUS, i) is not null)
            {
                sb.Append(LlvmGenerator.CallSub(resultMember, leftOperand, rightOperand));
            }
            else
            {
                throw new InvalidOperationException();
            }
            
            previousResult = new NodeResult
            {
                PolskiMember = resultMember.PolskiMember
            };
        }

        return new NodeResult
        {
            Code = sb.ToString(),
            PolskiMember = previousResult.PolskiMember
        };
    }

    public override NodeResult VisitMultiplicativeExpression(PolskiParser.MultiplicativeExpressionContext context)
    {
        var expressions = context.unaryExpression();

        if (expressions.Length == 1)
        {
            return Visit(expressions[0]);
        }

        var sb = new StringBuilder();
        var previousResult = Visit(expressions[0]);
        for (var i = 0; i < expressions.Length - 1; i++)
        {
            var right = Visit(expressions[i + 1]);
            
            if (previousResult.PolskiMember.Type != right.PolskiMember.Type)
            {
                throw new SemanticErrorException(
                    $"Cannot multiply not matching types: {previousResult.PolskiMember.Type} and {right.PolskiMember.Type}",
                    context);
            }

            sb.Append(previousResult.Code);
            sb.Append(right.Code);

            var leftOperand = PrepareForOperation(previousResult, sb, context);
            var rightOperand = PrepareForOperation(right, sb, context);
            var resultMember = _scopeContext.AddMember(previousResult.PolskiMember.Type);
            
            if (context.GetToken(PolskiParser.MULTIPLY, i) is not null)
            {
                sb.Append(LlvmGenerator.CallMul(resultMember, leftOperand, rightOperand));
            }
            else if (context.GetToken(PolskiParser.DIVIDE, i) is not null)
            {
                sb.Append(LlvmGenerator.CallDiv(resultMember, leftOperand, rightOperand));
            }
            else
            {
                throw new InvalidOperationException();
            }
            
            previousResult = new NodeResult
            {
                PolskiMember = resultMember.PolskiMember
            };
        }

        return new NodeResult
        {
            Code = sb.ToString(),
            PolskiMember = previousResult.PolskiMember
        };
    }

    public override NodeResult VisitUnaryExpression(PolskiParser.UnaryExpressionContext context)
    {
        return Visit(context.primaryExpression());
    }
    
    public override NodeResult VisitPrimaryExpression(PolskiParser.PrimaryExpressionContext context)
    {
        if (context.IDENTIFIER() is { } identifier)
        {
            var identifierMember = _scopeContext.GetMember(identifier.GetText(), context);
        
            return new NodeResult
            {
                PolskiMember = new PolskiMember(identifierMember.PolskiMember.Name, identifierMember.PolskiMember.Type)
            };
        }
        
        var number = context.number();
        if (number is not null)
        {
            return Visit(number);
        }
        
        throw new SemanticErrorException("Not recognized token", context);
    }
    
    public override NodeResult VisitNumber(PolskiParser.NumberContext context)
    {
        if (context.INTEGER_NUMBER() is {} integer)
        {
            return new NodeResult
            {
                PolskiMember = new PolskiMember(PolskiDataType.Int32),
                Value = integer.GetText()
            };
        }
        
        if (context.BIG_INTEGER_NUMBER() is {} bigInteger)
        {
            var text = bigInteger.GetText();
            return new NodeResult
            {
                PolskiMember = new PolskiMember(PolskiDataType.Int64),
                Value = text.Remove(text.Length - 1)
            };
        }

        if (context.REAL_NUMBER() is {} real)
        {
            return new NodeResult
            {
                PolskiMember = new PolskiMember(PolskiDataType.Double),
                Value = real.GetText()
            };
        }

        throw new InvalidOperationException();
    }

    private Operand PrepareForOperation(NodeResult nodeResult, StringBuilder stringBuilder, ParserRuleContext context)
    {
        Operand operand;
        switch (nodeResult.ResultKind)
        {
            case ResultKind.Variable:
                var leftMember = _scopeContext.GetMember(nodeResult.PolskiMember.Name, context);
                if (leftMember.StackAllocated)
                { 
                    var newMember = _scopeContext.AddMember(nodeResult.PolskiMember.Type);
                    operand = new Operand(ResultKind.Variable, newMember.LlvmName);
                    stringBuilder.Append(LlvmGenerator.LoadValue(
                        newMember.LlvmName,
                        leftMember));
                }
                else
                {
                    operand = new Operand(ResultKind.Variable, leftMember.LlvmName);
                }
                break;
            case ResultKind.Value:
                operand = new Operand(ResultKind.Value, nodeResult.Value);
                break;
            default:
                throw new NotSupportedException($"{nameof(ResultKind)}: ${nodeResult.ResultKind} is not supported");
        }

        return operand;
    }
}