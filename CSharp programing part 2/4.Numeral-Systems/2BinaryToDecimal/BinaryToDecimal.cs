using System;
using System.Text;

namespace _2BinaryToDecimal
{
    class BinaryToDecimal
    {
        static void Main()
        {
            Console.Write("Enter binary number: ");
            string input = Console.ReadLine();
            int decimalNumber = 0;

            if (input[0] == '-')
            {
                string str = input.Substring(1);
                decimalNumber = Convert.ToInt32(str, 2);
                decimalNumber *= -1;
            }
            else
            {
                decimalNumber = Convert.ToInt32(input, 2);
            }

            Console.WriteLine("Decimal representation: {0}", decimalNumber);
        }
    }
}
