using System;

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            var student1 = new StudentBuilder()
                .WithFullName("Василий Васильевич Васильев")
                .WithGender("M")
                .WithEducationForm("очная")
                .WithMaritalStatus("женат")
                .WithChild(new Child("Иван Васильевич Васильев", "20.02.2015", "M", "футбол"))
                .Build();

            var student2 = new StudentBuilder()
                .WithFullName("Иван Иванович Иванов")
                .WithGender("M")
                .WithEducationForm("очная-заочная")
                .WithMaritalStatus("не женат")
                .WithChild(new Child("Василий Иванович Иванов", "12.05.2017", "M", "волейбол"))
                .Build();

            Console.WriteLine($"Сравнение студента 1 - {student1}");
            Console.WriteLine($"и студента 2 - {student2}");
            Console.WriteLine($"Студент 1 {(student1.Equals(student2) ? "равен" : "не равен")} студенту 2");
        }
    }
}
