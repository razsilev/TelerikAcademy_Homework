using System;

class CirclePerimeterAndArea
{
    static void Main()
    {
        double radius = 0;
        double perimeter = 0;
        double area = 0;

        System.Threading.Thread.CurrentThread.CurrentCulture =
            System.Globalization.CultureInfo.InvariantCulture;

        Console.Write("Enter radius: ");
        radius = double.Parse(Console.ReadLine());

        perimeter = 2 * Math.PI * radius;
        area = Math.PI * radius * radius;

        Console.WriteLine("\nThe parimeter is: {0}", perimeter);
        Console.WriteLine("The area is:      {0}\n", area);
    }
}