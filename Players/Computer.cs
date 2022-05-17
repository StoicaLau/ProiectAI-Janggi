using Janggi.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janggi.Players
{
    public class Computer:Player
    {
        public Computer(PieceColor pieceColor, int direction)
        {
            this.pieceColor = pieceColor;
            this.direction = direction;
        }
        public override void turn(bool enable)
        {
            if (enable == true)
            {
                Random random = new Random();
                Piece piece = this.pieces[random.Next(0,Convert.ToInt32(pieces.Count)) ];
                while (piece.getListOfPossibleChanges().Count == 1 || piece.getListOfPossibleChanges().Count == 0)
                {
                    piece = this.pieces[random.Next(0, Convert.ToInt32(pieces.Count))];
                }
               
                Tuple<int,int> move= piece.getListOfPossibleChanges()[random.Next(0,Convert.ToInt32(piece.getListOfPossibleChanges().Count))];
                while(move.Item1==piece.getLine() && move.Item2 == piece.getColumn())
                {
                     move = piece.getListOfPossibleChanges()[random.Next(0, Convert.ToInt32(piece.getListOfPossibleChanges().Count))];
                }
                window_form.board[move.Item1,move.Item2].movePiece(piece);

                window_form.players[window_form.turnOfPlayer].turn(false);
                window_form.turnOfPlayer = (window_form.turnOfPlayer + 1) % 2;
                window_form.players[window_form.turnOfPlayer].turn(true);

            }
            else
            {
                king.enableMove(enable);
                foreach (Piece piece in pieces)
                {
                    piece.resetSpecialChange();
                    piece.enableMove(enable);

                }
            }
       
        }
    }
}
