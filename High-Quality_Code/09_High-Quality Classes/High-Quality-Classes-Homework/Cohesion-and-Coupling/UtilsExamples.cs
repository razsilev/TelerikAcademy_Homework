namespace CohesionAndCoupling
{
    using System;

    class UtilsExamples
    {
        static void Main()
        {
            Console.WriteLine(StringUtils.GetFileExtension("example"));
            Console.WriteLine(StringUtils.GetFileExtension("example.pdf"));
            Console.WriteLine(StringUtils.GetFileExtension("example.new.pdf"));
                              
            Console.WriteLine(StringUtils.GetFileNameWithoutExtension("example"));
            Console.WriteLine(StringUtils.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(StringUtils.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine("Distance in the 2D space = {0:f2}",
                MathUtils.CalcDistance2D(new Point2D(1, -2), new Point2D(3, 4)));
            Console.WriteLine("Distance in the 3D space = {0:f2}",
                MathUtils.CalcDistance3D(new Point3D(5, 2, -1), new Point3D(3, -6, 4)));

            double width = 3;
            double height = 4;
            double depth = 5;
            Point3D start = new Point3D();
            Point3D end = new Point3D(width, height, depth);

            Console.WriteLine("Volume = {0:f2}", MathUtils.CalcParallelepipedVolume(width, height, depth));
            Console.WriteLine("Diagonal XYZ = {0:f2}", MathUtils.ParallelepipedCalcDiagonalXYZ(start, end));
            Console.WriteLine("Diagonal XY = {0:f2}", MathUtils.ParallelepipedCalcDiagonalXY(start, end));
            Console.WriteLine("Diagonal XZ = {0:f2}", MathUtils.ParallelepipedCalcDiagonalXZ(start, end));
            Console.WriteLine("Diagonal YZ = {0:f2}", MathUtils.ParallelepipedCalcDiagonalYZ(start, end));
        }
    }
}
