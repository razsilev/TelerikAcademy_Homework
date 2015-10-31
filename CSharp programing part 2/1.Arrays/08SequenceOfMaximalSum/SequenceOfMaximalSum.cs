using System;

class SequenceOfMaximalSum
{
    static void Main()
    {
        int[] array = { 2, 3, -6, -1, 2, -1, 6, 4, -8, 8 };

        int startMaxSumIndex = 0;
        int count = 1;
        int maxSum = 0;

        int currentStartIndex = 0;
        int currentCount = 1;
        int currentMaxSum = 0;

        for (int i = 0; i < array.Length; i++)
        {
            if ((currentMaxSum + array[i]) > array[i])
            {
                currentMaxSum += array[i];
                currentCount++;
            }
            else
            {
                currentMaxSum = array[i];
                currentCount = 1;
                currentStartIndex = i;
            }

            if (maxSum < currentMaxSum)
            {
                maxSum = currentMaxSum;
                count = currentCount;
                startMaxSumIndex = currentStartIndex;
            }
        }

        Console.Write("{");
        for (int i = startMaxSumIndex; i < (startMaxSumIndex + count); i++)
        {
            char separatpr = ',';

            if (i == (startMaxSumIndex + count - 1))
            {
                separatpr = ' ';
            }

            Console.Write(" {0}{1}", array[i], separatpr);
        }
        Console.WriteLine("}");
    }
}