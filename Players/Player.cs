using Janggi.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janggi.Players
{
    public class Player
    {
        protected List<Piece> pieces;
        protected King king;
        protected PieceColor pieceColor;
        protected int direction;
        //Constructori
        public Player()
        {

        }
        public Player(PieceColor pieceColor, int direction)
        {
            this.pieceColor = pieceColor;
            this.direction = direction;


        }
        //Gettere
        public int getNumberOfPieces()
        {
            return pieces.Count;
        }
        public King getKing()
        {
            return king;
        }
        public List<Piece> getPieces()
        {
            return pieces;
        }
        public PieceColor getPieceColor()
        {
            return pieceColor;
        }
     
        //se seteaza daca jucatorul poate face o mutare sau nu
        public  virtual void turn(bool enable)
        {
          
        }
        //asezare piese
        public void placeThePieces()
        {
            Piece piece;
            int line;
            int column;
            pieces = new List<Piece>();

            if (direction == 1)
            {

                //pawn 
                for (column = 0; column < 9; column += 2)
                {
                    piece = new Pawn(pieceColor, direction);
                    window_form.board[3, column].movePiece(piece);
                    pieces.Add(piece);
                }
                //cannon
                piece = new Cannon(pieceColor);
                window_form.board[2, 1].movePiece(piece);
                pieces.Add(piece);
                piece = new Cannon(pieceColor);
                window_form.board[2, 7].movePiece(piece);
                pieces.Add(piece);
                //rook
                piece = new Rook(pieceColor);
                window_form.board[0, 0].movePiece(piece);
                pieces.Add(piece);
                piece = new Rook(pieceColor);
                window_form.board[0, 8].movePiece(piece);
                pieces.Add(piece);
                //horse
                piece = new Horse(pieceColor);
                window_form.board[0, 1].movePiece(piece);
                pieces.Add(piece);
                piece = new Horse(pieceColor);
                window_form.board[0, 7].movePiece(piece);
                pieces.Add(piece);
                //elephant
                piece = new Elephant(pieceColor);
                window_form.board[0, 2].movePiece(piece);
                pieces.Add(piece);
                piece = new Elephant(pieceColor);
                window_form.board[0, 6].movePiece(piece);
                pieces.Add(piece);


                //King
                king = new King(pieceColor);
                window_form.board[1, 4].movePiece(king);
                king.setLimit(king.getBox());
                //pieces.Add(king);
                //envoy
                piece = new Guard(pieceColor);
                window_form.board[0, 3].movePiece(piece);
                piece.setLimit(king.getBox());
                pieces.Add(piece);

                piece = new Guard(pieceColor);
                window_form.board[0, 5].movePiece(piece);
                piece.setLimit(king.getBox());
                pieces.Add(piece);

            }
            if (direction == -1)
            {

                //pawn 
                for (column = 0; column < 9; column += 2)
                {
                    piece = new Pawn(pieceColor, direction);
                    window_form.board[6, column].movePiece(piece);
                    pieces.Add(piece);
                }
                //cannon
                piece = new Cannon(pieceColor);
                window_form.board[7, 1].movePiece(piece);
                pieces.Add(piece);
                piece = new Cannon(pieceColor);
                window_form.board[7, 7].movePiece(piece);
                pieces.Add(piece);
                //rook
                piece = new Rook(pieceColor);
                window_form.board[9, 0].movePiece(piece);
                pieces.Add(piece);
                piece = new Rook(pieceColor);
                window_form.board[9, 8].movePiece(piece);
                pieces.Add(piece);
                //horse
                piece = new Horse(pieceColor);
                window_form.board[9, 1].movePiece(piece);
                pieces.Add(piece);
                piece = new Horse(pieceColor);
                window_form.board[9, 7].movePiece(piece);
                pieces.Add(piece);
                //elephant
                piece = new Elephant(pieceColor);
                window_form.board[9, 2].movePiece(piece);
                pieces.Add(piece);
                piece = new Elephant(pieceColor);
                window_form.board[9, 6].movePiece(piece);
                pieces.Add(piece);


                //King
                king = new King(pieceColor);
                window_form.board[8, 4].movePiece(king);
                king.setLimit(king.getBox());
                // pieces.Add(king);
                //envoy
                piece = new Guard(pieceColor);
                window_form.board[9, 3].movePiece(piece);
                piece.setLimit(king.getBox());
                pieces.Add(piece);

                piece = new Guard(pieceColor);
                window_form.board[9, 5].movePiece(piece);
                piece.setLimit(king.getBox());
                pieces.Add(piece);

            }

        }
    }
}
