namespace Lab11.Commands
{
    public class CopyCommand : AbstractCommand
    {
        public CopyCommand(StudentsGroup studentsGroup, string studentName)
            : base(studentsGroup, studentName)
        {
        }

        public override void Execute()
        {
            StudentsGroup.Copy(StudentName);
        }
    }
}