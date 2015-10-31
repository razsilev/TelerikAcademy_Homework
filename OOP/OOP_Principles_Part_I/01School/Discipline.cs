using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01School
{
    class Discipline : Comment
    {
        public string Name { get; set; }
        public int NumberOfLectures { get; set; }
        public int NumberOfExercises { get; set; }
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

        public Discipline(string name, int numberOfLectures, int numberOfExercises, string comments = "")
        {
            this.Name = name;
            this.NumberOfLectures = numberOfLectures;
            this.NumberOfExercises = numberOfExercises;
            this.Coments = comments;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
