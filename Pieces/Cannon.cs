using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janggi.Pieces
{
    public class Cannon : Piece
    {
        //Constructor
        //este pusa culoarea si imaginea piesei
        public Cannon(PieceColor pieceColor)
        {
            this.value = 7;
            this.pieceColor = pieceColor;

            if (pieceColor == PieceColor.BLUE)
            {
                img = Properties.Resources.bcannon;
            }
            if (pieceColor == PieceColor.RED)
            {
                img = Properties.Resources.rcannon;
            }

        }
        //Mutari Posibile
        // lista de mutari posbilie se construieste cu ajutorul unei metode mostenite de la clasa Piece ,metoda:addPossibleChange(int line,int column, List<Tuple<int, int>>  possibleChanges);
        //Pattern:trebuie sa existe piese peste care sa sara in linie orizontala sau verticala in fiecare directie
        public override List<Tuple<int, int>> getListOfPossibleChanges()
        {
            List<Tuple<int, int>> possibleChanges = new List<Tuple<int, int>>();
            int line = box.getLine();
            int column = box.getColumn();
            int contor = 0;
            int linePiece = -1;
            int columnPiece = -1;

            Boolean[] ifJumpPiece = new Boolean[4];
            for (int i = 0; i < 4; i++)
            {
                ifJumpPiece[i] = false;
            }
            //verifcare  existenta piesa peste care sa sara pe  linie verticala directia: sus 
            line = box.getLine() + 1;
            while (line < 9)
            {
                if (window_form.board[line, column].getPiece() != null)
                {
                    if (window_form.board[line, column].getPiece().GetType() == typeof(Cannon) == true)
                    {
                        break;
                    }
                    if (window_form.board[line + 1, column].getPiece() != null && window_form.board[line + 1, column].getPiece() != this)
                    {
                        break;

                    }
                    if (window_form.board[line - 1, column].getPiece() != null && window_form.board[line - 1, column].getPiece() != this)
                    {
                        break;

                    }
                    ifJumpPiece[0] = true;
                    linePiece = line;
                    columnPiece = column;
                    break;
                }
                line++;
            }
            //dezvaluirea mutarileor posibile pe linie verticala directia: sus
            if (ifJumpPiece[0] == true)
            {
                line = linePiece + 1;
                while (line < 10)
                {
                    if (window_form.board[line, column].getPiece() != null)
                    {
                        if (window_form.board[line, column].getPiece().getPieceColor() != this.pieceColor && (window_form.board[line, column].getPiece().GetType() == typeof(Cannon)) == false)
                        {
                            addPossibleChange(line, column, possibleChanges);
                        }
                        break;
                    }
                    addPossibleChange(line, column, possibleChanges);
                    line++;
                }
            }
            //verifcare  existenta piesa peste care sa sara pe  linie verticala directia: jos
            line = box.getLine() - 1;
            while (line > 0)
            {
                if (window_form.board[line, column].getPiece() != null)
                {
                    if (window_form.board[line, column].getPiece().GetType() == typeof(Cannon) == true)
                    {
                        break;
                    }
                    if (window_form.board[line + 1, column].getPiece() != null && window_form.board[line + 1, column].getPiece() != this)
                    {
                        break;

                    }
                    if (window_form.board[line - 1, column].getPiece() != null && window_form.board[line - 1, column].getPiece() != this)
                    {
                        break;

                    }
                    ifJumpPiece[1] = true;
                    linePiece = line;
                    columnPiece = column;
                    break;
                }
                line--;
            }
            //dezvaluirea mutarileor posibile pe linie verticala directia: jos
            if (ifJumpPiece[1] == true)
            {
                line = linePiece - 1;
                while (line >= 0)
                {
                    if (window_form.board[line, column].getPiece() != null)
                    {
                        if (window_form.board[line, column].getPiece().getPieceColor() != this.pieceColor && (window_form.board[line, column].getPiece().GetType() == typeof(Cannon)) == false)
                        {
                            addPossibleChange(line, column, possibleChanges);
                        }
                        break;
                    }
                    addPossibleChange(line, column, possibleChanges);
                    line--;
                }

            }
            //verifcare  existenta piesa peste care sa sara pe  linie orizontala directia: stanga
            line = box.getLine();
            column = box.getColumn() + 1;
            while (column < 8)
            {
                if (window_form.board[line, column].getPiece() != null)
                {
                    if (window_form.board[line, column].getPiece().GetType() == typeof(Cannon) == true)
                    {
                        break;
                    }
                    if (window_form.board[line, column + 1].getPiece() != null && window_form.board[line, column + 1].getPiece() != this)
                    {
                        break;
                    }
                    if (window_form.board[line, column - 1].getPiece() != null && window_form.board[line, column - 1].getPiece() != this)
                    {
                        break;
                    }

                    ifJumpPiece[2] = true;
                    linePiece = line;
                    columnPiece = column;
                    break;
                }
                column++;
            }
            //dezvaluirea mutarileor posibile pe linie orizontala directia:stanga
            if (ifJumpPiece[2] == true)
            {
                column = columnPiece + 1;
                while (column < 9)
                {
                    if (window_form.board[line, column].getPiece() != null)
                    {
                        if (window_form.board[line, column].getPiece().getPieceColor() != this.pieceColor && (window_form.board[line, column].getPiece().GetType() == typeof(Cannon)) == false)
                        {
                            addPossibleChange(line, column, possibleChanges);
                        }
                        break;
                    }
                    addPossibleChange(line, column, possibleChanges);
                    column++;
                }

            }
            //verifcare  existenta piesa peste care sa sara pe  linie orizontala directia: dreapta
            column = box.getColumn() - 1;
            while (column > 0)
            {
                if (window_form.board[line, column].getPiece() != null)
                {
                    if (window_form.board[line, column].getPiece().GetType() == typeof(Cannon) == true)
                    {
                        break;
                    }
                    if (window_form.board[line, column + 1].getPiece() != null && window_form.board[line, column + 1].getPiece() != this)
                    {
                        break;
                    }
                    if (window_form.board[line, column - 1].getPiece() != null && window_form.board[line, column - 1].getPiece() != this)
                    {
                        break;
                    }
                    ifJumpPiece[3] = true;
                    linePiece = line;
                    columnPiece = column;
                    break;
                }
                column--;
            }
            //dezvaluirea mutarileor posibile pe linie orizontala directia:dreapta
            if (ifJumpPiece[3] == true)
            {
                column = columnPiece - 1;
                while (column >= 0)
                {
                    if (window_form.board[line, column].getPiece() != null)
                    {
                        if (window_form.board[line, column].getPiece().getPieceColor() != this.pieceColor && (window_form.board[line, column].getPiece().GetType() == typeof(Cannon)) == false)
                        {
                            addPossibleChange(line, column, possibleChanges);
                        }
                        break;
                    }
                    addPossibleChange(line, column, possibleChanges);
                    column--;
                }
            }
            //se verifica daca exista o directie in care se poate muta tunul
            if (ifJumpPiece[0] == true || ifJumpPiece[1] == true || ifJumpPiece[2] == true || ifJumpPiece[3] == true)
            {
                line = box.getLine();
                column = box.getColumn();
                addPossibleChange(line, column, possibleChanges);

            }
            return possibleChanges;
        }

    }
}
