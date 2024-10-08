using Shared.FileLoaders;

namespace Lab2;

public class Program
{
    private static readonly string PathInput = Path.Combine(Path.GetFullPath("Lab2"), "Files", "INPUT.txt");
    private static readonly string PathOutput = Path.Combine(Path.GetFullPath("Lab2"), "Files", "OUTPUT.txt");

    public static void Main(string[] args)
    {
        var fileReader = new FileReader(PathInput);
        var lines = fileReader.ReadAllLines();
        var parser = new Parser(lines);
        parser.Parse();

        if (parser.IsDataCorrect)
        {
            var answers = new List<int>();

            // Loop through each parsed line of data
            for (int i = 0; i < parser.N.Count; i++)
            {
                // Use the corresponding values of N, K, and word for each line
                var answer = Calculate(parser.N[i], parser.K[i], parser.Words[i]);
                Console.WriteLine("Result: " + answer);
                answers.Add(answer);
            }



            // Write all answers to the output file
            var fileWriter = new FileWriter(PathOutput);
            fileWriter.Write(string.Join(Environment.NewLine, answers));
        }
        else
        {
            Console.WriteLine("Invalid data in input file");
        }
    }

    public static int Calculate(int n, int k, string word)
    {
        int almostPalindromeCount = 0;

        // Generate all substrings
        for (int start = 0; start < n; start++)
        {
            for (int end = start; end < n; end++)
            {
                string substring = word.Substring(start, end - start + 1);
                int changesNeeded = CountChangesToPalindrome(substring);

                // If the changes needed are less than or equal to K, count it
                if (changesNeeded <= k)
                {
                    almostPalindromeCount++;
                }
            }
        }

        return almostPalindromeCount;
    }

    // Function to count how many changes are needed to make a string a palindrome
    private static int CountChangesToPalindrome(string s)
    {
        int changes = 0;
        int left = 0;
        int right = s.Length - 1;

        while (left < right)
        {
            if (s[left] != s[right])
            {
                changes++;
            }
            left++;
            right--;
        }

        return changes;
    }
}
