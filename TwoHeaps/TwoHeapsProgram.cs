using System;
using System.Linq;

namespace TwoHeaps
{
    class TwoHeapsProgram
    {
        private static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .OrderByDescending(x => x)
                .ToArray();
            var result = MinDifferences(0, 0, 0, input, int.MaxValue);
            Console.WriteLine(result);
        }

        public static int MinDifferences(int counter, int sum1, int sum2, int[] input, int different)
        {
            if (counter == input.Length)
                return Math.Min(Math.Abs(sum1 - sum2), different);

            return Math.Min(MinDifferences(counter + 1, sum1 + input[counter], sum2, input, different),
                MinDifferences(counter + 1, sum1, sum2 + input[counter], input, different));
        }
    }
}
