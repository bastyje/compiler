using Antlr4.Runtime;
using Polski.Compiler.Common;
using Polski.Compiler.Visitor;

namespace Polski.Compiler;

public static class Compiler
{
    public static string Compile(string code)
    {
        var stream = CharStreams.fromString(code);
        var lexer = new PolskiLexer(stream);
        var tokens = new CommonTokenStream(lexer);
        var parser = new PolskiParser(tokens);
        var tree = parser.program();
        var scopeContext = new ScopeContext();
        var visitor = new PolskiVisitor(scopeContext);
        return visitor.Visit(tree);
    }
}