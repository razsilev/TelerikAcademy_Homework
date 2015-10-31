using System;

namespace _03FindStudents
{
    public struct Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Student(string firstName, string lastName) : this()
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
    }
}
