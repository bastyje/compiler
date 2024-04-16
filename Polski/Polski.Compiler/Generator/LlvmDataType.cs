using Polski.Compiler.LanguageDefinition;

namespace Polski.Compiler.Generator;

public static class LlvmDataType
{
    public const string Int32 = "i32";
    public const string Int64 = "i64";
    public const string Double = "double";
    public const string Bool = "i1";
    
    public static string MapFromPolski(string type)
    {
        return type switch
        {
            PolskiDataType.Int32 => Int32,
            PolskiDataType.Int64 => Int64,
            PolskiDataType.Double => Double,
            PolskiDataType.Bool => Bool,
            _ => throw new Exception($"Unknown type {type}.")
        };
    }
}