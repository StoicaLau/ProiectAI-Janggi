namespace Janggi
{
    partial class window_form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        public  void InitializeComponent()
        {
            this.board_panel = new System.Windows.Forms.Panel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            notification = new System.Windows.Forms.ListBox();
            this.btn_1Player = new System.Windows.Forms.Button();
            this.btn_2Players = new System.Windows.Forms.Button();
            this.btn_Server = new System.Windows.Forms.Button();
            this.btn_Client = new System.Windows.Forms.Button();
            this.tb_IP = new System.Windows.Forms.TextBox();
            this.tb_Port = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // board_panel
            // 
            this.board_panel.AutoSize = true;
            this.board_panel.BackColor = System.Drawing.Color.ForestGreen;
            this.board_panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.board_panel.Location = new System.Drawing.Point(12, 12);
            this.board_panel.Name = "board_panel";
            this.board_panel.Size = new System.Drawing.Size(870, 950);
            this.board_panel.TabIndex = 0;
            this.board_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.board_panel_Paint);
            // 
            // notification
            // 
            notification.FormattingEnabled = true;
           notification.Location = new System.Drawing.Point(943, 12);
            notification.Name = "notification";
           notification.Size = new System.Drawing.Size(217, 238);
            notification.TabIndex = 1;
            notification.SelectedIndexChanged += new System.EventHandler(this.arata_SelectedIndexChanged);
            // 
            // btn_1Player
            // 
            this.btn_1Player.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_1Player.Location = new System.Drawing.Point(943, 276);
            this.btn_1Player.Name = "btn_1Player";
            this.btn_1Player.Size = new System.Drawing.Size(217, 46);
            this.btn_1Player.TabIndex = 2;
            this.btn_1Player.Text = "1 Player";
            this.btn_1Player.UseVisualStyleBackColor = true;
            this.btn_1Player.Click += new System.EventHandler(this.btn_1Player_Click);
            // 
            // btn_2Players
            // 
            this.btn_2Players.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_2Players.Location = new System.Drawing.Point(943, 328);
            this.btn_2Players.Name = "btn_2Players";
            this.btn_2Players.Size = new System.Drawing.Size(217, 51);
            this.btn_2Players.TabIndex = 3;
            this.btn_2Players.Text = "2 Players";
            this.btn_2Players.UseVisualStyleBackColor = true;
            this.btn_2Players.Click += new System.EventHandler(this.btn_2Players_Click);
            // 
            // btn_Server
            // 
            this.btn_Server.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Server.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_Server.Location = new System.Drawing.Point(943, 661);
            this.btn_Server.Name = "btn_Server";
            this.btn_Server.Size = new System.Drawing.Size(217, 51);
            this.btn_Server.TabIndex = 4;
            this.btn_Server.Text = "Create Server";
            this.btn_Server.UseVisualStyleBackColor = true;
            this.btn_Server.Visible = false;
            this.btn_Server.Click += new System.EventHandler(this.btn_Server_Click);
            // 
            // btn_Client
            // 
            this.btn_Client.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Client.Location = new System.Drawing.Point(943, 727);
            this.btn_Client.Name = "btn_Client";
            this.btn_Client.Size = new System.Drawing.Size(217, 53);
            this.btn_Client.TabIndex = 5;
            this.btn_Client.Text = "Connect";
            this.btn_Client.UseVisualStyleBackColor = true;
            this.btn_Client.Visible = false;
            this.btn_Client.Click += new System.EventHandler(this.btn_Client_Click);
            // 
            // tb_IP
            // 
            this.tb_IP.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_IP.Location = new System.Drawing.Point(943, 799);
            this.tb_IP.Name = "tb_IP";
            this.tb_IP.Size = new System.Drawing.Size(217, 31);
            this.tb_IP.TabIndex = 6;
            this.tb_IP.Text = "127.0.0.1";
            this.tb_IP.Visible = false;
            // 
            // tb_Port
            // 
            this.tb_Port.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Port.Location = new System.Drawing.Point(943, 846);
            this.tb_Port.Name = "tb_Port";
            this.tb_Port.Size = new System.Drawing.Size(217, 31);
            this.tb_Port.TabIndex = 8;
            this.tb_Port.Text = "8000";
            this.tb_Port.Visible = false;
            // 
            // window_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 1011);
            this.Controls.Add(this.tb_Port);
            this.Controls.Add(this.tb_IP);
            this.Controls.Add(this.btn_Client);
            this.Controls.Add(this.btn_Server);
            this.Controls.Add(this.btn_2Players);
            this.Controls.Add(this.btn_1Player);
            this.Controls.Add(notification);
            this.Controls.Add(this.board_panel);
            this.Name = "window_form";
            this.Text = "Janggi";
            this.Load += new System.EventHandler(this.Janggi_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel board_panel;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        public static System.Windows.Forms.ListBox notification;
        private System.Windows.Forms.Button btn_1Player;
        private System.Windows.Forms.Button btn_2Players;
        private System.Windows.Forms.Button btn_Server;
        private System.Windows.Forms.Button btn_Client;
        private System.Windows.Forms.TextBox tb_IP;
        private System.Windows.Forms.TextBox tb_Port;
    }
}

