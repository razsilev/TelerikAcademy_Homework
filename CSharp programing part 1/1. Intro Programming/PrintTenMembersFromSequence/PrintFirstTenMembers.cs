using System;

class PrintFirstTenMembers
{
    static void Main()
    {
        int positive = 2;
        int negative = -3;

        for (int i = 0; i < 5; i++)
        {
            Console.Write("{0},{1},", positive, negative);

            positive += 2;
            negative -= 2;
        }

        Console.WriteLine();
    }
}