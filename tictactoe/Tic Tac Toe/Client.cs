// ========================================================
// 
//   File Name:   Client.cs
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
using System.IO;
using System.Net.Sockets;
using System.Threading;
using ServerTicTacToe;

namespace Tic_Tac_Toe
{
//------------------------------------------------------------------------
// Name:  Client
//
// Description: Connects to server and handles all communications.
//
//---------------------------------------------------------------------------
	public class Client
	{
		private readonly ProgressDelegate _progress;
		private bool _canSend;

		// Network Variables
		private TcpClient _client;

		// Threading variables
		private BackgroundWorker _listener;
		private NetworkStream _netStream;
		private int _port;
		private StreamReader _reader;
		private StreamWriter _writer;

		public Client(ProgressDelegate callback)
		{
			_progress = callback;
			IsConnected = false;
			_listener = new BackgroundWorker
			{
				WorkerSupportsCancellation = true,
				WorkerReportsProgress = true
			};
			_listener.DoWork += GetMessage;
			_listener.ProgressChanged += ProcessMessage;
			CurrentGame = new Game();
			PlayerSymbol = GameMark.None;
		}

		// Game variables
		public Game CurrentGame { get; }
		public GameMark PlayerSymbol { get; private set; }
		public bool IsConnected { get; private set; }

		public bool PlayersTurn => PlayerSymbol == CurrentGame.Turn;

		public bool Start(int clientNum)
		{
			if (clientNum < 0 || clientNum >= Server.Ports.Length)
			{
				return false;
			}
			_port = Server.Ports[clientNum];

			_progress("Connecting...");
			try
			{
				Connect();
				return IsConnected;
			}
			catch (Exception)
			{
				return IsConnected;
			}
		}

		private void Connect()
		{
			try
			{
				if (_client == null)
				{
					_client = new TcpClient("localhost", _port);
					_netStream = _client.GetStream();
					_netStream.ReadTimeout = 100;
					_reader = new StreamReader(_netStream);
					_writer = new StreamWriter(_netStream);
					_writer.AutoFlush = true;
					_progress("Connected");
					IsConnected = true;
					_canSend = true;
					Send(Server.GET_PLAYER_SYMBOL);
					StartListener();
				}
			}
			catch (Exception exception)
			{
				_progress("Error Connecting: {0}", exception.Message);
				IsConnected = false;
			}
		}


		public void Stop()
		{
			if (IsConnected)
			{
				_reader?.Close();
				_writer?.Close();
				_netStream?.Close();
				_client?.Close();
				IsConnected = false;
				_listener.CancelAsync();
				_listener = null;
			}
		}

		// --- WORKER THREAD ---
		private void GetMessage(object sender, DoWorkEventArgs e)
		{
			if (!IsConnected) return;
			while (true)
			{
				try
				{
					_canSend = false;
					_listener.ReportProgress(0, _reader.ReadLine());
					_canSend = true;
					Thread.Sleep(100);
				}
				catch (Exception exception)
				{
					Trace.TraceInformation(exception.Message);
				}
				finally
				{
					_canSend = true;
					Thread.Sleep(100);
				}
				if (!_listener.CancellationPending) continue;
				e.Cancel = true;
				break;
			}
		}

		// --- MAIN THREAD ---
		private void ProcessMessage(object sender, ProgressChangedEventArgs e)
		{
			string msg = (string) e.UserState;

			switch (msg.Substring(0, Server.COMMAND_LENGTH))
			{
				case Server.REDRAW:
					CurrentGame.LoadFromString(msg.Substring(Server.COMMAND_LENGTH));
					_progress("Game Redraw");
					break;
				case Server.GET_PLAYER_SYMBOL:
					PlayerSymbol = Game.MarkFromChar(msg.Substring(Server.COMMAND_LENGTH)[0]);
					_progress("Updated Symbol");
					break;
				case Server.DISCONNECT:
					Stop();
					break;
			}
		}

		private void Send(string msg)
		{
			if (!IsConnected) return;
			while (true)
			{
				if (!_canSend) continue;
				_writer.WriteLine(msg);
				break;
			}
		}

		private void StartListener()
		{
			if (!_listener.IsBusy)
			{
				_listener.RunWorkerAsync();
			}
		}

		public void SendMark(int x, int y)
		{
			Send(Server.MOVE + x + ',' + y);
		}

		public void RestartRequest()
		{
			Send(Server.RESTART_REQUEST);
		}
	}
}