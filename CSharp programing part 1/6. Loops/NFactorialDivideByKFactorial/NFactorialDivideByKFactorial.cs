using System;
using System.Numerics;

class NFactorialDivideByKFactorial
{
    static void Main()
    {
        int n = 0;
        int k = 0;
        BigInteger result = 1;

        Console.WriteLine("Calculates N!/K! for given N and K  1<K<N.\n");
        Console.Write("Enter N: ");
        n = int.Parse(Console.ReadLine());
        Console.Write("Enter K: ");
        k = int.Parse(Console.ReadLine());

        if ((1 < k) && (k < n))
        {
            // result is the product of the numbers from K to N
            for (int i = k + 1; i <= n; i++)
            {
                result *= i;
            }

            Console.WriteLine("\nN!/K! = {0}\n", result);
        }
        else
        {
            Console.WriteLine("Error Invalid input (1<K<N) -> (1<{0}<{1})", k, n);
        }
    }
}