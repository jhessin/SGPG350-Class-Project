namespace Tic_Tac_Toe
{
    partial class TicTacToeWindow
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
			this.lblTopLeft = new System.Windows.Forms.Label();
			this.lblTopMid = new System.Windows.Forms.Label();
			this.lblTopRight = new System.Windows.Forms.Label();
			this.lblMidLeft = new System.Windows.Forms.Label();
			this.lblMidMid = new System.Windows.Forms.Label();
			this.lblMidRight = new System.Windows.Forms.Label();
			this.lblBottomLeft = new System.Windows.Forms.Label();
			this.lblBottomMid = new System.Windows.Forms.Label();
			this.lblBottomRight = new System.Windows.Forms.Label();
			this.btnStart = new System.Windows.Forms.Button();
			this.btnConnect = new System.Windows.Forms.Button();
			this.lblMessage = new System.Windows.Forms.Label();
			this.File = new System.Windows.Forms.MenuStrip();
			this.Reset = new System.Windows.Forms.ToolStripMenuItem();
			this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.resetGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.lblYourSymbol = new System.Windows.Forms.Label();
			this.lblYourTurn = new System.Windows.Forms.Label();
			this._gameLoop = new System.ComponentModel.BackgroundWorker();
			this.label1 = new System.Windows.Forms.Label();
			this.rbO = new System.Windows.Forms.RadioButton();
			this.rbX = new System.Windows.Forms.RadioButton();
			this.File.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblTopLeft
			// 
			this.lblTopLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.lblTopLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblTopLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTopLeft.Location = new System.Drawing.Point(-1, 29);
			this.lblTopLeft.Margin = new System.Windows.Forms.Padding(5);
			this.lblTopLeft.Name = "lblTopLeft";
			this.lblTopLeft.Size = new System.Drawing.Size(100, 100);
			this.lblTopLeft.TabIndex = 0;
			this.lblTopLeft.Text = "X";
			this.lblTopLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblTopLeft.Click += new System.EventHandler(this.lblUpperLeft_Click);
			// 
			// lblTopMid
			// 
			this.lblTopMid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.lblTopMid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblTopMid.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTopMid.Location = new System.Drawing.Point(109, 29);
			this.lblTopMid.Margin = new System.Windows.Forms.Padding(5);
			this.lblTopMid.Name = "lblTopMid";
			this.lblTopMid.Size = new System.Drawing.Size(100, 100);
			this.lblTopMid.TabIndex = 1;
			this.lblTopMid.Text = "O";
			this.lblTopMid.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblTopMid.Click += new System.EventHandler(this.lblUpperMiddle_Click);
			// 
			// lblTopRight
			// 
			this.lblTopRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.lblTopRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblTopRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTopRight.Location = new System.Drawing.Point(219, 29);
			this.lblTopRight.Margin = new System.Windows.Forms.Padding(5);
			this.lblTopRight.Name = "lblTopRight";
			this.lblTopRight.Size = new System.Drawing.Size(100, 100);
			this.lblTopRight.TabIndex = 2;
			this.lblTopRight.Text = "X";
			this.lblTopRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblTopRight.Click += new System.EventHandler(this.lblUpperRight_Click);
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
			// lblBottomLeft
			// 
			this.lblBottomLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.lblBottomLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblBottomLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblBottomLeft.Location = new System.Drawing.Point(-1, 249);
			this.lblBottomLeft.Margin = new System.Windows.Forms.Padding(5);
			this.lblBottomLeft.Name = "lblBottomLeft";
			this.lblBottomLeft.Size = new System.Drawing.Size(100, 100);
			this.lblBottomLeft.TabIndex = 6;
			this.lblBottomLeft.Text = "X";
			this.lblBottomLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblBottomLeft.Click += new System.EventHandler(this.lblLowerLeft_Click);
			// 
			// lblBottomMid
			// 
			this.lblBottomMid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.lblBottomMid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblBottomMid.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblBottomMid.Location = new System.Drawing.Point(109, 249);
			this.lblBottomMid.Margin = new System.Windows.Forms.Padding(5);
			this.lblBottomMid.Name = "lblBottomMid";
			this.lblBottomMid.Size = new System.Drawing.Size(100, 100);
			this.lblBottomMid.TabIndex = 7;
			this.lblBottomMid.Text = "O";
			this.lblBottomMid.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblBottomMid.Click += new System.EventHandler(this.lblLowerMiddle_Click);
			// 
			// lblBottomRight
			// 
			this.lblBottomRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.lblBottomRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblBottomRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblBottomRight.Location = new System.Drawing.Point(219, 249);
			this.lblBottomRight.Margin = new System.Windows.Forms.Padding(5);
			this.lblBottomRight.Name = "lblBottomRight";
			this.lblBottomRight.Size = new System.Drawing.Size(100, 100);
			this.lblBottomRight.TabIndex = 8;
			this.lblBottomRight.Text = "O";
			this.lblBottomRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblBottomRight.Click += new System.EventHandler(this.lblLowerRight_Click);
			// 
			// btnStart
			// 
			this.btnStart.Enabled = false;
			this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnStart.Location = new System.Drawing.Point(209, 397);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(100, 35);
			this.btnStart.TabIndex = 9;
			this.btnStart.Text = "Restart";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.Restart_Click);
			// 
			// btnConnect
			// 
			this.btnConnect.Location = new System.Drawing.Point(209, 438);
			this.btnConnect.Name = "btnConnect";
			this.btnConnect.Size = new System.Drawing.Size(100, 35);
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
			this.resetGameToolStripMenuItem.Click += new System.EventHandler(this.Restart_Click);
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
			// lblYourSymbol
			// 
			this.lblYourSymbol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.lblYourSymbol.Cursor = System.Windows.Forms.Cursors.AppStarting;
			this.lblYourSymbol.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblYourSymbol.Location = new System.Drawing.Point(4, 354);
			this.lblYourSymbol.Name = "lblYourSymbol";
			this.lblYourSymbol.Size = new System.Drawing.Size(95, 23);
			this.lblYourSymbol.TabIndex = 23;
			this.lblYourSymbol.Text = "You Are: U";
			this.lblYourSymbol.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblYourSymbol.Click += new System.EventHandler(this.UpdateSymbol);
			// 
			// lblYourTurn
			// 
			this.lblYourTurn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.lblYourTurn.Cursor = System.Windows.Forms.Cursors.AppStarting;
			this.lblYourTurn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblYourTurn.Location = new System.Drawing.Point(219, 354);
			this.lblYourTurn.Name = "lblYourTurn";
			this.lblYourTurn.Size = new System.Drawing.Size(102, 23);
			this.lblYourTurn.TabIndex = 24;
			this.lblYourTurn.Text = "Your Turn!";
			this.lblYourTurn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// _gameLoop
			// 
			this._gameLoop.WorkerReportsProgress = true;
			this._gameLoop.DoWork += new System.ComponentModel.DoWorkEventHandler(this.GameLoop);
			this._gameLoop.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.GameLoopProgress);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(4, 409);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 13);
			this.label1.TabIndex = 18;
			this.label1.Text = "Desired Symbol";
			// 
			// rbO
			// 
			this.rbO.AutoSize = true;
			this.rbO.Location = new System.Drawing.Point(52, 448);
			this.rbO.Name = "rbO";
			this.rbO.Size = new System.Drawing.Size(33, 17);
			this.rbO.TabIndex = 25;
			this.rbO.Text = "O";
			this.rbO.UseVisualStyleBackColor = true;
			// 
			// rbX
			// 
			this.rbX.AutoSize = true;
			this.rbX.Checked = true;
			this.rbX.Location = new System.Drawing.Point(52, 425);
			this.rbX.Name = "rbX";
			this.rbX.Size = new System.Drawing.Size(32, 17);
			this.rbX.TabIndex = 26;
			this.rbX.TabStop = true;
			this.rbX.Text = "X";
			this.rbX.UseVisualStyleBackColor = true;
			// 
			// TicTacToeWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.ClientSize = new System.Drawing.Size(321, 516);
			this.Controls.Add(this.rbX);
			this.Controls.Add(this.rbO);
			this.Controls.Add(this.lblYourTurn);
			this.Controls.Add(this.lblYourSymbol);
			this.Controls.Add(this.lblMessage);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnConnect);
			this.Controls.Add(this.btnStart);
			this.Controls.Add(this.lblBottomRight);
			this.Controls.Add(this.lblBottomMid);
			this.Controls.Add(this.lblBottomLeft);
			this.Controls.Add(this.lblMidRight);
			this.Controls.Add(this.lblMidMid);
			this.Controls.Add(this.lblMidLeft);
			this.Controls.Add(this.lblTopRight);
			this.Controls.Add(this.lblTopMid);
			this.Controls.Add(this.lblTopLeft);
			this.Controls.Add(this.File);
			this.MainMenuStrip = this.File;
			this.Name = "TicTacToeWindow";
			this.Text = "Tic Tac Toe";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TicTacToeWindow_FormClosing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.File.ResumeLayout(false);
			this.File.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTopLeft;
        private System.Windows.Forms.Label lblTopMid;
        private System.Windows.Forms.Label lblTopRight;
        private System.Windows.Forms.Label lblMidLeft;
        private System.Windows.Forms.Label lblMidMid;
        private System.Windows.Forms.Label lblMidRight;
        private System.Windows.Forms.Label lblBottomLeft;
        private System.Windows.Forms.Label lblBottomMid;
        private System.Windows.Forms.Label lblBottomRight;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lblMessage;
		private System.Windows.Forms.MenuStrip File;
		private System.Windows.Forms.ToolStripMenuItem Reset;
		private System.Windows.Forms.ToolStripMenuItem resetGameToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.Label lblYourSymbol;
		private System.Windows.Forms.Label lblYourTurn;
		private System.ComponentModel.BackgroundWorker _gameLoop;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RadioButton rbO;
		private System.Windows.Forms.RadioButton rbX;
	}
}

