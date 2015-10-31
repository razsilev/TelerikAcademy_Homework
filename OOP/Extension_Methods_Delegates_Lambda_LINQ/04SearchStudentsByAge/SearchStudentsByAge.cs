using System;
using System.Linq;

// 4. Write a LINQ query that finds the first name and last name
//    of all students with age between 18 and 24.

namespace _04SearchStudentsByAge
{
    class SearchStudentsByAge
    {
        static void Main()
        {
            Student[] students = new Student[4];

            students[0] = new Student("Emo", "Georgiev", 30);
            students[1] = new Student("Georgi", "Dulgerov", 20);
            students[2] = new Student("Doncho", "Mladenov", 24);
            students[3] = new Student("Ivan", "Ivanov", 17);

            int startAge = 18;
            int endAge = 24;

            var result = from stud in students
                         where (stud.Age >= startAge && stud.Age <= endAge)
                         select new { FName = stud.FirstName, LName = stud.LastName };

            foreach (var human in result)
            {
                Console.WriteLine("{0} {1}", human.FName, human.LName);
            }
        }
    }
}
