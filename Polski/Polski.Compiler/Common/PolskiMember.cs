namespace Polski.Compiler.Common;

public class PolskiMember(string? name, string type)
{
    public PolskiMember(string type) : this(null, type) {}
    
    public string Name
    {
        get => _name; // ?? throw new InvalidOperationException("Name is not set");
        set => _name = value;
    }
    private string? _name = name;
    
    public string Type { get; set; } = type;
}