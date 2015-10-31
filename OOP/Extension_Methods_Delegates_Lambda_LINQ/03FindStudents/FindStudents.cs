using System;
using System.Collections.Generic;
using System.Linq;

// 3.   Write a method that from a given array of students finds all
//      students whose first name is before its last name alphabetically.
//      Use LINQ query operators.    

namespace _03FindStudents
{
    class FindStudents
    {
        static void Main()
        {
            Student[] students = new Student[3];

            students[0] = new Student("Emo", "Georgiev");
            students[1] = new Student("Georgi", "Dulgerov");
            students[2] = new Student("Doncho", "Mladenov");

            Student[] studentsWhitLittleFirstName = FindStudentsWhitLittleName(students);

            foreach (Student student in studentsWhitLittleFirstName)
            {
                Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
            }
        }

        private static Student[] FindStudentsWhitLittleName(Student[] students)
        {
            var result = from student in students
                         where student.FirstName.CompareTo(student.LastName) < 0
                         select student;

            List<Student> resultArray = new List<Student>();

            foreach (Student stud in result)
            {
                resultArray.Add(stud);
            }

            return resultArray.ToArray();
        }
    }
}
