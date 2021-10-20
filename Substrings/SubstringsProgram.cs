using System;
using System.Collections.Generic;
using System.Linq;

namespace Substrings
{
    internal class SubstringsProgram
    {
        private static void Main()
        {
            var input = Console.ReadLine();
            var maxWeights = new Dictionary<int, int>();
            var len = 1;
            while (len <= input.Length)
            {
                var wordsCount = new Dictionary<string, int>();
                for (var i = 0; i <= input.Length - len; i++)
                {
                    var word = input.Substring(i, len);
                    if (wordsCount.ContainsKey(word))
                        wordsCount[word] += 1;
                    else
                        wordsCount[word] = 1;
                }

                maxWeights[len++] = wordsCount.Max(p => p.Value);
            }

            Console.WriteLine(maxWeights.Max(p => p.Value));
        }
    }
}