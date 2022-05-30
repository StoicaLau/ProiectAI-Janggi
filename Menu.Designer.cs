namespace Janggi
{
    partial class Menu
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
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.player1 = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.Title = new System.Windows.Forms.Label();
            this.player2 = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.back1 = new System.Windows.Forms.Button();
            this.connect = new System.Windows.Forms.Button();
            this.create = new System.Windows.Forms.Button();
            this.ip = new System.Windows.Forms.TextBox();
            this.port = new System.Windows.Forms.TextBox();
            this.porttext = new System.Windows.Forms.Label();
            this.iptext = new System.Windows.Forms.Label();
            this.createserv = new System.Windows.Forms.Button();
            this.connectserver = new System.Windows.Forms.Button();
            this.back2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // player1
            // 
            this.player1.BackColor = System.Drawing.Color.Black;
            this.player1.Font = new System.Drawing.Font("Algerian", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player1.ForeColor = System.Drawing.Color.White;
            this.player1.Location = new System.Drawing.Point(85, 167);
            this.player1.Name = "player1";
            this.player1.Size = new System.Drawing.Size(147, 55);
            this.player1.TabIndex = 0;
            this.player1.Text = "1 Player";
            this.player1.UseVisualStyleBackColor = false;
            this.player1.Click += new System.EventHandler(this.player1_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.BackColor = System.Drawing.Color.Transparent;
            this.Title.Font = new System.Drawing.Font("Algerian", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.ForeColor = System.Drawing.Color.White;
            this.Title.Location = new System.Drawing.Point(78, 62);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(154, 41);
            this.Title.TabIndex = 1;
            this.Title.Text = "Janggi";
            // 
            // player2
            // 
            this.player2.BackColor = System.Drawing.Color.Black;
            this.player2.Font = new System.Drawing.Font("Algerian", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player2.ForeColor = System.Drawing.Color.White;
            this.player2.Location = new System.Drawing.Point(85, 272);
            this.player2.Name = "player2";
            this.player2.Size = new System.Drawing.Size(147, 55);
            this.player2.TabIndex = 2;
            this.player2.Text = "2 Players";
            this.player2.UseVisualStyleBackColor = false;
            this.player2.Click += new System.EventHandler(this.player2_Click);
            // 
            // exit
            // 
            this.exit.BackColor = System.Drawing.Color.Black;
            this.exit.Font = new System.Drawing.Font("Algerian", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exit.ForeColor = System.Drawing.Color.White;
            this.exit.Location = new System.Drawing.Point(85, 387);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(147, 55);
            this.exit.TabIndex = 3;
            this.exit.Text = "Exit";
            this.exit.UseVisualStyleBackColor = false;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // back1
            // 
            this.back1.BackColor = System.Drawing.Color.Black;
            this.back1.Font = new System.Drawing.Font("Algerian", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back1.ForeColor = System.Drawing.Color.White;
            this.back1.Location = new System.Drawing.Point(85, 387);
            this.back1.Name = "back1";
            this.back1.Size = new System.Drawing.Size(147, 55);
            this.back1.TabIndex = 4;
            this.back1.Text = "Back";
            this.back1.UseVisualStyleBackColor = false;
            this.back1.Visible = false;
            this.back1.Click += new System.EventHandler(this.back1_Click);
            // 
            // connect
            // 
            this.connect.BackColor = System.Drawing.Color.Black;
            this.connect.Font = new System.Drawing.Font("Algerian", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connect.ForeColor = System.Drawing.Color.White;
            this.connect.Location = new System.Drawing.Point(47, 272);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(218, 55);
            this.connect.TabIndex = 5;
            this.connect.Text = "Connect Server";
            this.connect.UseVisualStyleBackColor = false;
            this.connect.Visible = false;
            this.connect.Click += new System.EventHandler(this.connect_Click);
            // 
            // create
            // 
            this.create.BackColor = System.Drawing.Color.Black;
            this.create.Font = new System.Drawing.Font("Algerian", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.create.ForeColor = System.Drawing.Color.White;
            this.create.Location = new System.Drawing.Point(47, 167);
            this.create.Name = "create";
            this.create.Size = new System.Drawing.Size(218, 55);
            this.create.TabIndex = 6;
            this.create.Text = "Create Server";
            this.create.UseVisualStyleBackColor = false;
            this.create.Visible = false;
            this.create.Click += new System.EventHandler(this.create_Click);
            // 
            // ip
            // 
            this.ip.BackColor = System.Drawing.Color.White;
            this.ip.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ip.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ip.Location = new System.Drawing.Point(47, 179);
            this.ip.Name = "ip";
            this.ip.Size = new System.Drawing.Size(190, 31);
            this.ip.TabIndex = 7;
            this.ip.Visible = false;
            // 
            // port
            // 
            this.port.BackColor = System.Drawing.Color.White;
            this.port.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.port.ForeColor = System.Drawing.SystemColors.WindowText;
            this.port.Location = new System.Drawing.Point(53, 284);
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(190, 31);
            this.port.TabIndex = 8;
            this.port.Visible = false;
            // 
            // porttext
            // 
            this.porttext.AutoSize = true;
            this.porttext.BackColor = System.Drawing.Color.Transparent;
            this.porttext.Font = new System.Drawing.Font("Century Schoolbook", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.porttext.ForeColor = System.Drawing.Color.White;
            this.porttext.Location = new System.Drawing.Point(47, 236);
            this.porttext.Name = "porttext";
            this.porttext.Size = new System.Drawing.Size(70, 33);
            this.porttext.TabIndex = 9;
            this.porttext.Text = "Port";
            this.porttext.Visible = false;
            this.porttext.Click += new System.EventHandler(this.iptext_Click);
            // 
            // iptext
            // 
            this.iptext.AutoSize = true;
            this.iptext.BackColor = System.Drawing.Color.Transparent;
            this.iptext.Font = new System.Drawing.Font("Century Schoolbook", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iptext.ForeColor = System.Drawing.Color.White;
            this.iptext.Location = new System.Drawing.Point(41, 143);
            this.iptext.Name = "iptext";
            this.iptext.Size = new System.Drawing.Size(42, 33);
            this.iptext.TabIndex = 10;
            this.iptext.Text = "Ip";
            this.iptext.Visible = false;
            // 
            // createserv
            // 
            this.createserv.BackColor = System.Drawing.Color.Black;
            this.createserv.Font = new System.Drawing.Font("Algerian", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createserv.ForeColor = System.Drawing.Color.White;
            this.createserv.Location = new System.Drawing.Point(47, 344);
            this.createserv.Name = "createserv";
            this.createserv.Size = new System.Drawing.Size(218, 55);
            this.createserv.TabIndex = 11;
            this.createserv.Text = "Create Server";
            this.createserv.UseVisualStyleBackColor = false;
            this.createserv.Visible = false;
            this.createserv.Click += new System.EventHandler(this.createserv_Click);
            // 
            // connectserver
            // 
            this.connectserver.BackColor = System.Drawing.Color.Black;
            this.connectserver.Font = new System.Drawing.Font("Algerian", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectserver.ForeColor = System.Drawing.Color.White;
            this.connectserver.Location = new System.Drawing.Point(47, 344);
            this.connectserver.Name = "connectserver";
            this.connectserver.Size = new System.Drawing.Size(218, 55);
            this.connectserver.TabIndex = 12;
            this.connectserver.Text = "Connect Server";
            this.connectserver.UseVisualStyleBackColor = false;
            this.connectserver.Visible = false;
            this.connectserver.Click += new System.EventHandler(this.connectserver_Click);
            // 
            // back2
            // 
            this.back2.BackColor = System.Drawing.Color.Black;
            this.back2.Font = new System.Drawing.Font("Algerian", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back2.ForeColor = System.Drawing.Color.White;
            this.back2.Location = new System.Drawing.Point(85, 439);
            this.back2.Name = "back2";
            this.back2.Size = new System.Drawing.Size(137, 55);
            this.back2.TabIndex = 13;
            this.back2.Text = "Back";
            this.back2.UseVisualStyleBackColor = false;
            this.back2.Visible = false;
            this.back2.Click += new System.EventHandler(this.back2_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Janggi.Properties.Resources.fundal;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(306, 534);
            this.Controls.Add(this.back2);
            this.Controls.Add(this.connectserver);
            this.Controls.Add(this.createserv);
            this.Controls.Add(this.iptext);
            this.Controls.Add(this.porttext);
            this.Controls.Add(this.port);
            this.Controls.Add(this.ip);
            this.Controls.Add(this.create);
            this.Controls.Add(this.connect);
            this.Controls.Add(this.back1);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.player2);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.player1);
            this.Name = "Menu";
            this.Text = "Menu";
           
            this.Load += new System.EventHandler(this.Menu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button player1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Button player2;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.Button back1;
        private System.Windows.Forms.Button connect;
        private System.Windows.Forms.Button create;
        private System.Windows.Forms.TextBox ip;
        private System.Windows.Forms.TextBox port;
        private System.Windows.Forms.Label porttext;
        private System.Windows.Forms.Label iptext;
        private System.Windows.Forms.Button createserv;
        private System.Windows.Forms.Button connectserver;
        private System.Windows.Forms.Button back2;
    }
}