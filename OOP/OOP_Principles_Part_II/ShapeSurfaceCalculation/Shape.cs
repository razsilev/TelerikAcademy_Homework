﻿using System;

namespace ShapeSurfaceCalculation
{
    public abstract class Shape
    {
        protected double width;
        protected double height;

        public abstract double CalculateSurface();
    }
}
