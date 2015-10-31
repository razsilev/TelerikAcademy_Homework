using System;

class IntegerOddOrEven
{
    static void Main(string[] args)
    {
        int number = -5;
        
        if ((number & 1) == 0)
        {
            Console.WriteLine(number + " is even number");
        }
        else
        {
            Console.WriteLine(number + " is odd number");
        }
    }
}