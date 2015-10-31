using System;

class PrintNumbersFromOneToN
{
    static void Main()
    {
        int n = 0;

        Console.Write("Enter N: ");

        n = int.Parse(Console.ReadLine());

        if (n > 0)
        {
            for (int number = 1; number <= n; number++)
            {
                Console.WriteLine(number);
            }
        }
        else
        {
            for (int number = 1; number >= n; number--)
            {
                Console.WriteLine(number);
            }
        }
    }
}