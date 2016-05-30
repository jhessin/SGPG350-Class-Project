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

		// The game itself
		private readonly Game _game;
		private readonly ProgressDelegate _progress;
		private readonly GameMark[] _symbols = {GameMark.X, GameMark.O};

		// Client threads
		private readonly BackgroundWorker[] _listenWorkers = new BackgroundWorker[2];
		private readonly BackgroundWorker[] _sendWorkers = new BackgroundWorker[2];

		// Client Flags
		private readonly bool[] _canSend = {false, false};

		// Network Variables
		private readonly TcpClient[] _clients = new TcpClient[2];
		private readonly bool[] _connected = {false, false};
		private bool _isShuttingDown;
		private readonly NetworkStream[] _netStreams = new NetworkStream[2];
		private static int[] _ports = new int[2];
		public static int[] Ports { get { return _ports; } }
		private readonly StreamReader[] _readers = new StreamReader[2];
		private readonly StreamWriter[] _writers = new StreamWriter[2];

		public Server(ProgressDelegate callback)
		{
			Active = false;

			_progress = callback;
			_game = new Game();

			_listenWorkers[0] = new BackgroundWorker();
			_listenWorkers[1] = new BackgroundWorker();
			_sendWorkers[0] = new BackgroundWorker();
			_sendWorkers[1] = new BackgroundWorker();

			_listenWorkers[0].DoWork += Listen;
			_listenWorkers[1].DoWork += Listen;
			_listenWorkers[0].ProgressChanged += ReportProgress;
			_listenWorkers[1].ProgressChanged += ReportProgress;
			_listenWorkers[0].WorkerReportsProgress =
				_listenWorkers[1].WorkerReportsProgress = true;
			_listenWorkers[0].RunWorkerCompleted += WorkerCompleted;
			_listenWorkers[1].RunWorkerCompleted += WorkerCompleted;

			_sendWorkers[0].DoWork += ReadMessage;
			_sendWorkers[1].DoWork += ReadMessage;
		}

		public bool Active { get; private set; }

		private void WorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
		}

		// ONLY TO BE RUN ON SEND THREAD
		private void SendToClient(int client, string msg)
		{
			while (true)
			{
				if (!_canSend[client]) continue;
				_writers[client].WriteLine(msg);
				_writers[client].Flush();
				break;
			}
		}
		
		// ONLY TO BE RUN ON SEND THREAD
		private void SendToAll(string msg)
		{
			SendToClient(0, msg);
			SendToClient(1, msg);
		}

		// MAIN THREAD
		private void ReportProgress(object sender, ProgressChangedEventArgs e)
		{
			string msg = (string) e.UserState;
			_progress(msg);
		}

		// ---- LISTEN THREAD ----
		private void Listen(object sender, DoWorkEventArgs e)
		{
			int clientNum = (int) e.Argument;
			ConnectToClient((BackgroundWorker) sender, e, clientNum);
		}

		// ONLY TO BE RUN ON LISTEN THREAD
		private void ConnectToClient(BackgroundWorker worker, DoWorkEventArgs e, int clientNum)
		{
			try
			{
				var listener = new TcpListener(IPAddress.Any, _ports[clientNum]);
				listener.Start();
				worker.ReportProgress(3, "Listening for client 1");
				_clients[clientNum] = listener.AcceptTcpClient();

				if (_clients[clientNum].Connected)
				{
					while (true)
					{
						_connected[clientNum] = false;
						listener.Stop();
						_netStreams[clientNum] = _clients[clientNum].GetStream();
						_netStreams[clientNum].ReadTimeout = 100;
						_writers[clientNum] = new StreamWriter(_netStreams[clientNum]);
						_writers[clientNum].AutoFlush = true;
						_readers[clientNum] = new StreamReader(_netStreams[clientNum]);


						if (worker.CancellationPending)
						{
							e.Cancel = true;
							_readers[clientNum].Close();
							_writers[clientNum].Close();
							_netStreams[clientNum].Close();
							break;
						}
						
						_canSend[clientNum] = false;

						try
						{
							_sendWorkers[clientNum].RunWorkerAsync(_readers[clientNum].ReadLine());
						}
						catch (Exception)
						{
							worker.ReportProgress(1, "Client Timeout - retrying...");
						}
						finally
						{
							_canSend[clientNum] = true;
							_writers[clientNum].WriteLine(REDRAW + _game);
							_writers[clientNum].Flush();
							Thread.Sleep(1000);
						}
					}
				}
			}
			catch (Exception)
			{
				worker.ReportProgress(1,"Problem creating client listeners.");
//				Trace.TraceError("Error: {0}", exception.Message);
			}
		}

		// --- SEND THREAD ---
		private void ReadMessage(object sender, DoWorkEventArgs doWorkEventArgs)
		{
			var clientNum = sender == _sendWorkers[0] ? 0 : 1;
			var msg = doWorkEventArgs.Argument as string;
			if (msg == null || msg.Length < COMMAND_LENGTH)
			{
				return;
			}

			// Interpret the message
			var cmd = msg.Substring(0, COMMAND_LENGTH);

			switch (cmd)
			{
				case RESTART_REQUEST:
					_game.Restart();
					SendToAll(REDRAW + _game);
					break;
				case GET_PLAYER_SYMBOL:
					// Send the client's appropriate symbol.
					SendToClient(clientNum, GET_PLAYER_SYMBOL + PlayerMark(clientNum));
					break;
				case MOVE:
					// Read the move string and make the appropriate adjustments to the game board.
					if (_game.Turn != _symbols[clientNum])
					{
						break;
					}
					cmd = msg.Substring(COMMAND_LENGTH);
					var data = cmd.Split(',');
					_game.Mark(int.Parse(data[0]), int.Parse(data[1]));
					break;
				case DISCONNECT:
					_isShuttingDown = true;
					break;
			}
		}

		private string PlayerMark(int clientNum)
		{
			return Game.MarkToString(_symbols[clientNum]);
		}

		// --- MAIN THREAD ---
		private void Disconnect(int client)
		{
			Active = false;

			SendToClient(client, DISCONNECT);

			_readers[client].Close();
			_writers[client].Close();
			_netStreams[client].Close();
			_clients[client].Close();
			_connected[client] = false;
			if (!_isShuttingDown) StartListen(client);
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

			_ports[0] = port1;
			_ports[1] = port2;
			StartListen(0);
			StartListen(1);
		}

		private void StartListen(int clientNum)
		{
			if (!_listenWorkers[clientNum].IsBusy)
			{
				_listenWorkers[clientNum].RunWorkerAsync(clientNum);
			}
		}

		public void Stop()
		{
			Active = _connected[0] = _connected[1] = false;
			_isShuttingDown = true;
			SendToAll(DISCONNECT);
			Disconnect(0);
			Disconnect(1);
		}
	}
}