using Antlr4.Runtime;

namespace Polski.Compiler.listener;

public class ErrorListener : BaseErrorListener
{
    public override void SyntaxError(TextWriter output, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine,
        string msg, RecognitionException e)
    {
        Console.Error.WriteLine($"Error at line {line}:{charPositionInLine} - {msg}");
    }
}