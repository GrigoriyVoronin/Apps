namespace Lab10.Commands
{
    public abstract class AbstractCommand : ICommand
    {
        protected StudentsGroup StudentsGroup { get; }
        protected string StudentName { get; }

        protected AbstractCommand(StudentsGroup studentsGroup, string studentName)
        {
            StudentsGroup = studentsGroup;
            StudentName = studentName;
        }

        public abstract void Execute();
    }
}