using System;
using System.Collections.Generic;

namespace WorkWhit3DPoint
{
    public class Path
    {
        public List<Point3D> Points3D { get; set; }

        public Path()
        {
            Points3D = new List<Point3D>();
        }
    }
}
