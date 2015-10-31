using System;

namespace _1DecimalToBinary
{
    class DecimalToBinary
    {
        static void Main()
        {
            Console.Write("Enter number: ");
            int decimalNumber = int.Parse(Console.ReadLine());
            string binNumber = "";

            if (decimalNumber < 0)
            {
                decimalNumber *= -1;
                binNumber = Convert.ToString(decimalNumber, 2);
                binNumber = "-" + binNumber;
            }
            else
            {
                binNumber = Convert.ToString(decimalNumber, 2);
            }

            Console.WriteLine("Binary representation: {0}", binNumber);
        }
    }
}
