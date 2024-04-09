using Polski.Compiler.Common;

namespace Polski.Compiler.Visitor;

public class NodeResult
{
    public static implicit operator NodeResult(string code) => new() { Code = code };

    public static implicit operator string(NodeResult nodeResult) => nodeResult.ToString();
    
    public string? Code { get; init; }

    public PolskiMember PolskiMember
    {
        get => _polskiMember ?? throw new InvalidOperationException("PolskiMember is not set");
        init => _polskiMember = value;
    }

    private readonly PolskiMember? _polskiMember;

    public string Value
    {
        get => _value ?? throw new InvalidOperationException("PolskiMember is not set");
        init
        {
            ResultKind = ResultKind.Value;
            _value = value;
        }
    }

    private readonly string? _value;

    public ResultKind ResultKind { get; private set; }

    public override string ToString()
    {
        return Code ?? string.Empty;
    }
}