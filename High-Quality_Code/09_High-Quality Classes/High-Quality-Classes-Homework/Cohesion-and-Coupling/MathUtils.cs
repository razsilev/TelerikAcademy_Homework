namespace CohesionAndCoupling
{
    using System;

    public static class MathUtils
    {
        public static double CalcDistance2D(Point2D first, Point2D second)
        {
            double xDistance = first.X - second.X;
            double yDistance = first.Y = second.Y;
            double distance = Math.Sqrt(xDistance * xDistance + yDistance * yDistance);

            return distance;
        }

        public static double CalcDistance3D(Point3D first, Point3D second)
        {
            double xDistance = first.X - second.X;
            double yDistance = first.Y = second.Y;
            double zDistance = first.Z = second.Z;
            double distance = Math.Sqrt(xDistance * xDistance + yDistance * yDistance + zDistance * zDistance);
            
            return distance;
        }

        public static double CalcParallelepipedVolume(double width, double height, double depth)
        {
            double volume = width * height * depth;

            return volume;
        }

        public static double ParallelepipedCalcDiagonalXYZ(Point3D start, Point3D end)
        {
            double distance = CalcDistance3D(start, end);
            return distance;
        }

        public static double ParallelepipedCalcDiagonalXY(Point3D start, Point3D end)
        {
            Point2D start2D = new Point2D(start.X, start.Y);
            Point2D end2D = new Point2D(end.X, end.Y);

            double distance = CalcDistance2D(start2D, end2D);

            return distance;
        }

        public static double ParallelepipedCalcDiagonalXZ(Point3D start, Point3D end)
        {
            Point2D start2D = new Point2D(start.X, start.Z);
            Point2D end2D = new Point2D(end.X, end.Z);

            double distance = CalcDistance2D(start2D, end2D);

            return distance;
        }

        public static double ParallelepipedCalcDiagonalYZ(Point3D start, Point3D end)
        {
            Point2D start2D = new Point2D(start.Y, start.Z);
            Point2D end2D = new Point2D(end.Y, end.Z);

            double distance = CalcDistance2D(start2D, end2D);

            return distance;
        }
    }
}
