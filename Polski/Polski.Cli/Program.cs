using Cocona;
using Polski.Compiler;

var builder = CoconaApp.CreateBuilder();
var app = builder.Build();

app.AddCommand(([Option('o')] string? output) =>
{
    const string code =
        """
        bigint j;
        j = 4294967296b;
        bigint i = 1b + j;
        """;
    
    var compiled = Compiler.Compile(code);
    
    if (output is not null)
    {
        File.WriteAllText(output, compiled);
    }

    Console.WriteLine(compiled);
});

app.Run();
    
