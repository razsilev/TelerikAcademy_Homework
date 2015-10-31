using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    class Gift : MovingObject
    {
        protected int life;
        protected bool hitRacket;

        public Gift(MatrixCoords topLeft, char[,] body)
            : base(topLeft, body, new MatrixCoords(1, 0))
        {
            this.life = 60;
            this.hitRacket = false;
        }

        public override void Update()
        {
            base.Update();

            this.life--;

            if (this.life < 0)
            {
                this.IsDestroyed = true;
            }
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString.Equals(Racket.CollisionGroupString);
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.hitRacket = true;
            base.IsDestroyed = true;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            if (hitRacket)
            {
                return new GameObject[] { new ShootingRacket(this.topLeft) };
            }

            return base.ProduceObjects();
        }
    }
}
