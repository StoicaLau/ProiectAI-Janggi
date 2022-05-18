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

    public partial class window_form : Form
    {
        public static Box[,] board;
        public static Player[] players;
        public static int turnOfPlayer;
        public window_form()
        {
            InitializeComponent();



        }

        private void Janggi_Load(object sender, EventArgs e)
        {
            players = new Player[2];
            turnOfPlayer = 0;
            Board board = new Board(board_panel);
          


        }

        private void board_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void arata_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btn_1Player_Click(object sender, EventArgs e)
        {
            Player player1 = new Computer(PieceColor.RED, -1);
            btn_1Player.Visible = false;
            btn_2Players.Visible = false;
            window_form.players[0].placeThePieces();
            window_form.players[1] = player1;
            window_form.players[1].placeThePieces();
            window_form.players[1].turn(false);
            window_form.players[0].turn(true);
        }

        private void btn_2Players_Click(object sender, EventArgs e)
        {
            Player player1 = new Human(PieceColor.RED, -1);
            btn_1Player.Visible = false;
            btn_2Players.Visible = false;
            window_form.players[0].placeThePieces();
            window_form.players[1] = player1;
            window_form.players[1].placeThePieces();
            window_form.players[1].turn(false);
            window_form.players[0].turn(true);
            btn_Client.Visible = true;
            btn_Server.Visible = true;
            btn_Connect.Visible = true;
            tb_IP.Visible = true;
            tb_Port.Visible = true;
        }
    }
}
