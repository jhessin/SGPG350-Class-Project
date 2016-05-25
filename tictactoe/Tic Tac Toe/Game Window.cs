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
using Tic_Tac_Toe.TicTacToeService;

namespace Tic_Tac_Toe
{
	public partial class GameWindow : Form, TicTacToeCallback
	{
		private GameBoard _board;
		private bool _bWeHaveAWinner;

		private readonly Client _client;

		// flags

		private bool _connected;

		private int _port;
		private GameMark _playerMark = GameMark.None;
		private GameMark _winner = GameMark.None;
		private GameMark _turnMark = GameMark.X;

		private bool _playing
		{
			get { return _winner == GameMark.None && _playerMark == _turnMark; }
		}

		public GameWindow()
		{
			InitializeComponent();

			_client = new Client(this);
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

			_client.Start();

			btnStart.Enabled = _connected = true;
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
			if (_playing)
			{
				_client.Mark(_playerMark, x, y);
			}
		}

		public void Progress(string format, object[] args)
		{
			lblMessage.Text = string.Format(format, args);
			Trace.TraceInformation(format, args);
		}

		public void SetPlayerMark(GameMark mark)
		{
			_playerMark = mark;
			string strMark = "";

			switch (mark)
			{
				case GameMark.X:
					strMark = "X";
					break;
				case GameMark.O:
					strMark = "O";
					break;
				default:
					strMark = "Error";
					break;
			}
			lblYourSymbol.Text = "You are: " + strMark;
		}

		public void UpdateBoard(GameBoard board)
		{
			_board = board;
			Redraw();
		}

		public void SetTurn(GameMark symbol)
		{
			_turnMark = symbol;
			if (_playerMark == symbol)
			{
				lblYourTurn.Show();
			}
			else
			{
				lblYourTurn.Hide();
			}
		}

		public void Winner(GameMark winMark)
		{
			_winner = winMark;

			string message;
			switch (_winner)
			{
				case GameMark.X:
					MessageBox.Show("Player X Wins!");
					break;
				case GameMark.O:
					MessageBox.Show("Player O Wins!");
					break;
				case GameMark.Draw:
					MessageBox.Show("The Game is a Draw. Play again?");
					break;

			}

		}
	}
}