using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04SearchStudentsByAge
{
    public struct Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public Student(string firstName, string lastName, int age)
            : this()
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }
    }
}
