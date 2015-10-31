using System;

class ReadTwoArrays
{
    static void Main()
    {
        Console.Write("Enter number of integer elements for arrays: ");
        int length = int.Parse(Console.ReadLine());

        int[] firstArray = new int[length];
        int[] secondArray = new int[length];

        Console.WriteLine();
        Console.WriteLine("Enter first array elements.");
        for (int i = 0; i < length; i++)
        {
            Console.Write("Enter [{0}] = ", i);
            firstArray[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine();
        Console.WriteLine("Enter second array elements.");
        for (int i = 0; i < length; i++)
        {
            Console.Write("Enter [{0}] = ", i);
            secondArray[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine();
        Console.WriteLine("Compares elements:");

        // compare elements
        for (int i = 0; i < length; i++)
        {
            if (firstArray[i] == secondArray[i])
            {
                Console.WriteLine("[{0}]  {1} = {2}", i, firstArray[i], secondArray[i]);
            }
            else if (firstArray[i] > secondArray[i])
            {
                Console.WriteLine("[{0}]  {1} > {2}", i, firstArray[i], secondArray[i]);
            }
            else if (firstArray[i] < secondArray[i])
            {
                Console.WriteLine("[{0}]  {1} < {2}", i, firstArray[i], secondArray[i]);
            }
        }
    }
}