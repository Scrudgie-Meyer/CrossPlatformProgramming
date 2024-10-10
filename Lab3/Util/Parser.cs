namespace Lab3.Util;

public class Parser(List<string> lines)
{
    private readonly List<string> _lines = lines;
    public int N { get; private set; }
    public char[,] Labyrinth { get; private set; } = new char[0, 0];

    public void Parse()
    {
        N = int.Parse(_lines[0]);

        Labyrinth = new char[N, N];

        for (int i = 0; i < N; i++)
        {
            var line = _lines[i + 1];
            for (int j = 0; j < N; j++)
            {
                Labyrinth[i, j] = line[j];
            }
        }
    }
}
