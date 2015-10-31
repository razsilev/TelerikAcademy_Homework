using System;

class ReadNNumbersAndPrintMinMaxOfThem
{
    static void Main()
    {
        int number = 0;
        int n = 0;
        int minimalNumber = 0;
        int maximalNumber = 0;

        Console.Write("Enter N: ");

        n = int.Parse(Console.ReadLine());

        if (n <= 0)
        {
            Console.WriteLine("Error invalid length of sequence!");
        }
        else
        {
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());

            minimalNumber = number;
            maximalNumber = number;

            for (int i = 1; i < n; i++)
            {
                Console.Write("Enter number: ");
                number = int.Parse(Console.ReadLine());

                minimalNumber = (number < minimalNumber) ? number : minimalNumber;
                maximalNumber = (number > maximalNumber) ? number : maximalNumber;
            }

            Console.WriteLine("minimal = {0}  maximal = {1}", minimalNumber,
                maximalNumber);
        }
    }
}