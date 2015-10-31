using System;

class MaximalIncreasingSequence
{
    static void Main()
    {
        int[] array = { 3, 2, 3, 4, 5, 2, 2, 4 };

        int count = 1;
        int element = array[0] + 1;
        int sequenceCount = 0;
        int minElement = 0;

        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] == element)
            {
                element++;
                count++;
            }
            else
            {
                if (count > sequenceCount)
                {
                    sequenceCount = count;
                    minElement = array[i - count];
                }

                element = array[i] + 1;
                count = 1;
            }
        }

        // print maximal increasing sequence
        Console.Write("{");
        for (int i = 0; i < sequenceCount; i++)
        {
            Console.Write(" {0},", minElement + i);
        }

        Console.WriteLine("}");
    }
}