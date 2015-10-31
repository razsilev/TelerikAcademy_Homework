using System;
using System.Numerics;

namespace _6CalculateSumFromString
{
    class CalculateSumFromString
    {
        static void Main()
        {
            Console.Write("Enter string whit numbers: ");

            string inputString = Console.ReadLine();

            string[] numbers = inputString.Split(' ');

            BigInteger sum = new BigInteger();

            for (int i = 0; i < numbers.Length; i++)
            {
                sum += BigInteger.Parse(numbers[i]);
            }

            Console.WriteLine("\nSum is: {0}\n", sum);
        }
    }
}
