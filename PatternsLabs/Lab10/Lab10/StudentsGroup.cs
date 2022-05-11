using System;
using System.Collections.Generic;

namespace Lab10
{
    public class StudentsGroup
    {
        public string Name { get; }
        private readonly HashSet<string> _students = new HashSet<string>();

        public StudentsGroup(string name)
        {
            Name = name;
        }

        public void Add(string studentName)
        {
            Console.WriteLine(_students.Add(studentName)
                ? $"Студент {studentName} успешно добавлен в группу {Name}"
                : $"Студент {studentName} уже находится в группе {Name}");
        }

        public void Remove(string studentName)
        {
            Console.WriteLine(_students.Remove(studentName)
                ? $"Студент {studentName} успешно удалён из группы {Name}"
                : $"Студент {studentName} не найден в группе {Name}");
        }

        public void Copy(string studentName)
        {
            Console.WriteLine(_students.Add(studentName)
                ? $"Студент {studentName} успешно скопирован в группу {Name}"
                : $"Студент {studentName} уже находится в группе {Name}");
        }

        public override string ToString()
        {
            return $"Название группы: {Name}\n" +
                   "Состав группы:\n" +
                   $"{string.Join(", ", _students)}";
        }
    }
}