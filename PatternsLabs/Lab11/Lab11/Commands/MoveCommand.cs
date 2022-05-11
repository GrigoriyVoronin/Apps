using System;

namespace Lab11.Commands
{
    public class MoveCommand : ICommand
    {
        private readonly StudentsGroup _studentsGroupFrom;
        private readonly StudentsGroup _studentsGroupTo;
        private readonly string _studentName;

        public MoveCommand(StudentsGroup studentsGroupFrom, StudentsGroup studentsGroupTo, string studentName)
        {
            _studentsGroupFrom = studentsGroupFrom;
            _studentsGroupTo = studentsGroupTo;
            _studentName = studentName;
        }

        public void Execute()
        {
            Console.WriteLine("Перемещение студента: ");
            _studentsGroupFrom.Remove(_studentName);
            _studentsGroupTo.Add(_studentName);
        }
    }
}