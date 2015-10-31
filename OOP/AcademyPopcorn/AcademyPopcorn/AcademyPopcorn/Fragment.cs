using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    class Fragment : MovingObject
    {
        public int LifeTime { get; set; }

        public Fragment(MatrixCoords topLeft, int lifeTime)
            : this(topLeft, 'X', lifeTime)
        {
        }

        public Fragment(MatrixCoords topLeft, char symbol = 'X', int lifeTime = 3)
            : base(topLeft,new char[,] { {symbol} }, new MatrixCoords(0, 0))
        {
            this.LifeTime = lifeTime;
        }

        public override void Update()
        {
            this.LifeTime--;

            if (this.LifeTime < 0)
            {
                this.IsDestroyed = true;
            }
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            //return base.CanCollideWith(otherCollisionGroupString);
            return true;
        }

        public override string GetCollisionGroupString()
        {
            return Ball.CollisionGroupString;
        }
    }
}
