using System;

class CompareFlotingPointNumbersWhitPrecision
{
    static void Main()
    {
        decimal a = 5.00000021m;
        decimal b = 5.0000003m;

        decimal difference = Math.Abs(a - b);

        bool equal = (difference < 0.000001m) ? true : false;
        
        Console.WriteLine(equal);
    }
}