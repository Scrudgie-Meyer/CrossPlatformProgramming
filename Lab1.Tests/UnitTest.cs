namespace Lab1.Tests
{
    public class UnitTest
    {
        [Fact]
        public void TestCalc_ValidNumberWithPrimeDivisors()
        {
            var values = new List<int> { 30 };
            var result = Program.CalculatePrimeDivisorCounts(values);
            Assert.Single(result);
            Assert.Equal(3, result[0]);
            Console.WriteLine($"TestCalc_ValidNumberWithPrimeDivisors: {result[0]}");
        }

        [Fact]
        public void TestCalc_ValidNumberWithNoPrimeDivisors()
        {
            var values = new List<int> { 1 };
            var result = Program.CalculatePrimeDivisorCounts(values);
            Assert.Single(result);
            Assert.Equal(0, result[0]);
            Console.WriteLine($"TestCalc_ValidNumberWithNoPrimeDivisors: {result[0]}");
        }

        [Fact]
        public void TestCalc_PrimeNumber()
        {
            var values = new List<int> { 7 };
            var result = Program.CalculatePrimeDivisorCounts(values);
            Assert.Single(result);
            Assert.Equal(1, result[0]);
            Console.WriteLine($"TestCalc_PrimeNumber: {result[0]}");
        }

        [Fact]
        public void TestCalc_LargeCompositeNumber()
        {
            var values = new List<int> { 1000 };
            var result = Program.CalculatePrimeDivisorCounts(values);
            Assert.Single(result);
            Assert.Equal(2, result[0]);
            Console.WriteLine($"TestCalc_LargeCompositeNumber: {result[0]}");
        }

        [Fact]
        public void TestCalc_MultipleNumbers()
        {
            var values = new List<int> { 10, 15, 21 };
            var result = Program.CalculatePrimeDivisorCounts(values);
            Assert.Equal(3, result.Count);
            Assert.Equal(2, result[0]);
            Assert.Equal(2, result[1]);
            Assert.Equal(2, result[2]);
            Console.WriteLine($"TestCalc_MultipleNumbers: {string.Join(", ", result)}");
        }

        [Fact]
        public void TestCalc_NegativeNumber()
        {
            var values = new List<int> { -30 };
            var result = Program.CalculatePrimeDivisorCounts(values);
            Assert.Single(result);
            Assert.Equal(3, result[0]);
            Console.WriteLine($"TestCalc_NegativeNumber: {result[0]}");
        }

        [Fact]
        public void TestCalc_LargePrimeNumber()
        {
            var values = new List<int> { 997 };
            var result = Program.CalculatePrimeDivisorCounts(values);
            Assert.Single(result);
            Assert.Equal(1, result[0]);
            Console.WriteLine($"TestCalc_LargePrimeNumber: {result[0]}");
        }

        [Fact]
        public void TestCalc_EmptyList()
        {
            var values = new List<int>();
            var result = Program.CalculatePrimeDivisorCounts(values);
            Assert.Empty(result);
            Console.WriteLine($"TestCalc_EmptyList: {result.Count}");
        }

        [Fact]
        public void TestCalc_MultipleNumbersWithRepeats()
        {
            var values = new List<int> { 6, 6, 6 };
            var result = Program.CalculatePrimeDivisorCounts(values);
            Assert.Equal(3, result.Count);
            Assert.All(result, count => Assert.Equal(2, count));
            Console.WriteLine($"TestCalc_MultipleNumbersWithRepeats: {string.Join(", ", result)}");
        }
    }
}
