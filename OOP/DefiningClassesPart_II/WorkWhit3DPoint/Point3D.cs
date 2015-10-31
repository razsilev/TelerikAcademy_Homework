using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorkWhit3DPoint
{
    public struct Point3D
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        private static readonly Point3D o = new Point3D(0, 0, 0);

        public static Point3D O
        {
            get
            {
                return o;
            }
        }

        public Point3D(int x, int y, int z) : this()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public override string ToString()
        {
            return string.Format("x: {0} y: {1} z: {2}", this.X, this.Y, this.Z);
        }
    }
}
