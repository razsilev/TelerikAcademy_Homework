using System;

class ReadNumberAndPrintMatrix
{
    static void Main()
    {
        int n = 0;

        Console.Write("Enter (N < 20) N: ");
        n = int.Parse(Console.ReadLine());

        if ((n < 20) && (n > 0))
        {
            for (int row = 1; row <= n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(" {0,2}", (row + col));
                }

                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("Error Invalid input!");
        }
    }
}