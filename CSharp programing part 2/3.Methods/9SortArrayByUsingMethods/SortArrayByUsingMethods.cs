using System;

class SortArrayByUsingMethods
{
    static void Main()
    {
        int[] array = { 9, 5, 16, 3, 7, 3, 4, 5, 3, 5 };

        ArraySort(array);

        PrintArrayContent(array);
    }

    public static void ArraySort(int[] array)
    {
        for (int i = array.Length - 1; i > 0; i--)
        {

            int maxElementIndex = MaxElementIndex(array, i);
            Swap(array, i, maxElementIndex);
        }
    }

    private static int MaxElementIndex(int[] array, int end)
    {
        int max = array[0];
        int index = 0;

        for (int i = 1; i <= end; i++)
        {
            if (max < array[i])
            {
                max = array[i];
                index = i;
            }
        }

        return index;
    }

    private static void Swap(int[] array, int firstIndex, int secondIndex)
    {
        int oldValue = array[firstIndex];
        array[firstIndex] = array[secondIndex];
        array[secondIndex] = oldValue;
    }

    public static void PrintArrayContent(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("{0} ", array[i]);
        }

        Console.WriteLine();
    }
}