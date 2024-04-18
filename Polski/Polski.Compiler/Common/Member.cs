namespace Polski.Compiler.Common;

public class Member(PolskiMember? polskiMember, string llvmName, string llvmType, string? scope, bool stackAllocated, bool global = false)
{
    public PolskiMember PolskiMember
    {
        get => _polskiMember ?? throw new InvalidOperationException("PolskiMember is not set");
        set => _polskiMember = value;
    }
    private PolskiMember? _polskiMember = polskiMember;

    public string? Scope { get; set; } = scope;
    public string LlvmName { get; } = llvmName;
    public string LlvmType { get; } = llvmType;
    public bool Global { get; set; } = global;
    public bool StackAllocated { get; } = stackAllocated;
}