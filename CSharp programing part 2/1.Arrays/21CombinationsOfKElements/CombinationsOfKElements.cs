using System;

class CombinationsOfKElements
{
    static void Main()
    {
        Console.Write("Enter number of elements: ");
        int numberOfElements = int.Parse(Console.ReadLine());

        Console.Write("Enter max value of element N: ");
        int maxValue = int.Parse(Console.ReadLine());

        int[] arr = new int[numberOfElements];

        Console.WriteLine("Combinations are:");

        Combination(arr, maxValue, 0, 0);
    }

    private static void Combination(int[] arr, int maxValue,
        int numberOfElements, int next)
    {
        if (numberOfElements == arr.Length)
        {
            PrintArray(arr);
            return;
        }

        for (int j = next; j < maxValue; j++)
        {
            arr[numberOfElements] = j + 1;

            Combination(arr, maxValue, numberOfElements + 1, j + 1);
        }
    }

    static void PrintArray(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write("{0} ", arr[i]);
        }

        Console.WriteLine();
    }
}
