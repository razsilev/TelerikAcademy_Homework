using System;

namespace ShapeSurfaceCalculation
{
    public class Triangle : Shape
    {
        public Triangle(double width, double height)
        {
            base.width = width;
            base.height = height;
        }

        public override double CalculateSurface()
        {
            return (base.width * base.height) / 2;
        }

        public override string ToString()
        {
            return string.Format("Triangle width = {0}, height = {1}", base.width, base.height);
        }
    }
}
