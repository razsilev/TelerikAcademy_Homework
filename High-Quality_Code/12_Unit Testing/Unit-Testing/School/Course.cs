using System;
using System.Collections.Generic;

namespace School
{
    public class Course
    {
        private const int MAX_NUMBER_OF_STUDENTS = 29;
        private IList<Student> students;
        private int id;
        private HashSet<int> usedStudentsNumbers;

        public Course(int id)
        {
            this.Id = id;
            this.students = new List<Student>();
            this.usedStudentsNumbers = new HashSet<int>();
        }

        public int Id
        {
            get { return id; }

            private set
            {
                id = value;
            }
        }

        public Student Leave(int studentNumber)
        {
            if (this.students.Count == 0)
            {
                return null;
            }

            Student remuvedStudent = null;

            for (int i = 0; i < this.students.Count; i++)
            {
                if (this.students[i].Number == studentNumber)
                {
                    remuvedStudent = this.students[i];
                    this.students.RemoveAt(i);
                    break;
                }
            }

            return remuvedStudent;
        }

        public bool Join(Student student)
        {
            if (this.students.Count > MAX_NUMBER_OF_STUDENTS)
            {
                return false;
            }

            if (student == null)
            {
                throw new ArgumentNullException("Student to add in course can not be null");
            }

            if (this.usedStudentsNumbers.Contains(student.Number))
            {
                return false;
            }

            this.usedStudentsNumbers.Add(student.Number);
            this.students.Add(student);

            return true;
        }
    }
}