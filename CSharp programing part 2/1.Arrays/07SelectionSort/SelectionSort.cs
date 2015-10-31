using System;

class SelectionSort
{
    static void Main()
    {
        int[] array = { 3, 1, 5, 9, 6, 4};

        for (int i = 0; i < array.Length - 1; i++)
        {
            // faind min value elements
            int minValueIndex = i + 1;
            for (int j = minValueIndex + 1; j < array.Length; j++)
            {
                if (array[j] < array[minValueIndex])
                {
                    minValueIndex = j;
                }
            }

            if (array[i] > array[minValueIndex])
            {
                int oldValue = array[i];
                array[i] = array[minValueIndex];
                array[minValueIndex] = oldValue;
            }
        }

        Console.WriteLine("Sorted array:");
        foreach (var element in array)
        {
            Console.Write(" {0},", element);
        }

        Console.WriteLine();
    }
}