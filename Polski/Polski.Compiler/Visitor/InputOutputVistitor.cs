namespace Polski.Compiler.Visitor;

public partial class PolskiVisitor 
{
    public override NodeResult VisitPrintStatement(PolskiParser.PrintStatementContext context)
    {
        var expressionResult = Visit(context.expression());
        var code = $"call void @print({expressionResult.Type} %{expressionResult.Identifier})\n";
        return code;
    }

}