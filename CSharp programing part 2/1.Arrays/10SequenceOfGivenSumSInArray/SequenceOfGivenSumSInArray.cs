using System;

class SequenceOfGivenSumSInArray
{
    static void Main()
    {
        Console.Write("Enter sum S: ");
        int sumS = int.Parse(Console.ReadLine()); // 11;

        Console.Write("Enter Array length: ");
        int length = int.Parse(Console.ReadLine());

        int[] array = new int[length];//{ 4, 3, 1, 4, 2, 5, 8 };

        // fill array
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("Enter element [{0}]: ", i + 1);
            array[i] = int.Parse(Console.ReadLine());
        }

        bool haveSum = false;
        int startIndex = 0;
        int count = 0;

        // search sequence of given sum S
        for (int i = 0; i < array.Length; i++)
        {
            int currentSum = 0;
            startIndex = i;
            count = 0;

            for (int j = i; j < array.Length; j++)
            {
                currentSum += array[j];
                count++;

                // when find given sum stop search
                if (currentSum == sumS)
                {
                    haveSum = true;
                    break;
                }

                if (currentSum > sumS)
                {
                    break;
                }
            }

            if (haveSum)
            {
                break;
            }
        }

        // print result
        if (haveSum)
        {
            Console.Write("S={0} -> ", sumS);
            Console.Write("{");

            for (int i = startIndex; i < (startIndex + count); i++)
            {
                char separator = ',';

                if ((startIndex + count - 1) == i)
                {
                    separator = ' ';
                }

                Console.Write(" {0}{1}", array[i], separator);
            }
            Console.WriteLine("}");
        }
        else
        {
            Console.WriteLine("given array does not have sequence of given sum S");
        }
    }
}