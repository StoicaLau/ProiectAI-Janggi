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
            this.Enabled = true;
            this.BackgroundImage = piece.getImage();
        }
        //se seteaza daca se poate da click pe casuta
        public void enableMove(bool enable)
        {
            this.Enabled = enable;
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
                    }
                }
            }

        }
        private void Box_Load(object sender, EventArgs e)
        {
            this.BackColor = colors[(line + column) % 2];
            this.Location = new Point(5 + this.Width * column, 5 +810 - this.Height * line);
        }
        private void Box_Click(object sender, EventArgs e)
        {

            if (piece != null && (mobilePiece == null || piece == mobilePiece))
            {

                if (this.BackColor == colors[2])
                {
                    hidePossibleChanges();

                }
                else
                {
                    hidePossibleChanges();
                    piece.showPossibleChanges();
                }



            }
            else
            {
                movePiece(mobilePiece);
                //Anunt
               // window_form.notification.Items.Add("Player" + (window_form.turnOfPlayer + 1) + ":" +"(" +mobilePiece.getLine()+","+ mobilePiece.getColumn() +")->("+ this.getLine() + "," + this.getColumn() + ")");

                hidePossibleChanges();
                originalColor();
                Enabled = false;

                window_form.players[window_form.turnOfPlayer].turn(false);
                window_form.turnOfPlayer = (window_form.turnOfPlayer + 1) % 2;
                window_form.players[window_form.turnOfPlayer].turn(true);
                King kingPlayer = window_form.players[window_form.turnOfPlayer].getKing();
               
                if (kingPlayer.verifyCheck() == Condition.CHECK)
                {
                   
                   // window_form.notification.Items.Add("Player" + (window_form.turnOfPlayer + 1) + ":CHECK");
                    window_form.players[window_form.turnOfPlayer].turn(false);
                    kingPlayer.enableMove(false);
                    List<Piece> defensivePiece = kingPlayer.getListOfDefnsivePieces(kingPlayer.getLine(), kingPlayer.getColumn());
                    foreach (Piece piece in defensivePiece)
                    {
                        piece.enableMove(true);
                    }


                }
                else
                {
                    if (kingPlayer.verifyCheck() == Condition.CHECKMATE)
                    {
                        //window_form.notification.Items.Add("Player" + (window_form.turnOfPlayer + 1) + ":" + "LOSE");
                        window_form.players[window_form.turnOfPlayer].turn(false);
                        window_form.turnOfPlayer = (window_form.turnOfPlayer + 1) % 2;
                        window_form.players[window_form.turnOfPlayer].turn(false);
                        //window_form.notification.Items.Add("Player" + (window_form.turnOfPlayer + 1) + ":" + "WIN");

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
