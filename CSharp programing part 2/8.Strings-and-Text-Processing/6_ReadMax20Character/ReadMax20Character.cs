using System;

// 6.  Write a program that reads from the console a string 
//     of maximum 20 characters. If the length of the string 
//     is less than 20, the rest of the characters should be 
//     filled with '*'. Print the result string into the console.


namespace _6_ReadMax20Character
{
    class ReadMax20Character
    {
        static void Main()
        {
            Console.Title = "Read max 20 character";

            const int maxStringLength = 20;
            Console.Write("Enter max 20 character string: ");
            string str = Console.ReadLine();

            if (str.Length <= maxStringLength)
            {
                if (str.Length == maxStringLength)
                {
                    Console.WriteLine("length is exact 20 -> {0}", str);
                }
                else
                {
                    string append = new string('*', maxStringLength - str.Length);
                    str += append;

                    Console.WriteLine("length: {0} -> {1}", str.Length, str);
                }
            }
            else
            {
                Console.WriteLine("Length is more then 20 characters!!!");
            }
        }
    }
}
