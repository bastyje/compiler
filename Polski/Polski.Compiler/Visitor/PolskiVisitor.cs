using System.Text;
using Polski.Compiler.Common;
using Polski.Compiler.exception;
using Polski.Compiler.Generator;

namespace Polski.Compiler.Visitor;

/// <summary>
/// This partial class covers todo
/// </summary>
public partial class PolskiVisitor : PolskiBaseVisitor<NodeResult>
{
    public PolskiVisitor(ScopeContext scopeContext)
    {
        _scopeContext = scopeContext;
    }
    
    public override NodeResult VisitProgram(PolskiParser.ProgramContext context)
    {
        _scopeContext.PushScope();

        var sb = new StringBuilder();
        sb.AppendLine(LlvmGenerator.InitializeStandardFunctions());
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
        
        var printStatement = context.printStatement();
        if(printStatement is not null)
        {
            return Visit(printStatement);
        }
        
        var readStatement = context.readStatement();
        if(readStatement is not null)
        {
            return Visit(readStatement);
        }
        // exception
        throw new CompilationException($"Parser error: \"{context}\"", context);
    }

    public override NodeResult VisitExpression(PolskiParser.ExpressionContext context)
    {
        return Visit(context.arithmeticExpression());
    }
}

