using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorkWhit3DPoint
{
    class WorkWhit3DPoint
    {
        static void Main(string[] args)
        {
            Point3D pointA = new Point3D(3, 4, 5);
            Point3D pointB = new Point3D(3, 4, 4);
            Console.WriteLine("point A: {0}", pointA);
            Console.WriteLine("point B: {0}", pointB);

            Console.Write("\nDistance between point A & B: ");
            Console.WriteLine(Point3DMath.Distance(pointA, pointB));

            Path path = new Path();

            path.Points3D.Add(pointA);
            path.Points3D.Add(pointB);

            Console.WriteLine("\nSave path. . .");
            PathStorage.Save(path);
            path = null;
            path = PathStorage.Load();

            Console.WriteLine("\nLoaded path content:");
            PrintPath(path);
            Console.WriteLine();
        }

        private static void PrintPath(Path path)
        {
            int count = 0;

            foreach (var point3D in path.Points3D)
            {
                count++;
                Console.WriteLine("poin: [{0}]  {1}", count, point3D);
            }
        }
    }
}
