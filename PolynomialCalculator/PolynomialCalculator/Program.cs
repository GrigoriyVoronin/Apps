using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

/*
    1. Составить описание класса многочленов от одной переменной, задаваемых степенью многочлена и массивом коэффициентов.
    2. Предусмотреть методы для вычисления значения многочлена для заданного аргумента.
    3. Операции сложения, вычитания и умножения многочленов с получением нового объекта-многочлена
    4. Печать (вывод на экран) описания многочлена  
 */
namespace PolynomialCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите первый многочлен");
            var first = ReadPolynomial();
            Console.WriteLine("Введите второй многочлен");
            var second = ReadPolynomial();
            Console.WriteLine("Введите аргумент для которого будут рассчитаны полиномы: ");
            var arg = double.Parse(Console.ReadLine());
            Console.WriteLine($"{first} = {first.Calculate(arg)}");
            Console.WriteLine($"{second} = {second.Calculate(arg)}");

            var sum = Polynomial.SumPolynomials(first, second);
            Console.WriteLine("Сумма полиномов равна: ");
            Console.WriteLine($"{sum} = {sum.Calculate(arg)}");

            var sub = Polynomial.SubPolynomials(first, second);
            Console.WriteLine("Разность полиномов равна: ");
            Console.WriteLine($"{sub} = {sub.Calculate(arg)}");

            var multiply = Polynomial.MultiplyPolynomials(first, second);
            Console.WriteLine("Произведение полиномов равно: ");
            Console.WriteLine($"{multiply} = {multiply.Calculate(arg)}");
        }

        private static Polynomial ReadPolynomial()
        {
            Console.WriteLine("Введите степень полинома: ");
            var pow = int.Parse(Console.ReadLine());
            Console.WriteLine($"Введите {pow + 1} коэффицентов через пробел");
            var coefficients = Console.ReadLine().Split()
                .Select(double.Parse)
                .ToArray();
            var polynomial = new Polynomial(pow, coefficients);
            Console.WriteLine($"Вы ввели многочлен: {polynomial}");
            return polynomial;
        }
    }
}
