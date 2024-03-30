namespace Polski.Compiler.Common;

public class RegisteredIdentifier(string? name, string? type, string llvmName, string llvmType)
{
    public RegisteredIdentifier(string llvmName, string llvmType) : this(null, null, llvmName, llvmType) {}
    
    public string? Name { get; set; } = name;
    public string? Type { get; set; } = type;
    public string LlvmName { get; set; } = llvmName;
    public string LlvmType { get; set; } = llvmType;
}