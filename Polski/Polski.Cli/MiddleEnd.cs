namespace Polski.Cli;

public static class MiddleEnd
{
    public static void Run(string input, string output)
    {
        var process = new System.Diagnostics.Process
        {
            StartInfo = new System.Diagnostics.ProcessStartInfo
            {
                FileName = "opt",
                Arguments = $"-O3 -S {input} -o {output}"
            }
        };
        
        process.Start();
        process.WaitForExit();
    }
}