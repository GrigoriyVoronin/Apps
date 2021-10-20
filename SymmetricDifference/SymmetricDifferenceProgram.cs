using System;
using System.Collections.Generic;
using System.Linq;

namespace SymmetricDifference
{
    class SymmetricDifferenceProgram
    {
        private static void Main()
        {
            var (firstMultitude, secondMultitude) = ParseInput(Console.ReadLine());
            var symmetricDifference = GetSymmetricDifference(firstMultitude, secondMultitude);
            Console.WriteLine(string.Join(' ', symmetricDifference));
        }

        private static IEnumerable<double> GetSymmetricDifference(IEnumerable<double> firstMultitude, IEnumerable<double> secondMultitude)
        {
            var excludedNumbers = new HashSet<double>();
            var includedNumbers = new SortedSet<double>();
            foreach (var numb in firstMultitude
                .Where(numb => !includedNumbers.Add(numb)))
                excludedNumbers.Add(numb);
            foreach (var numb in secondMultitude
                .Where(numb => !includedNumbers.Add(numb)))
                excludedNumbers.Add(numb);
            includedNumbers.ExceptWith(excludedNumbers);
            return includedNumbers;
        }

        private static (List<double>, List<double>) ParseInput(string inputStr)
        {
            var firstMultitude = new List<double>();
            var secondMultitude = new List<double>();
            using var input = inputStr
                .Split()
                .Select(double.Parse)
                .GetEnumerator();
            while (input.MoveNext() && input.Current != 0)
                firstMultitude.Add(input.Current);
            while (input.MoveNext() && input.Current != 0)
                secondMultitude.Add(input.Current);
            return (firstMultitude, secondMultitude);
        }
    }
}