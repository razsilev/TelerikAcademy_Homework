using System;

class MaximalSequence
{
    static void Main()
    {
        int[] array = { 2, 1, 1, 2, 3, 3, 2, 2, 2, 1 };

        int count = 1;
        int element = array[0];
        int elementValue = 0;
        int elementCount = 0;

        // faind maximal sequence
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] == element)
            {
                count++;
            }
            else
            {
                if (count > elementCount)
                {
                    elementCount = count;
                    elementValue = element;
                }

                element = array[i];
                count = 1;
            }
        }

        // print maximal sequence
        Console.Write("{");
        for (int i = 0; i < elementCount; i++)
        {
            Console.Write(" {0},", elementValue);
        }

        Console.WriteLine("}");
    }
}