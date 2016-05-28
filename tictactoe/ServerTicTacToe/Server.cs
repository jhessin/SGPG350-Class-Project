// ========================================================
// 
//   File Name:   Server.cs
// 
//   Author:  Jim Hessin
// 
//   Course and Assignment:   SGPG440 - ServerTicTacToe
// 
//   Description:  Describe what is contained in the file
// 
// =========================================================

using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace ServerTicTacToe
{
	public delegate void ProgressDelegate(string msg, params object[] args);

//------------------------------------------------------------------------
// Name:  Server
//
// Description: The server that handles negotiating the connection with each client and communication between them.
//
//---------------------------------------------------------------------------
	public class Server
	{
		// Constants
		public const int COMMAND_LENGTH = 4;
		public const string RESTART_REQUEST = "CLR ";
		public const string MOVE = "MOV ";
		public const string DISCONNECT = "DISC";
		public const string GET_PLAYER_SYMBOL = "SMBL";
		public const string REDRAW = "DRAW";

		// Client threads
		private readonly BackgroundWorker _client1ConnectListener;
		private readonly BackgroundWorker _client1Listener;
		private readonly BackgroundWorker _client2ConnectListener;
		private readonly BackgroundWorker _client2Listener;

		// The game itself
		private readonly Game _game;
		private readonly ProgressDelegate _progress;
		private readonly GameMark _symbol1 = GameMark.X;
		private readonly GameMark _symbol2 = GameMark.O;
		private TcpClient _client1;

		// Client Flags
		private bool _client1Connected;
		private TcpClient _client2;
		private bool _client2Connected;
		private bool _isShuttingDown;
		private NetworkStream _netStream1;
		private NetworkStream _netStream2;

		// The variables used to differentiate between clients
		private int _port1;
		private int _port2;
		private StreamReader _reader1;
		private StreamReader _reader2;
		private StreamWriter _writer1;
		private StreamWriter _writer2;

		public Server(ProgressDelegate callback)
		{
			Active = false;

			_progress = callback;
			_game = new Game();

			_client1ConnectListener = new BackgroundWorker();
			_client2ConnectListener = new BackgroundWorker();
			_client1Listener = new BackgroundWorker();
			_client2Listener = new BackgroundWorker();

			_client1ConnectListener.DoWork += Connect;
			_client2ConnectListener.DoWork += Connect;
			_client1ConnectListener.ProgressChanged += ReportProgress;
			_client2ConnectListener.ProgressChanged += ReportProgress;
			_client1Listener.DoWork += Listen;
			_client1Listener.ProgressChanged += GetMessage;
			_client1ConnectListener.WorkerReportsProgress =
				_client2ConnectListener.WorkerReportsProgress =
					_client2Listener.WorkerReportsProgress =
						_client1Listener.WorkerReportsProgress = true;
			_client2Listener.DoWork += Listen;
			_client2Listener.ProgressChanged += GetMessage;
		}

		// Is the server active (are 

		public bool Active { get; private set; }

		public bool IsConnected
		{
			get { return _client1Connected && _client2Connected; }
		}

		private void SendToClient(int client, string msg)
		{
			switch (client)
			{
				case 1:
					_writer1.Write(msg);
					_writer1.Flush();
					break;
				case 2:
					_writer2.Write(msg);
					_writer2.Flush();
					break;
			}
		}

		private void SendToOther(int client, string msg)
		{
			if (client == 1)
			{
				SendToClient(2, msg);
			}
			else
			{
				SendToClient(1, msg);
			}
		}

		private void SendToAll(string msg)
		{
			SendToClient(1, msg);
			SendToClient(1, msg);
		}


		// ---- THREAD DELEGATES ----

		// ---- Connection Delegates ----

		private void Connect(object sender, DoWorkEventArgs e)
		{
			int clientNum = (int) e.Argument;
			ConnectToClient(clientNum);
		}

		private void ReportProgress(object sender, ProgressChangedEventArgs e)
		{
			string msg = (string) e.UserState;
			_progress(msg);
		}

		// ---- Listener Delegates ----
		private void Listen(object sender, DoWorkEventArgs e)
		{
			int clientNum = (int) e.Argument;
			if (!Active) return;
			try
			{
				switch (clientNum)
				{
					case 1:
						_client1Listener.ReportProgress(1, _reader1.ReadLine());
						break;
					case 2:
						_client2Listener.ReportProgress(2, _reader2.ReadLine());
						break;
				}
			}
			catch (Exception)
			{
				ConnectToClient(clientNum);
			}
		}

		// ONLY TO BE RUN ON WORKER THREAD
		private void ConnectToClient(int clientNum)
		{
			TcpListener listener = new TcpListener(IPAddress.Any, clientNum == 1 ? _port1 : _port2);
			try
			{
				listener.Start();
				switch (clientNum)
				{
					case 1:
						_client1 = listener.AcceptTcpClient();
						if (_client1.Connected)
						{
							_netStream1 = _client1.GetStream();
							_writer1 = new StreamWriter(_netStream1);
							_reader1 = new StreamReader(_netStream1);
							_client1ConnectListener.ReportProgress(1, "Client 1 Connected");
							_client1Connected = true;
							if (!_client1ConnectListener.IsBusy)
							{
								_client1Listener.RunWorkerAsync(clientNum);
							}
						}
						break;
					case 2:
						_client2 = listener.AcceptTcpClient();
						if (_client2.Connected)
						{
							_netStream2 = _client2.GetStream();
							_writer2 = new StreamWriter(_netStream2);
							_reader2 = new StreamReader(_netStream2);
							_client2ConnectListener.ReportProgress(1, "Client 2 Connected");
							_client2Connected = true;
							if (!_client2ConnectListener.IsBusy)
							{
								_client2Listener.RunWorkerAsync(clientNum);
							}
						}
						break;
				}
			}
			catch (Exception)
			{
				(clientNum == 1 ? _client1ConnectListener : _client2ConnectListener).ReportProgress(1,
					"Problem creating client listeners.");
			}
		}

		private void GetMessage(object sender, ProgressChangedEventArgs e)
		{
			string msg = (string) e.UserState;
			ReadMessage(e.ProgressPercentage, msg);
		}

		// ---- END THREAD DELEGATES ----

		private void ReadMessage(int clientNum, string msg)
		{
			// Interpret the message
			string cmd = msg.Substring(0, COMMAND_LENGTH);

			switch (cmd)
			{
				case RESTART_REQUEST:
					_game.Restart();
					SendToOther(clientNum, REDRAW + _game);
					StartListen(clientNum);
					break;
				case GET_PLAYER_SYMBOL:
					// Send the client's appropriate symbol.
					SendToClient(clientNum, GET_PLAYER_SYMBOL + Game.MarkToString(clientNum == 1 ? _symbol1 : _symbol2));
					StartListen(clientNum);
					break;
				case MOVE:
					// Read the move string and make the appropriate adjustments to the game board.
					cmd = msg.Substring(COMMAND_LENGTH);
					var data = cmd.Split(',');
					_game.Mark(int.Parse(data[0]), int.Parse(data[1]));

					// Send the gameboard to each client - forcing a redraw.
					SendToAll(REDRAW + _game);
					StartListen(3);
					break;
				case DISCONNECT:
					Disconnect(clientNum);
					break;
			}
		}

		private void Disconnect(int client)
		{
			Active = false;

			SendToClient(client, DISCONNECT);

			switch (client)
			{
				case 1:
					_reader1.Close();
					_writer1.Close();
					_netStream1.Close();
					_client1.Close();
					_client1Connected = false;
					if (!_isShuttingDown)
					{
						_client1ConnectListener.RunWorkerAsync(1);
					}
					break;
				case 2:
					_reader2.Close();
					_writer2.Close();
					_netStream2.Close();
					_client2.Close();
					_client2Connected = false;
					if (!_isShuttingDown)
					{
						_client2ConnectListener.RunWorkerAsync(2);
					}
					break;
			}
		}

		public void Start(int port1, int port2)
		{
			// Can only be started once.
			if (Active)
			{
				return;
			}
			Active = true;
			_isShuttingDown = false;

			_port1 = port1;
			_port2 = port2;
			StartListen(1);
			StartListen(2);
		}

		private void StartListen(int clientNum)
		{
			switch (clientNum)
			{
				case 1:
					if (!_client1ConnectListener.IsBusy)
					{
						_client1ConnectListener.RunWorkerAsync(1);
					}
					break;
				case 2:
					if (!_client2ConnectListener.IsBusy)
					{
						_client2ConnectListener.RunWorkerAsync(2);
					}
					break;
				case 3:
					if (!_client1ConnectListener.IsBusy)
					{
						_client1ConnectListener.RunWorkerAsync(1);
					}
					if (!_client2ConnectListener.IsBusy)
					{
						_client2ConnectListener.RunWorkerAsync(2);
					}
					break;
			}
		}

		public void Stop()
		{
			Active = _client1Connected = _client2Connected = false;
			_isShuttingDown = true;
			SendToAll(DISCONNECT);
			Disconnect(1);
			Disconnect(2);
		}
	}
}