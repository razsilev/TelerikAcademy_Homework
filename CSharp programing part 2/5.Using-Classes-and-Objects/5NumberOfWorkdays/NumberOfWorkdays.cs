using System;

namespace _5NumberOfWorkdays
{
    class NumberOfWorkdays
    {
        static void Main()
        {
            Console.WriteLine("Calculate workdays from today to entered date.");
            Console.Write("\nEnter year: ");
            int year = int.Parse(Console.ReadLine());

            Console.Write("\nEnter month: ");
            int month = int.Parse(Console.ReadLine());

            Console.Write("\nEnter day: ");
            int day = int.Parse(Console.ReadLine());

            DateTime endDate = new DateTime(year, month, day);
            DateTime[] holidays = GetHolidays();

            int workdays = CalculateWorkdays(endDate, holidays);

            Console.WriteLine("\n\n Workdays are: {0}\n", workdays);
        }

        public static int CalculateWorkdays(DateTime endDate, DateTime[] holidays)
        {
            DateTime today = DateTime.Now;
            int days = 0;

            while (today < endDate)
            {
                if (today.DayOfWeek != DayOfWeek.Saturday &&
                    today.DayOfWeek != DayOfWeek.Sunday &&
                    !IsHoliday(today, holidays))
                {
                    days++;
                }

                today = today.AddDays(1);
            }

            return days;
        }

        private static DateTime[] GetHolidays()
        {
            DateTime today = DateTime.Now;

            DateTime[] holidays = new DateTime[]
            {
                new DateTime(today.Year, 1, 1),
                new DateTime(today.Year, 3, 3),
                new DateTime(today.Year, 5, 1),
                new DateTime(today.Year, 5, 2),
                new DateTime(today.Year, 5, 3),
                new DateTime(today.Year, 5, 4),
                new DateTime(today.Year, 5, 6),
                new DateTime(today.Year, 5, 24),
                new DateTime(today.Year, 9, 6),
                new DateTime(today.Year, 9, 22),
                new DateTime(today.Year, 12, 24),
                new DateTime(today.Year, 12, 25),
                new DateTime(today.Year, 12, 26),
                new DateTime(today.Year, 12, 31)
            };

            return holidays;
        }

        static bool IsHoliday(DateTime day, DateTime[] holidays)
        {
            foreach (DateTime holiday in holidays)
            {
                if ((day.Month == holiday.Month) && (day.Day == holiday.Day))
                {
                    return true;
                }
            }
            return false;
        }

    }
}
