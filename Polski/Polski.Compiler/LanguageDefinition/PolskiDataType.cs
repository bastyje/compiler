namespace Polski.Compiler.LanguageDefinition;

public static class PolskiDataType
{
    public const string Int32 = "int";
    public const string Int64 = "bigint";
    public const string Float = "float";
    public const string Double = "double";
    
    public static bool IsKnownType(string type)
    {
        return type switch
        {
            Int32 => true,
            Int64 => true,
            Float => true,
            Double => true,
            _ => false
        };
    }
}