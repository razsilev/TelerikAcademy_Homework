using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    class MeteoriteBall : Ball
    {
        public MeteoriteBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        {
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            TrailObject trailObject = new TrailObject(base.GetTopLeft(), new char[,] { { 'x' } }, 3);

            return new GameObject[] { trailObject };
        }
    }
}
