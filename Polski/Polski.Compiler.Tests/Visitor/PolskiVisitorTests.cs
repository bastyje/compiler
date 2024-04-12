using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Polski.Compiler.Common;
using Polski.Compiler.Generator;
using Polski.Compiler.LanguageDefinition;
using Polski.Compiler.Visitor;

namespace Polski.Compiler.Tests.Visitor;

public class PolskiVisitorTests
{
    [Theory]
    [InlineData(PolskiDataType.Int32, LlvmDataType.Int32, PolskiParser.INT)]
    [InlineData(PolskiDataType.Int64, LlvmDataType.Int64, PolskiParser.INT64)]
    [InlineData(PolskiDataType.Double, LlvmDataType.Double, PolskiParser.DOUBLE)]
    public void VisitDeclaration_WhenIntVariableIsDeclared_ShouldGenerateAllocatingCode(string polskiType, string llvmType, int nodeTerminal)
    {
        // arrange
        var context = new PolskiParser.DeclarationContext(new ParserRuleContext(), default);
        context.AddChild(new TerminalNodeImpl(new CommonToken(PolskiParser.IDENTIFIER, "a")));

        var numericTypeContext = new PolskiParser.NumericTypeContext(context, default);
        numericTypeContext.AddChild(new TerminalNodeImpl(new CommonToken(nodeTerminal, polskiType)));
        
        var typeContext = new PolskiParser.TypeContext(context, default);
        typeContext.AddChild(numericTypeContext);
        context.AddChild(typeContext);      
        
        var scopeContext = new ScopeContext();
        scopeContext.PushScope();
        
        var visitor = new PolskiVisitor(scopeContext);
        
        // act
        var result = visitor.VisitDeclaration(context);
        
        // assert
        Assert.Equal($"  %1 = alloca {llvmType}\n", result.Code);
    }
    
    [Fact]
    public void VisitDeclaration_WhenVariableIsDeclaredTwice_ShouldThrowException()
    {
        // arrange
        var context = new PolskiParser.DeclarationContext(new ParserRuleContext(), default);
        context.AddChild(new TerminalNodeImpl(new CommonToken(PolskiParser.IDENTIFIER, "a")));

        var numericTypeContext = new PolskiParser.NumericTypeContext(context, default);
        numericTypeContext.AddChild(new TerminalNodeImpl(new CommonToken(PolskiParser.INT, PolskiDataType.Int32)));
        
        var typeContext = new PolskiParser.TypeContext(context, default);
        typeContext.AddChild(numericTypeContext);
        context.AddChild(typeContext);

        var scopeContext = new ScopeContext();
        scopeContext.PushScope();
        
        scopeContext.AddMember(new PolskiMember("a", PolskiDataType.Int32), numericTypeContext, true);
        
        var visitor = new PolskiVisitor(scopeContext);

        // act
        void Action() => visitor.VisitDeclaration(context);

        // assert
        Assert.Throws<InvalidOperationException>(Action);
    }
}