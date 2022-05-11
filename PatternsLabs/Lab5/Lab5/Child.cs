using System;

namespace Lab5
{
    public class Child
    {
        public Child(string fullName, string birthdayDate, string gender, string hobbies)
        {
            FullName = fullName;
            BirthdayDate = birthdayDate;
            Gender = gender;
            Hobbies = hobbies;
        }

        public string FullName { get; }
        public string BirthdayDate { get; }
        public string Gender { get; }
        public string Hobbies { get; }

        public override bool Equals(object? obj)
        {
            if (!(obj is Child child))
            {
                return false;
            }

            return Equals(child);
        }

        protected bool Equals(Child other)
        {
            return FullName == other.FullName
                   && BirthdayDate == other.BirthdayDate
                   && Gender == other.Gender
                   && Hobbies == other.Hobbies;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FullName, BirthdayDate, Gender, Hobbies);
        }

        public override string ToString()
        {
            return $"{Gender} {FullName} {BirthdayDate} {Hobbies}";
        }
    }
}