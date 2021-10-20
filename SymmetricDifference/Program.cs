using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace SymmetricDifference
{
    internal static class Program
    {
        private const string Separator = "|";
        private const string Input = "input.txt";
        private const string Output = "output.txt";
        private const string T1 = "t1.txt";
        private const string T2 = "t2.txt";

        private static void Main()
        {
            var start = GC.GetTotalMemory(false);
            Task5();
            var memoryUse = (GC.GetTotalMemory(false) - start) / (decimal) Math.Pow(2, 20);
            Console.WriteLine($"{memoryUse:F4}");
        }

        private static void Task5()
        {
            var timer = new Stopwatch();
            timer.Start();
            File.Copy(Input, Output, true);
            do
            {
                DivideToTempFiles();
            } while (MergeInOutputFile() != 1);

            timer.Stop();
            File.Copy(Output, "C:\\Users\\molch\\Desktop\\заочка\\3.1сем\\алгоритмы\\SymmetricDifference\\"+Output,true);
            Console.WriteLine(timer.Elapsed.TotalMilliseconds);
        }

        private static int MergeInOutputFile()
        {
            var enumerator1 = File.ReadLines(T1).GetEnumerator();
            var enumerator2 = File.ReadLines(T2).GetEnumerator();
            var streamWriter = new StreamWriter(Output, false);
            var is1NotEnd = enumerator1.MoveNext();
            var is2NotEnd = enumerator2.MoveNext();
            var seriesCount = 1;
            while (true)
                if (is1NotEnd && is2NotEnd)
                    seriesCount = enumerator1.Current.CompareTo(enumerator2.Current) <= 0
                        ? WriteAndMove(seriesCount, enumerator1, streamWriter, out is1NotEnd)
                        : WriteAndMove(seriesCount, enumerator2, streamWriter, out is2NotEnd);
                else if (is1NotEnd)
                    seriesCount = WriteAndMove(seriesCount, enumerator1, streamWriter, out is1NotEnd);
                else if (is2NotEnd)
                    seriesCount = WriteAndMove(seriesCount, enumerator2, streamWriter, out is2NotEnd);
                else
                    break;

            streamWriter.Close();
            enumerator1.Dispose();
            enumerator2.Dispose();
            return seriesCount;
        }

        private static int WriteAndMove(int seriesCount, IEnumerator<string> enumerator, StreamWriter streamWriter,
            out bool isNotEnd)
        {
            streamWriter.WriteLine(enumerator.Current);
            isNotEnd = enumerator.MoveNext();
            if (isNotEnd && enumerator.Current == Separator)
            {
                isNotEnd = enumerator.MoveNext();
                seriesCount++;
            }

            return seriesCount;
        }

        private static void DivideToTempFiles()
        {
            var linesEnumerator = File.ReadLines(Output).GetEnumerator();
            var streamWriter1 = new StreamWriter(T1, false);
            var streamWriter2 = new StreamWriter(T2, false);
            var isWriteToFirst = true;
            string previous = null;
            while (linesEnumerator.MoveNext())
            {
                if (string.CompareOrdinal(previous, linesEnumerator.Current) <= 0)
                {
                    WriteCurrentString(isWriteToFirst, linesEnumerator.Current, streamWriter1, streamWriter2);
                }
                else
                {
                    WriteCurrentString(isWriteToFirst, Separator, streamWriter1, streamWriter2);
                    isWriteToFirst = !isWriteToFirst;
                    WriteCurrentString(isWriteToFirst, linesEnumerator.Current, streamWriter1, streamWriter2);
                }

                previous = linesEnumerator.Current;
            }

            streamWriter1.Close();
            streamWriter2.Close();
            linesEnumerator.Dispose();
        }

        private static void WriteCurrentString(bool isWriteToFirst, string current,
            StreamWriter streamWriter1, StreamWriter streamWriter2)
        {
            if (isWriteToFirst)
                streamWriter1.WriteLine(current);
            else
                streamWriter2.WriteLine(current);
        }

        private static void Task4()
        {
            var ends = new Dictionary<int, string>
            {
                {1, "*)"},
                {2, "}"},
                {3, "\r\n"},
                {4, "‘"}
            };
            var counters = new Dictionary<int, int>
            {
                {1, 0},
                {2, 0},
                {3, 0},
                {4, 0}
            };
            var line = File.ReadAllText("Task4_Input.txt");
            var timer = new Stopwatch();
            timer.Start();
            var index = 0;
            var started = 0;
            while (index < line.Length)
                if (started != 0)
                {
                    var len = ends[started].Length;
                    if (line[new Range(index, Math.Min(index + len, line.Length))] == ends[started])
                    {
                        counters[started]++;
                        started = 0;
                        index += len;
                    }
                    else
                    {
                        index += 1;
                    }
                }
                else
                {
                    switch (line[new Range(index, index + 1)])
                    {
                        case "{":
                            started = 2;
                            index += 1;
                            break;
                        case "‘":
                            started = 4;
                            index += 1;
                            break;
                    }

                    if (started != 0)
                        continue;

                    switch (line[new Range(index, Math.Min(index + 2, line.Length))])
                    {
                        case "(*":
                            started = 1;
                            index += 2;
                            break;
                        case "//":
                            started = 3;
                            index += 2;
                            break;
                    }

                    if (started != 0)
                        continue;

                    index += 1;
                }

            timer.Stop();
            Console.WriteLine($"{counters[1]} {counters[2]} {counters[3]} {counters[4]}");
            Console.WriteLine(timer.Elapsed.TotalMilliseconds);
        }

        private static void Task3()
        {
            var lAndN = ReadLineAndParse();
            var coordinates = ReadLineAndParse();
            var timer = new Stopwatch();
            timer.Start();
            Array.Sort(coordinates);
            var answer = Analyze(coordinates, lAndN[0]);
            Console.WriteLine(answer); // Печатаем ответ
            timer.Stop();
            Console.WriteLine($"{timer.Elapsed.TotalMilliseconds}");
        }

        private static int Analyze(int[] sortedCoordinates, int len)
        {
            var pointCounter = 1;
            var currentPointValue = sortedCoordinates[0] + len;
            for (var i = 1; i < sortedCoordinates.Length; i++)
            {
                if (Math.Abs(currentPointValue - sortedCoordinates[i]) <= len)
                    continue;

                currentPointValue += sortedCoordinates[i] + len;
                pointCounter++;
            }

            return pointCounter;
        }

        private static int[] ReadLineAndParse() =>
            Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

        private static void Task1()
        {
            var input = Console.ReadLine(); /*File.ReadAllText("Task1_strbig.txt");*/
            var timer = new Stopwatch();
            timer.Start();
            var (firstMultitude, secondMultitude) =
                ParseInput(input); //Cчитываем множества чисел с консоли, в формате указанном в задании.
            var intersect = firstMultitude.Intersect(secondMultitude); // Находим пересечения данных множеств
            var union = firstMultitude.Union(secondMultitude); // Находим объединение множеств
            var symmetricDifference = union.Except(intersect); // Находим разность объединения с пересечением
            var sortedSet = symmetricDifference.OrderBy(x => x); //Сортируем итоговое множество для вывода результата
            var answer = BuildAnswer(sortedSet); //Готовим числа для печати в формате, указанном в задании
            Console.WriteLine(answer); // Печатаем ответ
            timer.Stop();
            Console.WriteLine($"{timer.Elapsed.TotalMilliseconds}");
        }

        private static (List<double>, List<double>) ParseInput(string inputStr)
        {
            var firstMultitude = new List<double>();
            var secondMultitude = new List<double>();
            var input = inputStr
                .Split()
                .Select(n => double.Parse(n, CultureInfo.InvariantCulture));
            var isFirstMul = true;
            foreach (var number in input)
            {
                if (number == 0 && isFirstMul)
                {
                    isFirstMul = false;
                    continue;
                }

                if (number == 0)
                    break;

                if (isFirstMul)
                    firstMultitude.Add(number);
                else
                    secondMultitude.Add(number);
            }

            return (firstMultitude, secondMultitude);
        }

        private static string BuildAnswer(IEnumerable<double> symmetricDifference)
        {
            var builder = new StringBuilder();
            foreach (var numb in symmetricDifference)
                builder.Append($"{numb} ");

            if (builder.Length > 0)
                builder.Remove(builder.Length - 1, 1);
            else
                builder.Append(0);

            return builder.ToString();
        }

        private static void Task2()
        {
            //Читаем данные с консоли
            var n = int.Parse(Console.ReadLine());
            Console.ReadLine();
            var ranking = Console.ReadLine()
                .Split()
                .Select(x => int.Parse(x) - 1)
                .Reverse() //Реверсим потому что нам над дали их по убыванию важности
                .ToArray();
            var data = InitData(n);
            //Дочитали
            var timer = new Stopwatch();
            timer.Start();
            //Заполняем массивы для названий, чисел, индексов
            var names = new string[data.Count];
            var dataArr = new int[data.Count][];
            var indexes = new int[data.Count];
            var i = 0;
            foreach (var input in data)
            {
                names[i] = input.Key;
                indexes[i] = i;
                dataArr[i++] = input.Value;
            }
            //Заполнили

            //Сортируем
            SortPhase(dataArr, indexes, ranking);
            //Выводим
            foreach (var index in indexes.Reverse())
                Console.WriteLine(names[index]);
            timer.Stop();
            Console.WriteLine($"{timer.Elapsed.TotalMilliseconds}");
        }

        private static void SortPhase(int[][] data, IList<int> indexes, IEnumerable<int> ranking)
        {
            // берем значения одного поля из каждого итема,
            // выстраиваем их в соотвествии с уже отсортированными значениями,
            // затем сортируем их самих
            foreach (var numbersToIndexes in ranking
                .Select(rank => data
                    .Select(dataValue => dataValue[rank])
                    .ToList())
                .Select(x => MoveNumbersToIndexes(x, indexes)))
                LuchshaiaSortirovkaVRossii(numbersToIndexes.ToArray(), indexes);
        }

        //Ставим значения в соотвествии уже отсортированным индексам
        private static int[] MoveNumbersToIndexes(IReadOnlyList<int> numbers, IList<int> indexes)
        {
            var movedArr = new int[indexes.Count];
            for (var i = 0; i < indexes.Count; i++)
                movedArr[i] = numbers[indexes[i]];
            return movedArr;
        }

        //Сама сортировка
        private static void LuchshaiaSortirovkaVRossii(IList<int> arr, IList<int> indexes)
        {
            int i, j;
            var startIndexes = indexes.ToArray();
            var radixArr = new int[arr.Count];
            var radixNumberArr = new int[arr.Count];
            int[] counterArr;
            var indexArr = new int[256];
            for (var shift = 0; shift < 4; shift++)
            {
                counterArr = new int[256];
                for (i = 0; i < arr.Count; i++)
                {
                    j = (arr[i] >> (shift * 8)) % 256;
                    counterArr[j]++;
                    radixArr[i] = j;
                    radixNumberArr[i] = arr[i];
                    startIndexes[i] = indexes[i];
                }

                indexArr[0] = 0;
                for (i = 1; i < counterArr.Length; i++)
                {
                    j = i - 1;
                    indexArr[i] = counterArr[j] + indexArr[j];
                }

                for (i = 0; i < arr.Count; i++)
                {
                    arr[indexArr[radixArr[i]]] = radixNumberArr[i];
                    indexes[indexArr[radixArr[i]]] = startIndexes[i];
                    indexArr[radixArr[i]]++;
                }
            }
        }

        //Чтение итемов с консоли
        private static Dictionary<string, int[]> InitData(int rankingLength)
        {
            var data = new Dictionary<string, int[]>();
            for (var i = 0; i < rankingLength; i++)
            {
                var input = Console.ReadLine()
                    .Split()
                    .ToArray();
                data[input[0]] = input
                    .Skip(1)
                    .Select(int.Parse)
                    .ToArray();
            }

            return data;
        }
    }
}