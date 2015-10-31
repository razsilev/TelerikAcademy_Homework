using System;
using System.Collections.Generic;
using System.IO;

namespace WorkWhit3DPoint
{
    public static class PathStorage
    {
        private static string filePath = "Points3D.txt";

        public static void Save(Path path)
        {
            using(StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var point3D in path.Points3D)
                {
                    writer.WriteLine("{0} {1} {2}", point3D.X, point3D.Y, point3D.Z);
                }
            }
        }

        public static Path Load()
        {
            List<Point3D> points3D = new List<Point3D>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string[] coordinates = reader.ReadLine().Split(' ');

                    int x = int.Parse(coordinates[0]);
                    int y = int.Parse(coordinates[1]);
                    int z = int.Parse(coordinates[2]);

                    points3D.Add(new Point3D(x, y, z));
                }
            }

            return new Path() { Points3D = points3D };
        }
    }
}
