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
        return new StringBuilder()
            .AppendLine(LlvmGenerator.Header())
            .AppendLine(LlvmGenerator.MainFunctionOpen())
            .AppendJoin(string.Empty, context.line().Select(l => Visit(l).Code))
            .AppendLine(LlvmGenerator.MainFunctionClose())
            .ToString();
    }

    public override NodeResult VisitLine(PolskiParser.LineContext context)
    {
        return Visit(context.statement());
    }

    public override NodeResult VisitStatement(PolskiParser.StatementContext context)
    {
        if (context.declaration() is {} declaration)
        {
            return Visit(declaration);
        }

        if (context.definition() is {} definition)
        {
            return Visit(definition);
        }

        if (context.assignment() is {} assignment)
        {
            return Visit(assignment);
        }
        
        if (context.expression() is {} expression)
        {
            return Visit(expression);
        }

        if (context.print() is { } print)
        {
            return Visit(print);
        }
        
        if (context.read() is { } read)
        {
            return Visit(read);
        }

        // exception
        throw new InvalidOperationException();
    }

    public override NodeResult VisitExpression(PolskiParser.ExpressionContext context)
    {
        return Visit(context.additiveExpression());
    }
}

