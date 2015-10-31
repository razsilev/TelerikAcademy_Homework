using System;

namespace Methods
{
    class Student
    {
        private const int MAX_AGE = 150;

        private string firstName;
        private string lastName;
        private DateTime dateOfBirth;

        public Student(string firstName, string lastName, DateTime dateOfBirth, string otherInfo = null)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateOfBirth = dateOfBirth;
            this.OtherInfo = OtherInfo;
        }

        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (value == null || value == string.Empty)
                {
                    throw new ArgumentException("First name can not be null or empty.");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (value == null || value == string.Empty)
                {
                    throw new ArgumentException("Last name can not be null or empty.");
                }

                this.lastName = value;
            }
        }

        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Date of birth can not be null.");
                }

                DateTime currentDate = DateTime.Now;
                int minYear = currentDate.Year - Student.MAX_AGE;

                if (minYear < value.Year && value.Year <= currentDate.Year)
                {
                    dateOfBirth = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Invalid date of birth.");
                }
            }
        }

        public string OtherInfo { get; set; }
    }
}
