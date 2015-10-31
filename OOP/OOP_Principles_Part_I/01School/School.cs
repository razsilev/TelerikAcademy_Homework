using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01School
{
    public class School
    {
        public static void Main()
        {
            List<Student> students = new List<Student>();

            students.Add(new Student("Pesho", "Petrov"));
            students.Add(new Student("Ivan", "Ivanov"));

            List<Teacher> teachers = new List<Teacher>();

            teachers.Add(new Teacher("Vidio", "Giurov"));
            teachers.Add(new Teacher("Mimi", "Mileva"));

            teachers[0].AddDiscipline(new Discipline("Fizics", 8, 8));
            teachers[1].AddDiscipline(new Discipline("Magic of Prime Numbers", 16, 16, "Great science"));

            SchoolClass eightAClass = new SchoolClass(students, teachers, "8A");

            Console.WriteLine("class identifier: {0}", eightAClass);
            Console.WriteLine("Teachers:");
            
            for (int i = 0; i < eightAClass.Teachers.Count; i++)
            {
                Console.WriteLine(eightAClass.Teachers[i]);
            }

            Console.WriteLine("Students:");

            for (int i = 0; i < eightAClass.Students.Count; i++)
            {
                Console.WriteLine(eightAClass.Students[i]);
            }

            Console.WriteLine("\nDiscipline \"{1}\" comment: {0}.\n", teachers[1].Disciplines[0].Coments, teachers[1].Disciplines[0]);
        }
    }
}
