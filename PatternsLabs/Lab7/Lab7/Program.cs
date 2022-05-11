using System;

namespace Lab7
{
    class Program
    {
        static void Main()
        {
            StudentsGroup.Instance.Print();

            StudentsGroup.Instance.InputName();
            StudentsGroup.Instance.Print();

            StudentsGroup.Instance.InputDepartment();
            StudentsGroup.Instance.Print();

            StudentsGroup.Instance.InputYear();
            StudentsGroup.Instance.Print();

            StudentsGroup.Instance.InputSemester();
            StudentsGroup.Instance.Print();

            StudentsGroup.Instance.InputExamsQuantity();
            StudentsGroup.Instance.Print();

            StudentsGroup.Instance.InputTestsQuantity();
            StudentsGroup.Instance.Print();
        }
    }
}
