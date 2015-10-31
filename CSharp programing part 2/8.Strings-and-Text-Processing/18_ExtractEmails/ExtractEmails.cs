using System;
using System.Text.RegularExpressions;

//18.   Write a program for extracting all email addresses
//      from given text. All substrings that match the format 
//      <identifier>@<host>…<domain> should be recognized as emails.


namespace _18_ExtractEmails
{
    class ExtractEmails
    {
        static void Main()
        {
            string str = "Ala bala porukala gencho@abv.com. Write in this email ehaa,menteMazno@gmail.com return";

            foreach (var item in Regex.Matches(str, @"\w+@\w+\.\w+"))
                Console.WriteLine(item);
        }
    }
}
