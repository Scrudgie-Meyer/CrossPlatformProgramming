namespace Lab1.Util
{
    public class Parser
    {
        public List<int> Values { get; private set; }
        public bool IsDataCorrect { get; private set; }

        private List<string?> lines;

        public Parser(List<string?> lines)
        {
            this.lines = lines;
            Values = new List<int>();
        }

        public void Parse()
        {
            Values.Clear();

            foreach (var line in lines)
            {
                if (int.TryParse(line, out var number))
                {
                    Values.Add(number);
                }
                else
                {
                    IsDataCorrect = false;
                    return;
                }
            }

            IsDataCorrect = true;
        }
    }
}
