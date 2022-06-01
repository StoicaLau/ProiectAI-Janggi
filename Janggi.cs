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
using System.Diagnostics;
using SimpleTCP;

namespace Janggi
{

    public partial class window_form : Form
    {
        public static Box[,] board;
        public static Player[] players;
        public static int turnOfPlayer;
        public static int port;
        public static string ip;
        public static SimpleTcpClient client;
        public static SimpleTcpServer server;
        public static bool isServer = false;
        public static bool isClient = false;
        public static Boolean playerVsPlayer;
        public window_form()
        {
            InitializeComponent();

            players = new Player[2];
            Board board = new Board(board_panel);

            Menu menu = new Menu();
            this.Hide();
            menu.ShowDialog();
            if (players[0] == null)
            {
                Close();
            }
            if (isServer == true)
            {
                server = new SimpleTcpServer();
                server.Delimiter = 0x13; //enter
                server.StringEncoder = Encoding.UTF8;
                System.Net.IPAddress address = System.Net.IPAddress.Parse(menu.ip.Text);
                server.Start(address, Convert.ToInt32(menu.port.Text));
                Console.WriteLine("Server waiting");
                server.DataReceived += Server_DataReceived;
                notification.Text = "TEST";
            }
            else if (isClient == true)
            {
                window_form.client = new SimpleTcpClient();
                window_form.client.StringEncoder = Encoding.UTF8;
                window_form.client.Connect(menu.ip.Text, Convert.ToInt32(menu.port.Text));
                Console.WriteLine("Conected");
                client.DataReceived += Client_DataReceived;
            }
            menu = null;
            this.Show();
        }

        private void Janggi_Load(object sender, EventArgs e)
        {
            turnOfPlayer = 0;
        }

        private void Client_DataReceived(object sender, SimpleTCP.Message e)
        {
            notification.Invoke((MethodInvoker)delegate ()
            {
                notification.Text += e.MessageString;
            });
        }

        private void Server_DataReceived(object sender, SimpleTCP.Message e)
        {
            notification.Invoke((MethodInvoker)delegate ()
            {
                notification.Text += e.MessageString;
                e.ReplyLine(string.Format("Am primit mesajul", e.MessageString));
            });
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

        private void send_Click(object sender, EventArgs e)
        {
            if (isServer == true)
            {
                server.BroadcastLine("test");
            }
            else if (isClient == true)
            {
                client.WriteLineAndGetReply("test",TimeSpan.FromSeconds(3));
            }
        }



        //private void btn_Server_Click(object sender, EventArgs e)
        //{
        //    port = Convert.ToInt32(tb_Port.Text);
        //    IPAddress localAddr = IPAddress.Parse(tb_IP.Text);
        //    TcpListener server = new TcpListener(localAddr, port);
        //    server.Start();

        //    while (true)
        //    {
        //        Console.Write("Waiting for a connection... ");

        //        // server.Server.ReceiveTimeout = 5000;
        //        TcpClient client = server.AcceptTcpClient();
        //        Console.WriteLine("Connected!");

        //        Byte[] bytes = new Byte[256];

        //        streamClient = client.GetStream();
        //        streamReader = new StreamReader(streamClient);
        //        streamWriter = new StreamWriter(streamClient);
        //        streamWriter.AutoFlush = true;

        //        // Loop to receive all the data sent by the client.
        //        //while (true)
        //        {
        //            if (streamClient.DataAvailable)
        //            {
        //                string data = streamReader.ReadLine();
        //                Debug.WriteLine(data);
        //                if (!data.Equals("Conexiune Reusita") && data != null)
        //                {
        //                    // Translate data bytes to a ASCII string.
        //                    String[] stringFromData = data.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        //                    foreach(string poz in stringFromData)
        //                    {
        //                        Debug.Write(poz + " ");
        //                    }
        //                    int[] positions = new int[4]; //position[0]-position[1]=poz initiala    position[2]-position[3]=poz finala
        //                    for (int i = 0; i < positions.Length; i++)
        //                    {
        //                        positions[i] = Convert.ToInt32(stringFromData[i]);
        //                    }
        //                    Piece temp = window_form.board[positions[0], positions[1]].getPiece();
        //                    window_form.board[positions[2], positions[3]].movePiece(temp);
        //                }
        //            }
        //        }
        //        server.Stop();
        //        streamReader.Close();
        //        streamWriter.Close();
        //        client.Close();
        //    }
        //}

        //private void btn_Client_Click(object sender, EventArgs e)
        //{
        //    // Create a TcpClient.
        //    // Note, for this client to work you need to have a TcpServer
        //    // connected to the same address as specified by the server, port
        //    // combination.
        //    port = Convert.ToInt32(tb_Port.Text);
        //    IPAddress localAddr = IPAddress.Parse(tb_IP.Text);
        //    TcpClient client = new TcpClient();
        //    client.Connect(localAddr, port);
        //    NetworkStream streamClient = client.GetStream();
        //    StreamReader streamReader = new StreamReader(streamClient);
        //    StreamWriter streamWriter = new StreamWriter(streamClient);
        //    streamWriter.AutoFlush = true;
        //    streamWriter.WriteLine("Test");
        //    while (true)
        //    {
        //        if (streamClient.DataAvailable)
        //        {
        //            string data = streamReader.ReadLine();
        //            // Translate data bytes to a ASCII string.
        //            String[] stringFromData = data.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        //            int[] positions = new int[4]; //position[0]-position[1]=poz initiala    position[2]-position[3]=poz finala
        //            for (int i = 0; i < positions.Length; i++)
        //            {
        //                positions[i] = Convert.ToInt32(stringFromData[i]);
        //            }
        //            Piece temp = window_form.board[positions[0], positions[1]].getPiece();
        //            window_form.board[positions[2], positions[3]].movePiece(temp);
        //        }
        //    }

        //    // Close everything.
        //    streamReader.Close();
        //    streamWriter.Close();
        //    client.Close();
        //}
    }
}
