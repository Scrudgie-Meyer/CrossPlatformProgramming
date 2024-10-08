namespace Lab2.Tests;

public class UnitTest1
{
    [Theory]
    [InlineData(6, 1, "reactor", 15)]
    [InlineData(4, 0, "abba", 6)]
    [InlineData(3, 1, "abc", 6)]
    [InlineData(7, 2, "kolobok", 26)]
    [InlineData(5, 0, "abcba", 7)]
    [InlineData(8, 3, "aabbccdd", 35)]
    [InlineData(6, 2, "abcabc", 21)]
    public void TestCalc(int n, int k, string word, int expected)
    {
        // Act
        var result = Program.Calculate(n, k, word);

        // Log the result for verification
        Console.WriteLine($"TestCalc: n = {n}, k = {k}, word = \"{word}\", result = {result}, expected = {expected}");

        // Assert
        Assert.Equal(expected, result);
    }
}
