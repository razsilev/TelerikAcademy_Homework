using System;

class PermutationsOfNElements
{
    static void Main()
    {
        Console.Write("Enter number of elements: ");
        int length = int.Parse(Console.ReadLine());
        Console.WriteLine();

        int[] arrayOfNumbers = new int[length];

        for (int i = 0; i < arrayOfNumbers.Length; i++)
        {
            arrayOfNumbers[i] = i + 1;
        }

        PermuteElements(arrayOfNumbers);

        Console.WriteLine();
    }

    public static void PermuteElements(int[] array)
    {
        Permute(array, 0, array.Length - 1);
    }

    private static void Swap(int[] array, int first, int second)
    {
        int oldValue = array[first];
        array[first] = array[second];
        array[second] = oldValue;
    }

    private static void Permute(int[] array, int current, int length)
    {
        if (current == length)
        {
            for (int i = 0; i <= length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }
        else
        {
            for (int i = current; i <= length; i++)
            {
                Swap(array, i, current);
                Permute(array, current + 1, length);
                Swap(array, i,current);
            }
        }

    }
}
