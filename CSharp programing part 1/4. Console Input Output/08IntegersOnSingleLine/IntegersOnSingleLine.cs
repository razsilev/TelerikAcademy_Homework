using System;

class IntegersOnSingleLine
{
    static void Main()
    {
        uint numbers = 0;

        Console.Write("Enter N for numbers: ");
        numbers = uint.Parse(Console.ReadLine());

        for (int number = 1; number <= numbers; number++)
        {
            Console.WriteLine(number);
        }
    }
}