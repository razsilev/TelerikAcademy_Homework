using System;

class ArrayBinSearch
{
    static void Main()
    {
        Console.Write("Enter array length: ");
        int length = int.Parse(Console.ReadLine());

        Console.Write("Enter search number: ");
        int searchNumber = int.Parse(Console.ReadLine());

        int[] array = new int[length];

        FillArray(array);
        Array.Sort(array);
        FindSearshNumber(array, searchNumber);
    }

    private static void FindSearshNumber(int[] array, int searchNumber)
    {
        int findNumber = BinSearch(array, searchNumber);

        Console.WriteLine("\nLargest number in the array <= {0} is: {1}",
            searchNumber, findNumber);

        PrintArray(array);

        // option search another number in array
        Console.WriteLine("\nIf you want to search anather number");
        Console.Write("enter number, To exit enter 'exit': ");

        string input = Console.ReadLine();

        bool isNumber = int.TryParse(input, out searchNumber);

        if (isNumber)
        {
            Console.Clear();
            FindSearshNumber(array, searchNumber);
        }
    }

    private static int BinSearch(int[] array, int searchNumber)
    {
        int startIndex = 0;
        int endIndex = array.Length;
        int searchedIndex = 0;
        int numberOfIteration = 0;

        for (int i = 0; i < array.Length; i++)
        {
            numberOfIteration = i;
            int middle = (endIndex - startIndex) / 2;
            middle += startIndex;

            if ((endIndex - startIndex) == 1)
            {
                searchedIndex = startIndex;
                break;
            }
            else if (array[middle] == searchNumber)
            {
                searchedIndex = middle;
                break;
            }

            if (array[middle] > searchNumber)
            {
                endIndex = middle;
            }
            else if (array[middle] < searchNumber)
            {
                startIndex = middle;
            }

        }

        //Console.WriteLine("\nnumber of Iteration: {0}", numberOfIteration + 1);

        return array[searchedIndex];
    }

    private static void FillArray(int[] array)
    {
        Console.WriteLine("\nEnter array elements: ");

        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("element [{0}]: ", i);

            array[i] = int.Parse(Console.ReadLine());
        }
    }

    private static void PrintArray(int[] array)
    {
        Console.WriteLine("\nPrint array content: ");

        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("{0}, ", array[i]);
        }

        Console.WriteLine();
    }
}
