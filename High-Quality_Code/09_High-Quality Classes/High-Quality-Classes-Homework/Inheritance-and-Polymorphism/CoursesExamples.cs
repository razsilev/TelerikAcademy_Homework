namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;

    class CoursesExamples
    {
        static void Main()
        {
            LocalCourse localCourse = new LocalCourse("Databases");
            Console.WriteLine(localCourse);
            Console.WriteLine();

            localCourse.Lab = "Enterprise";
            Console.WriteLine(localCourse);
            Console.WriteLine();

            localCourse.Students = new List<string>() { "Peter", "Maria" };
            Console.WriteLine(localCourse);
            Console.WriteLine();

            localCourse.TeacherName = "Svetlin Nakov";
            localCourse.Students.Add("Milena");
            localCourse.Students.Add("Todor");
            Console.WriteLine(localCourse);
            Console.WriteLine();

            OffsiteCourse offsiteCourse = new OffsiteCourse(
                "PHP and WordPress Development", "Mario Peshev", 
                new List<string>() { "Thomas", "Ani", "Steve" });
            Console.WriteLine(offsiteCourse);
        }
    }
}
