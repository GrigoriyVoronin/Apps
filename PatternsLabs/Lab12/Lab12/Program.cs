using System;

namespace Lab12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var university = new Department("Университет");
            var umu = new Department("УМУ");
            var pfu = new Department("ПФУ");
            var ok = new Department("ОК");
            var educationalDepartment = new Department("Учебный отдел");
            var departmentForWorkWithOP = new Department("Отдел по работе с ОП");
            var accountingDepartment = new Department("Бухгалтерия");
            university.AddDepartments(umu, pfu, ok);
            umu.AddDepartments(educationalDepartment, departmentForWorkWithOP);
            pfu.AddDepartments(accountingDepartment);

            AddEmployesForDepartment(educationalDepartment, 3);
            AddEmployesForDepartment(departmentForWorkWithOP, 2);
            AddEmployesForDepartment(accountingDepartment, 2);
            AddEmployesForDepartment(pfu, 2);
            AddEmployesForDepartment(ok, 3);

            Console.WriteLine("Итоговая структура университета:");
            Console.WriteLine(university.Print());
            Console.WriteLine($"Сумма всех зарплат в университете: {university.GetSalary()}");
            Console.WriteLine("Введите насколько изменить зарплаты работникам: ");

            var delta = double.Parse(Console.ReadLine());
            university.ChangeSalary(delta);
            Console.WriteLine("Структура университета с имзененными ЗП:");
            Console.WriteLine(university.Print());
            Console.WriteLine($"Сумма всех зарплат в университете после зименения: {university.GetSalary()}");
        }

        private static void AddEmployesForDepartment(Department department, int count)
        {
            for (int i = 0; i < count; i++)
            {
                department.AddEmployes(Employe.Create(department.Name));
            }
        }
    }
}
