using System;

class CalculatesTrapezoidArea
{
    static void Main()
    {
        decimal area = 0m;
        decimal sideA = 4;
        decimal sideB = 6;
        decimal height = 3;

        area = ((sideA + sideB) / 2) * height;

        Console.WriteLine("Trapezoid area is: " + area);
    }
}