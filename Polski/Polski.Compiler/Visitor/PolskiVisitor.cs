using System.Text;
using Antlr4.Runtime;
using Polski.Compiler.Common;
using Polski.Compiler.Error;
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
        if (context.statement() is {} statement)
        {
            return Visit(statement);
        }
        
        if (context.block() is {} block)
        {
            return Visit(block);
        }
        
        if (context.functionDeclaration() is {} functionDeclaration)
        {
            return Visit(functionDeclaration);
        }
        
        if (context.@if() is {} @if)
        {
            return Visit(@if);
        }
        
        if (context.@while() is {} @while)
        {
            return Visit(@while);
        }
        
        throw new SemanticErrorException("Unknown line type", context);
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
    
    public override NodeResult VisitAssignment(PolskiParser.AssignmentContext context)
    {
        var identifier = context.IDENTIFIER().GetText();
        var member = _scopeContext.GetMember(identifier, context);
        var expression = Visit(context.expression());
        var expressionResult = _scopeContext.GetMember(expression.PolskiMember.Name, context);
        
        if (member.PolskiMember.Type != expressionResult.PolskiMember.Type)
        {
            throw new SemanticErrorException(
                $"Cannot assign not matching types: {member.PolskiMember.Type} and {expressionResult.PolskiMember.Type}",
                context);
        }
        
        return new NodeResult
        {
            Code = new StringBuilder()
                .Append(expression.Code)
                .Append(LlvmGenerator.StoreValue(member.LlvmName, member.PolskiMember.Type, expressionResult.LlvmName))
                .ToString(),
        };
    }
}

