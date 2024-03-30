namespace Polski.Compiler.Visitor;

/// <summary>
/// This partial class covers todo
/// </summary>
public partial class PolskiVisitor : PolskiBaseVisitor<NodeResult>
{
    public override NodeResult VisitProgram(PolskiParser.ProgramContext context)
    {
        UsedIdentifiers.Clear();
        return context.children.Aggregate(string.Empty, (current, child) => current + Visit(child));
    }
    
    public override NodeResult VisitExpression(PolskiParser.ExpressionContext context)
    {
        return Visit(context.arithmeticExpression());
    }
}

