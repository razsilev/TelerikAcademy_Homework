using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    class UnstoppableBall : Ball
    {
        public UnstoppableBall(MatrixCoords topLeft, MatrixCoords speed, int ballSpeed = 4)
            : base(topLeft, speed, ballSpeed)
        {
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            if (collisionData.hitObjectsCollisionGroupStrings[0] == IndestructibleBlock.CollisionGroupString ||
                collisionData.hitObjectsCollisionGroupStrings[0] == Racket.CollisionGroupString)
            {
                base.RespondToCollision(collisionData);
            }
        }
    }
}
