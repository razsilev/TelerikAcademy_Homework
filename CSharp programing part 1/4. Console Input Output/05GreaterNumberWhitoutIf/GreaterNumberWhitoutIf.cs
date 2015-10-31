using System;

class GreaterNumberWhitoutIf
{
    static void Main()
    {
        decimal firstNumber = 0m;
        decimal secondNumber = 0m;
        decimal greater = 0m;

        System.Threading.Thread.CurrentThread.CurrentCulture =
           System.Globalization.CultureInfo.InvariantCulture;

        Console.Write("Enter first number: ");
        firstNumber = decimal.Parse(Console.ReadLine());

        Console.Write("Enter second number: ");
        secondNumber = decimal.Parse(Console.ReadLine());

        greater = Math.Max(firstNumber, secondNumber);

        Console.WriteLine("\nGreater of them is: {0}\n", greater);
    }
}