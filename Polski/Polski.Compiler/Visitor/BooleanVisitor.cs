using System.Text;
using Polski.Compiler.Common;
using Polski.Compiler.Error;
using Polski.Compiler.Generator;
using Polski.Compiler.LanguageDefinition;

namespace Polski.Compiler.Visitor;

public partial class PolskiVisitor
{
    public override NodeResult VisitBooleanValue(PolskiParser.BooleanValueContext context)
    {
        var left = Visit(context.expression(0));
        var right = Visit(context.expression(1));

        var sb = new StringBuilder()
            .Append(left)
            .Append(right);
            
        if (left.PolskiMember.Type != right.PolskiMember.Type)
        {
            throw new SemanticErrorException(
                $"Cannot compare not matching types: {left.PolskiMember.Type} and {right.PolskiMember.Type}",
                context);
        }

        var leftOperand = PrepareForOperation(left, sb, context);
        var rightOperand = PrepareForOperation(right, sb, context);
        
        var result = _scopeContext.AddMember(PolskiDataType.Bool);
        
        if (context.EQUALS() is not null)
        {
            sb.Append(LlvmGenerator.Equals(result, leftOperand, rightOperand, left.PolskiMember.Type));
        }
        else if (context.NOT_EQUALS() is not null)
        {
            sb.Append(LlvmGenerator.NotEquals(result, leftOperand, rightOperand, left.PolskiMember.Type));
        }
        else if (context.GREATER() is not null)
        {
            sb.Append(LlvmGenerator.Greater(result, leftOperand, rightOperand, left.PolskiMember.Type));
        }
        else if (context.GREATER_OR_EQUALS() is not null)
        {
            sb.Append(LlvmGenerator.GreaterOrEquals(result, leftOperand, rightOperand, left.PolskiMember.Type));
        }
        else if (context.LESS() is not null)
        {
            sb.Append(LlvmGenerator.Less(result, leftOperand, rightOperand, left.PolskiMember.Type));
        }
        else if (context.LESS_OR_EQUALS() is not null)
        {
            sb.Append(LlvmGenerator.LessOrEquals(result, leftOperand, rightOperand, left.PolskiMember.Type));
        }
        else
        {
            throw new SemanticErrorException("Unknown boolean operator", context);
        }
        
        return new NodeResult
        {
            Code = sb.ToString(),
            PolskiMember = result.PolskiMember
        };
    }
    
    public override NodeResult VisitBooleanPrimaryExpression(PolskiParser.BooleanPrimaryExpressionContext context)
    {
        if (context.booleanValue() is { } booleanValue)
        {
            return Visit(booleanValue);
        }
        
        if (context.booleanPrimaryExpression() is {} booleanPrimaryExpression)
        {
            var result = Visit(booleanPrimaryExpression);
            var sb = new StringBuilder().Append(result);
            
            var operand = PrepareForOperation(result, sb, context);
            var resultMember = _scopeContext.AddMember(PolskiDataType.Bool);
            
            sb.Append(LlvmGenerator.Xor(resultMember, operand, new Operand(ResultKind.Value, "true")));
            
            return new NodeResult
            {
                Code = sb.ToString(),
                PolskiMember = resultMember.PolskiMember
            };
        }
        
        throw new SemanticErrorException("Unknown boolean expression", context);
    }
    
