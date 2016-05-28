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
		// Game variables
		public Game CurrentGame { get; private set; }
		public GameMark PlayerSymbol { get; private set; }

		// Threading variables
		private BackgroundWorker _listener;
		private readonly ProgressDelegate _progress;

		// Network Variables
		private TcpClient _client;
		private int _port;
		private NetworkStream _netStream;
		private StreamReader _reader;
		private StreamWriter _writer;
		public bool IsConnected { get; private set; }

		public bool PlayersTurn => PlayerSymbol == CurrentGame.Turn;

		public Client(ProgressDelegate callback)
		{
			_progress = callback;
			IsConnected = false;
			_listener = new BackgroundWorker {WorkerSupportsCancellation = true};
			_listener.DoWork += GetMessage;
			_listener.ProgressChanged += ProcessMessage;
			CurrentGame = new Game();
			PlayerSymbol = GameMark.None;
		}

		public void Start(int port)
		{
			_port = port;

			_progress("Connecting...");

			Connect();

		}

		private void Connect()
		{
			try
			{
				_client = new TcpClient();
				_client.Connect("localhost", _port);
				_progress("Connected");
				IsConnected = true;
				_netStream = _client.GetStream();
				_reader = new StreamReader(_netStream);

			}
			catch (Exception exception)
			{
				Trace.TraceError("Error Connecting: {0}", exception.Message);
				IsConnected = false;
			}
		}


		public void Stop()
		{
			if (IsConnected)
			{
				IsConnected = false;
				_listener.CancelAsync();
				_listener = null;
				_reader?.Close();
				_writer?.Close();
				_netStream?.Close();
				_client?.Close();
			}
		}

		private void GetMessage(object sender, DoWorkEventArgs e)
		{
			while (IsConnected)
			{
				if (_listener.CancellationPending)
				{
					break;
				}
				try
				{
					_listener.ReportProgress(0, _reader.ReadLine());
				}
				catch (Exception exception)
				{
					Trace.TraceInformation(exception.Message);
				}				// If there is a cancel request alow time for it to take effect.
				Thread.Sleep(100);
			}
		}

		private void ProcessMessage(object sender, ProgressChangedEventArgs e)
		{
			string msg = (string) e.UserState;

			switch (msg.Substring(0, Server.COMMAND_LENGTH))
			{
				case Server.REDRAW:
					CurrentGame = new Game(msg.Substring(Server.COMMAND_LENGTH));
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
			if (IsConnected)
			{
				_writer = new StreamWriter(_netStream);
				_writer.Write(msg);
				_writer.Flush();
				_writer.Close();
				Connect();
				StartListener();
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

		public void RequestSymbol()
		{
			Send(Server.GET_PLAYER_SYMBOL);
		}
	}
}