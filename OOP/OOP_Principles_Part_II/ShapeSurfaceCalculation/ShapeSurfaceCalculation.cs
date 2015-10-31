using System;
using System.Collections.Generic;
using System.Linq;

namespace ShapeSurfaceCalculation
{
    class ShapeSurfaceCalculation
    {
        static void Main()
        {
            // Test CalculateSurface() method.
            Shape[] shapes = GetShapes();

            Console.WriteLine("Shapes Areas:");

            for (int i = 0; i < shapes.Length; i++)
            {
                Console.WriteLine("{0}, surface = {1:N2}\n", shapes[i], shapes[i].CalculateSurface());
            }
        }

        private static Shape[] GetShapes()
        {
            Shape[] shapes = new Shape[5];

            shapes[0] = new Rectangle(3, 4);
            shapes[1] = new Triangle(5, 4);
            shapes[2] = new Circle(6);
            shapes[3] = new Triangle(10, 10);
            shapes[4] = new Rectangle(4, 8);

            return shapes;
        }
    }
}
