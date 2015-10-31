using System;
using System.Collections.Generic;

class MergeSort
{
    static void Main()
    {
        int[] array = { 7, 3, 1, 5, 4, 18, 12, 8, 0 };

        Sort(array);
        PrintArray(array);
    }

    private static void Sort(int[] array)
    {
        // create two arrays
        int middle = array.Length / 2;
        int[] firstArray = new int[middle];
        int[] secondArray = new int[array.Length - middle];
        int count = middle;

        // fill arrays whit values from array
        for (int i = 0; i <= middle + 1; i++)
        {
            if (i < middle)
            {
                firstArray[i] = array[i];
            }

            if (count < array.Length)
            {
                secondArray[i] = array[count];
            }

            count++;
        }

        // Recursion end
        if (array.Length > 1)
        {
            Sort(firstArray);
            Sort(secondArray);
        }
        
        // merge two created arrays in inputed array
        int countFirst = 0;
        int countSecond = 0;

        for (int i = 0; i < array.Length; i++)
        {
            // take elements from the two arrays,
            // until one of them does not have elements who can get.
            if ((countFirst < firstArray.Length) && (countSecond < secondArray.Length))
            {
                if (firstArray[countFirst] < secondArray[countSecond])
                {
                    array[i] = firstArray[countFirst];
                    countFirst++;
                }
                else
                {
                    array[i] = secondArray[countSecond];
                    countSecond++;
                }
            }  // fill array from firstArray who have elements
            else if (countFirst < firstArray.Length) 
            {
                array[i] = firstArray[countFirst];
                countFirst++;
            }
            else  // fill array from secondArray
            {
                array[i] = secondArray[countSecond];
                countSecond++;
            }
        }
    }

    public static void PrintArray(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(" {0}", array[i]);
        }
        Console.WriteLine();
    }
}