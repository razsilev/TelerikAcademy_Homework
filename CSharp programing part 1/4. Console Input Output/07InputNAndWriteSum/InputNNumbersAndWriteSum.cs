using System;

class InputNNumbersAndWriteSum
{
    static void Main()
    {
        System.Threading.Thread.CurrentThread.CurrentCulture =
            System.Globalization.CultureInfo.InvariantCulture;

        uint numbers = 0;
        decimal sum = 0;

        Console.Write("Enter N for numbers: ");
        numbers = uint.Parse(Console.ReadLine());

        for (int i = 0; i < numbers; i++)
        {
            Console.Write("Enter number: ");
            sum += decimal.Parse(Console.ReadLine());
        }

        Console.WriteLine("\nsum of numbers is: {0}", sum);
    }
}