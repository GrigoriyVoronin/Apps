using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab3
{
    public static class IntSetCreator
    {
        public static TIntSet CreateIntSet()
        {
            Console.WriteLine("Введите Размер Множества");
            var setSize = int.Parse(Console.ReadLine());
            var types = new HashSet<string> {"positive", "negative", "zero", "mixed"};
            Console.WriteLine("Введите один из предложенных типов множеств:");
            Console.WriteLine(string.Join('/', types));
            var setType = Console.ReadLine().ToLowerInvariant();
            while (!types.Contains(setType))
            {
                Console.WriteLine("Вы ввели неверное значение!");
                Console.WriteLine("Введите один из предложенных типов множеств:");
                Console.WriteLine(string.Join('/', types));
                setType = Console.ReadLine().ToLowerInvariant();
            }
            var currentCount = 0;
            TIntSet set = setType switch
            {
                "positive" => new PositiveIntSet(setSize),
                "negative" => new NegativeIntSet(setSize),
                "zero" => new ZeroIntSet(setSize),
                "mixed" => new MixedIntSet(setSize),
                _ => throw new ArgumentOutOfRangeException(setType)
            };
            while (currentCount < setSize)
            {
                Console.WriteLine($"Введите число оносящееся к {setType} типу множества");
                var number = int.Parse(Console.ReadLine());
                while (!set.IsValidNumber(number))
                {
                    Console.WriteLine("Вы ввели неверное значение!");
                    Console.WriteLine($"Введите число оносящееся к {setType} типу множества");
                    number = int.Parse(Console.ReadLine());
                }

                set[currentCount++] = number;
            }
            
            return set;
		}

        public static TIntSet CreateIntSet(int maxSize, IList<int> elements)
        {
            TIntSet set;
            if (elements.All(x => x > 0))
            {
                set = new PositiveIntSet(maxSize);
            }
            else if (elements.All(x => x < 0))
            {
                set = new NegativeIntSet(maxSize);
            }
            else if (elements.All(x => x == 0))
            {
                set = new ZeroIntSet(maxSize);
            }
            else
            {
                set = new MixedIntSet(maxSize);
            }

            for (int i = 0; i < maxSize; i++)
            {
                set[i] = elements[i];
            }

            return set;
        }
    }
}