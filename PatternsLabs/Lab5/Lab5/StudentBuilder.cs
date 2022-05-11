using System.Collections.Generic;

namespace Lab5
{
    public class StudentBuilder
    {
        private string _fullName;
        private string _gender;
        private string _educationForm;
        private string _maritalStatus;
        private readonly List<Child> _children = new List<Child>();

        public StudentBuilder WithFullName(string fullName)
        {
            _fullName = fullName;
            return this;
        }

        public StudentBuilder WithGender(string gender)
        {
            _gender = gender;
            return this;
        }

        public StudentBuilder WithEducationForm(string educationForm)
        {
            _educationForm = educationForm;
            return this;
        }

        public StudentBuilder WithMaritalStatus(string maritalStatus)
        {
            _maritalStatus = maritalStatus;
            return this;
        }

        public StudentBuilder WithChild(Child child)
        {
            _children.Add(child);
            return this;
        }

        public Student Build()
        {
            return new Student(_fullName, _gender, _educationForm, _maritalStatus, _children);
        }
    }
}