using System;

namespace _01DefineClassStudent
{
    class DefineClassStudent
    {
        static void Main()
        {
            Student studentOne = new Student("Mimi", "Mileva", "0901282467", Specialties.QI);
            Student studentTwo = new Student("Pepi", "Ivanova", "0901282433", Specialties.QI);
            Student studentThree = studentOne;

            Console.WriteLine(studentOne);
            Console.WriteLine("\nHash code: {0}", studentOne.GetHashCode());

            Console.WriteLine("\nstudentOne Equals studentTwo: {0}", studentOne.Equals(studentTwo));
            Console.WriteLine("\nstudentOne Equals studentThree: {0}", Student.Equals(studentOne, studentThree));
            Console.WriteLine("\nstudentOne == studentTwo: {0}", studentOne == studentTwo);
            Console.WriteLine("\nstudentOne == null: {0}", studentOne == null);
            
            studentThree = null;

            Console.WriteLine("\nstudentThree == null: {0}", studentThree == null);
            Console.WriteLine("\nstudentThree != studentOne: {0}", studentThree != studentOne);

            studentThree = studentOne;

            Console.WriteLine("\nstudentOne != studentThree: {0}", studentOne != studentThree);

            Console.WriteLine("\n\nClone studentOne in studentThree and change name and specialty in studentThree.");
            studentThree = studentOne.Clone();

            studentThree.FirstName = "Aneta";
            studentThree.LastName = "Pesheva";
            studentThree.Specialty = Specialties.Math;

            Console.WriteLine("\n studentThree: {0}", studentThree);
            Console.WriteLine("\n studentOne: {0}", studentOne);

            Console.WriteLine("\nClone by using IColoneable.Clone()");
            ICloneable clone = studentOne;
            studentThree = (Student)clone.Clone();

            Console.WriteLine("\n studentThree: {0}", studentThree);

            Console.Write("\nCompare studentThree with studentOne result: ");
            Console.WriteLine(studentThree.CompareTo(studentOne));

            Console.Write("\nCompare studentOne with studentTwo result: ");
            Console.WriteLine(studentOne.CompareTo(studentTwo));

            Console.Write("\nCompare studentTwo with studentOne result: ");
            Console.WriteLine(studentTwo.CompareTo(studentOne));
        }
    }
}
