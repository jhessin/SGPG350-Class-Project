// ========================================================
// 
//   File Name:   Tic Tac Toe.cs
// 
//   Author:  Jim Hessin
// 
//   Course and Assignment:   SGPG440 - Tic Tac Toe
// 
//   Description:  Describe what is contained in the file
// 
// =========================================================

using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
	public partial class TicTacToeWindow : Form
	{
		private bool _boolPlayerTurn = true; // declare a variable for players turn
		private bool _bWeHaveAWinner;
		private TcpClient _client;
		private NetworkStream _netStream;
		private StreamReader _reader;
		private StreamWriter _writer;

		public TicTacToeWindow()
		{
			InitializeComponent();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			// draw grid
			Graphics g = e.Graphics;
			Pen myPen = new Pen(Color.Black, 10);
			//This will draw my Tic Tac Toe Board
			g.DrawLine(myPen, 0, 105, 320, 105);
			g.DrawLine(myPen, 0, 215, 320, 215);
			g.DrawLine(myPen, 105, 0, 105, 320);
			g.DrawLine(myPen, 215, 0, 215, 320);
			base.OnPaint(e);
		}

		private void btnQuit_Click(object sender, EventArgs e)
		{
		}

		private void ResetLabel(Label lbl)
		{
			lbl.Text = " ";
			lbl.Enabled = true;
		}

		private void btnStart_Click(object sender, EventArgs e)
		{
			InitializeBoard();

			if (radO.Checked)
			{
				// listen to server to indicate whether or not X made his move
				// send received information to MakeMove to have it display the proper symbol, then wait for player to make his/her move
			}
		}

		private void InitializeBoard()
		{
			//Clears and Enables Labels
			ResetLabel(lblLeft);
			ResetLabel(lblMiddle);
			ResetLabel(lblRight);
			ResetLabel(lblUpperLeft);
			ResetLabel(lblUpperMiddle);
			ResetLabel(lblUpperRight);
			ResetLabel(lblLowerLeft);
			ResetLabel(lblLowerMiddle);
			ResetLabel(lblLowerRight);
		}

		// Places X or O in the label passed to it
		private void UpdateLabel(Label lbl)
		{
			if (radX.Checked)
			{
				lbl.Text = "X";
			}
			else
			{
				lbl.Text = "O";
			}
			lbl.Enabled = false;
			if (CheckWin())
			{
				CheckWin();
			}
		}

		private void lblUpperLeft_Click(object sender, EventArgs e)
		{
			// display appropriate symbol on screen
			UpdateLabel(lblUpperLeft);
			// send information to server here
			SendInfo(1, 1, GetStringPlayerSymbol());
		}

		// returns a string symbol representing the symbol the user selected
		private string GetStringPlayerSymbol()
		{
			if (radX.Checked)
				return "X";
			return "O";
		}

		private void lblUpperMiddle_Click(object sender, EventArgs e)
		{
			UpdateLabel(lblUpperMiddle);
			SendInfo(1, 2, GetStringPlayerSymbol());
		}

		private void lblUpperRight_Click(object sender, EventArgs e)
		{
			UpdateLabel(lblUpperRight);
			SendInfo(1, 3, GetStringPlayerSymbol());
		}

		private void lblLeft_Click(object sender, EventArgs e)
		{
			UpdateLabel(lblLeft);
			SendInfo(2, 1, GetStringPlayerSymbol());
		}

		private void lblMiddle_Click(object sender, EventArgs e)
		{
			UpdateLabel(lblMiddle);
			SendInfo(2, 2, GetStringPlayerSymbol());
		}

		private void lblRight_Click(object sender, EventArgs e)
		{
			UpdateLabel(lblRight);
			SendInfo(2, 3, GetStringPlayerSymbol());
		}

		private void lblLowerLeft_Click(object sender, EventArgs e)
		{
			UpdateLabel(lblLowerLeft);
			SendInfo(3, 1, GetStringPlayerSymbol());
		}

		private void lblLowerMiddle_Click(object sender, EventArgs e)
		{
			UpdateLabel(lblLowerMiddle);
			SendInfo(3, 2, GetStringPlayerSymbol());
		}

		private void lblLowerRight_Click(object sender, EventArgs e)
		{
			UpdateLabel(lblLowerRight);
			SendInfo(3, 3, GetStringPlayerSymbol());
		}

		// this procedure checks if we have a winner. A winner is determined by 

		// having three same symbols either accross the board, or on one of its sides

		protected bool CheckWin()
		{
			//This will check to see it there is a winner with X's, O's, or a draw

			if (lblLeft.Text == "X" && lblMiddle.Text == "X" && lblRight.Text == "X" ||
			    lblUpperLeft.Text == "X" && lblUpperMiddle.Text == "X" && lblUpperRight.Text == "X" ||
			    lblLowerLeft.Text == "X" && lblLowerMiddle.Text == "X" && lblLowerRight.Text == "X" ||
			    lblLeft.Text == "X" && lblUpperLeft.Text == "X" && lblLowerLeft.Text == "X" ||
			    lblMiddle.Text == "X" && lblUpperMiddle.Text == "X" && lblLowerMiddle.Text == "X" ||
			    lblRight.Text == "X" && lblUpperRight.Text == "X" && lblLowerRight.Text == "X" ||
			    lblUpperLeft.Text == "X" && lblMiddle.Text == "X" && lblLowerRight.Text == "X" ||
			    lblUpperRight.Text == "X" && lblMiddle.Text == "X" && lblLowerLeft.Text == "X")
			{
				MessageBox.Show("X is the winnder!!", "Winner", MessageBoxButtons.OK);
				return true;
			}

			if (lblLeft.Text == "O" && lblMiddle.Text == "O" && lblRight.Text == "O" ||
			    lblUpperLeft.Text == "O" && lblUpperMiddle.Text == "O" && lblUpperRight.Text == "O" ||
			    lblLowerLeft.Text == "O" && lblLowerMiddle.Text == "O" && lblLowerRight.Text == "O" ||
			    lblLeft.Text == "O" && lblUpperLeft.Text == "O" && lblLowerLeft.Text == "O" ||
			    lblMiddle.Text == "O" && lblUpperMiddle.Text == "O" && lblLowerMiddle.Text == "O" ||
			    lblRight.Text == "O" && lblUpperRight.Text == "O" && lblLowerRight.Text == "O" ||
			    lblUpperLeft.Text == "O" && lblMiddle.Text == "O" && lblLowerRight.Text == "O" ||
			    lblUpperRight.Text == "O" && lblMiddle.Text == "O" && lblLowerLeft.Text == "O")
			{
				MessageBox.Show("O is the winner!!!", "Winner", MessageBoxButtons.OK);
				return true;
			}
			if ((lblLeft.Text == "O" | lblLeft.Text == "X") &
			    (lblMiddle.Text == "O" | lblMiddle.Text == "X") &
			    (lblRight.Text == "O" | lblRight.Text == "X") &
			    (lblUpperLeft.Text == "O" | lblUpperLeft.Text == "X") &
			    (lblUpperMiddle.Text == "O" | lblUpperMiddle.Text == "X") &
			    (lblUpperRight.Text == "O" | lblUpperRight.Text == "X") &
			    (lblLowerLeft.Text == "O" | lblLowerLeft.Text == "X") &
			    (lblLowerMiddle.Text == "O" | lblLowerMiddle.Text == "X") &
			    (lblLowerRight.Text == "O" | lblLowerRight.Text == "X"))
			{
				MessageBox.Show("Match is a draw!!!", "Winner", MessageBoxButtons.OK);
				return true;
			}
			return false;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			InitializeBoard();
		}

		private void btnConnect_Click(object sender, EventArgs e)
		{
			// setup connections, sockets, streamreader and streamwriter here
			if (_client == null)
			{
				_client = new TcpClient("localhost", int.Parse(txtConnectPort.Text));
				_netStream = _client.GetStream();
				_reader = new StreamReader(_netStream);
				_writer = new StreamWriter(_netStream);

				if (!listenThread.IsBusy)
				{
					listenThread.RunWorkerAsync();
				}
			}
		}

		private void btnDisconnect_Click(object sender, EventArgs e)
		{
			// close all variables, including network Stream, _reader and _writer
			_reader?.Close();
			_writer?.Close();
			_netStream?.Close();
			_client?.Close();
			Application.Exit();
		}

		private void SendInfo(int x, int y, string playerSymbol)
		{
			// send information to server
			_writer?.WriteLine("" + x + "," + y);

			// Flush information
			_writer?.Flush();

			// Listen for a response from the server. Assign response received to response variable
			if (!listenThread.IsBusy)
			{
				listenThread.RunWorkerAsync();
			}
		}

		// This function listens for a response sent through stream reader. Returns response back to caller

		private string ListenForResponse()
		{
			if (_bWeHaveAWinner)
				return "";
			try
			{
				//string outputString;
				// read the data from the host and display it
				{
					// listen for a response from stream reader, then send that response back to caller
				}
			}
			catch
			{
			}
			return "";
		}

		// process data received, make move displaying symbol on screen in appropriate location

		private void MakeMove(string line)
		{
			string[] data = new string[10];
			data = line.Split(',');
			MarkSymbol(int.Parse(data[0]), int.Parse(data[1]));
		}

		private void MarkSymbol(int x, int y)
		{
			if (x == 1 && y == 1)
				MarkClientSymbol(lblUpperLeft);
			else if (x == 1 && y == 2)
				MarkClientSymbol(lblUpperMiddle);
			else if (x == 1 && y == 3)
				MarkClientSymbol(lblUpperRight);
			else if (x == 2 && y == 1)
				MarkClientSymbol(lblLeft);
			else if (x == 2 && y == 2)
				MarkClientSymbol(lblMiddle);
			else if (x == 2 && y == 3)
				MarkClientSymbol(lblRight);
			else if (x == 3 && y == 1)
				MarkClientSymbol(lblLowerLeft);
			else if (x == 3 && y == 2)
				MarkClientSymbol(lblLowerMiddle);
			else if (x == 3 && y == 3)
				MarkClientSymbol(lblLowerRight);
		}

		// this function is called to mark what the opponent move was. If _client O calls it, then an X is displayed on the screen

		// if _client X calls it, then an O is displayed on the screen (representing what _client O move was)

		private void MarkClientSymbol(Label lbl)
		{
			if (radX.Checked)
			{
				lbl.Text = "O"; // mark the opposite of what's checked because we're marking what the other _client checked
			}
			else
			{
				lbl.Text = "X"; // mark the opposite of what's checked because we're marking what the other _client checked
			}
			lbl.Enabled = false;
			if (CheckWin())
			{
				_bWeHaveAWinner = true;
			}
		}

		private void radO_CheckedChanged(object sender, EventArgs e)
		{
			Trace.TraceInformation("Player set to " + (radX.Checked ? "X" : "O"));
			// if O is checked, force the connection socket to 34
			// not required, but guarentees that X and O players are not using the same socket to play
			txtConnectPort.Text = "34";
		}

		private void radX_CheckedChanged(object sender, EventArgs e)
		{
			Trace.TraceInformation("Player set to " + (radX.Checked ? "X" : "O"));
		}

		private void Listen(object sender, System.ComponentModel.DoWorkEventArgs e)
		{
			listenThread.ReportProgress(0, _reader?.ReadLine());
		}

		private void UpdateProgress(object sender, System.ComponentModel.ProgressChangedEventArgs e)
		{
			string response = (string)e.UserState;
			lblMessage.Text = "Message recieved:" + response;
			if (response != "")
				MakeMove(response);
		}
	}
}