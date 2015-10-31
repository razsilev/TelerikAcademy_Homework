using System;
using System.Collections.Generic;

class CheckSumOfSomeSubsetIs0
{
    static void Main()
    {
        int[] numbersArray = FillArray();
        List<int[]> subsets = CreateSubsets(numbersArray);
        int sum = 0;
        bool haveSubsetSumZero = false;
        System.Text.StringBuilder subsetAsString = new System.Text.StringBuilder();

        PrintGivenNumbers(numbersArray);

        foreach (var subSet in subsets)
        {
            sum = 0;
            subsetAsString.Clear();

            foreach (var number in subSet)
            {
                sum += number;
                subsetAsString.Append(number + ", ");
            }

            if (sum == 0)
            {
                haveSubsetSumZero = true;
                // remove last ", "
                subsetAsString.Remove(subsetAsString.Length - 2, 2);
                Console.WriteLine("sum of this subset ({0}) is 0", subsetAsString);
            }
        }

        if (haveSubsetSumZero == false)
        {
            Console.WriteLine("There is no zero subset sum value.");
        }
    }

    private static void PrintGivenNumbers(int[] numbersArray)
    {
        System.Text.StringBuilder numbersAsString = new System.Text.StringBuilder();

        for (int i = 0; i < numbersArray.Length; i++)
        {
            numbersAsString.Append(numbersArray[i] + ", ");
        }

        // remove last ", "
        numbersAsString.Remove(numbersAsString.Length - 2, 2);
        Console.WriteLine("\n integer numbers ({0})\n", numbersAsString);
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

    private static int[] FillArray()
    {
        bool validNumber = false;
        int[] numbersArray = new int[5];
        string inputstring = "";

        for (int i = 0; i < numbersArray.Length; i++)
        {
            validNumber = false;

            while (validNumber == false)
            {
                Console.Write("enter a number [{0}]: ", (i + 1));
                inputstring = Console.ReadLine();
                validNumber = int.TryParse(inputstring, out numbersArray[i]);

                if (!validNumber)
                {
                    Console.WriteLine("! Error <{0}> is NOT a number !", inputstring);
                }
            }
        }
        return numbersArray;
    }
}