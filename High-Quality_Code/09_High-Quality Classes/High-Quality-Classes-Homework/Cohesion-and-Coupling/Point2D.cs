namespace CohesionAndCoupling
{
    public class Point2D
    {
        /// <summary>
        /// Initialise X = 0, Y = 0;
        /// </summary>
        public Point2D()
            : this(0, 0)
        {

        }

        public Point2D(double initialX, double initialY)
        {
            this.X = initialX;
            this.Y = initialY;
        }

        public double X { get; set; }
        public double Y { get; set; }
    }
}
