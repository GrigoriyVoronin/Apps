using System;
using System.Linq;
using System.Text;

namespace PolynomialCalculator
{
    public class Polynomial
    {
        public int Pow { get; }
        public double[] Coefficients { get; }


        /// <param name="pow">Степень многочлена</param>
        /// <param name="coefficients">Коэффиценты многочлена начиная с 0 степени аргумета</param>
        /// <exception cref="ArgumentException">Количество аргументов должно быть равно степени многочлена + 1</exception>
        public Polynomial(int pow, params double[] coefficients)
        {
            if (pow + 1 != coefficients.Length)
            {
                throw new ArgumentException(
                    "The number of coefficients of a polynomial must be equal to its pow plus one.");
            }

            Pow = pow;
            Coefficients = coefficients;
        }

        public double Calculate(double argument)
        {
            var currentPow = 0;
            return Coefficients.Aggregate(0d, (a, b) => a + Math.Pow(currentPow++, argument) * b);
        }

        public static Polynomial SumPolynomials(Polynomial a, Polynomial b)
        {
            var newPow = Math.Max(a.Pow, b.Pow);
            var newCoefficients = new double[newPow + 1];
            for (int i = 0; i <= newPow; i++)
            {
                var newCoefficient = 0d;
                if (i <= a.Pow)
                {
                    newCoefficient += a.Coefficients[i];
                }

                if (i <= b.Pow)
                {
                    newCoefficient += b.Coefficients[i];
                }

                newCoefficients[i] = newCoefficient;
            }

            return new Polynomial(newPow, newCoefficients);
        }

        public static Polynomial SubPolynomials(Polynomial a, Polynomial b)
        {
            var newPow = Math.Max(a.Pow, b.Pow);
            var newCoefficients = new double[newPow + 1];
            for (int i = 0; i <= newPow; i++)
            {
                var newCoefficient = 0d;
                if (i <= a.Pow)
                {
                    newCoefficient += a.Coefficients[i];
                }

                if (i <= b.Pow)
                {
                    newCoefficient -= b.Coefficients[i];
                }

                newCoefficients[i] = newCoefficient;
            }

            return new Polynomial(newPow, newCoefficients);
        }

        public static Polynomial MultiplyPolynomials(Polynomial a, Polynomial b)
        {
            var newPow = a.Pow + b.Pow;
            var newCoefficients = new double[newPow + 1];
            for (int i = 0; i <= a.Pow; i++)
            {
                for (int j = 0; j <= b.Pow; j++)
                {
                    newCoefficients[i + j] = a.Coefficients[i] * b.Coefficients[j];
                }
            }

            return new Polynomial(newPow, newCoefficients);
        }

        public override string ToString()
        {
            var currentPow = 0;
            var builder = new StringBuilder();
            builder = Coefficients.Aggregate(builder, (a, b) => a.Append($"{b}x^{currentPow++} + "));
            builder.Remove(builder.Length - 3, 3);
            return builder.ToString();
        }
    }
}