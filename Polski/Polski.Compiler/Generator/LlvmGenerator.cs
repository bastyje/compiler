namespace Polski.Compiler.Generator;

public class LlvmGenerator
{
    public static string AllocateVariable(string name, string type)
    {
        var llvmType = LlvmDataType.MapFromPolski(type);
        return $"%{name} = alloca {llvmType}\n";
    }
}