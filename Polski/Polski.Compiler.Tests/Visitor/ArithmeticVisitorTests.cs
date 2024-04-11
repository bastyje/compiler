// using Antlr4.Runtime;
// using Antlr4.Runtime.Tree;
// using Polski.Compiler.Common;
// using Polski.Compiler.LanguageDefinition;
// using Polski.Compiler.Visitor;
//
// namespace Polski.Compiler.Tests.Visitor;
//
// public class ArithmeticVisitorTests
// {
//     [Fact]
//     public void VisitMultiplicativeExpression_WhenCalledInValidContext_ShouldGenerateCode()
//     {
//         // arrange
//         const string leftName = "left";
//         const string rightName = "right";
//         
//         var scopeContext = new ScopeContext();
//         var visitor = new PolskiVisitor(scopeContext);
//         
//         scopeContext.PushScope();
//         var leftMember = scopeContext.AddMember(new PolskiMember(leftName, PolskiDataType.Int32));
//         var rightMember = scopeContext.AddMember(new PolskiMember(rightName, PolskiDataType.Int32));
//         
//         var leftContext = new PolskiParser.MultiplicativeExpressionContext(new ParserRuleContext(), default);
//         leftContext.AddChild(new TerminalNodeImpl(new CommonToken(PolskiParser.IDENTIFIER, leftName)));
//         
//         var rightContext = new PolskiParser.ArithmeticExpressionContext(new ParserRuleContext(), default);
//         rightContext.AddChild(new TerminalNodeImpl(new CommonToken(PolskiParser.IDENTIFIER, rightName)));
//
//         var expressionContext = new PolskiParser.ArithmeticExpressionContext(new ParserRuleContext(), default);
//         expressionContext.AddChild(leftContext);
//         expressionContext.AddChild(new TerminalNodeImpl(new CommonToken(PolskiParser.MULTIPLY, "*")));
//         expressionContext.AddChild(rightContext);
//
//         // act
//         var result = visitor.VisitArithmeticExpression(expressionContext);
//
//         // assert
//         Assert.Equal($"  %3 = call i32 @mul_i32(i32 %{leftMember.LlvmName}, i32 %{rightMember.LlvmName})\n", result.Code);
//     }
//     
//     [Fact]
//     public void VisitArithmeticExpression_WhenDivisionIsGiven_ShouldReturnCorrectLlvmCode()
//     {
//         // arrange
//         const string leftName = "left";
//         const string rightName = "right";
//         
//         var scopeContext = new ScopeContext();
//         var visitor = new PolskiVisitor(scopeContext);
//         
//         scopeContext.PushScope();
//         var leftMember = scopeContext.AddMember(new PolskiMember(leftName, PolskiDataType.Int32));
//         var rightMember = scopeContext.AddMember(new PolskiMember(rightName, PolskiDataType.Int32));
//         
//         var leftContext = new PolskiParser.ArithmeticExpressionContext(new ParserRuleContext(), default);
//         leftContext.AddChild(new TerminalNodeImpl(new CommonToken(PolskiParser.IDENTIFIER, leftName)));
//         
//         var rightContext = new PolskiParser.ArithmeticExpressionContext(new ParserRuleContext(), default);
//         rightContext.AddChild(new TerminalNodeImpl(new CommonToken(PolskiParser.IDENTIFIER, rightName)));
//
//         var expressionContext = new PolskiParser.ArithmeticExpressionContext(new ParserRuleContext(), default);
//         expressionContext.AddChild(leftContext);
//         expressionContext.AddChild(new TerminalNodeImpl(new CommonToken(PolskiParser.DIVIDE, "/")));
//         expressionContext.AddChild(rightContext);
//
//         // act
//         var result = visitor.VisitArithmeticExpression(expressionContext);
//
//         // assert
//         Assert.Equal($"  %3 = call i32 @div_i32(i32 %{leftMember.LlvmName}, i32 %{rightMember.LlvmName})\n", result.Code);
//     }
//     
//     [Fact]
//     public void VisitArithmeticExpression_WhenAdditionIsGiven_ShouldReturnCorrectLlvmCode()
//     {
//         // arrange
//         const string leftName = "left";
//         const string rightName = "right";
//         
//         var scopeContext = new ScopeContext();
//         var visitor = new PolskiVisitor(scopeContext);
//         
//         scopeContext.PushScope();
//         var leftMember = scopeContext.AddMember(new PolskiMember(leftName, PolskiDataType.Int32));
//         var rightMember = scopeContext.AddMember(new PolskiMember(rightName, PolskiDataType.Int32));
//         
//         var leftContext = new PolskiParser.ArithmeticExpressionContext(new ParserRuleContext(), default);
//         leftContext.AddChild(new TerminalNodeImpl(new CommonToken(PolskiParser.IDENTIFIER, leftName)));
//         
//         var rightContext = new PolskiParser.ArithmeticExpressionContext(new ParserRuleContext(), default);
//         rightContext.AddChild(new TerminalNodeImpl(new CommonToken(PolskiParser.IDENTIFIER, rightName)));
//
//         var expressionContext = new PolskiParser.ArithmeticExpressionContext(new ParserRuleContext(), default);
//         expressionContext.AddChild(leftContext);
//         expressionContext.AddChild(new TerminalNodeImpl(new CommonToken(PolskiParser.PLUS, "+")));
//         expressionContext.AddChild(rightContext);
//
//         // act
//         var result = visitor.VisitArithmeticExpression(expressionContext);
//
//         // assert
//         Assert.Equal($"  %3 = call i32 @add_i32(i32 %{leftMember.LlvmName}, i32 %{rightMember.LlvmName})\n", result.Code);
//     }
//     
//     [Fact]
//     public void VisitArithmeticExpression_WhenSubtractionIsGiven_ShouldReturnCorrectLlvmCode()
//     {
//         // arrange
//         const string leftName = "left";
//         const string rightName = "right";
//         
//         var scopeContext = new ScopeContext();
//         var visitor = new PolskiVisitor(scopeContext);
//         
//         scopeContext.PushScope();
//         var leftMember = scopeContext.AddMember(new PolskiMember(leftName, PolskiDataType.Int32));
//         var rightMember = scopeContext.AddMember(new PolskiMember(rightName, PolskiDataType.Int32));
//         
//         var leftContext = new PolskiParser.ArithmeticExpressionContext(new ParserRuleContext(), default);
//         leftContext.AddChild(new TerminalNodeImpl(new CommonToken(PolskiParser.IDENTIFIER, leftName)));
//         
//         var rightContext = new PolskiParser.ArithmeticExpressionContext(new ParserRuleContext(), default);
//         rightContext.AddChild(new TerminalNodeImpl(new CommonToken(PolskiParser.IDENTIFIER, rightName)));
//
//         var expressionContext = new PolskiParser.ArithmeticExpressionContext(new ParserRuleContext(), default);
//         expressionContext.AddChild(leftContext);
//         expressionContext.AddChild(new TerminalNodeImpl(new CommonToken(PolskiParser.MINUS, "-")));
//         expressionContext.AddChild(rightContext);
//
//         // act
//         var result = visitor.VisitArithmeticExpression(expressionContext);
//
//         // assert
//         Assert.Equal($"  %3 = call i32 @sub_i32(i32 %{leftMember.LlvmName}, i32 %{rightMember.LlvmName})\n", result.Code);
//     }
// }