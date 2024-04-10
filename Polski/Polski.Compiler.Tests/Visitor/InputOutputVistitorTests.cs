using Xunit;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Polski.Compiler.LanguageDefinition;
using Polski.Compiler.Visitor;

namespace Polski.Compiler.Tests.Visitor;

public class InputOutputVisitorTests
{
    [Fact]
    public void VisitPrintStatement_WhenQuotedStringIsGiven_ShouldReturnCorrectLlvmCode()
    {
        // arrange
        const string quotedString = "\"Hello, World!\"";

        var visitor = new PolskiVisitor();

        var printStatementContext = new PolskiParser.PrintStatementContext(new ParserRuleContext(), default);
        printStatementContext.AddChild(new TerminalNodeImpl(new CommonToken(PolskiParser.QUOTED_STRING, quotedString)));

        // act
        var result = visitor.VisitPrintStatement(printStatementContext);

        // assert
        Assert.Contains("declare i32 @printf(i8*, ...)", result.Code);
        Assert.Contains("@.str = private unnamed_addr constant [14 x i8] c\"Hello, World!\\00\"", result.Code);
        Assert.Contains("call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([14 x i8], [14 x i8]* @.str, i64 0, i64 0))", result.Code);
    }

    [Fact]
    public void VisitPrintStatement_WhenEmptyQuotedStringIsGiven_ShouldReturnCorrectLlvmCode()
    {
        // arrange
        const string quotedString = "\"\"";

        var visitor = new PolskiVisitor();

        var printStatementContext = new PolskiParser.PrintStatementContext(new ParserRuleContext(), default);
        printStatementContext.AddChild(new TerminalNodeImpl(new CommonToken(PolskiParser.QUOTED_STRING, quotedString)));

        // act
        var result = visitor.VisitPrintStatement(printStatementContext);

        // assert
        Assert.Contains("declare i32 @printf(i8*, ...)", result.Code);
        Assert.Contains("@.str = private unnamed_addr constant [1 x i8] c\"\\00\"", result.Code);
        Assert.Contains("call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([1 x i8], [1 x i8]* @.str, i64 0, i64 0))", result.Code);
    }

    [Fact]
    public void VisitPrintStatement_WhenNoQuotedStringIsGiven_ShouldNotReturnLlvmCode()
    {
        // arrange
        var visitor = new PolskiVisitor();

        var printStatementContext = new PolskiParser.PrintStatementContext(new ParserRuleContext(), default);

        // act
        var result = visitor.VisitPrintStatement(printStatementContext);

        // assert
        Assert.Empty(result.Code);
    }
}