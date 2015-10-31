using System;

namespace _02People
{
    class Student : Human
    {
        private int grade;

        public int Grade
        {
            get { return grade; }
            set { grade = value; }
        }

        public string SetFirstName
        {
            set
            {
                base.firstName = value;
            }
        }
        public string SetLastName
        {
            set
            {
                base.lastName = value;
            }
        }

        public Student(string firstName, string lastName, int grade = 0)
        {
            this.SetFirstName = firstName;
            this.SetLastName = lastName;
            this.Grade = grade;
        }

        public override string ToString()
        {
            return string.Format("{0, -8} {1, -10} grade: {2}", this.firstName, this.lastName, this.grade);
        }
    }
}
