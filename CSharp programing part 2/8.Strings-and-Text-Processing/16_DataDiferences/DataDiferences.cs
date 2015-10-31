using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//16   Write a program that reads two dates in the format: 
//     day.month.year and calculates the number of days 
//     between them. Example:


namespace _16_DataDiferences
{
    class DataDiferences
    {
        static void Main()
        {
            Console.Title = "Diferences between two dates";
            Console.WriteLine("Date format 27.02.2006");
            
            Console.Write("\nEnter the first date: ");
            string inputDate = Console.ReadLine();
            DateTime firstDate = DateTime.Parse(inputDate);
            
            Console.Write("Enter the second date: ");
            inputDate = Console.ReadLine();
            DateTime secondDate = DateTime.Parse(inputDate);

            TimeSpan days = firstDate - secondDate;

            Console.WriteLine("Distance: {0} days\n", Math.Abs(days.Days));
        }
    }
}
