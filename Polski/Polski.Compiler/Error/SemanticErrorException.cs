using Antlr4.Runtime;

namespace Polski.Compiler.Error;

public class SemanticErrorException(string message, ParserRuleContext context) : Exception
{
    public int Line { get; } = context.Start.Line;
    public int Column { get; } = context.Start.Column;
    public override string Message { get; } = message;
}

internal class SemanticErrorInternalException(string message) : Exception
{
    public override string Message { get; } = message;
}