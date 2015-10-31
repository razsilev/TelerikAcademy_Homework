using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    public class Ball : MovingObject
    {
        public new const string CollisionGroupString = "ball";
        protected int mooveCount;
        protected int ballSpeed;

        public Ball(MatrixCoords topLeft, MatrixCoords speed, int ballSpeed = 4)
            : base(topLeft, new char[,] { { 'o' } }, speed)
        {
            this.ballSpeed = ballSpeed;
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "racket" || otherCollisionGroupString == "block";
        }

        public override string GetCollisionGroupString()
        {
            return Ball.CollisionGroupString;
        }

        public override void RespondToCollision(CollisionData collisionData)
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

        public override void Update()
        {
            this.mooveCount++;

            if (this.mooveCount > this.ballSpeed)
            {
                this.mooveCount = 0;
                base.Update();
            }
        }
    }
}
