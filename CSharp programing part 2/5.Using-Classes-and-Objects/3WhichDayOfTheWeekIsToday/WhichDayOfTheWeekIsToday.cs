using System;

namespace _3WhichDayOfTheWeekIsToday
{
    class WhichDayOfTheWeekIsToday
    {
        static void Main()
        {
            DateTime date = DateTime.Now;

            Console.WriteLine("Program that prints to the console");
            Console.WriteLine("which day of the week is today.\n");

            Console.WriteLine("Today is: {0}\n", date.DayOfWeek);
        }
    }
}
