using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    class UnstoppableBall : Ball
    {
        public UnstoppableBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        {
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            bool haveColision = otherCollisionGroupString == "racket" || otherCollisionGroupString == "indestructibleBlock";

            return haveColision;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            if (collisionData.hitObjectsCollisionGroupStrings.FirstOrDefault() != "block")
            {
                if (collisionData.CollisionForceDirection.Row * this.Speed.Row < 0)
                {
                    this.Speed.Row *= -1;
                }
                if (collisionData.CollisionForceDirection.Col * this.Speed.Col < 0)
                {
                    this.Speed.Col *= -1;
                }
            }
        }
    }
}
