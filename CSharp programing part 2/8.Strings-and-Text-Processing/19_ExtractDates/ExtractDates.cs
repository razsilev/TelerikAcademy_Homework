using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;

//19.   Write a program that extracts from a given text all 
//      dates that match the format DD.MM.YYYY. Display them 
//      in the standard date format for Canada.


namespace _19_ExtractDates
{
    class ExtractDates
    {
        static void Main()
        {
            string str = "dran dran 12.10.2012, 10.13.2018";

            PrinDates(str);
            Console.WriteLine();
        }

        private static void PrinDates(string str)
        {
            string[] pasableDates = GetPosableDates(str);
            Console.WriteLine("Dates are:\n");
            
            foreach (string dateStr in pasableDates)
            {
                DateTime date;

                bool isValid = DateTime.TryParse(dateStr, out date);

                if (isValid)
                {
                    Console.WriteLine(date.ToString("d", new CultureInfo("en-CA")));
                }
            }
        }

        private static string[] GetPosableDates(string str)
        {
            List<string> result = new List<string>();
            StringBuilder date = new StringBuilder();

            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsDigit(str[i]) || str[i] == '.')
                {
                    date.Append(str[i]);
                }
                else if (date.Length > 6 && date.Length <= 10)
                {
                    result.Add(date.ToString());
                    date.Clear();
                }
                else
                {
                    date.Clear();
                }
            }

            if (date.Length > 6 && date.Length <= 10)
            {
                result.Add(date.ToString());
                date.Clear();
            }

            return result.ToArray();
        }
    }
}
