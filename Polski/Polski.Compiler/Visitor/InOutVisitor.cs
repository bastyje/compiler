using System.Text;
using Polski.Compiler.Generator;

namespace Polski.Compiler.Visitor;

public partial class PolskiVisitor
{
    public override NodeResult VisitPrint(PolskiParser.PrintContext context)
    {
        var expression = Visit(context.expression());
        var expressionResult = _scopeContext.GetMember(expression.PolskiMember.Name);
        var printfVar = _scopeContext.AddMember(expression.PolskiMember.Type);
        
        _scopeContext.AddAnonymousMember();
        
        if (expressionResult.StackAllocated)
        {
            return new NodeResult
            {
                Code = new StringBuilder()
                    .Append(expression.Code)
                    .Append(LlvmGenerator.LoadValue(printfVar.LlvmName, expressionResult.LlvmName, expressionResult.PolskiMember.Type))
                    .Append(LlvmGenerator.Print(printfVar))
                    .ToString(),
            };
        }
        
        return new NodeResult
        {
            Code = new StringBuilder()
                .Append(expression)
                .Append(LlvmGenerator.Print(expressionResult))
                .ToString(),
        };
    }
    
    public override NodeResult VisitRead(PolskiParser.ReadContext context)
    {
        var identifier = context.IDENTIFIER().GetText();
        var member = _scopeContext.GetMember(identifier);
        
        _scopeContext.AddAnonymousMember();
        
        return new NodeResult
        {
            Code = LlvmGenerator.Scan(member),
        };
    }
}