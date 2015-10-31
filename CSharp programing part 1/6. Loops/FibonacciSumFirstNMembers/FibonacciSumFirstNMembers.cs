using System;

class FibonacciSumFirstNMembers
{
    static void Main()
    {
        decimal fibonacci = 0;
        decimal NextFibonacci = 1;
        decimal suma = 0;
        Console.WriteLine("For sum of first N numbers of Fibonachy.");
        Console.Write("Enter N: ");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine();
        if (n > 0)
        {
            for (int i = 1; i < n; i++)
            {
                Console.Write(" {0:N0},", fibonacci);
                //Console.WriteLine("sum is: " + suma);
                suma += NextFibonacci;
                NextFibonacci += fibonacci;
                fibonacci = NextFibonacci - fibonacci;
            }

            Console.Write(" {0:N0}\n", fibonacci);
            Console.WriteLine("\nSum of first {0} Fibonachy numbers is: {1:N0}\n",
                n, suma);
        }
        else
        {
            Console.WriteLine("Error invalid length of sequence!");
        }
    }
}