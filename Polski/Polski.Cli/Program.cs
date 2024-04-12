using Cocona;
using Polski.Cli;
using Polski.Compiler;
using Polski.Compiler.Error;

var builder = CoconaApp.CreateBuilder();
var app = builder.Build();
var dev = false;

#if DEBUG
    dev = true;
#endif

app.AddCommand((
    [Argument] string input,
    [Option('o')] string? output,
    [Option('l')] bool llvm,
    [Option('n')] bool noOptimize
) =>
{
    if (dev)
    {
        try
        {
            const string code =
                """
                abc = 1;  233
                float j = i + 1;
                """;

            var compiled = Compiler.Compile(code);
            Console.WriteLine(compiled);
            File.WriteAllText(output, compiled);
        }
        catch (CompilationErrorException) {}
    }
    else
    {
        try
        {
            Run(input, output, llvm, noOptimize);
        }
        catch (CompilationErrorException) {}
    }
});

app.Run();
return;

static void Run(string input, string? output, bool llvm, bool noOptimize)
{
    var code = File.ReadAllText(input);
    var compiled = Compiler.Compile(code);
    var llFile = Path.ChangeExtension(Path.GetTempFileName(), "ll");
    var llOptFile = Path.ChangeExtension(Path.GetTempFileName(), "ll");
    
    File.WriteAllText(llFile, compiled);
    
    if (!noOptimize)
    {
        MiddleEnd.Run(llFile, llOptFile);
    }
    
    if (llvm)
    {
        output ??= Path.ChangeExtension(input, ".ll");
        compiled = File.ReadAllText(noOptimize ? llFile : llOptFile);
        File.WriteAllText(output, compiled);
    }
    else
    {
        output ??= Path.ChangeExtension(input, Environment.OSVersion.Platform switch
        {
            PlatformID.Unix => ".out",
            PlatformID.Win32NT => ".exe",
            PlatformID.Win32S => ".exe",
            PlatformID.Win32Windows => ".exe",
            PlatformID.WinCE => ".exe",
            PlatformID.MacOSX => ".out",
            _ => throw new NotSupportedException()
        });
        Backend.Run(noOptimize ? llFile : llOptFile, output);
        
        if (Environment.OSVersion.Platform == PlatformID.Unix)
        {
            File.SetUnixFileMode(output, UnixFileMode.GroupExecute
                | UnixFileMode.GroupRead
                | UnixFileMode.GroupWrite
                | UnixFileMode.OtherExecute
                | UnixFileMode.OtherRead
                | UnixFileMode.OtherWrite
                | UnixFileMode.UserExecute
                | UnixFileMode.UserRead
                | UnixFileMode.UserWrite);
        }
    }
    
}