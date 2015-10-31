using System;

namespace _4HexadacimalToDecimal
{
    class HexadacimalToDecimal
    {
        static void Main()
        {
            Console.Write("Enter hexadecimal number: ");
            string input = Console.ReadLine();

            int number = 0;

            if (input[0] == '-')
            {
                string str = input.Substring(1);
                number = Convert.ToInt32(str, 16);
                number *= -1;
            }
            else
            {
                number = Convert.ToInt32(input, 16);
            }

            Console.WriteLine("Decimal representation: {0}", number);
        }
    }
}
