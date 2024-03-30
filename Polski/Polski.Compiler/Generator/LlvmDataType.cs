using Polski.Compiler.LanguageDefinition;

namespace Polski.Compiler.Generator;

public static class LlvmDataType
{
    public const string Int = "i32";
    public const string Float = "float";
    
    public static string MapFromPolski(string type)
    {
        return type switch
        {
            PolskiDataType.Int => Int,
            PolskiDataType.Float => Float,
            _ => throw new Exception($"Unknown type {type}.")
        };
    }
    
    public static bool TryMapFromPolski(string type, out string llvmType)
    {
        try
        {
            llvmType = MapFromPolski(type);
            return true;
        }
        catch
        {
            llvmType = null;
            return false;
        }
    }
}