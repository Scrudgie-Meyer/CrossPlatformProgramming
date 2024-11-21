using Lab3.Util;
using Lab5.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lab5.Controllers;

public class LabController : Controller
{
    [Authorize]
    public IActionResult Index()
    {

        return View(new IOModel()
        {
            SelectedLab = "Lab1"
        });
    }

    [Authorize]
    [HttpPost]
    public IActionResult Index(IOModel model)
    {
        var lines = model.Input.Split("\n").ToList();
        switch (model.SelectedLab)
        {
            case "Lab1":

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
                }
                else
                {
                    // Log an error if the input data is invalid
                    Console.WriteLine("Invalid data in input file");
                }

                break;
            case "Lab2":

                var parser2 = new Lab2.Util.Parser(lines);
                parser2.Parse();

                if (parser2.IsDataCorrect)
                {
                    var answers = new List<int>();

                    // Loop through each parsed line of data
                    for (int i = 0; i < parser2.N.Count; i++)
                    {
                        // Use the corresponding values of N, K, and word for each line
                        var answer = Lab2.Program.Calculate(parser2.N[i], parser2.K[i], parser2.Words[i]);
                        Console.WriteLine("Result: " + answer);
                        answers.Add(answer);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid data in input file");
                }

                break;
            case "Lab3":
                var nonNullLines = lines.Where(line => line != null).Cast<string>().ToList();
                foreach (var line in nonNullLines)
                {
                    Console.WriteLine(line);
                }

                var parser3 = new Lab3.Util.Parser(nonNullLines);
                parser3.Parse();

                Console.WriteLine("\nParsed labyrinth:");
                for (int i = 0; i < parser3.N; i++)
                {
                    for (int j = 0; j < parser3.N; j++)
                    {
                        Console.Write(parser3.Labyrinth[i, j] + " ");
                    }
                    Console.WriteLine();
                }

                int visibleWallArea = WallCalculator.CalculateVisibleWallArea(parser3.Labyrinth, parser3.N);
                Console.WriteLine($"\nCalculated visible wall area: {visibleWallArea} square meters");

                break;
        }
        return View(model);
    }
}