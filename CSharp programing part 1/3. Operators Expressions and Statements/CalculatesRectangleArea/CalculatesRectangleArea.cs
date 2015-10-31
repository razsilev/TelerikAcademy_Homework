using System;

class CalculatesRectangleArea
{
    static void Main()
    {
        System.Threading.Thread.CurrentThread.CurrentCulture =
            System.Globalization.CultureInfo.InvariantCulture;

        decimal width;
        decimal height;

        Console.Write("Enter rectangle width: ");
        width = decimal.Parse(Console.ReadLine());
        Console.Write("Enter rectangle height: ");
        height = decimal.Parse(Console.ReadLine());

        decimal rectangleArea = width * height;

        Console.WriteLine("Rectangle area is: " + rectangleArea);
    }
}