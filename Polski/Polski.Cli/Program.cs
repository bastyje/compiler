using Antlr4.Runtime;
using Cocona;
using Polski.Compiler;
using Polski.Compiler.listener;

var builder = CoconaApp.CreateBuilder();
var app = builder.Build();

app.AddCommand(([Option('o')] string? output) =>
{
    
    const string code = "princt(g);";
    
    var compiled = Compiler.Compile(code);
    
    if (output is not null)
    {
        File.WriteAllText(output, compiled);
    }

    Console.WriteLine(compiled);
});

app.Run();
    
