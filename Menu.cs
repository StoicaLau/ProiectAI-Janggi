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
            window_form.players[0] = null;


        }

        private void exit_Click(object sender, EventArgs e)
        {

            Application.Exit();

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
           
            player1.Visible = false;
            player2.Visible = false;
            exit.Visible = false;
            back1.Visible = true;
            connect.Visible = true;
            create.Visible = true;

        }

        private void back1_Click(object sender, EventArgs e)
        {
            window_form.players[0] = null;
            player1.Visible = true;
            player2.Visible = true;
            exit.Visible = true;
           

            back1.Visible = false;
            connect.Visible = false;
            create.Visible = false;
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }
        //private void btn_1Player_Click(object sender, EventArgs e)
        //{
        //    Player player1 = new Computer(PieceColor.RED, -1);
        //    btn_1Player.Visible = false;
        //    btn_2Players.Visible = false;
        //    window_form.players[0].placeThePieces();
        //    window_form.players[1] = player1;
        //    window_form.players[1].placeThePieces();
        //    window_form.players[1].turn(false);
        //    window_form.players[0].turn(true);
        //    playerVsPlayer = false;
        //}

        //private void btn_2Players_Click(object sender, EventArgs e)
        //{
        //    Player player1 = new Human(PieceColor.RED, -1);
        //    btn_1Player.Visible = false;
        //    btn_2Players.Visible = false;
        //    window_form.players[0].placeThePieces();
        //    window_form.players[1] = player1;
        //    window_form.players[1].placeThePieces();
        //    window_form.players[1].turn(false);
        //    window_form.players[0].turn(true);
        //    btn_Client.Visible = true;
        //    btn_Server.Visible = true;
        //    tb_IP.Visible = true;
        //    tb_Port.Visible = true;
        //    playerVsPlayer = true;
        //}
        //nu stiu care tb si portul si ip
        private void connect_Click(object sender, EventArgs e)
        {
           
            back1.Visible = false;
            connect.Visible = false;
            create.Visible = false;

            iptext.Visible = true;
            ip.Visible = true;
            porttext.Visible = true;
            port.Visible = true;
            connectserver.Visible = true;
            back2.Visible = true;
        }

        private void create_Click(object sender, EventArgs e)
        {
            Player playeraux = new Human(PieceColor.BLUE, 1);
            window_form.players[0] = playeraux;
            window_form.players[0].placeThePieces();
           
            playeraux = new Human(PieceColor.RED, -1);
            window_form.players[1] = playeraux;
            window_form.players[1].placeThePieces();
            window_form.players[1].turn(false);
            window_form.players[0].turn(true);

            back1.Visible = false;
            connect.Visible = false;
            create.Visible = false;

            iptext.Visible = true;
            ip.Visible = true;
            porttext.Visible = true;
            port.Visible = true;
            createserv.Visible = true;
            back2.Visible = true;
        }

        private void iptext_Click(object sender, EventArgs e)
        {

        }
      //ptrr coonectserver
        private void connectserver_Click(object sender, EventArgs e)
        {
            // aici asteti datele celeui care a creat servarul
            Player playeraux = new Human(PieceColor.BLUE, 1);
            window_form.players[0] = playeraux;
            window_form.players[0].placeThePieces();
            //primesti datele
            playeraux = new Human(PieceColor.RED, -1);
            window_form.players[1] = playeraux;
            window_form.players[1].placeThePieces();
            window_form.players[1].turn(false);
            window_form.players[0].turn(true);
        }
        //pt create server
        private void createserv_Click(object sender, EventArgs e)
        {
            Player playeraux = new Human(PieceColor.BLUE, 1);
            window_form.players[0] = playeraux;
            window_form.players[0].placeThePieces();
            //aici steptidatele
            playeraux = new Human(PieceColor.RED, -1);
            window_form.players[1] = playeraux;
            window_form.players[1].placeThePieces();
            window_form.players[1].turn(false);
            window_form.players[0].turn(true);
        }

        private void back2_Click(object sender, EventArgs e)
        {
            back1.Visible = true;
            connect.Visible = true;
            create.Visible = true;

            iptext.Visible = false;
            ip.Visible = false;
            porttext.Visible = false;
            port.Visible = false;
            createserv.Visible =false;
            connectserver.Visible =false;
            back2.Visible =false;
        }

    
    }
}
