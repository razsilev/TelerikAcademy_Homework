using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    class MeteoriteBall : Ball
    {
        protected int Length { get; set; }

        public MeteoriteBall(MatrixCoords topLeft, MatrixCoords speed, int length, int ballSpeed = 4)
            : base(topLeft, speed, ballSpeed)
        {
            this.Length = length;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            if (this.mooveCount >= this.ballSpeed)
            {
                var trails = new TrailObject[Length];

                for (int i = 0; i < Length; i++)
                {
                    trails[i] = new TrailObject(this.TopLeft, (i + 2) * this.ballSpeed);
                }

                return trails;
            }
            else
            {
                return base.ProduceObjects();
            }
        }
    }
}
