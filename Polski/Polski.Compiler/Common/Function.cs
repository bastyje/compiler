namespace Polski.Compiler.Common;

public class Function(string returnType, List<Member> parameters, string name)
{
    public string ReturnType { get; set; } = returnType;
    public List<Member> Parameters { get; set; } = parameters;
    public string Name { get; set; } = name;
}