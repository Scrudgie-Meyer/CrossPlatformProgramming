namespace Lab3.Tests
{
    public class UnitTest
    {
        [Fact]
        public void TestParser_ValidInput()
        {
            // Arrange
            var lines = new List<string>
            {
                "5",
                ".....",
                "..##.",
                "..#..",
                ".###.",
                "....."
            };

            var expectedLabyrinth = new char[,]
            {
                { '.', '.', '.', '.', '.' },
                { '.', '.', '#', '#', '.' },
                { '.', '.', '#', '.', '.' },
                { '.', '#', '#', '#', '.' },
                { '.', '.', '.', '.', '.' }
            };

            // Act
            var parser = new Parser(lines);
            parser.Parse();

            // Assert
            Console.WriteLine($"Expected N: 5, Actual N: {parser.N}");
            Console.WriteLine("Expected Labyrinth: ");
            PrintLabyrinth(expectedLabyrinth);
            Console.WriteLine("Actual Labyrinth: ");
            PrintLabyrinth(parser.Labyrinth);

            Assert.Equal(5, parser.N);
            Assert.Equal(expectedLabyrinth, parser.Labyrinth);
        }

        [Fact]
        public void TestWallCalculator_CalculateVisibleWallArea()
        {
            // Arrange
            var labyrinth = new char[,]
            {
                { '.', '.', '.', '.', '.' },
                { '.', '.', '#', '#', '.' },
                { '.', '.', '#', '.', '.' },
                { '.', '#', '#', '#', '.' },
                { '.', '.', '.', '.', '.' }
            };
            int N = 5;
            int expectedArea = 350;

            // Act
            var result = WallCalculator.CalculateVisibleWallArea(labyrinth, N);

            // Assert
            Console.WriteLine($"Expected area: {expectedArea}, Actual area: {result}");
            Assert.Equal(expectedArea, result);
        }

        [Fact]
        public void TestParser_EmptyInput()
        {
            // Arrange
            var lines = new List<string> { "0" };

            // Act & Assert
            var parser = new Parser(lines);
            parser.Parse();

            Console.WriteLine($"Expected N: 0, Actual N: {parser.N}");
            Assert.Equal(0, parser.N);
            Assert.Empty(parser.Labyrinth);
        }

        [Fact]
        public void TestParser_IncorrectInputFormat()
        {
            // Arrange
            var lines = new List<string> { "5", "....", "....", "....", "....", "...." }; // Некоректний формат

            // Act & Assert
            var parser = new Parser(lines);

            var ex = Assert.Throws<IndexOutOfRangeException>(() => parser.Parse());
            Console.WriteLine($"Caught exception: {ex.Message}");
            Assert.Equal("Index was outside the bounds of the array.", ex.Message);
        }

        // Additional Tests

        [Fact]
        public void TestWallCalculator_ComplexLabyrinth()
        {
            // Arrange
            var labyrinth = new char[,]
            {
                { '#', '#', '#', '#', '#' },
                { '#', '.', '.', '.', '#' },
                { '#', '.', '#', '.', '#' },
                { '#', '.', '.', '.', '#' },
                { '#', '#', '#', '#', '#' }
            };
            int N = 5;
            int expectedArea = 900;

            // Act
            var result = WallCalculator.CalculateVisibleWallArea(labyrinth, N);

            // Assert
            Console.WriteLine($"Expected area: {expectedArea}, Actual area: {result}");
            Assert.Equal(expectedArea, result);
        }

        [Fact]
        public void TestWallCalculator_FullWalls()
        {
            // Arrange
            var labyrinth = new char[,]
            {
                { '#', '#', '#', '#', '#' },
                { '#', '#', '#', '#', '#' },
                { '#', '#', '#', '#', '#' },
                { '#', '#', '#', '#', '#' },
                { '#', '#', '#', '#', '#' }
            };
            int N = 5;
            int expectedArea = 500;

            // Act
            var result = WallCalculator.CalculateVisibleWallArea(labyrinth, N);

            // Assert
            Console.WriteLine($"Expected area: {expectedArea}, Actual area: {result}");
            Assert.Equal(expectedArea, result);
        }

        [Fact]
        public void TestWallCalculator_NoWalls()
        {
            // Arrange
            var labyrinth = new char[,]
            {
                { '.', '.', '.', '.', '.' },
                { '.', '.', '.', '.', '.' },
                { '.', '.', '.', '.', '.' },
                { '.', '.', '.', '.', '.' },
                { '.', '.', '.', '.', '.' }
            };
            int N = 5;
            int expectedArea = 0;

            // Act
            var result = WallCalculator.CalculateVisibleWallArea(labyrinth, N);

            // Assert
            Console.WriteLine($"Expected area: {expectedArea}, Actual area: {result}");
            Assert.Equal(expectedArea, result);
        }

        private void PrintLabyrinth(char[,] labyrinth)
        {
            int n = labyrinth.GetLength(0);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(labyrinth[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
