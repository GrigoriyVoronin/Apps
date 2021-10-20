using System;
using System.Collections.Generic;
using System.Numerics;

namespace MaximumThree
{
    class MaximumThreeProgram
    {
        private static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var numbers = new List<int>(n);
            for (var i = 0; i < n; i++)
                numbers.Add(int.Parse(Console.ReadLine()));
            numbers.Sort();
            Console.WriteLine(GetMaxProduct(numbers));
        }

        private static BigInteger GetMaxProduct(IReadOnlyList<int> sortedNumbers)
        {
            var lastIndex = sortedNumbers.Count - 1;
            var firstMultiplier = sortedNumbers[lastIndex];
            var secondMultiplier = BigInteger.Max(
                BigInteger.Multiply(sortedNumbers[0], sortedNumbers[1]),
                BigInteger.Multiply(sortedNumbers[lastIndex - 1], sortedNumbers[lastIndex - 2]));
            return BigInteger.Multiply(firstMultiplier, secondMultiplier);
        }
    }
}
