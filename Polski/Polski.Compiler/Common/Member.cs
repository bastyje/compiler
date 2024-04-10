namespace Polski.Compiler.Common;

public class Member(PolskiMember? polskiMember, string llvmName, string llvmType, bool stackAllocated)
{
    public Member(string llvmName, string llvmType, bool stackAllocated) : this(null, llvmName, llvmType, stackAllocated) {}

    public PolskiMember PolskiMember
    {
        get => _polskiMember ?? throw new InvalidOperationException("PolskiMember is not set");
        set => _polskiMember = value;
    }
    private PolskiMember? _polskiMember = polskiMember;
    
    public string LlvmName { get; } = llvmName;
    public string LlvmType { get; } = llvmType;
    public bool StackAllocated { get; } = stackAllocated;
}