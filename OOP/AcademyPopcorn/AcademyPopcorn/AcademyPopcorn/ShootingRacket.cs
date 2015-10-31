using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    class ShootingRacket : Racket
    {
        public bool CanShoot { get; protected set; }

        public ShootingRacket(MatrixCoords topLeft, int width)
            : base(topLeft, width)
        {
            this.CanShoot = false;
        }

        public void Shoot()
        {
            this.CanShoot = true;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            if (this.CanShoot)
            {
                this.CanShoot = false;

                int col = this.topLeft.Col + (this.Width / 2);
                var bulletTopLeft = new MatrixCoords(this.topLeft.Row, col);
                var bullet = new Bullet(bulletTopLeft);

                return new GameObject[] { bullet };
            }

            return base.ProduceObjects();
        }

        public void ChangeInitialization(MatrixCoords topLeft, int width)
        {
            this.TopLeft = topLeft;
            this.Width = width;
        }
    }
}
