using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    class BlockDestroyer : MovingObject
    {
        private int lifeTime;

        public BlockDestroyer(MatrixCoords topLeft, char symbol, int lifeTime)
            : base(topLeft, new char[,] { { symbol } }, new MatrixCoords(0, 0))
        {
            this.lifeTime = lifeTime;
        }

        public override void Update()
        {
            lifeTime--;

            if (lifeTime < 0)
            {
                base.IsDestroyed = true;
            }
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == Block.CollisionGroupString;
        }

        public override string GetCollisionGroupString()
        {
            return Ball.CollisionGroupString;
        }
    }
}
