using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    public abstract class Gift : Ball
    {
        //public new const string CollisionGroupString = "gift";
        public int MaxRowLife { get; set; }
        public bool IsDestroyedByRacket { get; protected set; }

        public Gift(char symbol, int giftSpeed = 2)
            : base(new MatrixCoords(0, 0), new MatrixCoords(1, 0))
        {
            this.body = new char[,] { { symbol } };
            this.MaxRowLife = 50;
            this.IsDestroyedByRacket = false;
            this.ballSpeed = giftSpeed;
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == Racket.CollisionGroupString;
        }

        public override void Update()
        {
            base.Update();

            if (this.topLeft.Row > this.MaxRowLife)
            {
                this.IsDestroyed = true;
            }
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            if (collisionData.hitObjectsCollisionGroupStrings[0] == Racket.CollisionGroupString)
            {
                this.IsDestroyed = true;

                if (this.topLeft.Row < this.MaxRowLife)
                {
                    this.IsDestroyedByRacket = true;
                }

            }
            
        }

        public void SetTopLeft(MatrixCoords topLeft)
        {
            this.TopLeft = topLeft;
        }
    }
}
