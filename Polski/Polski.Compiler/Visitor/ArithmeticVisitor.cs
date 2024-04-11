using System.Text;
using Polski.Compiler.Common;
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
                throw new InvalidOperationException(
                    $"Cannot add not matching types: {previousResult.PolskiMember.Type} " +
                    $"and {right.PolskiMember.Type}");
            }
            
            sb.Append(previousResult.Code);
            sb.Append(right.Code);

            var leftOperand = PrepareForOperation(previousResult, sb);
            var rightOperand = PrepareForOperation(right, sb);
            var resultMember = _scopeContext.AddMember(previousResult.PolskiMember.Type);

            if (context.PLUS() is not null)
            {
                sb.Append(LlvmGenerator.CallAdd(resultMember, leftOperand, rightOperand));
            }
            else if (context.MINUS() is not null)
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
                throw new InvalidOperationException(
                    $"Cannot multiply not matching types: {previousResult.PolskiMember.Type} " +
                    $"and {right.PolskiMember.Type}");
            }

            sb.Append(previousResult.Code);
            sb.Append(right.Code);

            var leftOperand = PrepareForOperation(previousResult, sb);
            var rightOperand = PrepareForOperation(right, sb);
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
            _scopeContext.TryGetMember(identifier.GetText(), out var identifierMember);
        
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
        
        throw new InvalidOperationException();
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
                PolskiMember = new PolskiMember(PolskiDataType.Float),
                Value = real.GetText()
            };
        }
        
        if (context.BIG_REAL_NUMBER() is {} bigReal)
        {
            var text = bigReal.GetText();
            return new NodeResult
            {
                PolskiMember = new PolskiMember(PolskiDataType.Double),
                Value = text.Remove(text.Length - 1)
            };
        }

        throw new InvalidOperationException();
    }

    private Operand PrepareForOperation(NodeResult nodeResult, StringBuilder stringBuilder)
    {
        Operand operand;
        switch (nodeResult.ResultKind)
        {
            case ResultKind.Variable:
                _scopeContext.TryGetMember(nodeResult.PolskiMember.Name, out var leftMember);
                if (leftMember.StackAllocated)
                { 
                    var newMember = _scopeContext.AddMember(nodeResult.PolskiMember.Type);
                    operand = new Operand(ResultKind.Variable, newMember.LlvmName);
                    stringBuilder.Append(LlvmGenerator.LoadValue(
                        newMember.LlvmName,
                        leftMember.LlvmName,
                        newMember.LlvmType));
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