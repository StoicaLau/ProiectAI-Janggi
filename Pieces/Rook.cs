using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janggi.Pieces
{
    public class Rook : Piece
    {
        //Constructor
        //este pusa culoarea si imaginea piesei
        public Rook(PieceColor pieceColor)
        {
            this.pieceColor = pieceColor;
            if (pieceColor == PieceColor.BLUE)
            {
                img = Properties.Resources.brook;
            }
            if (pieceColor == PieceColor.RED)
            {
                img = Properties.Resources.rrook;
            }

        }
        //Mutari Posibile
        // lista de mutari posbilie se construieste cu ajutorul unei metode mostenite de la clasa Piece ,metoda:addPossibleChange(int line,int column, List<Tuple<int, int>>  possibleChanges);
        //Pattern:se muta  in linie orizontala sau verticala in fiecare directie
        public override List<Tuple<int, int>> getListOfPossibleChanges()
        {
            List<Tuple<int, int>> possibleChanges = new List<Tuple<int, int>>();
            int line = box.getLine();
            int column = box.getColumn();
            possibleChanges.Add(new Tuple<int, int>(line, column));
            line = line + 1;
            while (line < 10)
            {
                if (window_form.board[line, column].getPiece() != null)
                {
                    if (window_form.board[line, column].getPiece().getPieceColor() != this.pieceColor)
                    {
                        addPossibleChange(line, column, possibleChanges);
                    }
                    break;
                }
                addPossibleChange(line, column, possibleChanges);
                line++;
            }
            line = box.getLine() - 1;
            while (line >= 0)
            {
                if (window_form.board[line, column].getPiece() != null)
                {
                    if (window_form.board[line, column].getPiece().getPieceColor() != this.pieceColor)
                    {
                        addPossibleChange(line, column, possibleChanges);
                    }
                    break;
                }
                addPossibleChange(line, column, possibleChanges);
                line--;
            }
            line = box.getLine();
            column++;
            while (column < 9)
            {
                if (window_form.board[line, column].getPiece() != null)
                {
                    if (window_form.board[line, column].getPiece().getPieceColor() != this.pieceColor)
                    {
                        addPossibleChange(line, column, possibleChanges);
                    }
                    break;
                }
                addPossibleChange(line, column, possibleChanges);
                column++;
            }
            column = box.getColumn() - 1;
            while (column >= 0)
            {
                if (window_form.board[line, column].getPiece() != null)
                {
                    if (window_form.board[line, column].getPiece().getPieceColor() != this.pieceColor)
                    {
                        addPossibleChange(line, column, possibleChanges);
                    }
                    break;
                }
                addPossibleChange(line, column, possibleChanges);
                column--;
            }
            return possibleChanges;

        }
    }
}
