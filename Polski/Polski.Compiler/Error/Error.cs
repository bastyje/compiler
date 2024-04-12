namespace Polski.Compiler.Error;

public class Error
{
    public int Column { get; set; }
    public int Line { get; set; }
    public string Message { get; set; }
}