    public override NodeResult VisitBooleanXorExpression(PolskiParser.BooleanXorExpressionContext context)
    {
        var expressions = context.booleanPrimaryExpression();
        
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
                    $"Cannot xor not matching types: {previousResult.PolskiMember.Type} and {right.PolskiMember.Type}",
                    context);
            }
            
            sb.Append(previousResult.Code);
            sb.Append(right.Code);

            var resultMember = _scopeContext.AddMember(PolskiDataType.Bool, true);

            sb.Append(LlvmGenerator.AllocateVariable(resultMember.LlvmName, resultMember.LlvmType));
            
            var leftOperand = PrepareForOperation(previousResult, sb, context);
            var leftTrueLabel = _scopeContext.GetNewLabel();
            var leftFalseLabel = _scopeContext.GetNewLabel();

            sb.Append(LlvmGenerator.ConditionalJump(leftOperand, leftTrueLabel, leftFalseLabel));
            sb.AppendLine();
            sb.Append(LlvmGenerator.Label(leftTrueLabel));
            
            var rightOperand = PrepareForOperation(right, sb, context);
            var trueLabel = _scopeContext.GetNewLabel();
            var falseLabel = _scopeContext.GetNewLabel();
            var outLabel = _scopeContext.GetNewLabel();
            
            sb.Append(LlvmGenerator.ConditionalJump(rightOperand, falseLabel, trueLabel));
            sb.AppendLine();
            sb.Append(LlvmGenerator.Label(leftFalseLabel));
            sb.Append(LlvmGenerator.ConditionalJump(rightOperand, trueLabel, falseLabel));
            sb.AppendLine();
            
            sb.Append(LlvmGenerator.Label(trueLabel));
            sb.Append(LlvmGenerator.StorePrimitiveValue(resultMember.LlvmName, PolskiDataType.Bool, "true"));
            sb.Append(LlvmGenerator.UnconditionalJump(outLabel));
            sb.AppendLine();
            
            sb.Append(LlvmGenerator.Label(falseLabel));
            sb.Append(LlvmGenerator.StorePrimitiveValue(resultMember.LlvmName, PolskiDataType.Bool, "false"));
            sb.Append(LlvmGenerator.UnconditionalJump(outLabel));
            sb.AppendLine();

            sb.Append(LlvmGenerator.Label(outLabel));
            
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
    
    public override NodeResult VisitBooleanAndExpression(PolskiParser.BooleanAndExpressionContext context)
    {
        var expressions = context.booleanXorExpression();
        
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
                    $"Cannot and not matching types: {previousResult.PolskiMember.Type} and {right.PolskiMember.Type}",
                    context);
            }
            
            sb.Append(previousResult.Code);
            sb.Append(right.Code);

            var resultMember = _scopeContext.AddMember(PolskiDataType.Bool, true);

            var leftOperand = PrepareForOperation(previousResult, sb, context);
            var rightOperand = PrepareForOperation(right, sb, context);
            
            sb.Append(LlvmGenerator.AllocateVariable(resultMember.LlvmName, resultMember.LlvmType));
            
            var leftTrueLabel = _scopeContext.GetNewLabel();
            var trueLabel = _scopeContext.GetNewLabel();
            var falseLabel = _scopeContext.GetNewLabel();
            var outLabel = _scopeContext.GetNewLabel();
            
            sb.Append(LlvmGenerator.ConditionalJump(leftOperand, leftTrueLabel, falseLabel));
            sb.AppendLine();
            sb.Append(LlvmGenerator.Label(leftTrueLabel));
            sb.Append(LlvmGenerator.ConditionalJump(rightOperand, trueLabel, falseLabel));
            sb.AppendLine();
            
            sb.Append(LlvmGenerator.Label(trueLabel));
            sb.Append(LlvmGenerator.StorePrimitiveValue(resultMember.LlvmName, PolskiDataType.Bool, "true"));
            sb.Append(LlvmGenerator.UnconditionalJump(outLabel));
            sb.AppendLine();
                            
            sb.Append(LlvmGenerator.Label(falseLabel));
            sb.Append(LlvmGenerator.StorePrimitiveValue(resultMember.LlvmName, PolskiDataType.Bool, "false"));
            sb.Append(LlvmGenerator.UnconditionalJump(outLabel));
            sb.AppendLine();
            
            sb.Append(LlvmGenerator.Label(outLabel));
            
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
    
    public override NodeResult VisitBooleanOrExpression(PolskiParser.BooleanOrExpressionContext context)
    {
        var expressions = context.booleanAndExpression();
        
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
                    $"Cannot or not matching types: {previousResult.PolskiMember.Type} and {right.PolskiMember.Type}",
                    context);
            }
            
            sb.Append(previousResult.Code);
            sb.Append(right.Code);

            var resultMember = _scopeContext.AddMember(PolskiDataType.Bool, true);

            sb.Append(LlvmGenerator.AllocateVariable(resultMember.LlvmName, resultMember.LlvmType));
            
            var leftOperand = PrepareForOperation(previousResult, sb, context);
            var rightOperand = PrepareForOperation(right, sb, context);
            
            var leftFalseLabel = _scopeContext.GetNewLabel();
            var trueLabel = _scopeContext.GetNewLabel();
            var falseLabel = _scopeContext.GetNewLabel();
            var outLabel = _scopeContext.GetNewLabel();
            
            sb.Append(LlvmGenerator.ConditionalJump(leftOperand, trueLabel, leftFalseLabel));
            sb.AppendLine();
            sb.Append(LlvmGenerator.Label(leftFalseLabel));
            sb.Append(LlvmGenerator.ConditionalJump(rightOperand, trueLabel, falseLabel));
            sb.AppendLine();
            
            sb.Append(LlvmGenerator.Label(trueLabel));
            sb.Append(LlvmGenerator.StorePrimitiveValue(resultMember.LlvmName, PolskiDataType.Bool, "true"));
            sb.Append(LlvmGenerator.UnconditionalJump(outLabel));
            sb.AppendLine();
            
            sb.Append(LlvmGenerator.Label(falseLabel));
            sb.Append(LlvmGenerator.StorePrimitiveValue(resultMember.LlvmName, PolskiDataType.Bool, "false"));
            sb.Append(LlvmGenerator.UnconditionalJump(outLabel));
            sb.AppendLine();

            sb.Append(LlvmGenerator.Label(outLabel));
            
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
}

// assume %1 is i1
// assume %2 is i1
// xor
// br i1 %1, label %3, label %4
// %3:
// br i1 %2, label %5, label %6
// %5:
// ret i1 true
// %6:
// ret i1 false