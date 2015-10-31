using System;

class ExtractBitValue
{
    static void Main()
    {
        int position = 2;
        int number = 5;
        int checkNumber = 1 << position;
        byte value = 1;

        if ((number & checkNumber) == 0)
        {
            value = 0;
        }

        Console.WriteLine("i={0}; b={1} -> value={2}", number, position, value);
    }
}