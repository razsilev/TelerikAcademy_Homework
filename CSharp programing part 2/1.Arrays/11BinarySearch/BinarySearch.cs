using System;

class BinarySearch
{
    static void Main()
    {
        int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
                          11, 12, 13, 14, 15, 16, 17, 18, 19 };

        Console.Write("Enter number [1 - 19] to see his index: ");
        int searchNumber = int.Parse(Console.ReadLine());
        
        int startIndex = 0;
        int endIndex = array.Length;
        int searchedIndex = -1;
        int numberOfIteration = 0;

        for (int i = 0; i < array.Length; i++)
        {
            numberOfIteration = i;
            int middle = (endIndex - startIndex) / 2;
            middle += startIndex;

            if ((endIndex - startIndex) == 1)
            {
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

        if (searchedIndex < 0)
        {
            Console.WriteLine("There is no element whit this value!");
        }
        else
        {
            Console.WriteLine("element whit value: {0} have index: {1}",
                searchNumber, searchedIndex);
        }

        Console.WriteLine("number of Iteration: {0}", numberOfIteration + 1);
    }
}