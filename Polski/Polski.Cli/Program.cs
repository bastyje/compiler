using Cocona;
using Polski.Compiler;

var builder = CoconaApp.CreateBuilder();
var app = builder.Build();

app.AddCommand(([Option('o')] string? output) =>
{
    const string code =
        """
        int j = 3;
        int i = j + 4 / 2 * 5;
        """;
    
    var compiled = Compiler.Compile(code);
    
    if (output is not null)
    {
        File.WriteAllText(output, compiled);
    }

    Console.WriteLine(compiled);
});

app.Run();
    
