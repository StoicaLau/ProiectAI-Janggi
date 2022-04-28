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
        private void InitializeComponent()
        {
            this.board_panel = new System.Windows.Forms.Panel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.notification = new System.Windows.Forms.ListBox();
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
            this.notification.FormattingEnabled = true;
            this.notification.Location = new System.Drawing.Point(943, 12);
            this.notification.Name = "notification";
            this.notification.Size = new System.Drawing.Size(217, 238);
            this.notification.TabIndex = 1;
            this.notification.SelectedIndexChanged += new System.EventHandler(this.arata_SelectedIndexChanged);
            // 
            // window_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 981);
            this.Controls.Add(this.notification);
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
        public System.Windows.Forms.ListBox notification;
    }
}

