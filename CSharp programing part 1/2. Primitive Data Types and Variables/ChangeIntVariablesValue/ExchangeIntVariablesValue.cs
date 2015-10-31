using System;

class ExchangeIntVariablesValue
{
    static void Main()
    {
        byte a = 5;
        byte b = 10;
        byte temp = 0;

        Console.WriteLine("a = {0}", a);
        Console.WriteLine("b = {0}", b);

        temp = a;
        a = b;
        b = temp;

        Console.WriteLine();
        Console.WriteLine("a = {0}", a);
        Console.WriteLine("b = {0}", b);
    }
}

