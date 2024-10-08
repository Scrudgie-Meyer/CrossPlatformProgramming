public class Parser
{
    public List<int> N { get; private set; } = new List<int>();  // Store multiple N values
    public List<int> K { get; private set; } = new List<int>();  // Store multiple K values
    public List<string> Words { get; private set; } = new List<string>();  // Store multiple words
    public bool IsDataCorrect { get; private set; } = true;

    private List<string?> lines;

    public Parser(List<string?> lines)
    {
        this.lines = lines;
    }

    public void Parse()
    {
        if (lines.Count < 1)
        {
            Console.WriteLine("Insufficient data in input file");
            IsDataCorrect = false;
            return;
        }

        foreach (var line in lines)
        {
            if (string.IsNullOrEmpty(line))
            {
                Console.WriteLine("Empty line encountered");
                IsDataCorrect = false;
                continue; // Skip empty lines
            }

            var parts = line.Split(' ');

            if (parts.Length < 3)
            {
                Console.WriteLine("Invalid format in line: " + line);
                IsDataCorrect = false;
                continue;
            }

            if (!int.TryParse(parts[0], out int n))
            {
                Console.WriteLine("Invalid value for N in line: " + line);
                IsDataCorrect = false;
                continue;
            }

            if (!int.TryParse(parts[1], out int k))
            {
                Console.WriteLine("Invalid value for K in line: " + line);
                IsDataCorrect = false;
                continue;
            }

            var word = parts[2];

            if (string.IsNullOrEmpty(word) || word.Length != n)
            {
                Console.WriteLine("Invalid word or word length does not match N in line: " + line);
                IsDataCorrect = false;
                continue;
            }

            // Store the parsed values
            N.Add(n);
            K.Add(k);
            Words.Add(word);
        }
    }
}
