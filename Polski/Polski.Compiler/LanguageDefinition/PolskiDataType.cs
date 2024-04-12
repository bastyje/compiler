namespace Polski.Compiler.LanguageDefinition;

public static class PolskiDataType
{
    public const string Int32 = "int";
    public const string Int64 = "bigint";
    public const string Double = "double";
    public const string Anonymous = "anonymous";
    
    public static bool IsKnownType(string type)
    {
        return type switch
        {
            Int32 => true,
            Int64 => true,
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
        Double when right == Double => true,
        _ => false
    };
}