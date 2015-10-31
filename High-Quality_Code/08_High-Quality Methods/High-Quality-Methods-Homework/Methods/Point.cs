namespace Methods
{
    using System;

    public class Point
    {
        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public double X { get; set; }
        public double Y { get; set; }

        public double DistanceTo(Point point)
        {
            double xDistsnce = this.X - point.X;
            double yDistance = this.Y - point.Y;
            double distance = Math.Sqrt(xDistsnce * xDistsnce + yDistance * yDistance);

            return distance;
        }

        public bool IsHorizontalTo(Point point)
        {
            bool isHorizontal = this.X == point.X;

            return isHorizontal;
        }

        public bool IsVerticalTo(Point point)
        {
            bool isVertical = this.Y == point.Y;

            return isVertical;
        }
    }
}
