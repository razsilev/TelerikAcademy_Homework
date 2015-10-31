using System;

class GreatestOfGiven5Variables
{
    static void Main()
    {
        int[] numbers = { 3, 5, 0, 6, 4 };
        int max = numbers[0];

        for (int i = 1; i < numbers.Length; i++)
        {
            if (max < numbers[i])
            {
                max = numbers[i];
            }
        }

        Console.WriteLine("max is: " + max);
    }
}