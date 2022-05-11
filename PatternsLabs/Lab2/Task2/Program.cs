using System;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            var start = 1;
            var end = input[0];
            var k = input[1];
            var saveServers = GetSaveServers();
            var stack = new Stack<int>();
            stack.Push(start);
            var visited = new HashSet<int>();
            while (stack.Count > 0)
            {
                var current = stack.Pop();

                for (int i = 1; i <= k; i++)
                {
                    var next = current + i;
                    if (next == end)
                    {
                        Console.WriteLine("YES");
                        return;
                    }
                    if (!visited.Contains(next) && saveServers.Contains(next))
                    {
                        stack.Push(next);
                    }
                }
            }
            Console.WriteLine("NO");
        }

        private static HashSet<int> GetSaveServers()
        {
            var input = Console.ReadLine()
                .Select(ch => ch.Equals('1'))
                .ToArray();
            var saveSet = new HashSet<int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i])
                {
                    saveSet.Add(i + 1);
                }
            }

            return saveSet;
        }
    }
}
