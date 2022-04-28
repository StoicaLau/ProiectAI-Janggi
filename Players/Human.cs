using Janggi.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janggi.Players
{
    public class Human:Player
    {

        public Human(PieceColor pieceColor, int direction)
        {
            this.pieceColor = pieceColor;
            this.direction = direction;
        }
}
}
