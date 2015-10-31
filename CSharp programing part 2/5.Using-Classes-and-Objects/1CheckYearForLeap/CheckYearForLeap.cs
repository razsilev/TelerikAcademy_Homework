using System;

namespace _1CheckYearForLeap
{
    class CheckYearForLeap
    {
        static void Main()
        {
            Console.WriteLine("Program check year for leap.\n");
            Console.Write("Enter year: ");

            int year = int.Parse(Console.ReadLine());

            if (DateTime.IsLeapYear(year))
            {
                Console.WriteLine("\nYear is leap.\n");
            }
            else
            {
                Console.WriteLine("\nYear is Not leap.\n");
            }
            
        }
    }
}
