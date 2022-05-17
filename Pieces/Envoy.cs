using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janggi.Pieces
{
    internal class Envoy : Piece
    {
        private Tuple<int, int> lineLimit;
        private Tuple<int, int> columnLimit;
        //Constructor
        //este pusa culoarea si imaginea piesei
        public Envoy(PieceColor pieceColor)
        {
            this.value = 200;
            this.pieceColor = pieceColor;

            if (pieceColor == PieceColor.BLUE)
            {
                img = Properties.Resources.benvoy;
            }
            if (pieceColor == PieceColor.RED)
            {
                img = Properties.Resources.renvoy;
            }

        }
        //se seteaza limita in care se poate misca nebunul 
        public override void setLimit(Box box)
        {
            lineLimit = Tuple.Create(box.getLine() - 1, box.getLine() + 1);
            columnLimit = Tuple.Create(box.getColumn() - 1, box.getColumn() + 1);
        }
        //se verifica daca paramterul line se afla in limita impusa pe randuri
        private bool verifyLineLimt(int line)
        {
            if (line >= lineLimit.Item1 && line <= lineLimit.Item2)
            {
                return true;
            }
            return false;
        }
        //se verifica daca paramterul column se afla in limita impusa  pe coloane
        private bool verifyColumnLimt(int column)
        {
            if (column >= columnLimit.Item1 && column <= columnLimit.Item2)
            {
                return true;
            }
            return false;
        }
        //se verifca daca este posibila mutarea pe o casuta
        public void addEnvoyChange(int line, int column, List<Tuple<int, int>> possibleChange)
        {
            if (verifyLineLimt(line) && verifyColumnLimt(column) && (window_form.board[line, column].getPiece() == null || window_form.board[line, column].getPiece().getPieceColor() != this.pieceColor))// && verify(line, column) == Condition.NONE)
            {            
                possibleChange.Add(new Tuple<int, int>(line, column));        
            }
        }
        //Mutari Posibile
        // lista de mutari posbilie se construieste cu ajutorul metodei  addEnvoyChange(int line,int column, List<Tuple<int, int>>  possibleChanges);
        //Pattern :Are o limita de 3 X3 prin care se poate misca ,daca se afla pe centrul limitei sau daca centrul nu este ocupat  se poate plasa oriunde in acea limita,in caz contrar se poate deplasa doar pe orizontal sau vertical
        public override List<Tuple<int, int>> getListOfPossibleChanges()
        {
            List<Tuple<int, int>> possibleChanges = new List<Tuple<int, int>>();
            int line = box.getLine();
            int column = box.getColumn();
            possibleChanges.Add(new Tuple<int, int>(line, column));
            line = box.getLine() + 1;
            column = box.getColumn();
            addEnvoyChange(line, column, possibleChanges);
            line = box.getLine() - 1;
            column = box.getColumn();
            addEnvoyChange(line, column, possibleChanges);
            line = box.getLine();
            column = box.getColumn() + 1;
            addEnvoyChange(line, column, possibleChanges);
            line = box.getLine();
            column = box.getColumn() - 1;
            addEnvoyChange(line, column, possibleChanges);
            if (window_form.board[(lineLimit.Item1 + lineLimit.Item2) / 2, (columnLimit.Item1 + columnLimit.Item2) / 2].getPiece() == null || window_form.board[(lineLimit.Item1 + lineLimit.Item2) / 2, (columnLimit.Item1 + columnLimit.Item2) / 2].getPiece() == this || window_form.board[(lineLimit.Item1 + lineLimit.Item2) / 2, (columnLimit.Item1 + columnLimit.Item2) / 2].getPiece().getPieceColor() != this.pieceColor)
            {
                line = box.getLine() + 1;
                column = box.getColumn() + 1;
                addEnvoyChange(line, column, possibleChanges);
                line = box.getLine() - 1;
                column = box.getColumn() + 1;
                addEnvoyChange(line, column, possibleChanges);
                line = box.getLine() + 1;
                column = box.getColumn() - 1;
                addEnvoyChange(line, column, possibleChanges);
                line = box.getLine() - 1;
                column = box.getColumn() - 1;
                addEnvoyChange(line, column, possibleChanges);

            }

            return possibleChanges;
        }
    }
}
