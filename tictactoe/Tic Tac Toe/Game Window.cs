// ========================================================
// 
//   File Name:   Game Window.cs
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
using System.Threading;
using System.Windows.Forms;
using Tic_Tac_Toe.ServiceReference1;

namespace Tic_Tac_Toe
{
	public partial class GameWindow : Form
	{
		private GameBoard _board;
		private bool _bWeHaveAWinner;

		private readonly Client _client;

		// flags

		private bool _connected;

		private int _port;

		public GameWindow()
		{
			InitializeComponent();

			_client = new Client(UpdateProgress);
			_port = 32;
			btnStart.Enabled = _connected = false;
			_board = new GameBoard();
		}

		private void btnConnect_Click(object sender, EventArgs e)
		{
			if (_connected)
			{
				return;
			}

			_client.Start(int.Parse(txtConnectPort.Text));
			btnStart.Enabled = _connected = true;

			lblYourSymbol.Text = "You are: " + _client.GetMark();

			if (_client.YourTurn())
			{
				lblYourTurn.Show();
			}
			else
			{
				lblYourTurn.Hide();
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			// draw grid
			Graphics g = e.Graphics;
			Pen myPen = new Pen(Color.Black, 10);
			//This will draw my Tic Tac Toe Board
			g.DrawLine(myPen, 0, 135, 320, 135);
			g.DrawLine(myPen, 0, 245, 320, 245);
			g.DrawLine(myPen, 105, 30, 105, 350);
			g.DrawLine(myPen, 215, 30, 215, 350);
			base.OnPaint(e);
		}

		private void ResetLabel(Label lbl)
		{
			lbl.Text = " ";
			lbl.Enabled = true;
		}

		private void btnStart_Click(object sender, EventArgs e)
		{
			StartGame();
		}

		private void StartGame()
		{
			InitializeBoard();
			_client?.Reset();
		}

		private void InitializeBoard()
		{
			_client?.Reset();

			//Clears and Enables Labels
			ResetLabel(lblMidLeft);
			ResetLabel(lblMidMid);
			ResetLabel(lblMidRight);
			ResetLabel(lblUpperLeft);
			ResetLabel(lblUpperMiddle);
			ResetLabel(lblUpperRight);
			ResetLabel(lblLowerLeft);
			ResetLabel(lblLowerMiddle);
			ResetLabel(lblLowerRight);
		}

		private void Redraw()
		{
			_board = _client.UpdateBoard();

			lblMidLeft.Text = _board.MidLeft;
			lblMidMid.Text = _board.MidMid;
			lblMidRight.Text = _board.MidRight;
			lblUpperLeft.Text = _board.TopLeft;
			lblUpperMiddle.Text = _board.TopMid;
			lblUpperRight.Text = _board.TopRight;
			lblLowerLeft.Text = _board.BottomLeft;
			lblLowerMiddle.Text = _board.BottomMid;
			lblLowerRight.Text = _board.BottomRight;
		}

		private void lblUpperLeft_Click(object sender, EventArgs e)
		{
			// send information to server here
			SendInfo(1, 1);
		}

		// returns a string symbol representing the symbol the user selected

		private void lblUpperMiddle_Click(object sender, EventArgs e)
		{
			SendInfo(1, 2);
		}

		private void lblUpperRight_Click(object sender, EventArgs e)
		{
			SendInfo(1, 3);
		}

		private void lblLeft_Click(object sender, EventArgs e)
		{
			SendInfo(2, 1);
		}

		private void lblMiddle_Click(object sender, EventArgs e)
		{
			SendInfo(2, 2);
		}

		private void lblRight_Click(object sender, EventArgs e)
		{
			SendInfo(2, 3);
		}

		private void lblLowerLeft_Click(object sender, EventArgs e)
		{
			SendInfo(3, 1);
		}

		private void lblLowerMiddle_Click(object sender, EventArgs e)
		{
			SendInfo(3, 2);
		}

		private void lblLowerRight_Click(object sender, EventArgs e)
		{
			SendInfo(3, 3);
		}

		// this procedure checks if we have a winner. A winner is determined by 

		// having three same symbols either accross the board, or on one of its sides

		protected bool CheckWin()
		{
			//This will check to see it there is a winner with X's, O's, or a draw

			switch (_client.Winner())
			{
				case GameMark.X:
				case GameMark.O:
					return true;
				default:
					return false;
			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			InitializeBoard();
		}

		private void btnDisconnect_Click(object sender, EventArgs e)
		{
			_client?.Stop();
			btnStart.Enabled = false;
			Application.Exit();
		}

		private void SendInfo(int x, int y)
		{
			if (_client.YourTurn())
			{
				_client.Mark(x, y);
				Redraw();
				while (!_client.YourTurn())
				{
					Thread.Sleep(1000);
				}

				Redraw();
			}
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
				MarkOponentSymbol(lblUpperLeft);
			else if (x == 1 && y == 2)
				MarkOponentSymbol(lblUpperMiddle);
			else if (x == 1 && y == 3)
				MarkOponentSymbol(lblUpperRight);
			else if (x == 2 && y == 1)
				MarkOponentSymbol(lblMidLeft);
			else if (x == 2 && y == 2)
				MarkOponentSymbol(lblMidMid);
			else if (x == 2 && y == 3)
				MarkOponentSymbol(lblMidRight);
			else if (x == 3 && y == 1)
				MarkOponentSymbol(lblLowerLeft);
			else if (x == 3 && y == 2)
				MarkOponentSymbol(lblLowerMiddle);
			else if (x == 3 && y == 3)
				MarkOponentSymbol(lblLowerRight);
		}

		// this function is called to mark what the opponent move was. If _client O calls it, then an X is displayed on the screen

		// if _client X calls it, then an O is displayed on the screen (representing what _client O move was)

		private void MarkOponentSymbol(Label lbl)
		{
			lbl.Text = _client.GetOponentMark();
			lbl.Enabled = false;
			if (CheckWin())
			{
				_bWeHaveAWinner = true;
			}
		}

		private void UpdateProgress(string format, params object[] args)
		{
			lblMessage.Text = string.Format(format, args);
			Trace.TraceInformation(format, args);
		}

		private void txtConnectPort_TextChanged(object sender, EventArgs e)
		{
			try
			{
				_port = int.Parse(txtConnectPort.Text);
				txtConnectPort.Text = _port.ToString();
			}
			catch (Exception)
			{
				txtConnectPort.Text = _port.ToString();
			}
		}
	}
}