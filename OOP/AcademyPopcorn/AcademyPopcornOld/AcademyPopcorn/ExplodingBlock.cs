using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    class ExplodingBlock : Block
    {
        public const char Symbol = '@';

        public ExplodingBlock(MatrixCoords upperLeft)
            : base(upperLeft)
        {
            this.body[0, 0] = ExplodingBlock.Symbol;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            base.RespondToCollision(collisionData);
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            if (base.IsDestroyed)
            {
                List<GameObject> blockDestroyers = new List<GameObject>();
                int startRow = base.GetTopLeft().Row - 2;
                int startCol = base.GetTopLeft().Col - 2;
                int lifeTime = 5;

                for (int row = startRow; row < startRow + 5; row++)
                {
                    for (int col = startCol; col < startCol + 5; col++)
                    {
                        if (!(col == startCol + 2 && row == startRow + 2))
                        {
                            BlockDestroyer blockDestriyer = new BlockDestroyer(new MatrixCoords(row, col), 'X', lifeTime);

                            blockDestroyers.Add(blockDestriyer);
                        }
                    }
                }

                return blockDestroyers;
            }

            return base.ProduceObjects();
        }
    }
}
