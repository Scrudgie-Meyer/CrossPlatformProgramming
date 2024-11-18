using Lab3.Util;
using Shared.FileLoaders;

namespace Lab4;

public class LabExecutor(string? lab, string inputPath, string outputPath)
{
    public void Execute()
    {
        switch (lab)
        {
            case "lab1":
                ExecuteLab1();
                break;
            case "lab2":
                ExecuteLab2();
                break;
            case "lab3":
                ExecuteLab3();
                break;
            default:
                break;
        }
    }

    private void ExecuteLab1()
    {
        // Read all lines from the input file
        var fileReader = new FileReader(inputPath);
        var lines = fileReader.ReadAllLines();

        // Parse the data from the input file
        var parser = new Lab1.Util.Parser(lines);
        parser.Parse();

        // Check if the parsed data is valid
        if (parser.IsDataCorrect)
        {
            // Call the function to calculate the count of prime divisors for each value in the list
            var primeDivisorCounts = Lab1.Program.CalculatePrimeDivisorCounts(parser.Values);

            // Create a string from the counts of prime divisors for each number
            var result = string.Join(" ", primeDivisorCounts);

            // Output the result to the console before writing to the file
            Console.WriteLine("Prime divisor counts: " + result);

            // Write the result to the output file
            var fileWriter = new FileWriter(outputPath);
            fileWriter.Write(result);

            // Log the successful file write operation
            Console.WriteLine("Result has been written to the file: " + outputPath);
        }
        else
        {
            // Log an error if the input data is invalid
            Console.WriteLine("Invalid data in input file");
        }
    }

    private void ExecuteLab2()
    {
        var fileReader = new FileReader(inputPath);
        var lines = fileReader.ReadAllLines();
        var parser = new Lab2.Util.Parser(lines);
        parser.Parse();

        if (parser.IsDataCorrect)
        {
            var answers = new List<int>();

            // Loop through each parsed line of data
            for (int i = 0; i < parser.N.Count; i++)
            {
                // Use the corresponding values of N, K, and word for each line
                var answer = Lab2.Program.Calculate(parser.N[i], parser.K[i], parser.Words[i]);
                Console.WriteLine("Result: " + answer);
                answers.Add(answer);
            }



            // Write all answers to the output file
            var fileWriter = new FileWriter(outputPath);
            fileWriter.Write(string.Join(Environment.NewLine, answers));
        }
        else
        {
            Console.WriteLine("Invalid data in input file");
        }
    }

    private void ExecuteLab3()
    {
        var fileReader = new FileReader(inputPath);
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

        File.WriteAllText(outputPath, visibleWallArea.ToString());
    }
}