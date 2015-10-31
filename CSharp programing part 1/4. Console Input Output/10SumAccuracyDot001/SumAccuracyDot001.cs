using System;

class SumAccuracyDot001
{
    static void Main()
    {
        int divider = 2;
        decimal sum = 1.0m;
        decimal nexNumber = 0.5m;
        int sign = 1;

        while (nexNumber > 0.001M)
        {
            sum = sum + (nexNumber * sign);
            sign *= (-1);
            divider++;
            nexNumber = 1.0m / divider;
        }
          
        Console.WriteLine("sum is: {0:N6}", sum);
    }
}