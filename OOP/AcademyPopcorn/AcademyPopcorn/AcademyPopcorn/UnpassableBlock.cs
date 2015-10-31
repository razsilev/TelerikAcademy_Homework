using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    class UnpassableBlock : IndestructibleBlock
    {
        public new const char Symbol = '~';

        public UnpassableBlock(MatrixCoords upperLeft) : base(upperLeft)
        {
            this.body = new char[,] { {Symbol} };
        }
    }
}
