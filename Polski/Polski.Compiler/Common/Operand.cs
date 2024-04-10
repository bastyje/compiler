namespace Polski.Compiler.Common;

public class Operand(ResultKind resultKind, string value)
{
    public static implicit operator string(Operand operand) => operand.ToString();
    
    public ResultKind ResultKind { get; init; } = resultKind;
    public string Value { get; init; } = value;

    public override string ToString()
    {
        return ResultKind switch
        {
            ResultKind.Variable => $"%{Value}",
            ResultKind.Value => Value,
            _ => throw new NotSupportedException($"{nameof(Common.ResultKind)}: {ResultKind} is not supported")
        };
    }
}