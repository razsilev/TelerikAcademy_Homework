using System;
using System.Collections.Generic;

class FindSubsetSum
{
    static void Main()
    {
        Console.Write("Enter search subset sum S: ");
        int searchSum = int.Parse(Console.ReadLine()); // 11;

        Console.Write("Enter Array length: ");
        int length = int.Parse(Console.ReadLine());

        int[] array = new int[length];

        // fill array
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("Enter element [{0}]: ", i + 1);
            array[i] = int.Parse(Console.ReadLine());
        }
        
        List<int[]> results = CreateSubsets(array);
        bool haveSearchSum = false;

        foreach (var result in results)
        {
            int curentSum = result[0];

            for (int i = 1; i < result.Length; i++)
            {
                curentSum += result[i];
            }

            if (curentSum == searchSum)
            {
                PrintArray(result, searchSum);
                haveSearchSum = true;
                break;
            }
        }

        if (haveSearchSum == false)
        {
            Console.WriteLine("Subset whit sum: {0} Not exists!!!", searchSum);
        }

    }

    private static void PrintArray(int[] result, int searchSum)
    {
        Console.Write(" yes (");

        for (int i = 0; i < result.Length; i++)
        {
            Console.Write(result[i]);

            if (i < (result.Length - 1))
            {
                Console.Write("+");
            }
        }

        Console.WriteLine(")");
        
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
}