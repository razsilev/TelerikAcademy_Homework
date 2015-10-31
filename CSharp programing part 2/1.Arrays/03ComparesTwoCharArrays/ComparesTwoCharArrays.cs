using System;

class ComparesTwoCharArrays
{
    static void Main()
    {
        char[] first = { 'c', 'h', 'a', 'r' };
        char[] second = { 'q', 'b', 'a', 'n',};

        for (int i = 0; i < first.Length; i++)
        {
            if (first[i] == second[i])
            {
                Console.WriteLine("[{0}]  {1} = {2}", i, first[i], second[i]);
            }
            else if (first[i] > second[i])
            {
                Console.WriteLine("[{0}]  {1} > {2}", i, first[i], second[i]);
            }
            else if (first[i] < second[i])
            {
                Console.WriteLine("[{0}]  {1} < {2}", i, first[i], second[i]);
            }
        }
    }
}