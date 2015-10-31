using System;

class CheckBitPInNumberV
{
    static void Main()
    {
        int position = 1;
        int number = 5;
        int checkNumber = 1 << position;
        bool haveBitValue1 = true;

        if ((number & checkNumber) == 0)
        {
            haveBitValue1 = false;
        }

        Console.WriteLine("v={0}; p={1} -> {2}", number, position, haveBitValue1);
    }
}