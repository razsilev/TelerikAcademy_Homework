using System;

class QuadraticEquation
{
    static void Main()
    {
        double a = 0;
        double b = 0;
        double c = 0;

        System.Threading.Thread.CurrentThread.CurrentCulture =
            System.Globalization.CultureInfo.InvariantCulture;

        Console.Write("Enter coefficient a = ");
        a = double.Parse(Console.ReadLine());

        Console.Write("Enter coefficient b = ");
        b = double.Parse(Console.ReadLine());

        Console.Write("Enter coefficient c = ");
        c = double.Parse(Console.ReadLine());

        double d = (b * b) - (4 * a * c);

        if (d < 0)
        {
            Console.WriteLine("\nEquation do not have real roots");
        }
        else if (d == 0)
        {
            double x = -b / (2 * a);
            Console.WriteLine("\nEquation have 1 real root X = " + x);
        }
        else
        {
            d = Math.Sqrt(d);
            double x1 = (-b + d) / (2 * a);
            double x2 = (-b - d) / (2 * a);
            Console.WriteLine("\nEquation have 2 real roots \nX1 = {0:0.000}\nX2 = {1:0.000}", x1, x2);
        }
    }
}