using Lab1.Util;
using Shared.FileWorkers;

namespace Lab1;

public class Program
{
    // Define paths for input and output files
    private static readonly string PathInput = Path.Combine(Path.GetFullPath("Lab1"), "Files", "INPUT.txt");
    private static readonly string PathOutput = Path.Combine(Path.GetFullPath("Lab1"), "Files", "OUTPUT.txt");

    public static void Main(String[] args)
    {
        // Read all lines from the input file
        var fileReader = new FileReader(PathInput);
        var lines = fileReader.ReadAllLines();

        // Parse the data from the input file
        var parser = new Parser(lines);
        parser.Parse();

        // Check if the parsed data is valid
        if (parser.IsDataCorrect)
        {
            // Call the function to calculate the count of prime divisors for each value in the list
            var primeDivisorCounts = CalculatePrimeDivisorCounts(parser.Values);

            // Create a string from the counts of prime divisors for each number
            var result = string.Join(" ", primeDivisorCounts);

            // Output the result to the console before writing to the file
            Console.WriteLine("Prime divisor counts: " + result);

            // Write the result to the output file
            var fileWriter = new FileWriter(PathOutput);
            fileWriter.Write(result);

            // Log the successful file write operation
            Console.WriteLine("Result has been written to the file: " + PathOutput);
        }
        else
        {
            // Log an error if the input data is invalid
            Console.WriteLine("Invalid data in input file");
        }
    }

    // Function to calculate the count of prime divisors for each number in the list
    public static List<int> CalculatePrimeDivisorCounts(List<int> values)
    {
        var primeDivisorCounts = new List<int>();

        // Loop through each value in the input list
        foreach (var x in values)
        {
            // Get the prime divisors of the current number
            var primeDivisors = GetPrimeDivisors(x);

            // Add the count of prime divisors to the result list
            primeDivisorCounts.Add(primeDivisors.Count);
        }

        return primeDivisorCounts;
    }

    // Function to get all prime divisors of a number
    public static List<int> GetPrimeDivisors(long x)
    {
        var primeDivisors = new List<int>();

        // Check division by every prime number from 2 to 1000
        for (int i = 2; i <= 1000; i++)
        {
            if (IsPrime(i) && x % i == 0)
            {
                primeDivisors.Add(i);
            }
        }

        return primeDivisors;
    }

    // Function to check if a number is prime
    public static bool IsPrime(int n)
    {
        if (n < 2) return false;

        // Check if the number is divisible by any number less than its square root
        for (int i = 2; i * i <= n; i++)
        {
            if (n % i == 0)
                return false;
        }
        return true;
    }
}
