using System;

namespace _5HexadecimalToBinary
{
    class HexadecimalToBinary
    {
        static void Main()
        {
            Console.Write("Enter hesadecimal number: ");
            string input = Console.ReadLine();
            bool haveNegativesign = false;

            if (input[0] == '-')
            {
                input = input.Substring(1);
                haveNegativesign = true;
            }

            int number = Convert.ToInt32(input, 16);

            string binValue = Convert.ToString(number, 2);

            if (haveNegativesign)
            {
                binValue = "-" + binValue;
            }

            Console.WriteLine("Binary representation: {0}", binValue);
        }
    }
}
