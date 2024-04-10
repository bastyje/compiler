using Xunit;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Polski.Compiler.LanguageDefinition;
using Polski.Compiler.Visitor;

namespace Polski.Compiler.Tests.Visitor;

public class InputOutputVisitorTests
{
    [Fact]
    public void VisitPrintStatement_WithQuotedString_ShouldGenerateCorrectLlvmCode()
    {
        // Arrange
        var visitor = new PolskiVisitor();
        var context = new PolskiParser.PrintStatementContext(new ParserRuleContext(), default);
        context.AddChild(new TerminalNodeImpl(new CommonToken(PolskiParser.QUOTED_STRING, "\"Hello, World!\"")));

        // Act
        var result = visitor.VisitPrintStatement(context);

        // Expected LLVM IR code for printing "Hello, World!"
        var expectedLlvmIr = @"
declare i32 @printf(i8*, ...)
@.str0 = private unnamed_addr constant [14 x i8] c""Hello, World!\00"", align 1
call i32 (i8*, ...) @printf(i8* getelementptr ([14 x i8], [14 x i8]* @.str0, i32 0, i32 0))
".Trim();

        // Assert
        Assert.Equal(expectedLlvmIr, result.Code.Trim());
    }

    [Fact]
    public void VisitPrintStatement_WithIdentifier_ShouldGenerateCorrectLlvmLoadAndPrintCode()
    {
        // Arrange
        var visitor = new PolskiVisitor();
        // Simulate adding a variable to the visitor's scope with an int type
        var variableName = "myVar";
        var llvmVariableName = visitor.GenerateAndRegisterVariableName("i32", variableName);

        var context = new PolskiParser.PrintStatementContext(new ParserRuleContext(), default);
        context.AddChild(new TerminalNodeImpl(new CommonToken(PolskiParser.IDENTIFIER, variableName)));

        // Expected LLVM IR code for loading and printing a variable
        var expectedLlvmIr = $@"
declare i32 @printf(i8*, ...)
%tmp0 = load i32, i32* %{llvmVariableName}
@.str0 = private unnamed_addr constant [4 x i8] c""%d\00"", align 1
call i32 (i8*, ...) @printf(i8* getelementptr ([4 x i8], [4 x i8]* @.str0, i32 0, i32 0), i32 %tmp0)
".Trim();

        // Act
        var result = visitor.VisitPrintStatement(context);

        // Assert
        Assert.Contains("load i32, i32*", result.Code);
        Assert.Contains("@printf(i8* getelementptr", result.Code);
    }

    [Fact]
    public void VisitReadStatement_WithIdentifier_ShouldGenerateCorrectLlvmScanfCode()
    {
        // Arrange
        var visitor = new PolskiVisitor();
        // Assuming GenerateAndRegisterVariableName is a method that simulates adding a variable to the visitor's scope with an int type and returns the LLVM variable name
        var variableName = "inputVar";
        var llvmVariableName = visitor.GenerateAndRegisterVariableName("i32", variableName);

        var context = new PolskiParser.ReadStatementContext(new ParserRuleContext(), default);
        context.AddChild(new TerminalNodeImpl(new CommonToken(PolskiParser.IDENTIFIER, variableName)));

        // Expected LLVM IR code for reading into a variable
        var expectedLlvmIr = $@"
declare i32 @scanf(i8*, ...)
@.str0 = private unnamed_addr constant [3 x i8] c""%d\00"", align 1
call i32 (i8*, ...) @scanf(i8* getelementptr ([3 x i8], [3 x i8]* @.str0, i32 0, i32 0), i32* %{llvmVariableName})
".Trim();

        // Act
        var result = visitor.VisitReadStatement(context);

        // Assert
        Assert.Contains("declare i32 @scanf(i8*, ...)", result.Code);
        Assert.Contains("call i32 (i8*, ...) @scanf(i8* getelementptr", result.Code);
        Assert.Contains("%d", result.Code); // Verifies the format specifier is correct for an integer
    }
}