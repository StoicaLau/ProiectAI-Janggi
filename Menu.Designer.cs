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
            this.SuspendLayout();
            // 
            // player1
            // 
            this.player1.BackColor = System.Drawing.Color.Black;
            this.player1.Font = new System.Drawing.Font("Algerian", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player1.ForeColor = System.Drawing.Color.White;
            this.player1.Location = new System.Drawing.Point(85, 168);
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
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Janggi.Properties.Resources.fundal;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(306, 534);
            this.Controls.Add(this.back1);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.player2);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.player1);
            this.Name = "Menu";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.Leave += new System.EventHandler(this.exit_Click);
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
    }
}