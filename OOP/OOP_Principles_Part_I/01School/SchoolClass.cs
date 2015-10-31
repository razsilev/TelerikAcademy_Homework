using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01School
{
    class SchoolClass : Comment
    {
        public List<Teacher> Teachers { get; set; }
        public List<Student> Students { get; set; }

        public string Identifier { get; private set; }
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

        public SchoolClass(List<Student> students, List<Teacher> teachers, string identifier, string comments = "")
        {
            for (int i = 0; i < students.Count; i++)
            {
                students[i].ClassNumber = i + 1;
            }

            this.Students = students;
            this.Teachers = teachers;
            this.Identifier = identifier;
            this.Coments = comments;
        }

        public override string ToString()
        {
            return this.Identifier;
        }
    }
}
