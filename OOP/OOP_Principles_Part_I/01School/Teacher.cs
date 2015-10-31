using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01School
{
    class Teacher : People
    {
        private List<Discipline> disciplines;

        public List<Discipline> Disciplines 
        {
            get
            {
                return this.disciplines;
            }

            set
            {
                this.disciplines = value;
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

        public Teacher(string firstName, string lastName, string comments = "")
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Coments = comments;

            this.disciplines = new List<Discipline>();
        }

        public void AddDiscipline(Discipline discipline)
        {
            disciplines.Add(discipline);
        }

        public override string ToString()
        {
            return string.Format("teacher: {0} {1}", FirstName, LastName);
        }
    }
}
