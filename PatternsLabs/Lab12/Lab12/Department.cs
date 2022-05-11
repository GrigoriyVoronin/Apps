using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lab12
{
    public class Department : IEnumerable<Employe>
    {
        private readonly List<Department> _departments = new List<Department>();
        private readonly List<Employe> _employes = new List<Employe>();

        public Department(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public double GetSalary()
        {
            return this.Sum(part => part.GetSalary());
        }

        public void ChangeSalary(double delta)
        {
            foreach (var employe in this)
            {
                employe.ChangeSalary(delta);
            }
        }

        public string Print()
        {
            return $"Состав отдела \"{Name}\":\n" +
                   $"{string.Join(",\n", this.Select(d => d.Print()))}\n" +
                   $"Зарплата отдела \"{Name}\": {GetSalary()}";
        }

        public void AddDepartments(params Department[] departments)
        {
            _departments.AddRange(departments);
        }

        public void AddEmployes(params Employe[] employes)
        {
            _employes.AddRange(employes);
        }

        public IEnumerator<Employe> GetEnumerator()
        {
            foreach (var department in _departments)
            {
                foreach (var employe in department)
                {
                    yield return employe;
                }
            }

            foreach (var employe in _employes)
            {
                yield return employe;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}