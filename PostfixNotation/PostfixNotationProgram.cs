using System;
using System.Collections.Generic;

namespace PostfixNotation
{
    class PostfixNotationProgram
    {
        private static readonly Dictionary<string, Func<double, double, double>> Operators
            = new Dictionary<string, Func<double, double, double>>
            {
                {"+", Plus},
                {"-", Subtract},
                {"*", Multiply},
                {"/", Divide}
            };

        public static void Main()
        {
            var n = Console.ReadLine();
            var postFixString = Console.ReadLine();
            var elements = postFixString.Split();
            Console.WriteLine(CalculatePostfix(elements));
        }

        private static double CalculatePostfix(IEnumerable<string> postfixList)
        {
            var numbers = new Stack<double>();
            foreach (var element in postfixList)
                if (Operators.ContainsKey(element))
                {
                    var numb2 = numbers.Pop();
                    var numb1 = numbers.Pop();
                    numbers.Push(Operators[element](numb1, numb2));
                }
                else
                {
                    numbers.Push(double.Parse(element));
                }

            return numbers.Pop();
        }

        private static double Plus(double numb1, double numb2) => numb1 + numb2;

        private static double Subtract(double numb1, double numb2) => numb1 - numb2;

        private static double Multiply(double numb1, double numb2) => numb1 * numb2;

        private static double Divide(double numb1, double numb2) => numb1 / numb2;
    }
}
