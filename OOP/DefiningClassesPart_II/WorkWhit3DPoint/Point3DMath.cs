using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorkWhit3DPoint
{
    public static class Point3DMath
    {
        public static double Distance(Point3D firstPoint, Point3D secondPoint)
        {
            int xDistanceSquare = GetDistanceSquare(firstPoint.X, secondPoint.X);
            int yDistanceSquare = GetDistanceSquare(firstPoint.Y, secondPoint.Y);
            int zDistanceSquare = GetDistanceSquare(firstPoint.Z, secondPoint.Z);

            return Math.Sqrt(xDistanceSquare + yDistanceSquare + zDistanceSquare);
        }

        private static int GetDistanceSquare(int firstPointCoordinate, int secondPointCoordinate)
        {
            int distance = firstPointCoordinate - secondPointCoordinate;

            return distance * distance;
        }
    }
}
