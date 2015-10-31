using System;

class QuickSort
{
    static void Main()
    {
        int[] array = { 7, 3, 1, 5, 4, 18, 12, 8 };

        Sort(array);
        PrintArray(array);
    }

    public static void PrintArray(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(" {0}", array[i]);
        }
        Console.WriteLine();
    }

    public static void Sort(int[] array)
    {
        MyQuickSort(array, 0, array.Length);
    }

    private static void MyQuickSort(int[] array, int start, int end)
    {
        // recursion end
        if ((end - start) <= 1)
        {
            return;
        }

        int pivotIndex = start;

        for (int i = start; i < end; i++)
        {
            if (array[pivotIndex] > array[i])
            {
                Swap(array, pivotIndex, i);
                Swap(array, pivotIndex + 1, i);
                pivotIndex++;
            }
        }

        MyQuickSort(array, start, pivotIndex);
        MyQuickSort(array, pivotIndex + 1, end);
    }

    private static void Swap(int[] array, int firstIndex, int secondIndex)
    {
        int oldValue = array[firstIndex];
        array[firstIndex] = array[secondIndex];
        array[secondIndex] = oldValue;
    }
}