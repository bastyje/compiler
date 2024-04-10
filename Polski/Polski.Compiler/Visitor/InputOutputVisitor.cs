using Polski.Compiler.Generator;

namespace Polski.Compiler.Visitor;

public partial class PolskiVisitor
{
    private int strCounter = 0; // To ensure unique string labels
    private bool printfDeclared = false;
    private bool scanfDeclared = false;
    
    public override NodeResult VisitPrintStatement(PolskiParser.PrintStatementContext context)
    {
        var llvmIR = "";

        if (!printfDeclared)
        {
            llvmIR += "declare i32 @printf(i8*, ...)\n";
            printfDeclared = true;
        }

        if (context.QUOTED_STRING() != null)
        {
            var strValue = context.QUOTED_STRING().GetText().Trim('"');
            var strLabel = $"@.str{strCounter++}";
            llvmIR += $"{strLabel} = private unnamed_addr constant [{strValue.Length + 1} x i8] c\"{strValue}\\00\", align 1\n";
            llvmIR += $"call i32 (i8*, ...) @printf(i8* getelementptr ([{strValue.Length + 1} x i8], [{strValue.Length + 1} x i8]* {strLabel}, i32 0, i32 0))\n";
        }
        else if (context.IDENTIFIER() != null)
        {
            
            var variableName = context.IDENTIFIER().GetText();
            var resultName = "tmp" + strCounter++;

            var nodeResult = Visit(context.IDENTIFIER());
            var variableType = nodeResult.PolskiMember.Type; 
            
            llvmIR += LlvmGenerator.LoadValue(resultName, variableName, variableType);
            
            var formatSpecifier = GetFormatSpecifier(variableType);
            var formatStrLabel = $"@.str{strCounter++}";
            llvmIR += $"{formatStrLabel} = private unnamed_addr constant [4 x i8] c\"{formatSpecifier}\\00\", align 1\n";
            llvmIR += $"call i32 (i8*, ...) @printf(i8* getelementptr ([4 x i8], [4 x i8]* {formatStrLabel}, i32 0, i32 0), {variableType} %{resultName})\n";
        }
        
        return new NodeResult
        {
            Code = llvmIR
        };
    }

    private string GetFormatSpecifier(string llvmType)
    {
        switch (llvmType)
        {
            case "i32": return "%d";
            case "float": return "%f";
            default: throw new NotImplementedException($"No printf format specifier for LLVM type: {llvmType}");
        }
    }
    
    public override NodeResult VisitReadStatement(PolskiParser.ReadStatementContext context)
    {
        var llvmIR = "";

        if (!scanfDeclared)
        {
            llvmIR += "declare i32 @scanf(i8*, ...)\n";
            scanfDeclared = true;
        }

        var variableName = context.IDENTIFIER().GetText();
        var resultName = "tmp" + strCounter++;

        // Assuming you have a mechanism to get the type of a variable (similar to how it's done in VisitPrintStatement)
        var nodeResult = Visit(context.IDENTIFIER());
        var variableType = nodeResult.PolskiMember.Type; 

        var formatSpecifier = GetFormatSpecifier(variableType);
        var formatStrLabel = $"@.str{strCounter++}";
        llvmIR += $"{formatStrLabel} = private unnamed_addr constant [3 x i8] c\"{formatSpecifier}\\00\", align 1\n";
        llvmIR += $"call i32 (i8*, ...) @scanf(i8* getelementptr ([3 x i8], [3 x i8]* {formatStrLabel}, i32 0, i32 0), {variableType}* %{resultName})\n";

        return new NodeResult
        {
            Code = llvmIR
        };
    }
}