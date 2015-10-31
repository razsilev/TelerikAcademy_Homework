using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    class ShootingRacket : GameObject
    {
        bool canShoot;

        public ShootingRacket(MatrixCoords topLeft)
            : this(topLeft, new char[,] { { ' ' } })
        {
        }

        public ShootingRacket(MatrixCoords topLeft, char[,] body)
            : base(topLeft, body)
        {
            this.canShoot = false;
        }

        public override void Update()
        {
            //throw new NotImplementedException();
        }

        public void Shoot(MatrixCoords topLeft)
        {
            this.topLeft.Row = topLeft.Row - 1;
            this.topLeft.Col = topLeft.Col + 3;
            this.canShoot = true;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            if (this.canShoot)
            {
                this.canShoot = false;
                return new GameObject[]{new Bullet(this.topLeft, 'B')};
            }

            return base.ProduceObjects();
        }
    }
}
