using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janggi.Pieces
{
    public class Pawn : Piece
    {
        private int direction;
        //Constructor
        //este pusa culoarea si imaginea piesei si rectia de deplasare  1 pentru deplasare in sus si -1 pentru deplasare in jos 
        public Pawn(PieceColor pieceColor, int direction)
        {
            this.pieceColor = pieceColor;
            this.direction = direction;
            this.value = 100;
            if (pieceColor == PieceColor.BLUE)
            {
                img = Properties.Resources.bpawn;
            }
            if (pieceColor == PieceColor.RED)
            {
                img = Properties.Resources.rpawn;
            }

        }
        //Mutari Posibile
        // lista de mutari posbilie se construieste cu ajutorul unei metode mostenite de la clasa Piece ,metoda:addPossibleChange(int line,int column, List<Tuple<int, int>>  possibleChanges);
        //Pattern:1 casuta in directia indicata de direction ,1 casuta stanga,1 casuta dreapta
        public override List<Tuple<int, int>> getListOfPossibleChanges()
        {

            List<Tuple<int, int>> possibleChanges = new List<Tuple<int, int>>();
            int line = box.getLine();
            int column = box.getColumn();
            possibleChanges.Add(new Tuple<int, int>(line, column));

            line = box.getLine() + direction * 1;
            addPossibleChange(line, column, possibleChanges);

            line = box.getLine();
            column = box.getColumn() + 1;
            addPossibleChange(line, column, possibleChanges);

            line = box.getLine();
            column = box.getColumn() - 1;
            addPossibleChange(line, column, possibleChanges);
            return possibleChanges;
        }

    }
}
