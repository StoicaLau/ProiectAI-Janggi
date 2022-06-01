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
        public void InitializeComponent()
        {
            this.board_panel = new System.Windows.Forms.Panel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            notification = new System.Windows.Forms.ListBox();
            this.send = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // board_panel
            // 
            this.board_panel.AutoSize = true;
            this.board_panel.BackColor = System.Drawing.Color.ForestGreen;
            this.board_panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.board_panel.Location = new System.Drawing.Point(10, 10);
            this.board_panel.Name = "board_panel";
            this.board_panel.Size = new System.Drawing.Size(680, 750);
            this.board_panel.TabIndex = 0;
            this.board_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.board_panel_Paint);
            // 
            // notification
            // 
            notification.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            notification.BorderStyle = System.Windows.Forms.BorderStyle.None;
            notification.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            notification.FormattingEnabled = true;
            notification.ItemHeight = 23;
            notification.Location = new System.Drawing.Point(10, 780);
            notification.Name = "notification";
            notification.Size = new System.Drawing.Size(571, 115);
            notification.TabIndex = 1;
            notification.SelectedIndexChanged += new System.EventHandler(this.arata_SelectedIndexChanged);
            // 
            // send
            // 
            this.send.BackColor = System.Drawing.Color.LimeGreen;
            this.send.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.send.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.send.Location = new System.Drawing.Point(587, 780);
            this.send.Name = "send";
            this.send.Size = new System.Drawing.Size(103, 119);
            this.send.TabIndex = 2;
            this.send.Text = "Send";
            this.send.UseVisualStyleBackColor = false;
            this.send.Click += new System.EventHandler(this.send_Click);
            // 
            // window_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Janggi.Properties.Resources.fundal_sah;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(702, 910);
            this.Controls.Add(this.send);
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
        private System.Windows.Forms.Button send;
        public static System.Windows.Forms.ListBox notification;
    }
}

