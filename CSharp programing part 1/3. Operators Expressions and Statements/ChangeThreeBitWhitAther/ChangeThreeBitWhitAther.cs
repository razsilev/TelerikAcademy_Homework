using System;

class ExchangesThreeBitWhitAther
{
    static byte CheckBitPInNumberV(uint number, int position)
    {
        int checkNumber = 1 << position;
        byte value = 1;

        if ((number & checkNumber) == 0)
        {
            value = 0;
        }

        return value;
    }

    static uint ChangeBitValue(uint number, int position, int value)
    {
        uint checkNumber = 1u << position;
        uint numberWhitInvertedBit = number;

        if ((number & checkNumber) == 0)
        {
            if (value == 1)
            {
                numberWhitInvertedBit = number | checkNumber;
            }
        }
        else
        {
            if (value == 0)
            {
                numberWhitInvertedBit = number & (~checkNumber);
            }
        }

        return numberWhitInvertedBit;
    }

    static void Main()
    {
        const int startPositionFistBit = 3;
        const int startPositionSecondBit = 24;

        int numberOfBitForExchange = 3;
        uint number = 234;
        uint result = number;

        byte[] bits_3_4_5 = {
                            CheckBitPInNumberV(number, 3),
                            CheckBitPInNumberV(number, 4),
                            CheckBitPInNumberV(number, 5)
                        };

        byte[] bits_24_25_26 = {
                             CheckBitPInNumberV(number, 24),
                             CheckBitPInNumberV(number, 25),
                             CheckBitPInNumberV(number, 26)
                         };
        for (int i = 0; i < numberOfBitForExchange; i++)
        {
            result = ChangeBitValue(result, i + startPositionFistBit, bits_24_25_26[i]);
            result = ChangeBitValue(result, i + startPositionSecondBit, bits_3_4_5[i]);
        }

        Console.WriteLine(number);
        Console.WriteLine(Convert.ToString(number, 2));
        Console.WriteLine();
        Console.WriteLine(Convert.ToString(result, 2));
        Console.WriteLine(result);
    }
}