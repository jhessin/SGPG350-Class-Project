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
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ServerTicTacToe
{
	public delegate void ProgressDelegate(string msg);
	
//------------------------------------------------------------------------
// Name:  Server
//
// Description: The server that handles negotiating the connection with each client and communication between them.
//
//---------------------------------------------------------------------------
	public class Server
	{
		// The variables used to differentiate between clients
		private int _port1 = 0;
		private int _port2 = 0;
		private TcpClient _client1;
		private readonly GameMark _symbol1 = GameMark.X;
		private readonly GameMark _symbol2 = GameMark.O;
		private TcpClient _client2;

		// Client threads
		private BackgroundWorker _connectionListener;
		private BackgroundWorker _msgListener;

		// Client Flags
		private bool _client1Connected;
		private bool _client2Connected;
		private int _connectionPort;

		// The game itself
		private Game _game;

		// Is the server active (are 
		public bool Active { get; private set; }
		private readonly ProgressDelegate Progress;

		public Server(ProgressDelegate callback)
		{
			Active = false;

			Progress = callback;

			_msgListener.DoWork += Listen;
			_msgListener.ProgressChanged += GetMessage;

			_connectionListener.DoWork += Connect;
			_connectionListener.RunWorkerCompleted += Connected;
		}

		private void SendToClient(TcpClient client, object msg)
		{
			NetworkStream stream = client.GetStream();
			StreamWriter writer = new StreamWriter(stream);

			writer.Write(msg);
			writer.Flush();
			writer.Close();
			stream.Close();
		}

		// ---- THREAD DELEGATES ----

		// ---- On Worker thread ----
		private void Connect(object sender, DoWorkEventArgs e)
		{
			int port = (int) e.Argument;
			TcpListener listener = new TcpListener(IPAddress.Any, port);
			if (port == _port1)
			{
				e.Result = _client1 = listener.AcceptTcpClient();
				if (_client1.Connected)
				{
					_client1Connected = true;
				}
			}
			else if (port == _port2)
			{
				e.Result = _client2 = listener.AcceptTcpClient();
				if (_client2.Connected)
				{
					_client2Connected = true;
				}
			}
			else
			{
				e.Result = listener.AcceptTcpClient();
			}
		}

		// ---- On worker thread ----
		private void Listen(object sender, DoWorkEventArgs e)
		{
			int port = (int) e.Argument;
			TcpClient client = port == _port1 ? _client1 : _client2;
			StreamReader reader = new StreamReader(client.GetStream());
			_msgListener.ReportProgress(port, reader.ReadLine());
		}

		private void Connected(object sender, RunWorkerCompletedEventArgs e)
		{

			// Runs after a connection is established.
			if (_port1 == 0)
			{
				_client1 = (TcpClient) e.Result;
				_port1 = GetFreePort();
				SendToClient(_client1, _port1);
				_client1.Close();
				_client1 = null;
				_connectionListener.RunWorkerAsync(_port1);
				return;
			}
			if (_port2 == 0)
			{
				_port2 = GetFreePort();
				SendToClient(_client2, _port2);
				_client2.Close();
				_client2 = null;
				_connectionListener.RunWorkerAsync(_port2);
				return;
			}
			if (_client1Connected && !_client2Connected)
			{
				_connectionListener.RunWorkerAsync(_connectionPort);
			}
		}

		private void GetMessage(object sender, ProgressChangedEventArgs e)
		{

			string msg = (string) e.UserState;
			ReadMessage(e.ProgressPercentage, msg);
		}
		// ---- END THREAD DELEGATES ----

		private void ReadMessage(int port, string msg)
		{
			int clientNum = port == _port1 ? 1 : 2;
			TcpClient client = port == _port1 ? _client1 : _client2;

			// Interpret the message
			string cmd = msg.Substring(0, 4);

			switch (cmd)
			{
				case "smbl":
					// Send the client's appropriate symbol.
					if (clientNum == 1)
					{
						SendToClient(client, _symbol1);
					}
					else
					{
						SendToClient(client, _symbol2);
					}
					break;
				case "turn":
					// Send "X" or "O" to signify who's turn it is.
					SendToClient(client, _game.Turn);
					break;
				case "move":
					// Read the move string and make the appropriate adjustments to the game board.
					cmd = msg.Substring(4);
					string[] data = new string[10];
					data = cmd.Split(',');
					_game.Mark(int.Parse(data[0]), int.Parse(data[1]));

					// Send the gameboard to each client - forcing a redraw.
					SendToClient(_client1, _game);
					SendToClient(_client2, _game);
					break;
			}
		}

		private static int GetFreePort()
		{
			TcpListener l = new TcpListener(IPAddress.Loopback, 0);
			l.Start();
			int port = ((IPEndPoint) l.LocalEndpoint).Port;
			l.Stop();
			return port;
		}

		public void Start(int port)
		{
			// Can only be started once.
			if (Active)
			{
				return;
			}

			Active = true;
			_connectionPort = port;

			_connectionListener.RunWorkerAsync(port);

			while (!_client1Connected || !_client2Connected)
			{
				if (Progress != null)
				{
					if (!_client1Connected)
					{
						Progress("Waiting for clients");
					}
					else if (!_client2Connected)
					{
						Progress("Client 1 connected. Waiting for Client 2.");
					}
					else
					{
						Progress("Clients Connected! Starting Game.");
					}
				}
			}


//			client1.RunWorkerAsync();
//			client2.RunWorkerAsync();
		}
	}
}