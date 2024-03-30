namespace Polski.Compiler.Visitor;

public partial class PolskiVisitor
{
    public override NodeResult VisitType(PolskiParser.TypeContext context)
    {
        return Visit(context.numericType());
    }
    
    public override NodeResult VisitNumericType(PolskiParser.NumericTypeContext context)
    {
        return new NodeResult
        {
            Type = context.GetText()
        };
    }
}