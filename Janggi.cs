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
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Janggi
{

    public partial class window_form : Form
    {
        public static Box[,] board;
        public static Player[] players;
        public static int turnOfPlayer;
        public static int port;
        public static string ip;
        private static StreamReader streamReader;
        private static StreamWriter streamWriter;
        private static NetworkStream streamClient;
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
            tb_IP.Visible = true;
            tb_Port.Visible = true;
        }

        private void btn_Server_Click(object sender, EventArgs e)
        {
            port = Convert.ToInt32(tb_Port.Text);
            IPAddress localAddr = IPAddress.Parse(tb_IP.Text);
            TcpListener server = new TcpListener(localAddr, port);
            server.Start();

            while (true)
            {
                Console.Write("Waiting for a connection... ");

                // Perform a blocking call to accept requests.
                // You could also use server.AcceptSocket() here.
                TcpClient client = server.AcceptTcpClient();
                Console.WriteLine("Connected!");

                Byte[] bytes = new Byte[256];

                // Get a stream object for reading and writing
                streamClient = client.GetStream();
                streamReader = new StreamReader(streamClient);
                streamWriter = new StreamWriter(streamClient);
                streamWriter.AutoFlush = true;

                string data = streamReader.ReadLine();

                // Loop to receive all the data sent by the client.
                while (data != null)
                {
                    if (streamClient.DataAvailable)
                    {
                        // Translate data bytes to a ASCII string.
                        String[] stringFromData = data.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        int[] positions = new int[4]; //position[0]-position[1]=poz initiala    position[2]-position[3]=poz finala
                        for (int i = 0; i < positions.Length; i++)
                        {
                            positions[i] = Convert.ToInt32(stringFromData[i]);
                        }
                        Piece temp = window_form.board[positions[0], positions[1]].getPiece();
                        window_form.board[positions[2], positions[3]].movePiece(temp);
                    }
                }

                // Shutdown and end connection
                client.Close();
            }
        }
    }
}
