namespace Shared.FileWorkers;

public class FileReader(string path)
{
    public List<string?> ReadAllLines()
    {
        if (!File.Exists(path))
        {
            Console.WriteLine("Input file does not exists");
            return new List<string?>();
        }
        var lines = new List<string?>();
        using var streamReader = new StreamReader(path);

        while (streamReader.ReadLine() is {} line)
        {
            lines.Add(line);
        }
        return lines;
    }
}