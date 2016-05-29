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
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

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
		private readonly BackgroundWorker _c1Worker;
		private readonly BackgroundWorker _c2Worker;

		// The game itself
		private readonly Game _game;
		private readonly ProgressDelegate _progress;
		private readonly GameMark _symbol1 = GameMark.X;
		private readonly GameMark _symbol2 = GameMark.O;

		// Network Variables
		private TcpListener _c1Listener;
		private NetworkStream _c1NetStream;
		private TcpListener _c2Listener;
		private NetworkStream _c2NetStream;
		private TcpClient _client1;

		// Client Flags
		private bool _client1Connected;
		private TcpClient _client2;
		private bool _client2Connected;
		private bool _isShuttingDown;
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

			_c1Worker = new BackgroundWorker();
			_c2Worker = new BackgroundWorker();

			_c1Worker.DoWork += Listen;
			_c2Worker.DoWork += Listen;
			_c1Worker.ProgressChanged += ReportProgress;
			_c2Worker.ProgressChanged += ReportProgress;
			_c2Worker.WorkerReportsProgress =
				_c1Worker.WorkerReportsProgress = true;
			_c1Worker.RunWorkerCompleted += WorkerCompleted;
			_c2Worker.RunWorkerCompleted += WorkerCompleted;
		}

		public bool Active { get; private set; }

		public bool IsConnected => _client1Connected && _client2Connected;

		private void WorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
		}

		private void SendToClient(int client, string msg)
		{
			switch (client)
			{
				case 1:
					_writer1.WriteLine(msg);
					_writer1.Flush();
					break;
				case 2:
					_writer2.WriteLine(msg);
					_writer2.Flush();
					break;
			}
		}

		private void SendToOther(int client, string msg)
		{
			SendToClient(client == 1 ? 2 : 1, msg);
		}

		private void SendToAll(string msg)
		{
			SendToClient(1, msg);
			SendToClient(1, msg);
		}


		private void ReportProgress(object sender, ProgressChangedEventArgs e)
		{
			string msg = (string) e.UserState;
			_progress(msg);
		}

		// ---- WORKER THREAD ----
		private void Listen(object sender, DoWorkEventArgs e)
		{
			int clientNum = (int) e.Argument;
			ConnectToClient((BackgroundWorker) sender, e, clientNum);
		}

		// ONLY TO BE RUN ON WORKER THREAD
		private void ConnectToClient(BackgroundWorker worker, DoWorkEventArgs e, int clientNum)
		{
			TcpListener listener;
			TcpClient client;
			NetworkStream netStream;
			StreamReader reader;
			StreamWriter writer;
			bool firstRun = true;
			try
			{
				listener = new TcpListener(IPAddress.Any, clientNum == 1 ? _port1 : _port2);
				listener.Start();
				worker.ReportProgress(3, "Listening for client 1");
				client = listener.AcceptTcpClient();

				switch (clientNum)
				{
					case 1:
						_c1Listener = listener;
						_client1 = client;
						break;
					default:
						_c2Listener = listener;
						_client2 = client;
						break;
				}


				if (client.Connected)
				{
					while (true)
					{
						if (clientNum == 1)
						{
							_client1Connected = false;
						}
						else
						{
							_client2Connected = false;
						}
						listener?.Stop();
						netStream = client.GetStream();
						writer = new StreamWriter(netStream);
						reader = new StreamReader(netStream);
						worker.ReportProgress(1, "Client Connected");
						switch (clientNum)
						{
							case 1:
								_c1NetStream = netStream;
								_reader1 = reader;
								_writer1 = writer;
								_client1Connected = true;
								break;
							default:
								_c2NetStream = netStream;
								_reader2 = reader;
								_writer2 = writer;
								_client2Connected = true;
								break;
						}

						if (worker.CancellationPending)
						{
							e.Cancel = true;
							reader?.Close();
							writer?.Close();
							netStream?.Close();
							break;
						}

						// listen to information received from client 1
						if (PlayerTurn(clientNum) || firstRun)
						{
							ReadMessage(clientNum, reader.ReadLine());
							firstRun = false;
						}
						else
						{
							Thread.Sleep(1000);
						}
					}
				}
			}
			catch (Exception exception)
			{
				worker.ReportProgress(1,
					"Problem creating client listeners.");
				Trace.TraceError("Error: {0}", exception.Message);
			}
		}

		// ONLY TO BE RUN ON WORKER THREAD
		private void ReadMessage(int clientNum, string msg)
		{
			// Interpret the message
			string cmd = msg.Substring(0, COMMAND_LENGTH);

			switch (cmd)
			{
				case RESTART_REQUEST:
					_game.Restart();
					SendToOther(clientNum, REDRAW + _game);
					break;
				case GET_PLAYER_SYMBOL:
					// Send the client's appropriate symbol.
					SendToClient(clientNum, GET_PLAYER_SYMBOL + PlayerMark(clientNum));
					break;
				case MOVE:
					// Read the move string and make the appropriate adjustments to the game board.
					cmd = msg.Substring(COMMAND_LENGTH);
					var data = cmd.Split(',');
					_game.Mark(int.Parse(data[0]), int.Parse(data[1]));

					// Send the gameboard to each client - forcing a redraw.
					SendToAll(REDRAW + _game);
					break;
				case DISCONNECT:
					_isShuttingDown = true;
					break;
			}
		}

		private string PlayerMark(int clientNum)
		{
			return Game.MarkToString(clientNum == 1 ? _symbol1 : _symbol2);
		}

		private bool PlayerTurn(int clientNum)
		{
			return _game.Turn == (clientNum == 1 ? _symbol1 : _symbol2);
		}

		// --- MAIN THREAD ---
		private void Disconnect(int client)
		{
			Active = false;

			SendToClient(client, DISCONNECT);

			switch (client)
			{
				case 1:
					_reader1.Close();
					_writer1.Close();
					_c1NetStream.Close();
					_client1.Close();
					_client1Connected = false;
					if (!_isShuttingDown) StartListen(client);
					break;
				case 2:
					_reader2.Close();
					_writer2.Close();
					_c2NetStream.Close();
					_client2.Close();
					_client2Connected = false;
					if (!_isShuttingDown) StartListen(client);
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
					if (!_c1Worker.IsBusy)
					{
						_c1Worker.RunWorkerAsync(clientNum);
					}
					break;
				case 2:
					if (!_c2Worker.IsBusy)
					{
						_c2Worker.RunWorkerAsync(clientNum);
					}
					break;
				case 3:
					if (!_c1Worker.IsBusy)
					{
						_c1Worker.RunWorkerAsync(clientNum);
					}
					if (!_c2Worker.IsBusy)
					{
						_c2Worker.RunWorkerAsync(clientNum);
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