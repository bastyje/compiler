using System.Text;
using Polski.Compiler.Common;
using Polski.Compiler.Generator;

namespace Polski.Compiler.Visitor;

/// <summary>
/// This partial class covers todo
/// </summary>
public partial class PolskiVisitor(ScopeContext scopeContext) : PolskiBaseVisitor<NodeResult>
{
    public override NodeResult VisitProgram(PolskiParser.ProgramContext context)
    {
        _scopeContext.PushScope();

        var sb = new StringBuilder();
        sb.AppendLine(LlvmGenerator.MainFunctionOpen());
        sb.AppendJoin(string.Empty, context.line().Select(l => Visit(l).Code));
        sb.AppendLine(LlvmGenerator.MainFunctionClose());
        return sb.ToString();
    }

    public override NodeResult VisitLine(PolskiParser.LineContext context)
    {
        return Visit(context.statement());
    }

    public override NodeResult VisitStatement(PolskiParser.StatementContext context)
    {
        var declaration = context.declaration();
        if (declaration is not null)
        {
            return Visit(declaration);
        }

        var definition = context.definition();
        if (definition is not null)
        {
            return Visit(definition);
        }

        var assignment = context.assignment();
        if (assignment is not null)
        {
            return Visit(assignment);
        }
        
        var expression = context.expression();
        if (expression is not null)
        {
            return Visit(expression);
        }

        // exception
        throw new Exception("parser error");
    }

    public override NodeResult VisitExpression(PolskiParser.ExpressionContext context)
    {
        return Visit(context.additiveExpression());
    }
}

