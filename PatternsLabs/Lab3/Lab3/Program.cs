using System;

namespace Lab3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Первое множество:");
            var first = IntSetCreator.CreateIntSet();
            first.PrintElements();
            Console.WriteLine("Второе множество:");
            var second = IntSetCreator.CreateIntSet();
            second.PrintElements();
            Console.WriteLine("Обычное объединение:");
            var defaultUnion = TIntSet.DefaultUnion(first, second);
            defaultUnion.PrintElements();
            Console.WriteLine("Логическое объединение:");
            var logicUnion = TIntSet.LogicUnion(first, second);
            logicUnion.PrintElements();
            Console.WriteLine("Обычное объединение с сортировкой:");
            var orderedDefaultUnion = TIntSet.DefaultUnionWithOrdering(first, second);
            orderedDefaultUnion.PrintElements();
        }
    }
}
