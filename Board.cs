using Janggi.Pieces;
using Janggi.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Janggi
{
    public class Board
    {

        private Player player1;

        public Board(Panel board_panel)
        {
            window_form.board = new Box[10, 9];

            for (int i = 0; i < 10; i++)
            {
                CreateLabel(830, 90 * i + 40, (10 - i).ToString(), board_panel);
                for (int j = 0; j < 9; j++)
                {

                    window_form.board[i, j] = new Box(i, j);
                    board_panel.Controls.Add(window_form.board[i, j]);
                }
            }
            for (int i = 0; i < 9; i++)
            {
                CreateLabel(90 * i + 35, 910, (Convert.ToChar(97 + i)).ToString(), board_panel);
            }
            player1 = new Human(PieceColor.BLUE, 1);
            window_form.players[0] = player1;

        }
        private void CreateLabel(int x, int y, string text, Panel board_panel)
        {
            Label label = new System.Windows.Forms.Label();

            label.AutoSize = true;
            label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            label.Location = new System.Drawing.Point(x, y);
            label.Size = new System.Drawing.Size(25, 25);
            label.Text = text;
            board_panel.Controls.Add(label);
        }

        public Box getBox(int line, int column)
        {
            return window_form.board[line, column];
        }

    }
}
