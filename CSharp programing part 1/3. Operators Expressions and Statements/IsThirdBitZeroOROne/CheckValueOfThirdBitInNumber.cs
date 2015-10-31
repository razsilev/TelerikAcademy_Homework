using System;

class CheckValueOfThirdBitInNumber
{
    static void Main()
    {
        const int NUMBER_WHO_ONLI_THIRD_BIT_HAVE_VALUE_ONE = 8;
        int number = 25;
        
        if ((number & NUMBER_WHO_ONLI_THIRD_BIT_HAVE_VALUE_ONE) == 0)
        {
            Console.WriteLine("Third bit is 0");
        }
        else
        {
            Console.WriteLine("Third bit is 1");
        }
    }
}