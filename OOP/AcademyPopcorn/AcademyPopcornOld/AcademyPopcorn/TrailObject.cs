using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    class TrailObject : GameObject
    {
        private int lifetime;

        public TrailObject(MatrixCoords topLeft, char[,] body, int lifetime)
            : base(topLeft, body)
        {
            if (lifetime < 1)
            {
                throw new ArgumentOutOfRangeException("Life time can not be less then 1.");
            }

            this.lifetime = lifetime;
        }

        public override void Update()
        {
            this.lifetime--;

            if (this.lifetime <= 0)
            {
                this.IsDestroyed = true;
            }
        }
    }
}
