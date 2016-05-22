namespace ServerTicTacToe
{
    partial class ServerWindow
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
			this.btnStartListening = new System.Windows.Forms.Button();
			this.lblMessage = new System.Windows.Forms.Label();
			this.btnDisconnect = new System.Windows.Forms.Button();
			this.lblPort = new System.Windows.Forms.Label();
			this.tbPort = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// btnStartListening
			// 
			this.btnStartListening.AutoSize = true;
			this.btnStartListening.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnStartListening.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.btnStartListening.Location = new System.Drawing.Point(10, 82);
			this.btnStartListening.Name = "btnStartListening";
			this.btnStartListening.Padding = new System.Windows.Forms.Padding(10);
			this.btnStartListening.Size = new System.Drawing.Size(284, 43);
			this.btnStartListening.TabIndex = 10;
			this.btnStartListening.Text = "Start Listening";
			this.btnStartListening.UseVisualStyleBackColor = true;
			this.btnStartListening.Click += new System.EventHandler(this.startListening_Click);
			// 
			// lblMessage
			// 
			this.lblMessage.AutoSize = true;
			this.lblMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.lblMessage.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMessage.Location = new System.Drawing.Point(10, 168);
			this.lblMessage.Margin = new System.Windows.Forms.Padding(0);
			this.lblMessage.Name = "lblMessage";
			this.lblMessage.Padding = new System.Windows.Forms.Padding(10);
			this.lblMessage.Size = new System.Drawing.Size(20, 33);
			this.lblMessage.TabIndex = 9;
			this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnDisconnect
			// 
			this.btnDisconnect.AutoSize = true;
			this.btnDisconnect.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnDisconnect.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnDisconnect.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.btnDisconnect.Location = new System.Drawing.Point(10, 125);
			this.btnDisconnect.Name = "btnDisconnect";
			this.btnDisconnect.Padding = new System.Windows.Forms.Padding(10);
			this.btnDisconnect.Size = new System.Drawing.Size(284, 43);
			this.btnDisconnect.TabIndex = 11;
			this.btnDisconnect.Text = "Disconnect";
			this.btnDisconnect.UseVisualStyleBackColor = true;
			this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
			// 
			// lblPort
			// 
			this.lblPort.AutoSize = true;
			this.lblPort.Dock = System.Windows.Forms.DockStyle.Left;
			this.lblPort.Location = new System.Drawing.Point(10, 10);
			this.lblPort.Name = "lblPort";
			this.lblPort.Padding = new System.Windows.Forms.Padding(10, 5, 0, 0);
			this.lblPort.Size = new System.Drawing.Size(39, 18);
			this.lblPort.TabIndex = 12;
			this.lblPort.Text = "Port:";
			this.lblPort.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tbPort
			// 
			this.tbPort.Dock = System.Windows.Forms.DockStyle.Right;
			this.tbPort.Location = new System.Drawing.Point(56, 10);
			this.tbPort.Name = "tbPort";
			this.tbPort.Size = new System.Drawing.Size(238, 20);
			this.tbPort.TabIndex = 13;
			this.tbPort.Text = "34";
			this.tbPort.TextChanged += new System.EventHandler(this.tbPort_TextChanged);
			// 
			// ServerWindow
			// 
			this.AcceptButton = this.btnStartListening;
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.AutoSize = true;
			this.CancelButton = this.btnDisconnect;
			this.ClientSize = new System.Drawing.Size(304, 211);
			this.Controls.Add(this.tbPort);
			this.Controls.Add(this.lblPort);
			this.Controls.Add(this.btnStartListening);
			this.Controls.Add(this.btnDisconnect);
			this.Controls.Add(this.lblMessage);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(320, 250);
			this.MinimumSize = new System.Drawing.Size(320, 250);
			this.Name = "ServerWindow";
			this.Padding = new System.Windows.Forms.Padding(10);
			this.Text = "Server side Tic Tac Toe";
			this.TopMost = true;
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartListening;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnDisconnect;
		private System.Windows.Forms.Label lblPort;
		private System.Windows.Forms.TextBox tbPort;
	}
}

