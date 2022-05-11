using System;
using System.Collections.Generic;
using Lab10.Commands;

namespace Lab10
{
    internal class Program
    {
        private static StudentsGroup _groupEma181;

        private static StudentsGroup _groupEma182;


        private static void Main(string[] args)
        {
            _groupEma181 = new StudentsGroup("ЭМА-18-1");
            _groupEma182 = new StudentsGroup("ЭМА-18-2");

            while (true)
            {
                Console.WriteLine("Выберите комманду и нажмите соотвествующую клавишу:\n" +
                                  "e - добавление студента в группу\n" +
                                  "c - скопировать студента в группу\n" +
                                  "d - удалить студента из группы\n" +
                                  "x - перенос студента из одной группы в другую\n" +
                                  "p - вывести состав группы\n" +
                                  "z - выход из программы");
                var input = Console.ReadLine().ToLower();

                ICommand command;
                switch (input)
                {
                    case "e":
                        command = ExecuteAbstractCommand((g, s) => new AddCommand(g, s));
                        break;
                    case "c":
                        command = ExecuteAbstractCommand((g, s) => new CopyCommand(g, s));
                        break;
                    case "d":
                        command = ExecuteAbstractCommand((g, s) => new RemoveCommand(g, s));
                        break;
                    case "x":
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
                    case "z":
                        Console.WriteLine("Завершение программы");
                        return;
                    default:
                        command = null;
                        Console.WriteLine("Введена несуществующая команда");
                        break;
                }

                command?.Execute();
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
                Console.WriteLine($"Выберите группу для действия {_groupEma181.Name} или {_groupEma182.Name}");
                var input = Console.ReadLine();
                if (input == _groupEma181.Name)
                {
                    return _groupEma181;
                }

                if (input == _groupEma182.Name)
                {
                    return _groupEma182;
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
