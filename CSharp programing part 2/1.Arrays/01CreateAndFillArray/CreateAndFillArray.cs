using System;

class CreateAndFillArray
{
    static void Main()
    {
        int[] integersArray = new int[20];

        for (int i = 0; i < integersArray.Length; i++)
        {
            integersArray[i] = i * 5;
        }

        // print array values
        for (int i = 0; i < integersArray.Length; i++)
        {
            Console.Write("{0} ", integersArray[i]);
        }

        Console.WriteLine();
    }
}