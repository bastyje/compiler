using System.Text;
using Polski.Compiler.Common;
using Polski.Compiler.Generator;

namespace Polski.Compiler.Visitor;

public partial class PolskiVisitor
{
    public override NodeResult VisitFunctionDeclaration(PolskiParser.FunctionDeclarationContext context)
    {
        var identifier = context.IDENTIFIER().GetText();
        var type = Visit(context.type()).PolskiMember.Type;
        
        _scopeContext.PushScope(identifier);
        var parameters = context.declaration().Select(p => _scopeContext.AddMember(Visit(p).PolskiMember, p)).ToList();
        
        var function = _scopeContext.AddFunction(type, parameters, identifier, context);
        var sb = new StringBuilder();
        sb.Append(LlvmGenerator.FunctionDeclaration(function));

        sb.Append(Visit(context.functionBlock()));
        _scopeContext.PopScope(context);
        sb.Append(LlvmGenerator.FunctionClose());
        
        return sb.ToString();
    }

    public override NodeResult VisitFunctionBlock(PolskiParser.FunctionBlockContext context)
    {
        var sb = new StringBuilder();
        NodeResult result;
        
        foreach (var line in context.line())
        {
            result = Visit(line);
            sb.Append(result);
        }

        var expressionResult = Visit(context.expression());
        var operand = PrepareForOperation(expressionResult, sb, context);

        sb.Append(LlvmGenerator.Return(operand, expressionResult.PolskiMember.Type));
        
        return sb.ToString();
    }

    public override NodeResult VisitFunctionCall(PolskiParser.FunctionCallContext context)
    {
        var identifier = context.IDENTIFIER().GetText();
        var function = _scopeContext.GetFunction(identifier, context);
        
        var sb = new StringBuilder();
        var arguments = context.expression().Select(e => PrepareForOperation(Visit(e), sb, context)).ToList();
        var member = _scopeContext.AddMember(function.ReturnType);
        sb.Append(LlvmGenerator.FunctionCall(member, function, arguments));

        return new NodeResult
        {
            Code = sb.ToString(),
            PolskiMember = member.PolskiMember
        };
    }
}