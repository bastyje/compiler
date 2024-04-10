using Xunit;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Polski.Compiler.Common;
using Polski.Compiler.LanguageDefinition;
using Polski.Compiler.Visitor;

namespace Polski.Compiler.Tests.Visitor;

public class InputOutputVisitorTests
{
    [Fact]
    public void VisitPrintStatement_WithQuotedString_ShouldGenerateCorrectLlvmCode()
    {
        var scopeContext = new ScopeContext();
        var visitor = new PolskiVisitor(scopeContext);
        var context = new PolskiParser.PrintStatementContext(new ParserRuleContext(), default);
        context.AddChild(new TerminalNodeImpl(new CommonToken(PolskiParser.QUOTED_STRING, "\"Hello, World!\"")));
        
        var result = visitor.VisitPrintStatement(context);
        
        var expectedLlvmIr = @"
declare i32 @printf(i8*, ...)
@.str0 = private unnamed_addr constant [14 x i8] c""Hello, World!\00"", align 1
call i32 (i8*, ...) @printf(i8* getelementptr ([14 x i8], [14 x i8]* @.str0, i32 0, i32 0))
".Trim();
        Assert.Equal(expectedLlvmIr, result.Code.Trim());
    }

    [Fact]
    public void VisitPrintStatement_WithIdentifier_ShouldGenerateCorrectLlvmLoadAndPrintCode()
    {
        const string variableName = "myVar";
        var scopeContext = new ScopeContext();
        var visitor = new PolskiVisitor(scopeContext);
        scopeContext.PushScope();
        var member = scopeContext.AddMember(new PolskiMember(variableName, PolskiDataType.Int32));

        var context = new PolskiParser.PrintStatementContext(new ParserRuleContext(), default);
        context.AddChild(new TerminalNodeImpl(new CommonToken(PolskiParser.IDENTIFIER, variableName)));
        
        var result = visitor.VisitPrintStatement(context);
        
        var expectedLlvmIr = @"
declare i32 @printf(i8*, ...)
@.str0 = private unnamed_addr constant [3 x i8] c""%d\00"", align 1
call i32 (i8*, ...) @printf(i8* getelementptr ([3 x i8], [3 x i8]* @.str0, i32 0, i32 0), i32 %myVar)
".Trim();
        Assert.Equal(expectedLlvmIr, result.Code.Trim());
    }

    [Fact]
    public void VisitReadStatement_WithIdentifier_ShouldGenerateCorrectLlvmScanfCode()
    {
        const string variableName = "inputVar";
        var scopeContext = new ScopeContext();
        var visitor = new PolskiVisitor(scopeContext);
        scopeContext.PushScope();
        var member = scopeContext.AddMember(new PolskiMember(variableName, PolskiDataType.Int32));

        var context = new PolskiParser.ReadStatementContext(new ParserRuleContext(), default);
        context.AddChild(new TerminalNodeImpl(new CommonToken(PolskiParser.IDENTIFIER, variableName)));
        
        var result = visitor.VisitReadStatement(context);
        
        var expectedLlvmIr = @"
declare i32 @scanf(i8*, ...)
@.str0 = private unnamed_addr constant [3 x i8] c""%d\00"", align 1
call i32 (i8*, ...) @scanf(i8* getelementptr ([3 x i8], [3 x i8]* @.str0, i32 0, i32 0), i32* %inputVar)
".Trim();
        Assert.Equal(expectedLlvmIr, result.Code.Trim());
    }
}