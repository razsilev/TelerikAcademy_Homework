using System;
using System.Linq;

// 5.   Using the extension methods OrderBy() and ThenBy() 
//      with lambda expressions sort the students by first
//      name and last name in descending order.
//      Rewrite the same with LINQ.

namespace _05SortStudents
{
    class SortStudents
    {
        static void Main()
        {
            Student[] students = new Student[5];

            students[0] = new Student("Emo", "Georgiev");
            students[1] = new Student("Georgi", "Dulgerov");
            students[2] = new Student("Doncho", "Stoqnov");
            students[3] = new Student("Doncho", "Ivanov");
            students[4] = new Student("Doncho", "Mladenov");

            var sotedStudents = students.OrderBy(stud => stud.FirstName).ThenBy(s => s.LastName);

            Console.WriteLine("Sort whit extension methods OrderBy() and ThenBy()");
            foreach (var stud in sotedStudents)
            {
                Console.WriteLine("{0} {1}", stud.FirstName, stud.LastName);
            }

            Console.WriteLine("\nSort whit LINQ");

            var sortedWhitLinq = from s in students
                                 orderby s.FirstName, s.LastName
                                 select s;

            foreach (var stud in sortedWhitLinq)
            {
                Console.WriteLine("{0} {1}", stud.FirstName, stud.LastName);
            }
        }
    }
}
