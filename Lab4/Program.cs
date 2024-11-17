using McMaster.Extensions.CommandLineUtils;

namespace Lab4;

public class Program
{
    public static void Main(string[] args)
    {
        CommandLineApplication.Execute<Program>(args);
    }
    private void OnExecute()
    {
        Console.WriteLine("Available commands:");

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("  dotnet run {labName}   - Run the specified lab.");
        Console.WriteLine("  dotnet run version     - Display app version.");
        Console.WriteLine("  dotnet run set-path    - Set default lab directory path.");
        Console.ResetColor();
    }

}
