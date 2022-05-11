using System;

namespace Lab7
{
    public class StudentsGroup
    {
        public static StudentsGroup Instance { get; } = new StudentsGroup();

        public string Name { get; private set; }
        public int Year { get; private set; }
        public string Semester { get; private set; }
        public string Department { get; private set; }
        public int ExamsQuantity { get; private set; }
        public int TestsQuantity { get; private set; }

        private StudentsGroup()
        {
        }

        public void InputName()
        {
            Console.WriteLine("Введите название группы:");
            Name = Console.ReadLine();
        }

        public void InputYear()
        {
            Console.WriteLine("Введите год обучения:");
            Year = int.Parse(Console.ReadLine());
        }

        public void InputSemester()
        {
            Console.WriteLine("Введите семестр обучения:");
            Semester= Console.ReadLine();
        }

        public void InputDepartment()
        {
            Console.WriteLine("Введите выпускающую кафедру:");
            Department = Console.ReadLine();
        }

        public void InputExamsQuantity()
        {
            Console.WriteLine("Введите кол-во экзаменов:");
            ExamsQuantity = int.Parse(Console.ReadLine());
        }

        public void InputTestsQuantity()
        {
            Console.WriteLine("Введите кол-во зачётов:");
            TestsQuantity = int.Parse(Console.ReadLine());
        }

        public void Print()
        {
            const string defaultValue = "Без значения";
            Console.WriteLine("Группа:\n" +
                              $"Название - {Name ?? defaultValue}\n" +
                              $"Год обучения - {Year}\n" +
                              $"Кафедра - {Department ?? defaultValue}\n" +
                              $"Семестр - {Semester ?? defaultValue}\n" +
                              $"Кол-во экзаменов - {ExamsQuantity}\n" +
                              $"Кол-во зачётов - {TestsQuantity}");
        }
    }
}