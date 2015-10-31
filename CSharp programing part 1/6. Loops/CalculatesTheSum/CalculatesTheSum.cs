using System;
using System.Numerics;

    class CalculatesTheSum
    {
        static void Main(string[] args)
        {
            uint n = 0;
            double result = 1.0d;
            uint x = 0;
            double xPower = 0;
            double nFactorial = 1;

            Console.WriteLine("For a given two integer numbers N and X,");
            Console.WriteLine("calculates the sumS = 1 + 1!/X + 2!/X2 + … + N!/XN\n");
            Console.Write("Enter N: ");
            n = uint.Parse(Console.ReadLine());
            Console.Write("Enter X: ");
            x = uint.Parse(Console.ReadLine());

            xPower = x;

            if ((n > 0) && (x > 0))
            {
                for (int i = 1; i <= n; i++)
                {
                    nFactorial *= i;
                    result = result + (nFactorial / xPower);
                    xPower *= x;
                }

                Console.WriteLine("The sum is: {0}\n", result);
            }
            else
            {
                Console.WriteLine("Error invalid integer numbers!/n");
            }
        }
    }