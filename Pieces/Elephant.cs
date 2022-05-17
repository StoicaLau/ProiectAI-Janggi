using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janggi.Pieces
{
    public class Elephant : Piece
    {
        //Constructor
        //este pusa culoarea si imaginea piesei
        public Elephant(PieceColor pieceColor)
        {
            this.value = 500;
            this.pieceColor = pieceColor;
            if (pieceColor == PieceColor.BLUE)
            {
                img = Properties.Resources.belephant;
            }
            if (pieceColor == PieceColor.RED)
            {
                img = Properties.Resources.relephant;
            }

        }
        //Mutari Posibile
        // lista de mutari posbilie se construieste cu ajutorul unei metode mostenite de la clasa Piece ,metoda:addPossibleChange(int line,int column, List<Tuple<int, int>>  possibleChanges);
        //Pattern : 3 casute pe orice lineie(orizontala sau vericala) si apoi 2 casute de a stanga sau de a dreapta liniei sau  2 casute pe orice lineie(orizontala sau vericala si apoi 3 casute de a stanga sau de a dreapta liniei
        public override List<Tuple<int, int>> getListOfPossibleChanges()
        {
            List<Tuple<int, int>> possibleChanges = new List<Tuple<int, int>>();
            int line = box.getLine();
            int column = box.getColumn();
            possibleChanges.Add(new Tuple<int, int>(line, column));
            line = box.getLine() + 3;
            column = box.getColumn() + 2;
            addPossibleChange(line, column, possibleChanges);
            line = box.getLine() + 3;
            column = box.getColumn() - 2;
            addPossibleChange(line, column, possibleChanges);
            line = box.getLine() - 3;
            column = box.getColumn() + 2;
            addPossibleChange(line, column, possibleChanges);
            line = box.getLine() - 3;
            column = box.getColumn() - 2;
            addPossibleChange(line, column, possibleChanges);
            line = box.getLine() + 2;
            column = box.getColumn() + 3;
            addPossibleChange(line, column, possibleChanges);
            line = box.getLine() - 2;
            column = box.getColumn() + 3;
            addPossibleChange(line, column, possibleChanges);
            line = box.getLine() + 2;
            column = box.getColumn() - 3;
            addPossibleChange(line, column, possibleChanges);
            line = box.getLine() - 2;
            column = box.getColumn() - 3;
            addPossibleChange(line, column, possibleChanges);
            return possibleChanges;

        }
    }
}
