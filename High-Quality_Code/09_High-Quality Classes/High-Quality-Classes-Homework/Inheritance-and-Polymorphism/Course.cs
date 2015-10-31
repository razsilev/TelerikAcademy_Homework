namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Course
    {
        private string name;

        public Course(string courseName)
            : this(courseName, null, null)
        {
            
        }

        public Course(string courseName, string teacherName)
            : this(courseName, teacherName, new List<string>())
        {

        }

        public Course(string courseName, string teacherName, IList<string> students)
        {
            this.Name = courseName;
            this.TeacherName = teacherName;
            this.Students = students;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Course name can not be null");
                }
                else if (value == string.Empty)
                {
                    throw new ArgumentOutOfRangeException("Course name can not be empty");
                }

                this.name = value;
            }
        }

        public string TeacherName { get; set; }
        
        public IList<string> Students { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            
            result.Append(this.GetType().Name);
            result.Append(" { Name = ");
            result.Append(this.Name);
            
            if (this.TeacherName != null)
            {
                result.Append("; Teacher = ");
                result.Append(this.TeacherName);
            }

            result.Append("; Students = ");
            result.Append(this.GetStudentsAsString());

            return result.ToString();
        }

        private string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }
    }
}
