using System.Text;
using Polski.Compiler.Common;
using Polski.Compiler.exception;
using Polski.Compiler.Generator;
using Polski.Compiler.LanguageDefinition;

namespace Polski.Compiler.Visitor;

/// <summary>
/// This partial class covers arithmetic expressions
/// </summary>
public partial class PolskiVisitor
{
    public override NodeResult VisitArithmeticExpression(PolskiParser.ArithmeticExpressionContext context)
    {
        if (context.IDENTIFIER() is { } identifier)
        {
            _scopeContext.TryGetMember(identifier.GetText(), out var identifierMember);

            return new NodeResult
            {
                PolskiMember = new PolskiMember(identifierMember.PolskiMember.Name, identifierMember.PolskiMember.Type)
            };
        }

        if (context.MULTIPLY() is not null)
        {
            var left = Visit(context.arithmeticExpression(0));
            var right = Visit(context.arithmeticExpression(1));

            var sb = new StringBuilder();
            sb.Append(left);
            sb.Append(right);

            var leftOperand = PrepareForOperation(left, sb);
            var rightOperand = PrepareForOperation(right, sb);
            var resultMember = _scopeContext.AddMember(left.PolskiMember.Type);
            
            sb.Append(LlvmGenerator.CallMulI32(resultMember.LlvmName, leftOperand, rightOperand));

            return new NodeResult
            {
                // todo use proper division operator with respect to operand types
                Code = sb.ToString(),
                PolskiMember = resultMember.PolskiMember
            };
        }

        if (context.DIVIDE() is not null)
        {
            var left = Visit(context.arithmeticExpression(0));
            var right = Visit(context.arithmeticExpression(1));

            var sb = new StringBuilder();
            sb.Append(left);
            sb.Append(right);

            var leftOperand = PrepareForOperation(left, sb);
            var rightOperand = PrepareForOperation(right, sb);
            var resultMember = _scopeContext.AddMember(left.PolskiMember.Type);
            
            sb.Append(LlvmGenerator.CallDivI32(resultMember.LlvmName, leftOperand, rightOperand));
            
            return new NodeResult
            {
                // todo use proper division operator with respect to operand types
                Code = sb.ToString(),
                PolskiMember = resultMember.PolskiMember
            };
        }

        if (context.PLUS() is not null)
        {
            var left = Visit(context.arithmeticExpression(0));
            var right = Visit(context.arithmeticExpression(1));

            var sb = new StringBuilder();
            sb.Append(left);
            sb.Append(right);

            var leftOperand = PrepareForOperation(left, sb);
            var rightOperand = PrepareForOperation(right, sb);
            var resultMember = _scopeContext.AddMember(left.PolskiMember.Type);
            
            sb.Append(LlvmGenerator.CallAddI32(resultMember.LlvmName, leftOperand, rightOperand));
            
            return new NodeResult
            {
                // todo use proper division operator with respect to operand types
                Code = sb.ToString(),
                PolskiMember = resultMember.PolskiMember
            };
        }

        if (context.MINUS() is not null)
        {
            var left = Visit(context.arithmeticExpression(0));
            var right = Visit(context.arithmeticExpression(1));

            var sb = new StringBuilder();
            sb.Append(left);
            sb.Append(right);

            var leftOperand = PrepareForOperation(left, sb);
            var rightOperand = PrepareForOperation(right, sb);
            var resultMember = _scopeContext.AddMember(left.PolskiMember.Type);
            
            sb.Append(LlvmGenerator.CallSubI32(resultMember.LlvmName, leftOperand, rightOperand));
            
            return new NodeResult
            {
                // todo use proper division operator with respect to operand types
                Code = sb.ToString(),
                PolskiMember = resultMember.PolskiMember
            };
        }

        var number = context.number();
        if (number is not null)
        {
            return Visit(number);
        }

        // todo exception
        throw new CompilationException("Invalid arithmetic expression", context.Start.Line, context.arithmeticExpression(0).Stop.Column);
    }

    public override NodeResult VisitNumber(PolskiParser.NumberContext context)
    {
        var integer = context.INTEGER_NUMBER();
        
        if (integer is not null)
        {
            return new NodeResult
            {
                PolskiMember = new PolskiMember(PolskiDataType.Int32),
                Value = integer.GetText()
            };
        }

        var real = context.REAL_NUMBER();
        if (real is not null)
        {
            return new NodeResult
            {
                PolskiMember = new PolskiMember(PolskiDataType.Float),
                Value = real.GetText()
            };
        }

        throw new CompilationException($"Invalid number type {context.GetText()}", context);
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