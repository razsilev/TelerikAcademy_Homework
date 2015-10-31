using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    class UnpassableBlock : Block
    {
        public new const string CollisionGroupString = "indestructibleBlock";
        public const char Symbol = '$';

        public UnpassableBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
            base.body[0, 0] = UnpassableBlock.Symbol;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            //this.IsDestroyed = true;
        }

        public override string GetCollisionGroupString()
        {
            return UnpassableBlock.CollisionGroupString;
        }
    }
}
