using System;

class ExchangeBitFromPToK
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
        int startPositionP = 0;
        int startPositionQ = 10;
        int numberOfBitsForExchange = 4;
        
        uint number = 7;
        uint result = number;
        
        byte[] bitStartP = new byte[numberOfBitsForExchange];
        byte[] bitStartQ = new byte[numberOfBitsForExchange];

        // get bits vavue
        for (int i = 0; i < numberOfBitsForExchange; i++)
        {
            bitStartP[i] = CheckBitPInNumberV(number, i + startPositionP);
            bitStartQ[i] = CheckBitPInNumberV(number, i + startPositionQ);
        }

        // exchange bit value
        for (int i = 0; i < numberOfBitsForExchange; i++)
        {
            result = ChangeBitValue(result, i + startPositionQ, bitStartP[i]);
            result = ChangeBitValue(result, i + startPositionP, bitStartQ[i]);
        }

        // print result
        Console.WriteLine(number);
        Console.WriteLine(Convert.ToString(number, 2));
        Console.WriteLine();
        Console.WriteLine(Convert.ToString(result, 2));
        Console.WriteLine(result);
    }
}