namespace Polski.Compiler.Visitor;

public class NodeResult
{
    public static implicit operator NodeResult(string code) => new() { Code = code };
    
    public string? Code { get; set; }
    public string? Type { get; set; }
    public string? Identifier { get; set; }
}