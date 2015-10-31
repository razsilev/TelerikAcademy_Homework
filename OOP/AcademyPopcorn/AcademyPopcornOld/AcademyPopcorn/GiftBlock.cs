using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    class GiftBlock : Block
    {
        public const char Symbol = '?';

        public GiftBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
            base.body[0, 0] = GiftBlock.Symbol;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            if (this.IsDestroyed)
            {
                Gift gift = new Gift(base.topLeft, new char[,] { { '^' }, { '|' } });

                return new GameObject[] { gift };
            }

            return base.ProduceObjects();
        }
    }
}
