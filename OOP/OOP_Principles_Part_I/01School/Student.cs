using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01School
{
    class Student : People
    {
        private int classNumber;

        public int ClassNumber
        {
            get { return classNumber; }
            set 
            {
                if (classNumber == 0)
                {
                    classNumber = value;
                }
                else
                {
                    throw new ArgumentException("The student already have a class number.");
                }
            }
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                this.lastName = value;
            }
        }

        public string Coments
        {
            get
            {
                return this.comments;
            }

            set
            {
                this.comments = value;
            }
        }

        public Student(string FirstName, string lastName, string comments = "")
        {
            this.FirstName = FirstName;
            this.LastName = lastName;
            this.Coments = comments;
        }

        public override string ToString()
        {
            return string.Format("sudent: {0} {1}", FirstName, LastName);
        }
    }
}
