using System;
using System.Numerics;

class NthCatalanNumber
{
    static void Main(string[] args)
    {
        Console.Write("Enter Catalan N: ");
        uint n = uint.Parse(Console.ReadLine());
        BigInteger numeratorFactorial = 0;
        BigInteger denominatorFactorial = 0;
        BigInteger result = 0;

        numeratorFactorial = CalculateFactorial((n + 1), (2 * n));
        denominatorFactorial = CalculateFactorial(1, n);

        result = numeratorFactorial / denominatorFactorial;

        Console.WriteLine("{1}-tiq number of Catalan is: {0}",
            result, n);
    }

    private static BigInteger CalculateFactorial(ulong from, ulong to)
    {
        BigInteger result = 1;

        // result is the product of the numbers from K to N
        for (ulong i = from + 1; i <= to; i++)
        {
            result *= i;
        }

        return result;
    }
}