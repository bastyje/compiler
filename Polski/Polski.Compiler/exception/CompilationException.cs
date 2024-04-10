using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace Polski.Compiler.exception;

public class CompilationException : Exception
{
    public int Line { get; }
    public int Position { get; }

    public CompilationException(string message, int line, int position)
        : base(message)
    {
        Line = line;
        Position = position;
    }
    
    public CompilationException(string message, ParserRuleContext context)
        : base($"{message} at line {context.Start.Line}, position {context.Start.Column}.")
    {
        Line = context.Start.Line;
        Position = context.Start.Column;
    }
    
    public CompilationException(string message, ITerminalNode node)
        : base($"{message}' at line {node.Symbol.Line}, position {node.Symbol.Column}.")
    {
        Line = node.Symbol.Line;
        Position = node.Symbol.Column;
    }
    
    
    
}