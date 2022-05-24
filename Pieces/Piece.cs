using Janggi.Players;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janggi.Pieces
{
    public class Piece
    {

        //protected Player player;
        protected Box box;
        protected PieceColor pieceColor;
        protected Image img;

        //Value:
        // Cannon 7
        //Elephant 3
        //Horse 5
        //guard 3
        //pawn 2
        //rook 13
        protected int value;
        //pentru piese care trebuie sa se miste doar casa apere regele cand este in sah

        protected List<Tuple<int, int>> specialChange;

        //Constructor
        public Piece()
        {
            specialChange = new List<Tuple<int, int>>();
        }
        //Gettere si Settere
        public int getValue()
        {
            return value;
        }
        public void setBox(Box box)
        {
            this.box = box;
        }
        public Box getBox()
        {
            return box;
        }
        public int getLine()
        {
            return box.getLine();
        }
        public int getColumn()
        {
            return box.getColumn();
        }
        public Image getImage()
        {
            return img;
        }
        public PieceColor getPieceColor()
        {
            return pieceColor;
        }
        public void addSpecialChange(Tuple<int, int> position)
        {
            specialChange.Add(position);
        } 
        public void resetSpecialChange()
        {
            specialChange = new List<Tuple<int, int>>();
        }

        //se seteaza daca se poate da click pe piesa sau nu
        //intai se verifica daca prin muatrea aceelei piese se poate prima sah,in caz afirmativ se va seta astfel inacat nu se va da click pe piesa ,caz contrar se seteaza in functie  de parametrul enable

        public virtual void enableMove(bool enable)
        {
            Piece aux = this;
            Player player;
            King king;
            if (window_form.players[0].getPieceColor() == pieceColor)
            {
                player = window_form.players[0];
            }
            else
            {
                player = window_form.players[1];
            }
            king = player.getKing();
            window_form.board[this.getLine(), this.getColumn()].setPiece(null);
            List<Tuple<int, int>> changes = this.getListOfPossibleChanges();
            if (king.verifyCheck() != Condition.NONE)
            {
                window_form.board[this.getLine(), this.getColumn()].setPiece(aux);
                foreach (Tuple<int, int> change in this.getListOfPossibleChanges())
                {
                    if (window_form.board[change.Item1, change.Item2].getPiece() != null)
                    {
                        specialChange.Add(change);
                    }
                    else
                    {
                        window_form.board[this.getLine(), this.getColumn()].setPiece(null);
                        window_form.board[change.Item1, change.Item2].setPiece(this);
                        if (king.verifyCheck() == Condition.NONE)
                        {
                            specialChange.Add(change);
                        }
                        window_form.board[this.getLine(), this.getColumn()].setPiece(this);
                        window_form.board[change.Item1, change.Item2].setPiece(null);
                    }
                }
                if (specialChange.Count() == 1)
                {
                    box.enableMove(false);
                }
                else
                {
                    box.enableMove(enable);
                }
            }
            else
            {
                window_form.board[this.getLine(), this.getColumn()].setPiece(this);
                box.enableMove(enable);
            }
        }
        //se construieste lista cu posibile piese  inamicie care pot ataca piesa aflata la cordonatele date de parametrii line ,column
        public List<Piece> getListOfOffensivePieces(int line, int column)
        {
            List<Piece> enemyPieces = new List<Piece>();
            List<Tuple<int, int>> changes = new List<Tuple<int, int>>();
            Player enemy;
            if (window_form.players[0].getPieceColor() != pieceColor)
            {
                enemy = window_form.players[0];
            }
            else
            {
                enemy = window_form.players[1];
            }
            foreach (Piece piece in enemy.getPieces())
            {

                changes = piece.getListOfPossibleChanges();
                if (changes.Count != 1)
                {
                    if (changes.Contains(new Tuple<int, int>(line, column)) == true)
                    {
                        enemyPieces.Add(piece);
                    }
                }
            }
            return enemyPieces;

        }
        public virtual int getDirection()
        {
            return 0;
        }
        //se construieste lista cu posibile piese aliate care poate apara piesa aflata  la cordonatele date de parametrii line ,column
        public virtual List<Piece> getListOfDefensivePieces(int line, int column)
        {
            List<Piece> playerPieces = new List<Piece>();
            List<Tuple<int, int>> changes = new List<Tuple<int, int>>();

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
                if (piece != this)
                {
                    Piece aux = this;
                    window_form.board[this.getLine(), this.getColumn()].setPiece(null);
                    changes = piece.getListOfPossibleChanges();
                    window_form.board[aux.getLine(), aux.getColumn()].setPiece(aux);
                    if (changes.Count != 1)
                    {
                        if (changes.Contains(new Tuple<int, int>(line, column)) == true)
                        {
                            playerPieces.Add(piece);
                        }
                    }
                }

            }

            return playerPieces;

        }
         
        //se verifca daca este posibila mutarea
        public void addPossibleChange(int line, int column, List<Tuple<int, int>> list)
        {
            if ((line < 10 && line >= 0) && (column >= 0 && column < 9) && (window_form.board[line, column].getPiece() == null || window_form.board[line, column].getPiece().getPieceColor() != this.pieceColor))
            {

                list.Add(new Tuple<int, int>(line, column));

            }
        }
        public virtual List<Tuple<int, int>> getListOfPossibleChanges()
        {
            return null;
        }
        //functia care coloreaza casutele in functie de lista cu mutari  posibile
        public void showPossibleChanges()
        {
            List<Tuple<int, int>> possibleChanges = new List<Tuple<int, int>>();
            if (specialChange.Count == 0)
            {
                possibleChanges = this.getListOfPossibleChanges();
            }
            else
            {
                possibleChanges = specialChange;
            }
            foreach (Tuple<int, int> position in possibleChanges)
            {
                window_form.board[position.Item1, position.Item2].selected(this);
            }
        }

        public virtual void setLimit(Box box)
        {

        }


    }
}
