using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Polski.Compiler.Visitor;

namespace Polski.Compiler.Tests.Visitor;

public class PolskiVisitorTests
{
    [Theory]
    [InlineData("int", "i32")]
    [InlineData("float", "float")]
    public void VisitDeclaration_WhenIntVariableIsDeclared_ShouldGenerateAllocatingCode(string polskiType, string llvmType)
    {
        // arrange
        var context = new PolskiParser.DeclarationContext(new ParserRuleContext(), default);
        context.AddChild(new TerminalNodeImpl(new CommonToken(PolskiParser.IDENTIFIER, "a")));

        var numericTypeContext = new PolskiParser.NumericTypeContext(context, default);
        numericTypeContext.AddChild(new TerminalNodeImpl(new CommonToken(PolskiParser.INT, polskiType)));
        
        var typeContext = new PolskiParser.TypeContext(context, default);
        typeContext.AddChild(numericTypeContext);
        context.AddChild(typeContext);      
        
        var visitor = new PolskiVisitor();
        
        // act
        var result = visitor.VisitDeclaration(context);
        
        // assert
        Assert.Equal($"%a = alloca {llvmType}\n", result.Code);
    }
    
    [Fact]
    public void VisitDeclaration_WhenVariableIsDeclaredTwice_ShouldThrowException()
    {
        // arrange
        var context = new PolskiParser.DeclarationContext(new ParserRuleContext(), default);
        context.AddChild(new TerminalNodeImpl(new CommonToken(PolskiParser.IDENTIFIER, "a")));

        var numericTypeContext = new PolskiParser.NumericTypeContext(context, default);
        numericTypeContext.AddChild(new TerminalNodeImpl(new CommonToken(PolskiParser.INT, "int")));
        
        var typeContext = new PolskiParser.TypeContext(context, default);
        typeContext.AddChild(numericTypeContext);
        context.AddChild(typeContext);      
        
        var visitor = new PolskiVisitor();
        visitor.VisitDeclaration(context);

        // act
        void Action() => visitor.VisitDeclaration(context);

        // assert
        Assert.Throws<Exception>(Action);
    }
}