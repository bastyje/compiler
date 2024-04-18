using Polski.Compiler.Common;
using Polski.Compiler.Error;
using Polski.Compiler.Generator;

namespace Polski.Compiler.Visitor;

public partial class PolskiVisitor
{
    private readonly ScopeContext _scopeContext = scopeContext;
    
    #region Local
    
    public override NodeResult VisitDeclaration(PolskiParser.DeclarationContext context)
    {
        var identifier = context.IDENTIFIER().GetText();
        var type = Visit(context.type());

        var member = _scopeContext.AddMember(new PolskiMember(identifier, type.PolskiMember.Type), context, true);
        
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
            throw new SemanticErrorException(
                $"Cannot assign not matching types: {declarationStatement.PolskiMember.Type} and {expression.PolskiMember.Type}",
                context);
        }

        var declarationMember = _scopeContext.GetMember(declarationStatement.PolskiMember.Name, context);

        string valueAssignment;
        switch (expression.ResultKind)
        {
            case ResultKind.Variable:
                var expressionMember = _scopeContext.GetMember(expression.PolskiMember.Name, context);
                valueAssignment = LlvmGenerator.StoreValue(
                    declarationMember,
                    expressionMember.LlvmName);
                break;
            case ResultKind.Value:
                valueAssignment = LlvmGenerator.StorePrimitiveValue(declarationMember, expression.Value);
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
    
    #endregion
    
    
    #region Global
    
    public override NodeResult VisitGlobalDefinition(PolskiParser.GlobalDefinitionContext context)
    {
        var identifier = context.IDENTIFIER().GetText();
        var type = Visit(context.type());
        var member = _scopeContext.AddMember(new PolskiMember(identifier, type.PolskiMember.Type), context, true, true);
        var number = Visit(context.number());

        if (member.PolskiMember.Type != number.PolskiMember.Type)
        {
            throw new SemanticErrorException(
                $"Cannot assign not matching types: {member.PolskiMember.Type} and {number.PolskiMember.Type}",
                context);
        }

        return LlvmGenerator.CreateGlobalVariable(member.LlvmName, member.LlvmType, number.Value);
    }
    
    #endregion
    
}