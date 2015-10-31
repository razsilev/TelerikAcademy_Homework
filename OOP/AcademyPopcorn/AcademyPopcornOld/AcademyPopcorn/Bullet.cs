using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    class Bullet : MovingObject
    {
        public Bullet(MatrixCoords topLeft, char symbol)
            : base(topLeft, new char[,] { { symbol } }, new MatrixCoords(-1, 0))
        {
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return true;//otherCollisionGroupString.Equals(Block.CollisionGroupString);
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }

        public override string GetCollisionGroupString()
        {
            return Ball.CollisionGroupString;
        }
    }
}
