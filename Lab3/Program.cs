using Lab3.Util;
using Shared.FileLoaders;

public class Program
{
    private static readonly string PathInput = Path.Combine(Path.GetFullPath("Lab3"), "Files", "INPUT.txt");
    private static readonly string PathOutput = Path.Combine(Path.GetFullPath("Lab3"), "Files", "OUTPUT.txt");

    public static void Main(string[] args)
    {
        var fileReader = new FileReader(PathInput);
        var lines = fileReader.ReadAllLines();
        var parser = new Parser(lines);
        parser.Parse();
    }
}