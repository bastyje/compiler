using Antlr4.Runtime;
using Polski.Compiler.exception;
using Polski.Compiler.listener;
using Polski.Compiler.Visitor;

namespace Polski.Compiler;

public static class Compiler
{
    public static string Compile(string code)
    {
        try
        {
            var inputStream = new AntlrInputStream(code);
            var lexer = new PolskiLexer(inputStream);
            var tokenStream = new CommonTokenStream(lexer);
            var parser = new PolskiParser(tokenStream);
            parser.RemoveErrorListeners();
            parser.AddErrorListener(new ErrorListener());
            var tree = parser.program();
            var visitor = new PolskiVisitor();
            return visitor.Visit(tree);
        }
        catch (Exception e)
        {
            if (e.GetType() == typeof(CompilationException))
            {
                return e.Message;
            }
            else
            {
                return "\r";
            }
            
        }
        
    }
}