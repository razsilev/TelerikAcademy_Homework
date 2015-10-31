using System;
using System.Collections.Generic;

class ChooseElementsToReceiveSortedArray
{
    static void Main()
    {
        Console.Write("Enter Array length: ");
        int length = int.Parse(Console.ReadLine());

        int[] array = new int[length];

        // fill array
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("Enter element [{0}]: ", i + 1);
            array[i] = int.Parse(Console.ReadLine());
        }
        //int[] array = { 6, 1, 4, 3, 0, 3, 6, 4, 5 };

        List<int[]> subsets = CreateSubsets(array);
        int maxLength = 0;
        int numberOfSubset = -1;

        for (int i = 0; i < subsets.Count; i++)
        {
            bool isSorted = true;
            int element = subsets[i][0];

            for (int j = 1; j < subsets[i].Length; j++)
            {
                if (element <= subsets[i][j])
                {
                    element = subsets[i][j];
                }
                else
                {
                    isSorted = false;
                    break;
                }
            }

            if (isSorted && (maxLength < subsets[i].Length))
            {
                maxLength = subsets[i].Length;
                numberOfSubset = i;
            }
        }

        PrintArray(subsets[numberOfSubset]);
    }

    private static List<T[]> CreateSubsets<T>(T[] originalArray)
    {
        List<T[]> subsets = new List<T[]>();
        for (int i = 0; i < originalArray.Length; i++)
        {
            int subsetCount = subsets.Count;
            subsets.Add(new T[] { originalArray[i] });
            for (int j = 0; j < subsetCount; j++)
            {
                T[] newSubset = new T[subsets[j].Length + 1];
                subsets[j].CopyTo(newSubset, 0);
                newSubset[newSubset.Length - 1] = originalArray[i];
                subsets.Add(newSubset);
            }
        }
        return subsets;
    }

    static void PrintArray(int[] result)
    {
        Console.Write("{");

        for (int i = 0; i < result.Length; i++)
        {
            Console.Write(result[i]);

            if (i < (result.Length - 1))
            {
                Console.Write(", ");
            }
        }

        Console.WriteLine("}");
    }
}