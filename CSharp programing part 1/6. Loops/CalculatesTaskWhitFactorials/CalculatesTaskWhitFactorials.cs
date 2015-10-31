using System;
using System.Numerics;

class CalculatesTaskWhitFactorials
{
    static void Main()
    {
        int n = 0;
        int k = 0;
        BigInteger result = 0;
        BigInteger kFactorial = 0;
        BigInteger nFactorial = 0;

        Console.WriteLine("Calculates N!*K! / (K-N)! for given N and K  1<N<K.\n");
        Console.Write("Enter N: ");
        n = int.Parse(Console.ReadLine());
        Console.Write("Enter K: ");
        k = int.Parse(Console.ReadLine());

        if ((1 < n) && (n < k))
        {
            nFactorial = CalculateFactorial(1, n);
            kFactorial = CalculateFactorial((k - n), k);
            result = nFactorial * kFactorial;

            Console.WriteLine("\nN!*K! / (K-N)! = {0}\n", result);
        }
        else
        {
            Console.WriteLine("Error Invalid input (1<N<K) -> (1<{0}<{1})", n, k);
        }
    }

    private static BigInteger CalculateFactorial(int from, int to)
    {
        BigInteger result = 1;

        // result is the product of the numbers from K to N
        for (int i = from + 1; i <= to; i++)
        {
            result *= i;
        }

        return result;
    }
}