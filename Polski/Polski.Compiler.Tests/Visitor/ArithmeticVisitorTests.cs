using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Polski.Compiler.LanguageDefinition;
using Polski.Compiler.Visitor;

namespace Polski.Compiler.Tests.Visitor;

public class ArithmeticVisitorTests
{
    [Fact]
    public void VisitArithmeticExpression_WhenMultiplicationIsGiven_ShouldReturnCorrectLlvmCode()
    {
        // arrange
        const string leftName = "left";
        const string rightName = "right";
        
        var visitor = new PolskiVisitor();
        
        var leftLlvmName = visitor.GenerateAndRegisterVariableName(PolskiDataType.Int32, leftName);
        var rightLlvmName = visitor.GenerateAndRegisterVariableName(PolskiDataType.Int32, rightName);
        
        var leftContext = new PolskiParser.ArithmeticExpressionContext(new ParserRuleContext(), default);
        leftContext.AddChild(new TerminalNodeImpl(new CommonToken(PolskiParser.IDENTIFIER, leftName)));
        
        var rightContext = new PolskiParser.ArithmeticExpressionContext(new ParserRuleContext(), default);
        rightContext.AddChild(new TerminalNodeImpl(new CommonToken(PolskiParser.IDENTIFIER, rightName)));

        var expressionContext = new PolskiParser.ArithmeticExpressionContext(new ParserRuleContext(), default);
        expressionContext.AddChild(leftContext);
        expressionContext.AddChild(new TerminalNodeImpl(new CommonToken(PolskiParser.MULTIPLY, "*")));
        expressionContext.AddChild(rightContext);

        // act
        var result = visitor.VisitArithmeticExpression(expressionContext);

        // assert
        Assert.Equal($"%3 = mul i32 %{leftLlvmName}, %{rightLlvmName}\n", result.Code);
    }
    
    [Fact]
    public void VisitArithmeticExpression_WhenDivisionIsGiven_ShouldReturnCorrectLlvmCode()
    {
        // arrange
        const string leftName = "left";
        const string rightName = "right";
        
        var visitor = new PolskiVisitor();
        
        var leftLlvmName = visitor.GenerateAndRegisterVariableName(PolskiDataType.Int32, leftName);
        var rightLlvmName = visitor.GenerateAndRegisterVariableName(PolskiDataType.Int32, rightName);
        
        var leftContext = new PolskiParser.ArithmeticExpressionContext(new ParserRuleContext(), default);
        leftContext.AddChild(new TerminalNodeImpl(new CommonToken(PolskiParser.IDENTIFIER, leftName)));
        
        var rightContext = new PolskiParser.ArithmeticExpressionContext(new ParserRuleContext(), default);
        rightContext.AddChild(new TerminalNodeImpl(new CommonToken(PolskiParser.IDENTIFIER, rightName)));

        var expressionContext = new PolskiParser.ArithmeticExpressionContext(new ParserRuleContext(), default);
        expressionContext.AddChild(leftContext);
        expressionContext.AddChild(new TerminalNodeImpl(new CommonToken(PolskiParser.DIVIDE, "/")));
        expressionContext.AddChild(rightContext);

        // act
        var result = visitor.VisitArithmeticExpression(expressionContext);

        // assert
        Assert.Equal($"%3 = div i32 %{leftLlvmName}, %{rightLlvmName}\n", result.Code);
    }
    
    [Fact]
    public void VisitArithmeticExpression_WhenAdditionIsGiven_ShouldReturnCorrectLlvmCode()
    {
        // arrange
        const string leftName = "left";
        const string rightName = "right";
        
        var visitor = new PolskiVisitor();
        
        var leftLlvmName = visitor.GenerateAndRegisterVariableName(PolskiDataType.Int32, leftName);
        var rightLlvmName = visitor.GenerateAndRegisterVariableName(PolskiDataType.Int32, rightName);
        
        var leftContext = new PolskiParser.ArithmeticExpressionContext(new ParserRuleContext(), default);
        leftContext.AddChild(new TerminalNodeImpl(new CommonToken(PolskiParser.IDENTIFIER, leftName)));
        
        var rightContext = new PolskiParser.ArithmeticExpressionContext(new ParserRuleContext(), default);
        rightContext.AddChild(new TerminalNodeImpl(new CommonToken(PolskiParser.IDENTIFIER, rightName)));

        var expressionContext = new PolskiParser.ArithmeticExpressionContext(new ParserRuleContext(), default);
        expressionContext.AddChild(leftContext);
        expressionContext.AddChild(new TerminalNodeImpl(new CommonToken(PolskiParser.PLUS, "+")));
        expressionContext.AddChild(rightContext);

        // act
        var result = visitor.VisitArithmeticExpression(expressionContext);

        // assert
        Assert.Equal($"%3 = add i32 %{leftLlvmName}, %{rightLlvmName}\n", result.Code);
    }
    
    [Fact]
    public void VisitArithmeticExpression_WhenSubtractionIsGiven_ShouldReturnCorrectLlvmCode()
    {
        // arrange
        const string leftName = "left";
        const string rightName = "right";
        
        var visitor = new PolskiVisitor();
        
        var leftLlvmName = visitor.GenerateAndRegisterVariableName(PolskiDataType.Int32, leftName);
        var rightLlvmName = visitor.GenerateAndRegisterVariableName(PolskiDataType.Int32, rightName);
        
        var leftContext = new PolskiParser.ArithmeticExpressionContext(new ParserRuleContext(), default);
        leftContext.AddChild(new TerminalNodeImpl(new CommonToken(PolskiParser.IDENTIFIER, leftName)));
        
        var rightContext = new PolskiParser.ArithmeticExpressionContext(new ParserRuleContext(), default);
        rightContext.AddChild(new TerminalNodeImpl(new CommonToken(PolskiParser.IDENTIFIER, rightName)));

        var expressionContext = new PolskiParser.ArithmeticExpressionContext(new ParserRuleContext(), default);
        expressionContext.AddChild(leftContext);
        expressionContext.AddChild(new TerminalNodeImpl(new CommonToken(PolskiParser.MINUS, "-")));
        expressionContext.AddChild(rightContext);

        // act
        var result = visitor.VisitArithmeticExpression(expressionContext);

        // assert
        Assert.Equal($"%3 = sub i32 %{leftLlvmName}, %{rightLlvmName}\n", result.Code);
    }
}