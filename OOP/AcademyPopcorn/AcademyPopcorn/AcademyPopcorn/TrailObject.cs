using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    class TrailObject : Block
    {
        public int LifeTime { get; set; }

        public TrailObject(MatrixCoords topLeft, int lifeTime)
            : base(topLeft)
        {
            this.body = new char[,] { { '%' } };
            this.LifeTime = lifeTime;
        }

        public override void Update()
        {
            this.LifeTime--;

            if (LifeTime < 0)
            {
                this.IsDestroyed = true;
            }
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return false;
        }
    }
}
