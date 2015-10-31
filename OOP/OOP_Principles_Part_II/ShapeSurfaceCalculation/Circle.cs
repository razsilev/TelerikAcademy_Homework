using System;

namespace ShapeSurfaceCalculation
{
    class Circle : Shape
    {
        public Circle(double width)
        {
            base.width = width;
            base.height = width;
        }

        public override double CalculateSurface()
        {
            double r = base.width / 2;

            return Math.PI * r * r;
        }

        public override string ToString()
        {
            return string.Format("Circle width = {0}, height = {1}", base.width, base.height);
        }
    }
}
