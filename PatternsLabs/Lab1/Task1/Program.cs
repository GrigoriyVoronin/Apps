using System;
using System.Linq;
using System.Text;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var pair = GetPair();
            var x = pair[0];
            var y = pair[1];
            if (x < y)
            {
                Print(x, y, 'X', 'Y');
            }
            else
            {
                Print(y, x, 'Y', 'X');
            }
        }

        public static int[] GetPair()
        {
            return Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
        }

        public static void Print(int min, int max, char minChar, char maxChar)
        {
            var builder = new StringBuilder();
            for (int i = 0; i < max; i++)
            {
                builder.Append(maxChar);
                if (i < min)
                {
                    builder.Append(minChar);
                }
            }
            Console.WriteLine(builder.ToString());
        }
    }
}
