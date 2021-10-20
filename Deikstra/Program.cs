using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace DeikstraPolina
{
    class Program
    {
        static void Main(string[] args)
        {
            var time = new Stopwatch();
            time.Start();
            var lines = File.ReadAllLines("data.txt");
            FindWay(lines);
            Console.WriteLine(time.Elapsed.TotalMilliseconds);
            time.Stop();
        }

        public static void FindWay(string[] lines)
        {
            var countOfTowns = int.Parse(lines[0]);
            Console.WriteLine("Введите индекс начального города(целое число от 1 до {0})", countOfTowns);
            var startTown = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите индекс конечного города(целое число от 1 до {0})", countOfTowns);
            var endTown = int.Parse(Console.ReadLine());
            Console.WriteLine("Из города А в город Б существует лишь одна дорога, true or false?");
            var multyRoads = bool.Parse(Console.ReadLine());
            var dataBase = CreateDataBase(lines, multyRoads);
            var way = FindMinWay(dataBase, startTown, endTown, countOfTowns);
            Console.WriteLine(way == int.MaxValue ? "Маршрут не существует" : $"Кратчайший путь составит {way} условных единиц");
        }

        private static int FindMinWay(SortedDictionary<int, SortedDictionary<int, int>> dataBase, int startTown, int endTown, int countOfTowns)
        {
            var tagsLenght = new int[countOfTowns + 1].Select(tag => int.MaxValue).ToArray();
            var tagsVisit = new bool[countOfTowns + 1];
            tagsVisit[0] = true;
            tagsLenght[startTown] = 0;
            while (!tagsVisit[endTown])
            {
                var index = FindIndexOfMinTag(tagsLenght, tagsVisit);
                if (index == 0)
                    break;
                if (dataBase.ContainsKey(index))
                    foreach (var town in dataBase[index])
                    {
                        tagsLenght[town.Key] = Math.Min(tagsLenght[town.Key], town.Value + tagsLenght[index]);
                    }
                tagsVisit[index] = true;
            }
            return tagsLenght[endTown];
        }

        private static int FindIndexOfMinTag(int[] tagsLenght, bool[] tagsVisit)
        {
            var index = 0;
            var value = int.MaxValue;
            for (int i = 1; i < tagsVisit.Length; i++)
            {
                if (!tagsVisit[i] && tagsLenght[i] < value)
                {
                    value = tagsLenght[i];
                    index = i;
                }
            }
            return index;
        }

        private static SortedDictionary<int, SortedDictionary<int, int>> CreateDataBase(string[] data, bool isManyRoadsFromAToB)
        {
            var dataBase = new SortedDictionary<int, SortedDictionary<int, int>>();
            if (!isManyRoadsFromAToB)
                for (int i = 1; i < data.Length; i++)
                {
                    var dataInline = data[i].Split().Select(x => int.Parse(x)).ToArray();
                    if (!dataBase.ContainsKey(dataInline[0]))
                        dataBase[dataInline[0]] = new SortedDictionary<int, int>();
                    dataBase[dataInline[0]][dataInline[1]] = dataInline[2];
                }
            else
                for (int i = 1; i < data.Length; i++)
                {
                    var dataInline = data[i].Split().Select(x => int.Parse(x)).ToArray();
                    if (!dataBase.ContainsKey(dataInline[0]))
                        dataBase[dataInline[0]] = new SortedDictionary<int, int>();
                    if (dataBase[dataInline[0]].ContainsKey(dataInline[1]))
                        dataBase[dataInline[0]][dataInline[1]] = Math.Min(dataInline[2], dataBase[dataInline[0]][dataInline[1]]);
                    else
                        dataBase[dataInline[0]][dataInline[1]] = dataInline[2];
                }
            return dataBase;
        }
    }
}
