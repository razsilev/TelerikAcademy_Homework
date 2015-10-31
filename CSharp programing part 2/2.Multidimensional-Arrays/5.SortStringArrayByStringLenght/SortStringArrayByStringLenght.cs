using System;

class SortStringArrayByStringLenght
{
    static void Main()
    {
        Console.Write("Enter array length: ");
        int length = int.Parse(Console.ReadLine());

        string[] arrayOfStrings = new string[length];

        FillArray(arrayOfStrings);
        SortArray(arrayOfStrings);
        PrintArray(arrayOfStrings);
    }

    private static void SortArray(string[] arrayOfStrings)
    {
        MyQuickSort(arrayOfStrings, 0, arrayOfStrings.Length);
    }

    private static void MyQuickSort(string[] arrayOfStrings, int startIndex, int endIndex)
    {
        if ((endIndex - startIndex) <= 1)
        {
            return;
        }

        int pivotIndex = startIndex;

        for (int i = startIndex; i < endIndex; i++)
        {
            if (arrayOfStrings[pivotIndex].Length > arrayOfStrings[i].Length)
            {
                Swap(arrayOfStrings, pivotIndex, i);
                Swap(arrayOfStrings, i, pivotIndex + 1);
            }
        }

        MyQuickSort(arrayOfStrings, startIndex, pivotIndex);
        MyQuickSort(arrayOfStrings, pivotIndex + 1, endIndex);
    }

    private static void Swap(string[] arrayOfStrings, int firstElementIndex, int secondElementIndex)
    {
        string oldValue = arrayOfStrings[firstElementIndex];
        arrayOfStrings[firstElementIndex] = arrayOfStrings[secondElementIndex];
        arrayOfStrings[secondElementIndex] = oldValue;
    }

    private static void FillArray(string[] array)
    {
        Console.WriteLine("\nEnter array elements: ");

        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("element [{0}]: ", (i + 1));

            array[i] = Console.ReadLine();
        }
    }

    private static void PrintArray(string[] array)
    {
        Console.WriteLine("\nPrint array content: ");

        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine(array[i]);
        }

        Console.WriteLine();
    }
}