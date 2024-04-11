namespace Polski.Cli;

public static class Backend
{
    public static void Run(string input, string output)
    {
        var process = new System.Diagnostics.Process
        {
            StartInfo = new System.Diagnostics.ProcessStartInfo
            {
                FileName = "clang-15",
                Arguments = $"-o {output} {input}"
            }
        };
        
        process.Start();
        process.WaitForExit();
    }
}