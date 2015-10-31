using System;

// 11   Write a program that reads a number and prints
//      it as a decimal number, hexadecimal number, percentage 
//      and in scientific notation. Format the output aligned 
//      right in 15 symbols.

namespace _11_PrintNumber
{
    class PrintNumber
    {
        static void Main()
        {
            Console.Title = "Print Number";
            System.Threading.Thread.CurrentThread.CurrentCulture =
                System.Globalization.CultureInfo.InvariantCulture;

            Console.Write("Enter number: ");
            double number = double.Parse(Console.ReadLine());

            Console.WriteLine("{0,15:G14}", number); // Decimal

            Console.WriteLine("{0,15:X}", (int)number); // Hexadecimal

            Console.WriteLine("{0,15:P}", number); // Percentage

            Console.WriteLine("{0,15:E}", number); // Scientific notation
        }
    }
}
