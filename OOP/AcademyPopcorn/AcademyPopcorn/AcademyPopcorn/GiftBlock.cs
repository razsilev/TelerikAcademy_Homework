using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    class GiftBlock : Block
    {
        public const char Symbol = '?';
        public Gift CurrentGift { get; protected set; }

        public GiftBlock(MatrixCoords topLeft, Gift gift)
            : base(topLeft)
        {
            this.CurrentGift = gift;
            this.CurrentGift.SetTopLeft(topLeft);
            this.body = new char[,] { { GiftBlock.Symbol } };
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            if (this.IsDestroyed)
            {
                return new Gift[] { this.CurrentGift };
            }

            return base.ProduceObjects();
        }
    }
}
