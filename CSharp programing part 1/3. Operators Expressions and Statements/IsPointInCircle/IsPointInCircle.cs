using System;

class IsPointInCircle
{
    static void Main()
    {
        int x = 3;
        int y = 5;
        int radius = 5;

        if ((x * x + y * y) <= (radius * radius))
        {
            Console.WriteLine("Point is in the circle K(0, 5)");
        }
        else
        {
            Console.WriteLine("Point is out the circle K(0, 5)");
        }
    }
}