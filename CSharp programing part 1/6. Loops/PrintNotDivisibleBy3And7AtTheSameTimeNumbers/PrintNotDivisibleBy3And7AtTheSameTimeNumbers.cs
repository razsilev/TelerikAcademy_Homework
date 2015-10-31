using System;

class PrintNotDivisibleBy3And7AtTheSameTimeNumbers
{
    static void Main()
    {
        const int DIVIDE3 = 3;
        const int DIVIDE7 = 7;
        int n = 0;

        Console.Write("Enter N: ");

        n = int.Parse(Console.ReadLine());

        if (n > 0)
        {
            for (int number = 1; number <= n; number++)
            {
                if (((number % DIVIDE3) == 0) && ((number % DIVIDE7) == 0))
                {

                }
                else
                {
                    Console.WriteLine(number);
                }
            }
        }
        else
        {
            for (int number = 1; number >= n; number--)
            {
                if (((number % DIVIDE3) == 0) && ((number % DIVIDE7) == 0))
                {

                }
                else
                {
                    Console.WriteLine(number);
                }
            }
        }
    }
}