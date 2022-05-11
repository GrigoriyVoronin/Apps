using System.Collections.Generic;

namespace Lab9
{
    public interface IDepartmentPart
    {
        public double GetSalary();
        public void ChangeSalary(double delta);
        public string Print();
    }
}