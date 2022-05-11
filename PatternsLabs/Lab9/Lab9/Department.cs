using System.Collections.Generic;
using System.Linq;

namespace Lab9
{
    public class Department : IDepartmentPart
    {
        private readonly List<IDepartmentPart> _departmentParts = new List<IDepartmentPart>();

        public Department(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public double GetSalary()
        {
            return _departmentParts.Sum(part => part.GetSalary());
        }

        public void ChangeSalary(double delta)
        {
            _departmentParts.ForEach(part => part.ChangeSalary(delta));
        }

        public string Print()
        {
            return $"Состав отдела \"{Name}\":\n" +
                   $"{string.Join(",\n", _departmentParts.Select(d => d.Print()))}\n" +
                   $"Зарплата отдела \"{Name}\": {GetSalary()}";
        }

        public void Add(params IDepartmentPart[] departmentParts)
        {
            _departmentParts.AddRange(departmentParts);
        }
    }
}