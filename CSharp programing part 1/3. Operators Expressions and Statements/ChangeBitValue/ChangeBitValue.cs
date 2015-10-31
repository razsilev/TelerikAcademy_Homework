using System;

class ChangeBitValue
{
    static void Main(string[] args)
    {
        int number = 5;
        byte position = 3;
        byte value = 1;
        int checkNumber = 1 << position;
        int numberWhitInvertedBit = number;

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
        
        String numberBinary = Convert.ToString(number, 2);
        String binaryNumberWhitInvertedBit =
            Convert.ToString(numberWhitInvertedBit, 2);

        Console.WriteLine("n={0}({4}), p={1}, v={2} -> {3}({5})", number,
            position, value, numberWhitInvertedBit, numberBinary, binaryNumberWhitInvertedBit);
    }
}