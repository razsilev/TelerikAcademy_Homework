namespace CohesionAndCoupling
{
    public class Point3D : Point2D
    {
        /// <summary>
        /// Initialise X = 0, Y = 0, Z = 0;
        /// </summary>
        public Point3D()
            : this(0, 0, 0)
        {

        }

        public Point3D(double initialX, double initialY, double initialZ)
            : base(initialX, initialY)
        {
            this.Z = initialZ;
        }

        public double Z { get; set; }
    }
}
