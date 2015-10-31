using System;
using System.Collections.Generic;

class SubsetSumOfKElements
{
    static void Main()
    {
        Console.Write("Enter number of elements in array: ");
        int numberOfElements = int.Parse(Console.ReadLine());

        Console.Write("Enter sum: ");
        int searchSum = int.Parse(Console.ReadLine());

        Console.Write("Enter number of elements whit search sum: ");
        int subsetLength = int.Parse(Console.ReadLine());

        int[] array = new int[numberOfElements];

        Console.WriteLine("Fill array:");
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("[{0}]: ", (i + 1));
            array[i] = int.Parse(Console.ReadLine());
        }
        
        bool find = false;

        List<int[]> result = CreateSubsets(array);

        foreach (var arr in result)
        {
            if (arr.Length == subsetLength)
            {
                int sum = arr[0];

                for (int i = 1; i < subsetLength; i++)
                {
                    sum += arr[i];
                }

                if (sum == searchSum)
                {
                    find = true;
                    Console.WriteLine("Sum: {0} number of elements: {1}",
                        searchSum, subsetLength);
                    PrintArr(arr);
                }
            }
        }

        if (!find)
        {
            Console.WriteLine("!!! Absence subset whit sum: {0}  and elements: {1} !!!",
                searchSum, subsetLength);
        }
    }

    private static void PrintArr(int[] arr)
    {
        Console.Write("{");
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(arr[i]);

            if (i < arr.Length - 1)
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine("}");
        Console.WriteLine();
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