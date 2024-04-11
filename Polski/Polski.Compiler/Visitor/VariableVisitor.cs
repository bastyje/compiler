using Polski.Compiler.Common;
using Polski.Compiler.Generator;

namespace Polski.Compiler.Visitor;

public partial class PolskiVisitor
{
    private readonly ScopeContext _scopeContext = scopeContext;
    
    public override NodeResult VisitDeclaration(PolskiParser.DeclarationContext context)
    {
        var identifier = context.IDENTIFIER().GetText();
        var type = Visit(context.type());

        var member = _scopeContext.AddMember(new PolskiMember(identifier, type.PolskiMember.Type), true);
        
        return new NodeResult
        {
            Code = LlvmGenerator.AllocateVariable(member.LlvmName, member.LlvmType),
            PolskiMember = new PolskiMember(identifier, type.PolskiMember.Type)
        };
    }
    
    public override NodeResult VisitDefinition(PolskiParser.DefinitionContext context)
    {
        var declarationStatement = Visit(context.declaration());
        var expression = Visit(context.expression());

        if (declarationStatement.PolskiMember.Type != expression.PolskiMember.Type)
        {
            // todo exception
            throw new InvalidOperationException(
                $"Cannot assign not matching types: {declarationStatement.PolskiMember.Type} " +
                $"and {expression.PolskiMember.Type}");
        }

        _scopeContext.TryGetMember(declarationStatement.PolskiMember.Name, out var declarationMember);

        string valueAssignment;
        switch (expression.ResultKind)
        {
            case ResultKind.Variable:
                _scopeContext.TryGetMember(expression.PolskiMember.Name, out var expressionMember);
                valueAssignment = LlvmGenerator.StoreValue(
                    declarationMember.LlvmName,
                    declarationStatement.PolskiMember.Type,
                    expressionMember.LlvmName);
                break;
            case ResultKind.Value:
                valueAssignment = LlvmGenerator.StorePrimitiveValue(declarationMember.LlvmName,
                    declarationStatement.PolskiMember.Type,
                    expression.Value);
                break;
            default:
                throw new NotSupportedException($"{nameof(ResultKind)}: ${expression.ResultKind} is not supported");
        }
        
        return string.Join(
            string.Empty,
            declarationStatement,
            expression,
            valueAssignment);
    }
}