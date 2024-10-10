using Lab3.Util;
using Shared.FileLoaders;

namespace Lab3
{
    public class Program
    {
        private static readonly string PathInput = Path.Combine(Path.GetFullPath("Lab3"), "Files", "INPUT.txt");
        private static readonly string PathOutput = Path.Combine(Path.GetFullPath("Lab3"), "Files", "OUTPUT.txt");

        public static void Main(string[] args)
        {
            var fileReader = new FileReader(PathInput);
            var lines = fileReader.ReadAllLines();

            var nonNullLines = lines.Where(line => line != null).Cast<string>().ToList();
            foreach (var line in nonNullLines)
            {
                Console.WriteLine(line);
            }

            var parser = new Parser(nonNullLines);
            parser.Parse();

            Console.WriteLine("\nParsed labyrinth:");
            for (int i = 0; i < parser.N; i++)
            {
                for (int j = 0; j < parser.N; j++)
                {
                    Console.Write(parser.Labyrinth[i, j] + " ");
                }
                Console.WriteLine();
            }

            int visibleWallArea = WallCalculator.CalculateVisibleWallArea(parser.Labyrinth, parser.N);
            Console.WriteLine($"\nCalculated visible wall area: {visibleWallArea} square meters");

            File.WriteAllText(PathOutput, visibleWallArea.ToString());
        }
    }
}
