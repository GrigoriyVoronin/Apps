using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lab3
{
    public abstract unsafe class TIntSet : IEnumerable<int>, IEquatable<TIntSet>
    {
        protected abstract string GetSetType();
        public abstract bool IsValidNumber(int number);
        public int* Pointer { get; private set; }
        public int MaxSize { get; private set; }

        public int this[int index]
        {
            get => *PointersArray[index];
            set => *PointersArray[index] = value;
        }

        private int*[] PointersArray { get; set; }

        protected TIntSet()
        {
            MaxSize = 8;
            PointersArray = new int*[MaxSize];
            var set = new int[MaxSize];
            ElementsToPointers(this, set);
        }

        protected TIntSet(int maxSize)
        {
            MaxSize = maxSize;
            PointersArray = new int*[MaxSize];
            var random = new Random();
            var randomSet = new int[MaxSize]
                .Select(x => random.Next())
                .ToArray();
            ElementsToPointers(this, randomSet);
        }

        protected TIntSet(TIntSet intSet)
        {
            MaxSize = intSet.MaxSize;
            Pointer = intSet.Pointer;
            PointersArray = intSet.PointersArray;
        }

        public static TIntSet DefaultUnion(TIntSet first, TIntSet second)
        {
            var unionSetSize = first.MaxSize + second.MaxSize;
            var unionSet = new int[unionSetSize];
            for (var i = 0; i < first.MaxSize; i++)
                unionSet[i] = first[i];
            for (var i = 0; i < second.MaxSize; i++)
                unionSet[first.MaxSize + i] = second[i];
            return IntSetCreator.CreateIntSet(unionSetSize, unionSet);
        }

        public static TIntSet LogicUnion(TIntSet first, TIntSet second)
        {
            var setUnion = new HashSet<int>(first);
            setUnion.UnionWith(second);
            return IntSetCreator.CreateIntSet(setUnion.Count, setUnion.ToArray());
        }

        public static TIntSet DefaultUnionWithOrdering(TIntSet first, TIntSet second)
        {
            var unionSetSize = first.MaxSize + second.MaxSize;
            var unionSet = new int[unionSetSize];
            for (var i = 0; i < first.MaxSize; i++)
                unionSet[i] = first[i];
            for (var i = 0; i < second.MaxSize; i++)
                unionSet[first.MaxSize + i] = second[i];
            Array.Sort(unionSet);
            return IntSetCreator.CreateIntSet(unionSetSize, unionSet);
        }

        public void InputElements()
        {
            var input = ParseInput();
            *Pointer = input[0];
            for (var i = 0; i < MaxSize; ++i)
                *PointersArray[i] = input[i];
        }

        public void PrintElements()
        {
            Console.WriteLine($"It's {GetSetType()} set");
            Console.WriteLine("Elements:");
            foreach (var el in this)
                Console.WriteLine(el);
        }

        public bool Equals(TIntSet? other)
        {
            if (other == null || other.MaxSize != MaxSize)
                return false;

            if (other.Pointer == Pointer)
                return true;

            for (var i = 0; i < MaxSize; i++)
                if (other[i] != this[i])
                    return false;

            return true;
        }

        public IEnumerator<int> GetEnumerator()
        {
            var numbers = new List<int>();
            for (var i = 0; i < MaxSize; i++)
                numbers.Add(*PointersArray[i]);

            return numbers.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private int[] ParseInput()
        {
            Console.WriteLine($"Введите элементы множества через пробел, в количестве: {MaxSize}");
            int[] input;
            while (true)
                try
                {
                    input = Console.ReadLine()
                        .Split()
                        .Select(int.Parse)
                        .ToArray();
                    if (input.Length == MaxSize)
                        break;

                    Console.WriteLine($"Количество чисел долнжо быть равно: {MaxSize}");
                }
                catch
                {
                    Console.WriteLine("Проверьте правильность ввода");
                }

            return input;
        }

        private static void ElementsToPointers(TIntSet intSet, int[] elements)
        {
            fixed (int* p = elements)
            {
                intSet.Pointer = p;
                for (var i = 0; i < intSet.MaxSize; ++i)
                    intSet.PointersArray[i] = p + i;
            }
        }
    }
}