using Cocona;
using Polski.Compiler;

var builder = CoconaApp.CreateBuilder();
var app = builder.Build();

app.AddCommand(([Argument] string? fileName) =>
{
    const string code =
        """
        int i = 1;
        int j = 2;
        int k = i + j * 3;
        """;
    
    new Compiler().Compile(code);
});

app.Run();