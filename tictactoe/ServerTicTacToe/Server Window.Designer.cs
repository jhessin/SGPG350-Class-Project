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
			this.btnDisconnect = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnStartListening
			// 
			this.btnStartListening.AutoSize = true;
			this.btnStartListening.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnStartListening.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.btnStartListening.Location = new System.Drawing.Point(10, 15);
			this.btnStartListening.Name = "btnStartListening";
			this.btnStartListening.Padding = new System.Windows.Forms.Padding(10);
			this.btnStartListening.Size = new System.Drawing.Size(264, 43);
			this.btnStartListening.TabIndex = 10;
			this.btnStartListening.Text = "Start Listening";
			this.btnStartListening.UseVisualStyleBackColor = true;
			this.btnStartListening.Click += new System.EventHandler(this.startListening_Click);
			// 
			// btnDisconnect
			// 
			this.btnDisconnect.AutoSize = true;
			this.btnDisconnect.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnDisconnect.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnDisconnect.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.btnDisconnect.Location = new System.Drawing.Point(10, 58);
			this.btnDisconnect.Name = "btnDisconnect";
			this.btnDisconnect.Padding = new System.Windows.Forms.Padding(10);
			this.btnDisconnect.Size = new System.Drawing.Size(264, 43);
			this.btnDisconnect.TabIndex = 11;
			this.btnDisconnect.Text = "Disconnect";
			this.btnDisconnect.UseVisualStyleBackColor = true;
			this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
			// 
			// ServerWindow
			// 
			this.AcceptButton = this.btnStartListening;
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.AutoSize = true;
			this.CancelButton = this.btnDisconnect;
			this.ClientSize = new System.Drawing.Size(284, 111);
			this.Controls.Add(this.btnStartListening);
			this.Controls.Add(this.btnDisconnect);
			this.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.MaximizeBox = false;
			this.Name = "ServerWindow";
			this.Padding = new System.Windows.Forms.Padding(10);
			this.Text = "Server side Tic Tac Toe";
			this.TopMost = true;
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartListening;
        private System.Windows.Forms.Button btnDisconnect;
	}
}

