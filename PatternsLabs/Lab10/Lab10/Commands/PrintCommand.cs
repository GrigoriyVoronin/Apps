using System;

namespace Lab10.Commands
{
    public class PrintCommand : ICommand
    {
        private readonly StudentsGroup _studentsGroup;

        public PrintCommand(StudentsGroup studentsGroup)
        {
            _studentsGroup = studentsGroup;
        }

        public void Execute()
        {
            Console.WriteLine(_studentsGroup.ToString());
        }
    }
}