using System;

namespace _7BinaryToHexaddecimal
{
    class BinaryToHexaddecimal
    {
        static void Main()
        {
            Console.Write("Enter binary number: ");
            string binValue = Console.ReadLine();
            bool haveNegativeSign = false;

            if (binValue[0] == '-')
            {
                binValue = binValue.Substring(1);
                haveNegativeSign = true;
            }

            int number = Convert.ToInt32(binValue, 2);

            string hexadecimal = Convert.ToString(number, 16);

            if (haveNegativeSign)
            {
                hexadecimal = "-" + hexadecimal;
            }

            Console.WriteLine("\nHexadecimal representation: {0}\n", hexadecimal.ToUpper());
        }
    }
}
