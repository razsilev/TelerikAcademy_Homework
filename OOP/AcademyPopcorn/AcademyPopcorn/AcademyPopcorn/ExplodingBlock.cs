using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    class ExplodingBlock : Block
    {
        public ExplodingBlock(MatrixCoords topLeft, char symbol = 'B') : base(topLeft)
        {
            this.body = new char[,] { { symbol } };
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
            //base.RespondToCollision(collisionData);
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            if (this.IsDestroyed)
            {
                var producedObjects = new List<GameObject>(9);
                int length = 3;
                int startRow = this.topLeft.Row - 1;
                int endRol = startRow + length;
                int startCol = this.topLeft.Col - 1;
                int endCol = startCol + length;

                for (int row = startRow; row < endRol; row++)
                {
                    for (int col = startCol; col < endCol; col++)
                    {
                        var fragment = new Fragment(new MatrixCoords(row, col));

                        producedObjects.Add(fragment);
                    }
                }

                return producedObjects;
            }

            return base.ProduceObjects();
        }

    }
}
