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
			this.lblUpperLeft = new System.Windows.Forms.Label();
			this.lblUpperMiddle = new System.Windows.Forms.Label();
			this.lblUpperRight = new System.Windows.Forms.Label();
			this.lblLeft = new System.Windows.Forms.Label();
			this.lblMiddle = new System.Windows.Forms.Label();
			this.lblRight = new System.Windows.Forms.Label();
			this.lblLowerLeft = new System.Windows.Forms.Label();
			this.lblLowerMiddle = new System.Windows.Forms.Label();
			this.lblLowerRight = new System.Windows.Forms.Label();
			this.btnStart = new System.Windows.Forms.Button();
			this.radX = new System.Windows.Forms.RadioButton();
			this.radO = new System.Windows.Forms.RadioButton();
			this.btnConnect = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txtConnectPort = new System.Windows.Forms.TextBox();
			this.lblMessage = new System.Windows.Forms.Label();
			this.btnDisconnect = new System.Windows.Forms.Button();
			this.listenThread = new System.ComponentModel.BackgroundWorker();
			this.SuspendLayout();
			// 
			// lblUpperLeft
			// 
			this.lblUpperLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.lblUpperLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblUpperLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblUpperLeft.Location = new System.Drawing.Point(0, 0);
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
			this.lblUpperMiddle.Location = new System.Drawing.Point(110, 0);
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
			this.lblUpperRight.Location = new System.Drawing.Point(220, 0);
			this.lblUpperRight.Margin = new System.Windows.Forms.Padding(5);
			this.lblUpperRight.Name = "lblUpperRight";
			this.lblUpperRight.Size = new System.Drawing.Size(100, 100);
			this.lblUpperRight.TabIndex = 2;
			this.lblUpperRight.Text = "X";
			this.lblUpperRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblUpperRight.Click += new System.EventHandler(this.lblUpperRight_Click);
			// 
			// lblLeft
			// 
			this.lblLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.lblLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblLeft.Location = new System.Drawing.Point(0, 110);
			this.lblLeft.Margin = new System.Windows.Forms.Padding(5);
			this.lblLeft.Name = "lblLeft";
			this.lblLeft.Size = new System.Drawing.Size(100, 100);
			this.lblLeft.TabIndex = 3;
			this.lblLeft.Text = "X";
			this.lblLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblLeft.Click += new System.EventHandler(this.lblLeft_Click);
			// 
			// lblMiddle
			// 
			this.lblMiddle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.lblMiddle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblMiddle.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMiddle.Location = new System.Drawing.Point(110, 110);
			this.lblMiddle.Margin = new System.Windows.Forms.Padding(5);
			this.lblMiddle.Name = "lblMiddle";
			this.lblMiddle.Size = new System.Drawing.Size(100, 100);
			this.lblMiddle.TabIndex = 4;
			this.lblMiddle.Text = "X";
			this.lblMiddle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblMiddle.Click += new System.EventHandler(this.lblMiddle_Click);
			// 
			// lblRight
			// 
			this.lblRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.lblRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblRight.Location = new System.Drawing.Point(220, 110);
			this.lblRight.Margin = new System.Windows.Forms.Padding(5);
			this.lblRight.Name = "lblRight";
			this.lblRight.Size = new System.Drawing.Size(100, 100);
			this.lblRight.TabIndex = 5;
			this.lblRight.Text = "O";
			this.lblRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblRight.Click += new System.EventHandler(this.lblRight_Click);
			// 
			// lblLowerLeft
			// 
			this.lblLowerLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.lblLowerLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblLowerLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblLowerLeft.Location = new System.Drawing.Point(0, 220);
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
			this.lblLowerMiddle.Location = new System.Drawing.Point(110, 220);
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
			this.lblLowerRight.Location = new System.Drawing.Point(220, 220);
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
			this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnStart.Location = new System.Drawing.Point(110, 361);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(100, 35);
			this.btnStart.TabIndex = 9;
			this.btnStart.Text = "Start";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// radX
			// 
			this.radX.AutoSize = true;
			this.radX.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.radX.Location = new System.Drawing.Point(42, 331);
			this.radX.Name = "radX";
			this.radX.Size = new System.Drawing.Size(39, 24);
			this.radX.TabIndex = 15;
			this.radX.Text = "X";
			this.radX.UseVisualStyleBackColor = true;
			this.radX.CheckedChanged += new System.EventHandler(this.radX_CheckedChanged);
			// 
			// radO
			// 
			this.radO.AutoSize = true;
			this.radO.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.radO.Location = new System.Drawing.Point(215, 330);
			this.radO.Name = "radO";
			this.radO.Size = new System.Drawing.Size(40, 24);
			this.radO.TabIndex = 16;
			this.radO.Text = "O";
			this.radO.UseVisualStyleBackColor = true;
			this.radO.CheckedChanged += new System.EventHandler(this.radO_CheckedChanged);
			// 
			// btnConnect
			// 
			this.btnConnect.Location = new System.Drawing.Point(151, 409);
			this.btnConnect.Name = "btnConnect";
			this.btnConnect.Size = new System.Drawing.Size(76, 35);
			this.btnConnect.TabIndex = 17;
			this.btnConnect.Text = "Connect";
			this.btnConnect.UseVisualStyleBackColor = true;
			this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(2, 419);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(77, 13);
			this.label1.TabIndex = 18;
			this.label1.Text = "Connet to port:";
			// 
			// txtConnectPort
			// 
			this.txtConnectPort.Location = new System.Drawing.Point(85, 417);
			this.txtConnectPort.Name = "txtConnectPort";
			this.txtConnectPort.Size = new System.Drawing.Size(43, 20);
			this.txtConnectPort.TabIndex = 19;
			this.txtConnectPort.Text = "33";
			// 
			// lblMessage
			// 
			this.lblMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.lblMessage.Cursor = System.Windows.Forms.Cursors.AppStarting;
			this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMessage.Location = new System.Drawing.Point(5, 456);
			this.lblMessage.Name = "lblMessage";
			this.lblMessage.Size = new System.Drawing.Size(315, 23);
			this.lblMessage.TabIndex = 20;
			this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnDisconnect
			// 
			this.btnDisconnect.Location = new System.Drawing.Point(234, 409);
			this.btnDisconnect.Name = "btnDisconnect";
			this.btnDisconnect.Size = new System.Drawing.Size(75, 35);
			this.btnDisconnect.TabIndex = 21;
			this.btnDisconnect.Text = "Disconnect";
			this.btnDisconnect.UseVisualStyleBackColor = true;
			this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
			// 
			// listenThread
			// 
			this.listenThread.WorkerReportsProgress = true;
			this.listenThread.WorkerSupportsCancellation = true;
			this.listenThread.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Listen);
			this.listenThread.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.UpdateProgress);
			// 
			// TicTacToeWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.ClientSize = new System.Drawing.Size(321, 482);
			this.Controls.Add(this.btnDisconnect);
			this.Controls.Add(this.lblMessage);
			this.Controls.Add(this.txtConnectPort);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnConnect);
			this.Controls.Add(this.radO);
			this.Controls.Add(this.radX);
			this.Controls.Add(this.btnStart);
			this.Controls.Add(this.lblLowerRight);
			this.Controls.Add(this.lblLowerMiddle);
			this.Controls.Add(this.lblLowerLeft);
			this.Controls.Add(this.lblRight);
			this.Controls.Add(this.lblMiddle);
			this.Controls.Add(this.lblLeft);
			this.Controls.Add(this.lblUpperRight);
			this.Controls.Add(this.lblUpperMiddle);
			this.Controls.Add(this.lblUpperLeft);
			this.Name = "TicTacToeWindow";
			this.Text = "Tic Tac Toe";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUpperLeft;
        private System.Windows.Forms.Label lblUpperMiddle;
        private System.Windows.Forms.Label lblUpperRight;
        private System.Windows.Forms.Label lblLeft;
        private System.Windows.Forms.Label lblMiddle;
        private System.Windows.Forms.Label lblRight;
        private System.Windows.Forms.Label lblLowerLeft;
        private System.Windows.Forms.Label lblLowerMiddle;
        private System.Windows.Forms.Label lblLowerRight;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.RadioButton radX;
        private System.Windows.Forms.RadioButton radO;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtConnectPort;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnDisconnect;
		private System.ComponentModel.BackgroundWorker listenThread;
	}
}

