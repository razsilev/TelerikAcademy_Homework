using System;

class UseGetMax
{
    static void Main()
    {
        int[] array = new int[3];

        Console.WriteLine("Input three integer numbers: ");
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("Enter [{0}]: ", i + 1);

            array[i] = int.Parse(Console.ReadLine());
        }

        int max = GetMax(array[0], array[1]);

        max = GetMax(max, array[2]);

        Console.WriteLine("\nMax value = {0}\n", max);
    }

    private static int GetMax(int first, int second)
    {
        if (first > second)
        {
            return first;
        }

        return second;
    }
}
