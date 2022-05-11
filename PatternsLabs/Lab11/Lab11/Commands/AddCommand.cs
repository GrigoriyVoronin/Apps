namespace Lab11.Commands
{
    public class AddCommand : AbstractCommand
    {
        public AddCommand(StudentsGroup studentsGroup, string studentName)
            : base(studentsGroup, studentName)
        {
        }

        public override void Execute()
        {
            StudentsGroup.Add(StudentName);
        }
    }
}