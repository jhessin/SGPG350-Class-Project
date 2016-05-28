// ========================================================
// 
//   File Name:   Client Window.cs
// 
//   Author:  Jim Hessin
// 
//   Course and Assignment:   SGPG440 - Tic Tac Toe
// 
//   Description:  Describe what is contained in the file
// 
// =========================================================

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using ServerTicTacToe;
using Tic_Tac_Toe.Properties;

namespace Tic_Tac_Toe
{
	public partial class TicTacToeWindow : Form
	{
		private readonly Client _client;
		private Game _game;
		private bool _gameOver;
		private bool _needsUpdate;
		private bool _playersTurn;
		private GameMark _playerSymbol;

		public TicTacToeWindow()
		{
			InitializeComponent();
			_client = new Client(ShowMessage);
		}

		private void ShowMessage(string msg, params object[] args)
		{
			lblMessage.Text = string.Format(msg, args);
			Trace.TraceInformation(msg, args);
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
			lbl.Text = Resources.BlankSpace;
			lbl.Enabled = true;
		}

		private void Restart_Click(object sender, EventArgs e)
		{
			_client.RestartRequest();
		}

		private void StartGame()
		{
			InitializeBoard();
			_client.RequestSymbol();
			if (!_gameLoop.IsBusy)
			{
				_gameLoop.RunWorkerAsync();
			}
		}

		private void InitializeBoard()
		{
			//Clears and Enables Labels
			ResetLabel(lblMidLeft);
			ResetLabel(lblMidMid);
			ResetLabel(lblMidRight);
			ResetLabel(lblTopLeft);
			ResetLabel(lblTopMid);
			ResetLabel(lblTopRight);
			ResetLabel(lblBottomLeft);
			ResetLabel(lblBottomMid);
			ResetLabel(lblBottomRight);
		}

		// Places X or O in the label passed to it
		private void UpdateBoard()
		{
			if (!_client.IsConnected)
			{
				return;
			}
			string gameString = _game?.ToString();

			lblTopLeft.Text = gameString[0].ToString();
			lblTopMid.Text = gameString[1].ToString();
			lblTopRight.Text = gameString[2].ToString();
			lblMidLeft.Text = gameString[3].ToString();
			lblMidMid.Text = gameString[4].ToString();
			lblMidRight.Text = gameString[5].ToString();
			lblBottomLeft.Text = gameString[6].ToString();
			lblBottomMid.Text = gameString[7].ToString();
			lblBottomRight.Text = gameString[8].ToString();
		}

		// returns a string symbol representing the symbol the user selected

		private void lblUpperLeft_Click(object sender, EventArgs e)
		{
			// display appropriate symbol on screen
			UpdateBoard();
			// send information to server here
			SendInfo(1, 1);
		}

		private void lblUpperMiddle_Click(object sender, EventArgs e)
		{
			SendInfo(1, 2);
			UpdateBoard();
		}

		private void lblUpperRight_Click(object sender, EventArgs e)
		{
			UpdateBoard();
			SendInfo(1, 3);
		}

		private void lblLeft_Click(object sender, EventArgs e)
		{
			UpdateBoard();
			SendInfo(2, 1);
		}

		private void lblMiddle_Click(object sender, EventArgs e)
		{
			UpdateBoard();
			SendInfo(2, 2);
		}

		private void lblRight_Click(object sender, EventArgs e)
		{
			UpdateBoard();
			SendInfo(2, 3);
		}

		private void lblLowerLeft_Click(object sender, EventArgs e)
		{
			UpdateBoard();
			SendInfo(3, 1);
		}

		private void lblLowerMiddle_Click(object sender, EventArgs e)
		{
			UpdateBoard();
			SendInfo(3, 2);
		}

		private void lblLowerRight_Click(object sender, EventArgs e)
		{
			UpdateBoard();
			SendInfo(3, 3);
		}

		// this procedure checks if we have a winner. A winner is determined by 

		// having three same symbols either accross the board, or on one of its sides

		private void Form1_Load(object sender, EventArgs e)
		{
			InitializeBoard();
			btnStart.Enabled = false;
		}

		private void btnConnect_Click(object sender, EventArgs e)
		{
			_client.Start(int.Parse(txtConnectPort.Text));
				Thread.Sleep(1);
			if (_client.IsConnected)
			{
				StartGame();
				btnStart.Enabled = true;
				btnConnect.Enabled = false;
				UpdateSymbol();
			}
			else
			{
				ShowMessage("Waiting for connection");
				BackgroundWorker WaitForConnection = new BackgroundWorker();
				WaitForConnection.DoWork += Connected;
				WaitForConnection.RunWorkerCompleted += ConnectNotify;
				WaitForConnection.RunWorkerAsync();
			}
		}

		private void Connected(object sender, DoWorkEventArgs e)
		{
			while (!_client.IsConnected)
			{
				Thread.Sleep(1000);
			}
				StartGame();
				btnStart.Enabled = true;
				btnConnect.Enabled = false;
				UpdateSymbol();
		}

		private void ConnectNotify(object sender, RunWorkerCompletedEventArgs e)
		{
			ShowMessage("Connected");
		}

		private void OnExit()
		{
			// close all variables, including network Stream, _reader and _writer
			_client.Stop();
			btnStart.Enabled = false;
			btnConnect.Enabled = true;
			Application.Exit();
		}

		private void TicTacToeWindow_FormClosing(object sender, FormClosingEventArgs e)
		{
			OnExit();
		}

		private void btnDisconnect_Click(object sender, EventArgs e)
		{
			OnExit();
		}

		private void SendInfo(int x, int y)
		{
			_client.SendMark(x, y);
		}

		private void NumbersOnly_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == '\b');
		}

		private void UpdateSymbol(object sender, EventArgs e)
		{
			_client.RequestSymbol();
			lblYourSymbol.Text = Resources.YouAre + Game.MarkToString(_client.PlayerSymbol);
			if (_playersTurn)
			{
				lblYourTurn.Show();
			}
			else
			{
				lblYourTurn.Hide();
			}
		}

		private void UpdateSymbol()
		{
			UpdateSymbol(new object(), new EventArgs());
		}

		private void GameLoop(object sender, DoWorkEventArgs e)
		{
			while (!_gameOver)
			{
				_needsUpdate = _game != _client.CurrentGame || _playersTurn != _client.PlayersTurn ||
				               _playerSymbol != _client.PlayerSymbol;
				_game = _client.CurrentGame;
				_playerSymbol = _client.PlayerSymbol;
				_playersTurn = _client.PlayersTurn;
				_gameOver = _game.CheckWin() != GameMark.None;
				if (_needsUpdate)
				{
					_gameLoop.ReportProgress(0);
				}
			}
		}

		private void GameLoopProgress(object sender, ProgressChangedEventArgs e)
		{
			UpdateSymbol();
			UpdateBoard();
		}
	}
}