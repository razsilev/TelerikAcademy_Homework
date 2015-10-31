using System;

class Read3IntegerPrintSum
{
    static void Main()
    {
        int first = 0;
        int second = 0;
        int third = 0;

        Console.Write("Enter first number: ");
        first = int.Parse(Console.ReadLine());

        Console.Write("Enter second number: ");
        second = int.Parse(Console.ReadLine());

        Console.Write("Enter third number: ");
        third = int.Parse(Console.ReadLine());

        Console.WriteLine("Their sum is: " + (first + second + third));
    }
}