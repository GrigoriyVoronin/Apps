using System;
using System.Collections.Generic;

namespace Lab9
{
    public class Employe : IDepartmentPart
    {
        public string LastName { get; }
        private double _salary;

        public static Employe Create(string departmentName)
        {
            Console.WriteLine($"Создание работника для отдела {departmentName}");
            Console.WriteLine("Введите фамилию работника: ");
            var lastName = Console.ReadLine();
            Console.WriteLine("Введите зарплату работника: ");
            var salary = double.Parse(Console.ReadLine());
            return new Employe(lastName, salary);
        }

        public Employe(string lastName, double salary)
        {
            LastName = lastName;
            _salary = salary;
        }

        public double GetSalary()
        {
            return _salary;
        }

        public void ChangeSalary(double delta)
        {
            _salary += delta;
        }

        public string Print()
        {
            return $"{LastName} зарплата = {_salary}";
        }
    }
}