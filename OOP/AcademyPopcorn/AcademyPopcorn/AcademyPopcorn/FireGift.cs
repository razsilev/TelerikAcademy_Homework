using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    class FireGift : Gift
    {
        public FireGift()
            : base('@')
        {
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            if (this.IsDestroyedByRacket)
            {
                // TODO create fire racket
                var racketTopLeft = new MatrixCoords(this.topLeft.Row + 1, this.topLeft.Col);
                var racket = new ShootingRacket(racketTopLeft, 6);

                return new GameObject[] { racket };
            }

            return base.ProduceObjects();
        }
    }
}
