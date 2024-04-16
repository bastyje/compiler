using System.Text;
using Polski.Compiler.Generator;

namespace Polski.Compiler.Visitor;

public partial class PolskiVisitor
{
    public override NodeResult VisitBlock(PolskiParser.BlockContext context)
    {
        _scopeContext.PushScope();
        
        var sb = new StringBuilder();
        foreach (var line in context.line())
        {
            sb.Append(Visit(line));
        }
        
        _scopeContext.PopScope(context);

        return sb.ToString();
    }

    public override NodeResult VisitIf(PolskiParser.IfContext context)
    {
        var sb = new StringBuilder();
        var boolExpressionResult = Visit(context.booleanOrExpression());
        
        sb.Append(boolExpressionResult.Code);
        var conditionOperand = PrepareForOperation(boolExpressionResult, sb, context);
        
        var trueLabel = _scopeContext.GetNewLabel();
        var blockResult = Visit(context.block(0));
        var falseLabel = _scopeContext.GetNewLabel();
        
        sb.Append(LlvmGenerator.ConditionalJump(conditionOperand, trueLabel, falseLabel));
        sb.AppendLine();
        sb.Append(LlvmGenerator.Label(trueLabel));
        sb.Append(blockResult);
        
        var elseBlockResult = string.Empty;
        if (context.ELSE() is not null)
        {
            elseBlockResult = Visit(context.block(1));
        }
        var endLabel = _scopeContext.GetNewLabel();
        
        sb.Append(LlvmGenerator.UnconditionalJump(endLabel));
        sb.AppendLine();
        sb.Append(LlvmGenerator.Label(falseLabel));
        sb.Append(elseBlockResult);

        sb.Append(LlvmGenerator.UnconditionalJump(endLabel));
        sb.AppendLine();
        sb.Append(LlvmGenerator.Label(endLabel));

        return sb.ToString();
    }
    
    public override NodeResult VisitWhile(PolskiParser.WhileContext context)
    {
        var sb = new StringBuilder();
        
        var startLabel = _scopeContext.GetNewLabel();
        
        sb.Append(LlvmGenerator.UnconditionalJump(startLabel));
        sb.AppendLine();
        sb.Append(LlvmGenerator.Label(startLabel));
        
        var boolExpressionResult = Visit(context.booleanOrExpression());
        var conditionOperand = PrepareForOperation(boolExpressionResult, sb, context);
        var bodyLabel = _scopeContext.GetNewLabel();
        var bodyResult = Visit(context.block());
        var outLabel = _scopeContext.GetNewLabel();
        
        sb.Append(boolExpressionResult);
        sb.Append(LlvmGenerator.ConditionalJump(conditionOperand, bodyLabel, outLabel));
        sb.AppendLine();

        sb.Append(LlvmGenerator.Label(bodyLabel));
        sb.Append(bodyResult);
        sb.Append(LlvmGenerator.UnconditionalJump(startLabel));
        sb.AppendLine();

        sb.Append(LlvmGenerator.Label(outLabel));
        
        return sb.ToString();
    }
}