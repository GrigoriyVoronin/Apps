using System;
using System.Collections.Generic;

namespace Lab5
{
    public class Student
    {
        public Student(string fullName, string gender, string educationForm, string maritalStatus, List<Child> children)
        {
            FullName = fullName;
            Gender = gender;
            EducationForm = educationForm;
            MaritalStatus = maritalStatus;
            IsHasChildren = children.Count > 0;
            Children = children;
        }

        public string FullName { get; }
        public string Gender { get; }
        public string EducationForm { get; }
        public string MaritalStatus { get; }
        public bool IsHasChildren { get; }
        public List<Child> Children { get; }

        public override bool Equals(object? obj)
        {
            if (!(obj is Student student))
            {
                return false;
            }

            return Equals(student);
        }

        protected bool Equals(Student other)
        {
            return FullName == other.FullName
                   && Gender == other.Gender
                   && EducationForm == other.EducationForm
                   && MaritalStatus == other.MaritalStatus
                   && IsHasChildren == other.IsHasChildren
                   && Children.TrueForAll(c => other.Children.Contains(c))
                   && other.Children.TrueForAll(c => Children.Contains(c));
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FullName, Gender, EducationForm, MaritalStatus, IsHasChildren, Children);
        }

        public override string ToString()
        {
            return $"{FullName} {Gender} {EducationForm} {MaritalStatus} Есть дети: {(IsHasChildren? "Да" : "Нет")} Дети: {string.Join(", ", Children)}";
        }
    }
}