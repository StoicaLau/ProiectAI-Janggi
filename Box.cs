using Janggi.Pieces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Janggi
{
    public partial class Box : UserControl
    {
        //Parameters
        private Color[] colors;
        private int line;
        private int column;
        private Piece piece;
        private Piece mobilePiece;
        private Panel panel;
        public static String dataToSend;

        //Constructor
        public Box(int line, int column)
        {
            InitializeComponent();
            colors = new Color[] { Color.AntiqueWhite, Color.DarkGreen, Color.LimeGreen };
            this.line = line;
            this.column = column;
            piece = null;
            mobilePiece = null;


        }
        public Box()
        {

        }
        public Box(Box box)
        {
            // InitializeComponent();
            //this.Visible = false;
            if (box != null)
            {
                colors = new Color[] { Color.AntiqueWhite, Color.DarkGreen, Color.LimeGreen };
                this.line = box.getLine();
                this.column = box.getColumn();
                Piece pieceaux = null;
                Piece pieceBox = box.getPiece();
                

                switch (pieceBox)
                {
                    case Cannon cannon: pieceaux = new Cannon(pieceBox.getPieceColor()); break;
                    case Elephant elephant: pieceaux = new Elephant(pieceBox.getPieceColor()); break;
                    case Guard guard: pieceaux = new Guard(pieceBox.getPieceColor()); break;
                    case Horse horse: pieceaux = new Horse(pieceBox.getPieceColor()); break;
                    case King King: pieceaux = new King(pieceBox.getPieceColor()); break;
                    case Rook rook: pieceaux = new Rook(pieceBox.getPieceColor()); break;
                    case Pawn pawn: pieceaux = new Pawn(pieceBox.getPieceColor(), pieceBox.getDirection()); break;
                    case null: pieceaux = null; break;

                }

                if (pieceaux != null)
                {
                    this.movePiece(pieceaux);
                }
                //piece =box.getPiece();
                mobilePiece = null;
            }
        }
        //Gettere si Settere

        public int getLine()
        {
            return line;
        }
        public void setPiece(Piece piece)
        {
            this.piece = piece;
        }
        public int getColumn()
        {
            return column;
        }

        public Piece getMobilePiece()
        {
            return mobilePiece;
        }
        public Piece getPiece()
        {
            return piece;
        }
        public void setColor(Color color)
        {
            this.BackColor = color;
        }
        public void clear()
        {
            piece = null;
            this.BackgroundImage = null;
            originalColor();
        }
        //coolorare casuta
        public void selected(Piece mobilePiece)
        {
            this.mobilePiece = mobilePiece;

            this.BackColor = colors[2];
            this.Enabled = true;

        }
        //aducere la culoarea originala
        public void originalColor()
        {
            mobilePiece = null;
            this.BackColor = colors[(line + column) % 2];
            if (piece == null)
            {
                this.Enabled = false;
            }

        }

        public void movePiece(Piece piece,List<Piece>bluePieces,List<Piece> redPieces)
        {
            Piece oldpiece = this.piece;
            this.piece = piece;
            //pt a lua piesa adversarului
            if (oldpiece != null)
            {
                if (oldpiece.getPieceColor() == PieceColor.RED)
                {
                    redPieces.Remove(oldpiece);
                }
                else
                {
                   bluePieces.Remove(oldpiece);
                }
             
            }
            //pt a sterge imaginea dinn blocul precedent
            if (this.piece.getBox() != null)
            {
                this.piece.getBox().clear();
            }
            this.piece.setBox(this);
            //this.Enabled = true;
            this.BackgroundImage = piece.getImage();
        }
        public void movePiece(Piece piece)
        {
            Piece oldpiece = this.piece;
            this.piece = piece;
            //pt a lua piesa adversarului
            if (oldpiece != null)
            {
                window_form.players[(window_form.turnOfPlayer + 1) % 2].getPieces().Remove(oldpiece);
            }
            //pt a sterge imaginea dinn blocul precedent
            if (this.piece.getBox() != null)
            {
                this.piece.getBox().clear();
            }
            this.piece.setBox(this);
            //this.Enabled = true;
            this.BackgroundImage = piece.getImage();
        }
        //se seteaza daca se poate da click pe casuta
        public void enableMove(bool enable)
        {
            this.Enabled = enable;
            if (enable == false)
            {
                originalColor();
            }

        }

        private void hidePossibleChanges()
        {


            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (window_form.board[i, j].getMobilePiece() != null)
                    {
                       
                           
                        
                        window_form.board[i, j].originalColor();
                        window_form.board[i, j].enableMove(false);



                    }
                }
            }

        }
        private void Box_Load(object sender, EventArgs e)
        {
            this.BackColor = colors[(line + column) % 2];
            this.Location = new Point(5 + this.Width * column, 5 + 630 - this.Height * line);
        }
        private void Box_Click(object sender, EventArgs e)
        {

            if (piece != null && (mobilePiece == null || piece == mobilePiece))
            {

                if (this.BackColor == colors[2])
                {
                    hidePossibleChanges();
                    this.enableMove(true);

                }
                else
                {
                    hidePossibleChanges();
                    piece.showPossibleChanges();
                }

            }
            else
            {
                if (window_form.playerVsPlayer == true)
                {
                    dataToSend = (9-mobilePiece.getLine()) + " " + (mobilePiece.getColumn()) + " " + (9-this.getLine()) + " " + (this.getColumn())+" ";
                }
                int line = mobilePiece.getLine();
                int column = mobilePiece.getColumn();
                //window_form.notification.Items.Add("Player" + (window_form.turnOfPlayer + 1) + " move "  + "(" + (line + 1) + "," + Convert.ToChar(97 + column) + ") to (" + (this.getLine() + 1) + "," + Convert.ToChar(97 + this.getColumn()) + ")");
                //window_form.notification.Refresh();
               
                movePiece(mobilePiece);
                //Anunt
                window_form.notification.Items.Add("Player" + (window_form.turnOfPlayer + 1) + " move" + ":" +"(" +(line+1)+","+Convert.ToChar (97+ column) +") to ("+ (this.getLine()+1) + "," + Convert.ToChar(97 + this.getColumn()) + ")");
                window_form.notification.Refresh();
                hidePossibleChanges();
                originalColor();
                Enabled = false;

                if (window_form.playerVsPlayer == true)
                {
                    window_form.players[0].turn(true);
                    window_form.players[1].turn(false);
                }
                else
                {
                    window_form.players[window_form.turnOfPlayer].turn(false);
                    window_form.turnOfPlayer = (window_form.turnOfPlayer + 1) % 2;
                    window_form.players[window_form.turnOfPlayer].turn(true);
                }
                King kingPlayer = window_form.players[window_form.turnOfPlayer].getKing();

                if (kingPlayer.verifyCheck() == Condition.CHECK)
                {

                     window_form.notification.Items.Add("Player" + (window_form.turnOfPlayer + 1) + ":CHECK");
                    window_form.players[window_form.turnOfPlayer].turn(false);
                    kingPlayer.enableMove(false);
                    List<Piece> defensivePiece = kingPlayer.getListOfDefensivePieces(kingPlayer.getLine(), kingPlayer.getColumn());
                    foreach (Piece piece in defensivePiece)
                    {
                        piece.enableMove(true);
                    }


                }
                else
                {
                    if (kingPlayer.verifyCheck() == Condition.CHECKMATE)
                    {
                        window_form.notification.Items.Add("Player" + (window_form.turnOfPlayer + 1) + ":" + "LOSE");
                        window_form.players[window_form.turnOfPlayer].turn(false);
                        window_form.turnOfPlayer = (window_form.turnOfPlayer + 1) % 2;
                        window_form.players[window_form.turnOfPlayer].turn(false);
                        window_form.notification.Items.Add("Player" + (window_form.turnOfPlayer + 1) + ":" + "WIN");

                    }

                }

                //if (kingPlayer.verify(kingPlayer.getBox().getLine(), kingPlayer.getBox().getColumn()) == Condition.CHECK) 
                //{
                //    window_form.notification.Items.Add("Player" + (window_form.turnOfPlayer + 1) );
                //}
                //window_form.notification.Items.Add("Player1:" + window_form.players[0].getNumberOfPieces());
                //window_form.notification.Items.Add("Player2:" + window_form.players[1].getNumberOfPieces());

            }

        }
    }
}
