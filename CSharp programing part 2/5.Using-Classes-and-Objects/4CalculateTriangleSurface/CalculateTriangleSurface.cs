using System;

namespace _4CalculateTriangleSurface
{
    class CalculateTriangleSurface
    {
        static void Main()
        {
            Console.WriteLine("Calculate surface of triangle\n");

            // Side and an altitude to it.
            double sideA = 3.0;
            double altitudeA = 4.0;

            double area = TiangleAreaBySideAnAltitudeToIt(sideA, altitudeA);

            Console.WriteLine("side a: {0}  altitude ha: {1}  \nThe area is: {2}\n\n",
                sideA, altitudeA, area);

            // Three sides.
            double sideB = 6;
            double sideC = 5;

            area = TiangleAreaByThreeSides(sideA, sideB, sideC);

            Console.WriteLine("side a: {0} \nside b: {1} \nside c: {2}", sideA, sideB, sideC);
            Console.WriteLine("The area is: {0}\n\n", area);

            // Two sides and an angle between them.
            double angle = 88.6;

            area = TiangleAreaByTwoSidesAndAngleBetweenThem(sideA, sideB, angle);
            Console.WriteLine("side a: {0} \nside b: {1}", sideA, sideB);
            Console.WriteLine("angle between them: {0}", angle);
            Console.WriteLine("The area is: {0}\n\n", area);

        }

        private static double TiangleAreaByTwoSidesAndAngleBetweenThem(double sideA, double sideB, double angle)
        {
            double sinAnglse = Math.Sin(angle);

            return (sideA * sideB * sinAnglse) / 2;
        }

        private static double TiangleAreaByThreeSides(double sideA, double sideB, double sideC)
        {
            double semiperimeter = (sideA + sideB + sideC) / 2;
            double forSQRT = semiperimeter * (semiperimeter - sideA) *
                            (semiperimeter - sideB) * (semiperimeter - sideC);

            double surface = Math.Sqrt(forSQRT);

            return surface;
        }

        private static double TiangleAreaBySideAnAltitudeToIt(double side, double altitude)
        {
            return (side * altitude) / 2;
        }
    }
}
