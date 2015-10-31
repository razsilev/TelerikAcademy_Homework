using System;

namespace ShapeSurfaceCalculation
{
    public class Rectangle : Shape
    {
        public Rectangle(double width, double height)
        {
            base.width = width;
            base.height = height;
        }

        public override double CalculateSurface()
        {
            return base.width * base.height;
        }

        public override string ToString()
        {
            return string.Format("Rectangle width = {0}, height = {1}", base.width, base.height);
        }
    }
}
