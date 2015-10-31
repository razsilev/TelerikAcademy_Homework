using System;

namespace _3DecimalToHexadecimal
{
    class DecimalToHexadecimal
    {
        static void Main()
        {
            Console.Write("Enter number: ");
            int input = int.Parse(Console.ReadLine());
           
            string hexadecimal = "";

            if (input < 0)
            {
                input *= -1;
                hexadecimal = Convert.ToString(input, 16);
                hexadecimal = "-" + hexadecimal;
            }
            else
            {
                hexadecimal = Convert.ToString(input, 16);
            }
            Console.WriteLine("Hexadecimal representation: {0}", hexadecimal.ToUpper());
        }
    }
}
