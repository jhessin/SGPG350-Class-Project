﻿namespace ServerTicTacToe
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
			this.txtClient1Port = new System.Windows.Forms.TextBox();
			this.lblClient1Port = new System.Windows.Forms.Label();
			this.txtClient2Port = new System.Windows.Forms.TextBox();
			this.lblMessage1 = new System.Windows.Forms.Label();
			this.lblClient2Port = new System.Windows.Forms.Label();
			this.btnDisconnect = new System.Windows.Forms.Button();
			this.client1 = new System.ComponentModel.BackgroundWorker();
			this.client2 = new System.ComponentModel.BackgroundWorker();
			this.lblMessage2 = new System.Windows.Forms.Label();
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.SuspendLayout();
			// 
			// btnStartListening
			// 
			this.btnStartListening.Location = new System.Drawing.Point(55, 129);
			this.btnStartListening.Name = "btnStartListening";
			this.btnStartListening.Size = new System.Drawing.Size(186, 33);
			this.btnStartListening.TabIndex = 0;
			this.btnStartListening.Text = "Start Listening";
			this.btnStartListening.UseVisualStyleBackColor = true;
			this.btnStartListening.Click += new System.EventHandler(this.startListening_Click);
			// 
			// txtClient1Port
			// 
			this.txtClient1Port.Location = new System.Drawing.Point(173, 42);
			this.txtClient1Port.Name = "txtClient1Port";
			this.txtClient1Port.Size = new System.Drawing.Size(41, 20);
			this.txtClient1Port.TabIndex = 4;
			this.txtClient1Port.Text = "33";
			this.txtClient1Port.TextChanged += new System.EventHandler(this.txtClient1Port_TextChanged);
			// 
			// lblClient1Port
			// 
			this.lblClient1Port.AutoSize = true;
			this.lblClient1Port.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblClient1Port.Location = new System.Drawing.Point(15, 45);
			this.lblClient1Port.Name = "lblClient1Port";
			this.lblClient1Port.Size = new System.Drawing.Size(152, 13);
			this.lblClient1Port.TabIndex = 3;
			this.lblClient1Port.Text = "Listen to Client 1 on Port:";
			// 
			// txtClient2Port
			// 
			this.txtClient2Port.Location = new System.Drawing.Point(173, 68);
			this.txtClient2Port.Name = "txtClient2Port";
			this.txtClient2Port.Size = new System.Drawing.Size(41, 20);
			this.txtClient2Port.TabIndex = 8;
			this.txtClient2Port.Text = "34";
			this.txtClient2Port.TextChanged += new System.EventHandler(this.txtClient2Port_TextChanged);
			// 
			// lblMessage1
			// 
			this.lblMessage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.lblMessage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMessage1.Location = new System.Drawing.Point(15, 242);
			this.lblMessage1.Name = "lblMessage1";
			this.lblMessage1.Size = new System.Drawing.Size(250, 23);
			this.lblMessage1.TabIndex = 9;
			this.lblMessage1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblClient2Port
			// 
			this.lblClient2Port.AutoSize = true;
			this.lblClient2Port.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblClient2Port.Location = new System.Drawing.Point(15, 71);
			this.lblClient2Port.Name = "lblClient2Port";
			this.lblClient2Port.Size = new System.Drawing.Size(152, 13);
			this.lblClient2Port.TabIndex = 10;
			this.lblClient2Port.Text = "Listen to Client 2 on Port:";
			// 
			// btnDisconnect
			// 
			this.btnDisconnect.Location = new System.Drawing.Point(55, 183);
			this.btnDisconnect.Name = "btnDisconnect";
			this.btnDisconnect.Size = new System.Drawing.Size(186, 34);
			this.btnDisconnect.TabIndex = 11;
			this.btnDisconnect.Text = "Disconnect";
			this.btnDisconnect.UseVisualStyleBackColor = true;
			this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
			// 
			// client1
			// 
			this.client1.WorkerReportsProgress = true;
			this.client1.WorkerSupportsCancellation = true;
			this.client1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ListenToClient);
			this.client1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.ProgressChanged);
			this.client1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.WorkerCompleted);
			// 
			// client2
			// 
			this.client2.WorkerReportsProgress = true;
			this.client2.WorkerSupportsCancellation = true;
			this.client2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ListenToClient);
			this.client2.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.ProgressChanged);
			this.client2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.WorkerCompleted);
			// 
			// lblMessage2
			// 
			this.lblMessage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.lblMessage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMessage2.Location = new System.Drawing.Point(15, 276);
			this.lblMessage2.Name = "lblMessage2";
			this.lblMessage2.Size = new System.Drawing.Size(250, 23);
			this.lblMessage2.TabIndex = 12;
			this.lblMessage2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// ServerWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(298, 313);
			this.Controls.Add(this.lblMessage2);
			this.Controls.Add(this.btnDisconnect);
			this.Controls.Add(this.lblClient2Port);
			this.Controls.Add(this.lblMessage1);
			this.Controls.Add(this.txtClient2Port);
			this.Controls.Add(this.txtClient1Port);
			this.Controls.Add(this.lblClient1Port);
			this.Controls.Add(this.btnStartListening);
			this.Name = "ServerWindow";
			this.Text = "Server side Tic Tac Toe";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartListening;
        private System.Windows.Forms.TextBox txtClient1Port;
        private System.Windows.Forms.Label lblClient1Port;
        private System.Windows.Forms.TextBox txtClient2Port;
        private System.Windows.Forms.Label lblMessage1;
        private System.Windows.Forms.Label lblClient2Port;
        private System.Windows.Forms.Button btnDisconnect;
		private System.ComponentModel.BackgroundWorker client1;
		private System.ComponentModel.BackgroundWorker client2;
		private System.Windows.Forms.Label lblMessage2;
		private System.ComponentModel.BackgroundWorker backgroundWorker1;
	}
}

