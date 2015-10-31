using System;
using System.Collections.Generic;

namespace _11AddsTwoPolinomials
{
    class AddsTwoPolinomials
    {
        static void Main()
        {
            int[] firstPolinomial = { 4, -5 };
            int[] secondPolinomial = { -4, 0, 1 };

            Console.Write("first = ");
            PrintPolinomial(firstPolinomial);
            Console.Write("second = ");
            PrintPolinomial(secondPolinomial);

            Console.WriteLine("\nPolinomial adds is:");
            int[] sum = AddsPolinomial(firstPolinomial, secondPolinomial);
            PrintPolinomial(sum);
            
            int[] substractPolinomials =
                        SubstractPolinomials(firstPolinomial, secondPolinomial);
            Console.WriteLine("\nPolinomial substract first - second is:");
            PrintPolinomial(substractPolinomials);

            int[] multiplicationPolinom =
                    MultiplicationOfPolynomials(firstPolinomial, secondPolinomial);
            Console.WriteLine("\nPolinomial multiplication is:");
            PrintPolinomial(multiplicationPolinom);
        }

        private static int[] MultiplicationOfPolynomials(int[] first, int[] second)
        {
            int arrayLength = first.Length + second.Length - 1;
            int[] result = new int[arrayLength];

            for (int i = 0; i < first.Length; i++)
            {
                int[] multiplicated = new int[arrayLength];

                for (int j = 0; j < second.Length; j++)
                {
                    int index = i + j;

                    multiplicated[index] = first[i] * second[j];
                }

                result = AddsPolinomial(result, multiplicated);
            }

            return result;
        }

        private static int[] SubstractPolinomials(int[] first, int[] second)
        {
            // change sign
            int[] secondPolinomial = new int[second.Length];
            second.CopyTo(secondPolinomial, 0);

            for (int i = 0; i < secondPolinomial.Length; i++)
            {
                secondPolinomial[i] *= (-1);
            }

            return AddsPolinomial(first, secondPolinomial);
        }

        private static int[] AddsPolinomial(int[] firstPolinomial, int[] secondPolinomial)
        {
            int[] sum;
            int length = firstPolinomial.Length;

            if (length > secondPolinomial.Length)
            {
                sum = new int[length];
                firstPolinomial.CopyTo(sum, 0);
                length = secondPolinomial.Length;
            }
            else
            {
                sum = new int[secondPolinomial.Length];
                secondPolinomial.CopyTo(sum, 0);
            }

            for (int i = 0; i < length; i++)
            {
                if (length == firstPolinomial.Length)
                {
                    sum[i] += firstPolinomial[i];
                }
                else
                {
                    sum[i] += secondPolinomial[i];
                }
            }

            return sum;
        }

        private static void PrintPolinomial(int[] polinom)
        {
            for (int i = polinom.Length -1; i >= 0; i--)
            {
                Console.Write(polinom[i]);

                for (int j = 0; j < i; j++)
                {
                    Console.Write("x");
                }

                if (i != 0)
                {
                    Console.Write(" + ");
                }
            }

            Console.WriteLine();
        }
    }
}
