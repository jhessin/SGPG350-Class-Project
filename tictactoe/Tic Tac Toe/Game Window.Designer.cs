namespace Tic_Tac_Toe
{
    partial class GameWindow
    {
	    /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

	    /// <summary>
	    /// Required method for Designer support - do not modify
	    /// the contents of this method with the code editor.
	    /// </summary>
	    private void InitializeComponent()
	    {
			this.lblYourSymbol = new System.Windows.Forms.Label();
			this.lblUpperLeft = new System.Windows.Forms.Label();
			this.lblUpperMiddle = new System.Windows.Forms.Label();
			this.lblUpperRight = new System.Windows.Forms.Label();
			this.lblMidLeft = new System.Windows.Forms.Label();
			this.lblMidMid = new System.Windows.Forms.Label();
			this.lblMidRight = new System.Windows.Forms.Label();
			this.lblLowerLeft = new System.Windows.Forms.Label();
			this.lblLowerMiddle = new System.Windows.Forms.Label();
			this.lblLowerRight = new System.Windows.Forms.Label();
			this.btnStart = new System.Windows.Forms.Button();
			this.btnConnect = new System.Windows.Forms.Button();
			this.lblMessage = new System.Windows.Forms.Label();
			this.btnDisconnect = new System.Windows.Forms.Button();
			this.File = new System.Windows.Forms.MenuStrip();
			this.Reset = new System.Windows.Forms.ToolStripMenuItem();
			this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.resetGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.lblYourTurn = new System.Windows.Forms.Label();
			this.File.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblYourSymbol
			// 
			this.lblYourSymbol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.lblYourSymbol.Cursor = System.Windows.Forms.Cursors.AppStarting;
			this.lblYourSymbol.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblYourSymbol.Location = new System.Drawing.Point(4, 354);
			this.lblYourSymbol.Name = "lblYourSymbol";
			this.lblYourSymbol.Size = new System.Drawing.Size(95, 23);
			this.lblYourSymbol.TabIndex = 23;
			this.lblYourSymbol.Text = "You are: ";
			this.lblYourSymbol.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblUpperLeft
			// 
			this.lblUpperLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.lblUpperLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblUpperLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblUpperLeft.Location = new System.Drawing.Point(-1, 29);
			this.lblUpperLeft.Margin = new System.Windows.Forms.Padding(5);
			this.lblUpperLeft.Name = "lblUpperLeft";
			this.lblUpperLeft.Size = new System.Drawing.Size(100, 100);
			this.lblUpperLeft.TabIndex = 0;
			this.lblUpperLeft.Text = "X";
			this.lblUpperLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblUpperLeft.Click += new System.EventHandler(this.lblUpperLeft_Click);
			// 
			// lblUpperMiddle
			// 
			this.lblUpperMiddle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.lblUpperMiddle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblUpperMiddle.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblUpperMiddle.Location = new System.Drawing.Point(109, 29);
			this.lblUpperMiddle.Margin = new System.Windows.Forms.Padding(5);
			this.lblUpperMiddle.Name = "lblUpperMiddle";
			this.lblUpperMiddle.Size = new System.Drawing.Size(100, 100);
			this.lblUpperMiddle.TabIndex = 1;
			this.lblUpperMiddle.Text = "O";
			this.lblUpperMiddle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblUpperMiddle.Click += new System.EventHandler(this.lblUpperMiddle_Click);
			// 
			// lblUpperRight
			// 
			this.lblUpperRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.lblUpperRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblUpperRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblUpperRight.Location = new System.Drawing.Point(219, 29);
			this.lblUpperRight.Margin = new System.Windows.Forms.Padding(5);
			this.lblUpperRight.Name = "lblUpperRight";
			this.lblUpperRight.Size = new System.Drawing.Size(100, 100);
			this.lblUpperRight.TabIndex = 2;
			this.lblUpperRight.Text = "X";
			this.lblUpperRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblUpperRight.Click += new System.EventHandler(this.lblUpperRight_Click);
			// 
			// lblMidLeft
			// 
			this.lblMidLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.lblMidLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblMidLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMidLeft.Location = new System.Drawing.Point(-1, 139);
			this.lblMidLeft.Margin = new System.Windows.Forms.Padding(5);
			this.lblMidLeft.Name = "lblMidLeft";
			this.lblMidLeft.Size = new System.Drawing.Size(100, 100);
			this.lblMidLeft.TabIndex = 3;
			this.lblMidLeft.Text = "X";
			this.lblMidLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblMidLeft.Click += new System.EventHandler(this.lblLeft_Click);
			// 
			// lblMidMid
			// 
			this.lblMidMid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.lblMidMid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblMidMid.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMidMid.Location = new System.Drawing.Point(109, 139);
			this.lblMidMid.Margin = new System.Windows.Forms.Padding(5);
			this.lblMidMid.Name = "lblMidMid";
			this.lblMidMid.Size = new System.Drawing.Size(100, 100);
			this.lblMidMid.TabIndex = 4;
			this.lblMidMid.Text = "X";
			this.lblMidMid.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblMidMid.Click += new System.EventHandler(this.lblMiddle_Click);
			// 
			// lblMidRight
			// 
			this.lblMidRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.lblMidRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblMidRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMidRight.Location = new System.Drawing.Point(219, 139);
			this.lblMidRight.Margin = new System.Windows.Forms.Padding(5);
			this.lblMidRight.Name = "lblMidRight";
			this.lblMidRight.Size = new System.Drawing.Size(100, 100);
			this.lblMidRight.TabIndex = 5;
			this.lblMidRight.Text = "O";
			this.lblMidRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblMidRight.Click += new System.EventHandler(this.lblRight_Click);
			// 
			// lblLowerLeft
			// 
			this.lblLowerLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.lblLowerLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblLowerLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblLowerLeft.Location = new System.Drawing.Point(-1, 249);
			this.lblLowerLeft.Margin = new System.Windows.Forms.Padding(5);
			this.lblLowerLeft.Name = "lblLowerLeft";
			this.lblLowerLeft.Size = new System.Drawing.Size(100, 100);
			this.lblLowerLeft.TabIndex = 6;
			this.lblLowerLeft.Text = "X";
			this.lblLowerLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblLowerLeft.Click += new System.EventHandler(this.lblLowerLeft_Click);
			// 
			// lblLowerMiddle
			// 
			this.lblLowerMiddle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.lblLowerMiddle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblLowerMiddle.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblLowerMiddle.Location = new System.Drawing.Point(109, 249);
			this.lblLowerMiddle.Margin = new System.Windows.Forms.Padding(5);
			this.lblLowerMiddle.Name = "lblLowerMiddle";
			this.lblLowerMiddle.Size = new System.Drawing.Size(100, 100);
			this.lblLowerMiddle.TabIndex = 7;
			this.lblLowerMiddle.Text = "O";
			this.lblLowerMiddle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblLowerMiddle.Click += new System.EventHandler(this.lblLowerMiddle_Click);
			// 
			// lblLowerRight
			// 
			this.lblLowerRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.lblLowerRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblLowerRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblLowerRight.Location = new System.Drawing.Point(219, 249);
			this.lblLowerRight.Margin = new System.Windows.Forms.Padding(5);
			this.lblLowerRight.Name = "lblLowerRight";
			this.lblLowerRight.Size = new System.Drawing.Size(100, 100);
			this.lblLowerRight.TabIndex = 8;
			this.lblLowerRight.Text = "O";
			this.lblLowerRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblLowerRight.Click += new System.EventHandler(this.lblLowerRight_Click);
			// 
			// btnStart
			// 
			this.btnStart.Enabled = false;
			this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnStart.Location = new System.Drawing.Point(109, 390);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(100, 35);
			this.btnStart.TabIndex = 9;
			this.btnStart.Text = "Restart";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// btnConnect
			// 
			this.btnConnect.Location = new System.Drawing.Point(12, 438);
			this.btnConnect.Name = "btnConnect";
			this.btnConnect.Size = new System.Drawing.Size(76, 35);
			this.btnConnect.TabIndex = 17;
			this.btnConnect.Text = "Connect";
			this.btnConnect.UseVisualStyleBackColor = true;
			this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
			// 
			// lblMessage
			// 
			this.lblMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.lblMessage.Cursor = System.Windows.Forms.Cursors.AppStarting;
			this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMessage.Location = new System.Drawing.Point(4, 485);
			this.lblMessage.Name = "lblMessage";
			this.lblMessage.Size = new System.Drawing.Size(315, 23);
			this.lblMessage.TabIndex = 20;
			this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnDisconnect
			// 
			this.btnDisconnect.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnDisconnect.Location = new System.Drawing.Point(233, 438);
			this.btnDisconnect.Name = "btnDisconnect";
			this.btnDisconnect.Size = new System.Drawing.Size(75, 35);
			this.btnDisconnect.TabIndex = 21;
			this.btnDisconnect.Text = "Disconnect";
			this.btnDisconnect.UseVisualStyleBackColor = true;
			this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
			// 
			// File
			// 
			this.File.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Reset});
			this.File.Location = new System.Drawing.Point(0, 0);
			this.File.Name = "File";
			this.File.Size = new System.Drawing.Size(321, 24);
			this.File.TabIndex = 22;
			this.File.Text = "menuStrip1";
			// 
			// Reset
			// 
			this.Reset.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem,
            this.resetGameToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
			this.Reset.Name = "Reset";
			this.Reset.Size = new System.Drawing.Size(37, 20);
			this.Reset.Text = "&File";
			// 
			// connectToolStripMenuItem
			// 
			this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
			this.connectToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
			this.connectToolStripMenuItem.Text = "&Connect";
			this.connectToolStripMenuItem.Click += new System.EventHandler(this.btnConnect_Click);
			// 
			// resetGameToolStripMenuItem
			// 
			this.resetGameToolStripMenuItem.Name = "resetGameToolStripMenuItem";
			this.resetGameToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
			this.resetGameToolStripMenuItem.Text = "&Reset Game";
			this.resetGameToolStripMenuItem.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(133, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
			this.exitToolStripMenuItem.Text = "E&xit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.btnDisconnect_Click);
			// 
			// lblYourTurn
			// 
			this.lblYourTurn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.lblYourTurn.Cursor = System.Windows.Forms.Cursors.AppStarting;
			this.lblYourTurn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblYourTurn.Location = new System.Drawing.Point(219, 354);
			this.lblYourTurn.Name = "lblYourTurn";
			this.lblYourTurn.Size = new System.Drawing.Size(100, 23);
			this.lblYourTurn.TabIndex = 24;
			this.lblYourTurn.Text = "YourTurn";
			this.lblYourTurn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// GameWindow
			// 
			this.AcceptButton = this.btnConnect;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.CancelButton = this.btnDisconnect;
			this.ClientSize = new System.Drawing.Size(321, 516);
			this.Controls.Add(this.lblYourTurn);
			this.Controls.Add(this.lblYourSymbol);
			this.Controls.Add(this.btnDisconnect);
			this.Controls.Add(this.lblMessage);
			this.Controls.Add(this.btnConnect);
			this.Controls.Add(this.btnStart);
			this.Controls.Add(this.lblLowerRight);
			this.Controls.Add(this.lblLowerMiddle);
			this.Controls.Add(this.lblLowerLeft);
			this.Controls.Add(this.lblMidRight);
			this.Controls.Add(this.lblMidMid);
			this.Controls.Add(this.lblMidLeft);
			this.Controls.Add(this.lblUpperRight);
			this.Controls.Add(this.lblUpperMiddle);
			this.Controls.Add(this.lblUpperLeft);
			this.Controls.Add(this.File);
			this.MainMenuStrip = this.File;
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(337, 555);
			this.MinimumSize = new System.Drawing.Size(337, 555);
			this.Name = "GameWindow";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Tic Tac Toe";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.File.ResumeLayout(false);
			this.File.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

	    }

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

	    #endregion

        private System.Windows.Forms.Label lblUpperLeft;
        private System.Windows.Forms.Label lblUpperMiddle;
        private System.Windows.Forms.Label lblUpperRight;
        private System.Windows.Forms.Label lblMidLeft;
        private System.Windows.Forms.Label lblMidMid;
        private System.Windows.Forms.Label lblMidRight;
        private System.Windows.Forms.Label lblLowerLeft;
        private System.Windows.Forms.Label lblLowerMiddle;
        private System.Windows.Forms.Label lblLowerRight;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnDisconnect;
		private System.Windows.Forms.MenuStrip File;
		private System.Windows.Forms.ToolStripMenuItem Reset;
		private System.Windows.Forms.ToolStripMenuItem resetGameToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.Label lblYourTurn;
		private System.Windows.Forms.Label lblYourSymbol;
	}
}

