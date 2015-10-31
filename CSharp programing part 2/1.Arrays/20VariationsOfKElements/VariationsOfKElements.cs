using System;

class VariationsOfKElements
{
    static void Main()
    {
        Console.Write("Enter number of elements: ");
        int numberOfElements = int.Parse(Console.ReadLine());

        Console.Write("Enter max value of element N: ");
        int maxValue = int.Parse(Console.ReadLine());

        int[] variations = new int[numberOfElements];
        Variations(variations, 0, maxValue);
    }

    private static void Variations(int[] array, int index,
        int maxValue)
    {
        if (index == array.Length)
        {
            PrintArray(array);
        }
        else
        {
            for (int i = 1; i <= maxValue; i++)
            {
                array[index] = i;
                Variations(array, index + 1, maxValue);
            }
        }
    }

    private static void PrintArray(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("{0} ", array[i]);
        }
        Console.WriteLine();
    }
}