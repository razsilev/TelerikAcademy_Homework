﻿namespace Abstraction
{
    using System;

    public class Circle : Figure
    {
        private double radius;

        public Circle(double initialRadius)
        {
            this.Radius = initialRadius;
        }

        public double Radius
        {
            get
            {
                return this.radius;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("radius can not be equal or less then zero.");
                }

                this.radius = value;
            }
        }

        public override double CalcPerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;

            return perimeter;
        }

        public override double CalcSurface()
        {
            double surface = Math.PI * this.Radius * this.Radius;
            
            return surface;
        }
    }
}
