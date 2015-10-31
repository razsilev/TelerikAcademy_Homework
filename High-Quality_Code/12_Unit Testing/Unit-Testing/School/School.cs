using System.Collections.Generic;

namespace School
{
    public class School
    {
        private Dictionary<int, Course> courses;
        private HashSet<int> usedStudentsNumbers;
        private HashSet<int> usedCoursesId;

        public School()
        {
            courses = new Dictionary<int, Course>();
            this.usedStudentsNumbers = new HashSet<int>();
            this.usedCoursesId = new HashSet<int>();
        }

        public bool TryCreateCourse(int id)
        {
            if (this.usedCoursesId.Contains(id))
            {
                return false;
            }

            this.courses.Add(id, new Course(id));
            this.usedCoursesId.Add(id);

            return true;
        }

        public bool TryJoinStudentInCourse(Student student, int courseId)
        {
            if (student == null)
            {
                return false;
            }

            if (this.usedStudentsNumbers.Contains(student.Number))
            {
                if (this.usedCoursesId.Contains(courseId))
                {
                    return this.courses[courseId].Join(student);
                }

                return false;
            }
            else
            {
                if (this.usedCoursesId.Contains(courseId))
                {
                    bool isJoined = this.courses[courseId].Join(student);

                    if (isJoined)
                    {
                        this.usedStudentsNumbers.Add(student.Number);
                    }

                    return isJoined;
                }
            }

            // student wont to join to not existing course
            return false;
        }

        public Student StudentLeaveCourse(int studentNumber, int courseId)
        {
            if (!this.usedStudentsNumbers.Contains(studentNumber))
            {
                return null;
            }

            if (!usedCoursesId.Contains(courseId))
            {
                return null;
            }

            this.usedStudentsNumbers.Remove(studentNumber);

            return this.courses[courseId].Leave(studentNumber);
        }
    }
}
