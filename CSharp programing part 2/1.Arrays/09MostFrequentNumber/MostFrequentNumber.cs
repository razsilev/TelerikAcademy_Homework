using System;
using System.Collections.Generic;

class MostFrequentNumber
{
    static void Main()
    {
        int[] array = { 4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3 };
        Dictionary<int, int> frequent = new Dictionary<int, int>();
        int maxFrequentCount = 0;
        int frequentNumber = 0;

        for (int i = 0; i < array.Length; i++)
        {
            if (frequent.ContainsKey(array[i]))
            {
                frequent[array[i]]++;
            }
            else
            {
                frequent.Add(array[i], 1);
            }
        }

        foreach (var item in frequent)
        {
            if (item.Value > maxFrequentCount)
            {
                maxFrequentCount = item.Value;
                frequentNumber = item.Key;
            }
        }

        Console.WriteLine("Most frequent number is: {0} ({1} times)", frequentNumber, maxFrequentCount);
    }
}