using Janggi.Pieces;
using Janggi.Players;
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
    public partial class Menu : Form
    {
        private window_form janggi;
        public Menu()
        {
            InitializeComponent();
          
        }

        private void exit_Click(object sender, EventArgs e)
        {

            Close();
           
        }

       

      

        private void player1_Click(object sender, EventArgs e)
        {
            Player playeraux = new Human(PieceColor.BLUE, 1);
            window_form.players[0] = playeraux;
            window_form.players[0].placeThePieces();
            playeraux = new Computer(PieceColor.RED, -1);
            window_form.players[1] = playeraux;
            window_form.players[1].placeThePieces();
            window_form.players[1].turn(false);
            window_form.players[0].turn(true);

            Close();
        }

        private void player2_Click(object sender, EventArgs e)
        {
            Player playeraux = new Human(PieceColor.BLUE, 1);
            window_form.players[0] = playeraux;
            window_form.players[0].placeThePieces();
            playeraux = new Human(PieceColor.RED, -1);
            window_form.players[1] = playeraux;
            window_form.players[1].placeThePieces();
            window_form.players[1].turn(false);
            window_form.players[0].turn(true);
            player1.Visible = false;
            player2.Visible = false;
            exit.Visible = false;
            back1.Visible = true;

        }

        private void back1_Click(object sender, EventArgs e)
        {
            player1.Visible = true;
            player2.Visible = true;
            exit.Visible = true;
            back1.Visible = false;
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }
    }
}
