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

    public static bool IsAssignable(string left, string right) => left switch
    {
        Int32 when right == Int32 => true,
        Int32 when right == Int64 => true,
        Int64 when right == Int32 => true,
        Int64 when right == Int64 => true,
        Float when right == Float => true,
        Float when right == Double => true,
        Double when right == Float => true,
        Double when right == Double => true,
        _ => false
    };
}