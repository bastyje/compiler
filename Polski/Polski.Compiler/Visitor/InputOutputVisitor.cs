using System.Text;
using Polski.Compiler.Generator;

namespace Polski.Compiler.Visitor;

public partial class PolskiVisitor
{
    private int strCounter = 0; // To ensure unique string labels

    public override NodeResult VisitPrintStatement(PolskiParser.PrintStatementContext context)
    {
        var llvmIR = new StringBuilder();

        if (context.QUOTED_STRING() != null)
        {
            var strValue = context.QUOTED_STRING().GetText().Trim('"');
            llvmIR.AppendLine(LlvmGenerator.PrintLiteral(strValue, ref strCounter));
        }
        else if (context.IDENTIFIER() != null)
        {
            var variableName = context.IDENTIFIER().GetText();
            var resultName = $"tmp{strCounter++}";

            var nodeResult = Visit(context.IDENTIFIER());
            var variableType = nodeResult.PolskiMember.Type; 

            llvmIR.AppendLine(LlvmGenerator.LoadValue(resultName, variableName, variableType));
            llvmIR.AppendLine(LlvmGenerator.PrintfVariable(resultName, variableType, ref strCounter));
        }
        
        return new NodeResult
        {
            Code = llvmIR.ToString()
        };
    }

    private string GetFormatSpecifier(string llvmType)
    {
        return llvmType switch
        {
            "i32" => "%d",      
            "i64" => "%ld",      
            "float" => "%f",     
            "double" => "%lf",
            _ => throw new NotImplementedException($"No printf format specifier for LLVM type: {llvmType}")
        };
        
    }
    
    public override NodeResult VisitReadStatement(PolskiParser.ReadStatementContext context)
    {
        var llvmIR = new StringBuilder();
        var variableName = context.IDENTIFIER().GetText();
        var nodeResult = Visit(context.IDENTIFIER());
        var variableType = nodeResult.PolskiMember.Type; 

        llvmIR.AppendLine(LlvmGenerator.ScanfVariable(variableName, variableType, ref strCounter));

        return new NodeResult
        {
            Code = llvmIR.ToString()
        };
    }
}