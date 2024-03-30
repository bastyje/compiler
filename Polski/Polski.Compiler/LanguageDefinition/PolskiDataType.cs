namespace Polski.Compiler.LanguageDefinition;

public static class PolskiDataType
{
    public const string Int = "int";
    public const string Float = "float";
    
    public static bool IsKnownType(string type)
    {
        return type switch
        {
            Int => true,
            Float => true,
            _ => false
        };
    }
}