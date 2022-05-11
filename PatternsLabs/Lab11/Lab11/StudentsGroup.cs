using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab11
{
    public class StudentsGroup
    {
        public string Name { get; }
        private HashSet<string> Students { get; } = new HashSet<string>();

        public StudentsGroup(string name)
        {
            Name = name;
        }

        public void Add(string studentName)
        {
            Console.WriteLine(Students.Add(studentName)
                ? $"Студент {studentName} успешно добавлен в группу {Name}"
                : $"Студент {studentName} уже находится в группе {Name}");
        }

        public void Remove(string studentName)
        {
            Console.WriteLine(Students.Remove(studentName)
                ? $"Студент {studentName} успешно удалён из группы {Name}"
                : $"Студент {studentName} не найден в группе {Name}");
        }

        public void Copy(string studentName)
        {
            Console.WriteLine(Students.Add(studentName)
                ? $"Студент {studentName} успешно скопирован в группу {Name}"
                : $"Студент {studentName} уже находится в группе {Name}");
        }

        public override string ToString()
        {
            return $"Название группы: {Name}\n" +
                   "Состав группы:\n" +
                   $"{string.Join(", ", Students)}";
        }

        public StudentsGroup Clone()
        {
            var students = Students.ToHashSet();
            var group = new StudentsGroup(Name);
            foreach (var student in students)
            {
                group.Students.Add(student);
            }

            return group;
        }
    }
}