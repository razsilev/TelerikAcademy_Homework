using System;

class ZeroDigitsInFacturial
{
    static void Main()
    {
        Console.WriteLine("Enter N to calculate how many trailing zeros");
        Console.WriteLine("present at the end of the number N!.\n");
        Console.Write("N: ");
        int n = int.Parse(Console.ReadLine());
        int numberOfZeros = 0;

        if (n / 5 > 0)
        {
            numberOfZeros = n / 5;
        }

        if (n / 25 > 0)
        {
            numberOfZeros = numberOfZeros + (n / 25);
        }

        Console.WriteLine("number 0 in {0}! is: {1}", n, numberOfZeros);
    }

    //static void Main()
    //{
    //    Console.Write("N = ");
    //    int n = int.Parse(Console.ReadLine());
    //    int result = 0;

    //    for (int i = 5; i <= n; i *= 5)
    //    {
    //        result += (n / i);
    //    }
    //    Console.WriteLine("The number of trailing zeros:{0}", result);
    //}
}