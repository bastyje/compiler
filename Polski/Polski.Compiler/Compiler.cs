using Antlr4.Runtime;
using Polski.Compiler.Visitor;

namespace Polski.Compiler;

public class Compiler
{
    public void Compile(string code)
    {
        var stream = CharStreams.fromString(code);
        var lexer = new PolskiLexer(stream);
        var tokens = new CommonTokenStream(lexer);
        var parser = new PolskiParser(tokens);
        var tree = parser.program();
        
        Console.WriteLine(tree.ToStringTree());
        
        var visitor = new PolskiVisitor();
        visitor.Visit(tree);
    }
}