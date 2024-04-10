namespace Polski.Compiler.Visitor;

public partial class PolskiVisitor
{
    private bool printfDeclared = false;
    public override NodeResult VisitPrintStatement(PolskiParser.PrintStatementContext context)
    {
        var llvmIR = "";
        
        if (!printfDeclared && context.QUOTED_STRING() != null)
        {
            llvmIR += "declare i32 @printf(i8*, ...)\n";
            printfDeclared = true;
        }

        if (context.QUOTED_STRING() != null)
        {
            var strValue = context.QUOTED_STRING().GetText().Trim('"');
            var strLabel = "@.str";
            llvmIR += $"{strLabel} = private unnamed_addr constant [{strValue.Length + 1} x i8] c\"{strValue}\\00\"\n";
            llvmIR += $"call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([{strValue.Length + 1} x i8], [{strValue.Length + 1} x i8]* {strLabel}, i64 0, i64 0))\n";
        }
        else if (context.IDENTIFIER() != null)
        {
            var variableName = context.IDENTIFIER().GetText();
            var variableValue = GetVariableValueFromSymbolTable(variableName); // You need to implement this method
            var strLabel = "@.str";
            llvmIR += $"{strLabel} = private unnamed_addr constant [{variableValue.Length + 1} x i8] c\"{variableValue}\\00\"\n";
            llvmIR += $"call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([{variableValue.Length + 1} x i8], [{variableValue.Length + 1} x i8]* {strLabel}, i64 0, i64 0))\n";
        }
        
        return new NodeResult
        {
            Code = llvmIR
        };
    }
}