using Janggi.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janggi.Pieces
{
    public class King : Piece
    {
        private Tuple<int, int> lineLimit;
        private Tuple<int, int> columnLimit;

        //Constructor
        //este pusa culoarea si imaginea piesei
        public King(PieceColor pieceColor)
        {

            this.pieceColor = pieceColor;

            if (pieceColor == PieceColor.BLUE)
            {
                img = Properties.Resources.bking;
            }
            if (pieceColor == PieceColor.RED)
            {
                img = Properties.Resources.rking;
            }

        }
        //se seteaza daca se poate da click pe piesa sau nu
        public override void enableMove(bool enable)
        {
            box.enableMove(enable);
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
        public void addKingChange(int line, int column, List<Tuple<int, int>> possibleChange)
        {
            if (verifyLineLimt(line) && verifyColumnLimt(column) && (window_form.board[line, column].getPiece() == null || window_form.board[line, column].getPiece().getPieceColor() != this.pieceColor))// && verify(line, column) == Condition.NONE)
            {
                //mutare care nu este in sah
                if (verifyPossibleChnage(line, column) == true)
                {

                    possibleChange.Add(new Tuple<int, int>(line, column));
                }
                //verific daca pot lua cu regele piesa
                else
                {
                    Piece aux = this;
                    window_form.board[this.getLine(), this.getColumn()].setPiece(null);
                    List<Piece> enemyPieces = getListOfOffensivePieces(line, column);
                    window_form.board[aux.getLine(), aux.getColumn()].setPiece(aux);
                    foreach (Piece enemyPiece in enemyPieces)
                    {

                        if (window_form.board[line, column].getPiece() == enemyPiece)
                        {

                            if (enemyPiece.getListOfDefensivePieces(enemyPiece.getLine(), enemyPiece.getColumn()).Count == 0)
                            {
                                possibleChange.Add(new Tuple<int, int>(line, column));
                            }
                        }

                    }
                }


            }
        }
        //se verifca daca exista cel putin o mutare valabila pentru rege
        public bool verifyPossibleChnage(int line, int column)
        {
            Piece aux = this;
            window_form.board[this.getLine(), this.getColumn()].setPiece(null);
            List<Piece> enemyPieces = getListOfOffensivePieces(line, column);
            window_form.board[this.getLine(), this.getColumn()].setPiece(this);
            if (enemyPieces.Count != 0)
            {
                return false;
            }


            return true;
        }
        //se construieste lista cu posibile piese aliate care il pot ajuta pe rege sa scape de CHECK aflat  la cordonatele date de parametrii line ,column
        public override List<Piece> getListOfDefensivePieces(int line, int column)
        {
            List<Piece> enemyPieces = getListOfOffensivePieces(line, column);
            List<Piece> playerPieces = new List<Piece>();
            List<Tuple<int, int>> changes = new List<Tuple<int, int>>();
            List<Tuple<int, int>> enemyChanges = new List<Tuple<int, int>>();
            Player player;
            if (window_form.players[0].getPieceColor() == pieceColor)
            {
                player = window_form.players[0];
            }
            else
            {
                player = window_form.players[1];
            }
            foreach (Piece piece in player.getPieces())
            {
                changes = piece.getListOfPossibleChanges();
                if (changes.Count != 1)
                {
                    foreach (Piece enemyPiece in enemyPieces)
                    {
                        enemyChanges = enemyPiece.getListOfPossibleChanges();

                        foreach (Tuple<int, int> enemyChange in enemyChanges)
                        {
                            if (changes.Contains(enemyChange) == true && ((enemyChange.Item1 >= line && enemyChange.Item1 <= enemyPiece.getLine()) || (enemyChange.Item1 <= line && enemyChange.Item1 >= enemyPiece.getLine())) && ((enemyChange.Item2 >= column && enemyChange.Item2 <= enemyPiece.getColumn()) || (enemyChange.Item2 <= column && enemyChange.Item2 >= enemyPiece.getColumn())))
                            {
                                piece.addSpecialChange(enemyChange);
                                piece.addSpecialChange(new Tuple<int, int>(piece.getLine(), piece.getColumn()));
                                playerPieces.Add(piece);
                            }
                        }

                    }
                }

            }
            changes = player.getKing().getListOfPossibleChanges();
            if (changes.Count != 1)
            {
                foreach (Piece enemyPiece in enemyPieces)
                {
                    enemyChanges = enemyPiece.getListOfPossibleChanges();
                    if (enemyChanges.Count != 1)
                    {
                        foreach (Tuple<int, int> enemyChange in enemyChanges)
                        {
                            if (changes.Contains(enemyChange) == true)
                            {
                                playerPieces.Add(player.getKing());
                            }
                        }
                    }
                }
            }
            return playerPieces;

        }
        //se verifica in ce stare se afla Regele(NONE,CHECK,CHECKMATE)
        public Condition verifyCheck()
        {
            int line = this.getLine();
            int column = this.getColumn();
            if (getListOfOffensivePieces(line, column).Count != 0)
            {
                if (getListOfPossibleChanges().Count == 1 && this.getListOfDefensivePieces(line, column).Count == 0)
                {
                    return Condition.CHECKMATE;
                }

                return Condition.CHECK;
            }

            return Condition.NONE;

        }
        //Mutari Posibile
        // lista de mutari posbilie se construieste cu ajutorul metodei  addKingChange(int line,int column, List<Tuple<int, int>>  possibleChanges);
        //Pattern :Are o limita de 3 X3 prin care se poate misca ,daca se afla pe centrul limitei sau daca centrul nu este ocupat  se poate plasa oriunde in acea limita,in caz contrar se poate deplasa doar pe orizontal sau vertical
        public override List<Tuple<int, int>> getListOfPossibleChanges()
        {
            List<Tuple<int, int>> possibleChanges = new List<Tuple<int, int>>();
            int line = box.getLine();
            int column = box.getColumn();
            possibleChanges.Add(new Tuple<int, int>(line, column));
            line = box.getLine() + 1;
            column = box.getColumn();
            addKingChange(line, column, possibleChanges);
            line = box.getLine() - 1;
            column = box.getColumn();
            addKingChange(line, column, possibleChanges);
            line = box.getLine();
            column = box.getColumn() + 1;
            addKingChange(line, column, possibleChanges);
            line = box.getLine();
            column = box.getColumn() - 1;
            addKingChange(line, column, possibleChanges);
            if ((window_form.board[(lineLimit.Item1 + lineLimit.Item2) / 2, (columnLimit.Item1 + columnLimit.Item2) / 2].getPiece() == null || window_form.board[(lineLimit.Item1 + lineLimit.Item2) / 2, (columnLimit.Item1 + columnLimit.Item2) / 2].getPiece() == this || window_form.board[(lineLimit.Item1 + lineLimit.Item2) / 2, (columnLimit.Item1 + columnLimit.Item2) / 2].getPiece().getPieceColor() != this.pieceColor))//&& verifyPossibleChnage((lineLimit.Item1 + lineLimit.Item2) / 2, (columnLimit.Item1 + columnLimit.Item2) / 2) ==true)
            {
                line = box.getLine() + 1;
                column = box.getColumn() + 1;
                addKingChange(line, column, possibleChanges);
                line = box.getLine() - 1;
                column = box.getColumn() + 1;
                addKingChange(line, column, possibleChanges);
                line = box.getLine() + 1;
                column = box.getColumn() - 1;
                addKingChange(line, column, possibleChanges);
                line = box.getLine() - 1;
                column = box.getColumn() - 1;
                addKingChange(line, column, possibleChanges);

            }

            return possibleChanges;
        }





    }
}
