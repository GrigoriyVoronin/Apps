using System;
using System.Collections.Generic;
using Lab11.Commands;

namespace Lab11
{
    internal class Program
    {
        private static Snapshot _snapshot;
        private static readonly Stack<Snapshot> PreviousSnapshots = new Stack<Snapshot>();

        private static void Main(string[] args)
        {
            _snapshot = new Snapshot(
                new StudentsGroup("ЭМА-18-1"),
                new StudentsGroup("ЭМА-18-2")
            );

            while (true)
            {
                Console.WriteLine("Выберите комманду и нажмите соотвествующую клавишу:\n" +
                                  "e - добавление студента в группу\n" +
                                  "c - скопировать студента в группу\n" +
                                  "d - удалить студента из группы\n" +
                                  "x - перенос студента из одной группы в другую\n" +
                                  "p - вывести состав группы\n" +
                                  "s - откатить последнее изменение\n" +
                                  "z - выход из программы");
                Console.WriteLine();
                var input = Console.ReadLine().ToLower();

                ICommand command = null;
                switch (input)
                {
                    case "e":
                        PreviousSnapshots.Push(_snapshot.MakeSnapshot());
                        command = ExecuteAbstractCommand((g, s) => new AddCommand(g, s));
                        break;
                    case "c":
                        PreviousSnapshots.Push(_snapshot.MakeSnapshot());
                        command = ExecuteAbstractCommand((g, s) => new CopyCommand(g, s));
                        break;
                    case "d":
                        PreviousSnapshots.Push(_snapshot.MakeSnapshot());
                        command = ExecuteAbstractCommand((g, s) => new RemoveCommand(g, s));
                        break;
                    case "x":
                        PreviousSnapshots.Push(_snapshot.MakeSnapshot());
                        Console.WriteLine("Группа из которой будет перенесён студент:");
                        var groupFrom = ChooseGroup();
                        Console.WriteLine("Группа в которую будет перенесён студент: ");
                        var groupTo = ChooseGroup();
                        var student = ReadStudent();
                        command = new MoveCommand(groupFrom, groupTo, student);
                        break;
                    case "p":
                        Console.WriteLine("Выбери группы для вывода на экран:");
                        var printGroup = ChooseGroup();
                        command = new PrintCommand(printGroup);
                        break;
                    case "s":
                        if (PreviousSnapshots.Count != 0)
                        {
                            Console.WriteLine("Откат последнего изменения");
                            _snapshot = PreviousSnapshots.Pop();
                        }
                        else
                        {
                            Console.WriteLine("Больше нет изменений");
                        }
                        break;
                    case "z":
                        Console.WriteLine("Завершение программы");
                        return;
                    default:
                        Console.WriteLine("Введена несуществующая команда");
                        break;
                }
                command?.Execute();
                Console.WriteLine();
                Console.WriteLine(new string('-', 10));
            }
        }

        private static string ReadStudent()
        {
            Console.WriteLine("Введите имя студента: ");
            return Console.ReadLine();
        }

        private static StudentsGroup ChooseGroup()
        {
            while (true)
            {
                Console.WriteLine($"Выберите группу для действия {_snapshot.GroupEma181.Name} или {_snapshot.GroupEma182.Name}");
                var input = Console.ReadLine();
                if (input == _snapshot.GroupEma181.Name)
                {
                    return _snapshot.GroupEma181;
                }

                if (input == _snapshot.GroupEma182.Name)
                {
                    return _snapshot.GroupEma182;
                }
                Console.WriteLine("Имя группы введено неверно");
            }
        }

        private static AbstractCommand ExecuteAbstractCommand(Func<StudentsGroup, string, AbstractCommand> commandGetter)
        {
            var group = ChooseGroup();
            var student = ReadStudent();
            return commandGetter(group, student);
        }
    }
}
