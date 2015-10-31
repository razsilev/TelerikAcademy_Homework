using System;

namespace Abstraction
{
    public class Rectangle : Figure
    {
        private double width;
        private double height;

        public Rectangle(double initialWidth, double initialHeight)
        {
            this.Width = initialWidth;
            this.Height = initialHeight;
        }

        public double Width
        {
            get { return width; }
            set 
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Width can not be equal or less then zero.");
                }

                width = value;
            }
        }

        public double Height
        {
            get { return height; }
            set 
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Height can not be equal or less then zero.");
                }

                height = value;
            }
        }

        // checked mode for type double does not work
        public override double CalcPerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);
            
            return perimeter;
        }

        public override double CalcSurface()
        {
            double surface = this.Width * this.Height;
            
            return surface;
        }
    }
}
