using System;

namespace School
{
    public class Student
    {
        private string name;
        private int number;

        public Student(string name, int number)
        {
            this.Name = name;
            this.Number = number;
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                if (value == null || value == string.Empty)
                {
                    throw new ArgumentException("Name can not be null or empty");
                }

                name = value;
            }
        }

        public int Number
        {
            get
            {
                return number;
            }

            private set
            {
                if (value < 10000 || 99999 < value)
                {
                    throw new ArgumentOutOfRangeException("number mas be betwine 10 000 and 99 999");
                }

                number = value;
            }
        }
    }
}