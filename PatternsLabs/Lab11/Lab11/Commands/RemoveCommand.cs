namespace Lab11.Commands
{
    public class RemoveCommand : AbstractCommand
    {
        public RemoveCommand(StudentsGroup studentsGroup, string studentName)
            : base(studentsGroup, studentName)
        {
        }

        public override void Execute()
        {
            StudentsGroup.Remove(StudentName);
        }
    }
}