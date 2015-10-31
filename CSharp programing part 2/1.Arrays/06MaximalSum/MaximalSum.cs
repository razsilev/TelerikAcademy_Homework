using System;

class MaximalSum
{
    static void Main()
    {
        Console.Write("Enter array length: ");
        int arrayLength = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter number of elements");
        Console.Write("who mast have max sum: ");
        int numberOfElementsWhitMaxSum = int.Parse(Console.ReadLine());

        int[] array = new int[arrayLength];

        // fill array
        for (int i = 0; i < arrayLength; i++)
        {
            Console.Write("[{0}]: ", i);
            array[i] = int.Parse(Console.ReadLine());
        }        
        
        // sort array
        Array.Sort(array);

        Console.WriteLine();

        // print elements who have max sum, they are in the end of the array.
        Console.WriteLine("Elements whit max sum are:");

        for (int i = (array.Length - numberOfElementsWhitMaxSum); i < array.Length; i++)
        {
            Console.Write(" {0},", array[i]);
        }

        Console.WriteLine();
    }
}