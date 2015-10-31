using System;
using System.Globalization;

//17.   Write a program that reads a date and time given
//      in the format: day.month.year hour:minute:second 
//      and prints the date and time after 6 hours and 30 minutes
//      (in the same format) along with the day of week in Bulgarian.


namespace _17_CalculateDateAfterTime
{
    class CalculateDateAfterTime
    {
        static void Main()
        {
            string str = "23.06.2013 18:53:00";

            DateTime dateAndTime = DateTime.ParseExact(str, 
                                        "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            
            dateAndTime = dateAndTime.AddHours(6.5d);
            
            Console.WriteLine("{0} {1}", dateAndTime.ToString("dddd", new CultureInfo("bg-BG")), dateAndTime);
        }
    }
}
