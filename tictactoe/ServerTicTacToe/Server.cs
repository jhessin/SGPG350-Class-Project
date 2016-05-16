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
//------------------------------------------------------------------------
// Name:  Server
//
// Description: The server that handles negotiating the connection with each client and communication between them.
//
//---------------------------------------------------------------------------
	public class Server
	{
		// Network variables
		private TcpListener _listener;
		private NetworkStream _netStream;
		private StreamReader _reader;
		private StreamWriter _writer;

		// The ports used to differentiate between clients
		private int _port1 = 0;
		private int _port2 = 0;
		private TcpClient _client1;
		private TcpClient _client2;

		// Client threads
		private BackgroundWorker _connectionListener;
		private BackgroundWorker _msgListener;
		private bool _client1Connected;
		private bool _client2Connected;

		// Is the server active
		public bool Active { get; private set; }

		public Server()
		{
			Active = false;

			_msgListener.DoWork += Listen;
			_msgListener.ProgressChanged += GetMessage;

			_connectionListener.DoWork += Connect;
			_connectionListener.RunWorkerCompleted += Connected;
		}

		private void Connect(object sender, DoWorkEventArgs e)
		{
			int port = (int) e.Argument;
			TcpListener listener = new TcpListener(IPAddress.Any, port);
			if (port == _port1)
			{
				e.Result = _client1 = listener.AcceptTcpClient();
			}
			else if (port == _port2)
			{
				e.Result = _client2 = listener.AcceptTcpClient();
			}
			else
			{
				e.Result = listener.AcceptTcpClient();
			}
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
				_listener.Stop();
				_listener = new TcpListener(IPAddress.Any, _port1);
				_listener.Start();
				_connectionListener.RunWorkerAsync(_port1);
				return;
			}
			if (_port2 == 0)
			{
				_port2 = GetFreePort();
				SendToClient(_client2, _port2);
				_client2.Close();
				_client2 = null;
				_listener.Stop();
				_listener = new TcpListener(IPAddress.Any, _port2);
				_listener.Start();
				_connectionListener.RunWorkerAsync(_port2);
				return;
			}
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

		private void Listen(object sender, DoWorkEventArgs e)
		{
			int port = (int) e.Argument;
			TcpClient client = port == _port1 ? _client1 : _client2;
			StreamReader reader = new StreamReader(client.GetStream());
			_msgListener.ReportProgress(port, reader.ReadLine());
		}

		private void GetMessage(object sender, ProgressChangedEventArgs e)
		{

			string msg = (string) e.UserState;
			ReadMessage(e.ProgressPercentage, msg);
		}

		private void ReadMessage(int port, string msg)
		{
			TcpClient client = port == _port1 ? _client1 : _client2;

			// Interpret the message
			string cmd = msg.Substring(0, 4);

			switch (cmd)
			{
				case "smbl":
					// Send the client's appropriate symbol.
					break;
				case "turn":
					// Send "X" or "O" to signify who's turn it is.
					break;
				case "move":
					// Read the move string and make the appropriate adjustments to the game board.
					// Send the gameboard to each client - forcing a redraw.
					break;
			}
		}


		// Message boxes for output
		public Label Msg1 { private get; set; }
		public Label Msg2 { private get; set; }

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
			if (Active)
			{
				return;
			}

			Active = true;

			_listener = new TcpListener(IPAddress.Any, port);
			_listener.Start();


//			client1.RunWorkerAsync();
//			client2.RunWorkerAsync();
		}

		public void Stop()
		{
//			client1.CancelAsync();
//			client2.CancelAsync();
		}

/*		private void ListenToClient(object sender, DoWorkEventArgs e)
		{
			bool isClient1 = sender == client1;
			BackgroundWorker worker = (BackgroundWorker) sender;
			int port;

			try
			{
				// get IP address of server
				IPEndPoint host;
				host = new IPEndPoint(IPAddress.Any, ConnectionPort);


				// assign IP address to listener (_listener)
				if (isClient1)
				{
					_listener = new TcpListener(host);

					// start _listener
					_listener.Start();
				}
				else
				{
					_c2Listener = new TcpListener(host);
					_c2Listener.Start();
				}
				worker.ReportProgress(0, "Listener started.");


				// if new connection received, accept it
				var socketForClient = isClient1 ? _listener.AcceptTcpClient() : _c2Listener.AcceptTcpClient();
				if (socketForClient.Connected)
				{
					// create the _netStream and c1Reader and _writer
					if (isClient1)
					{
						_listener?.Stop();
						_netStream = socketForClient.GetStream();
						_writer = new StreamWriter(_netStream);
					}
					else
					{
						_c2Listener?.Stop();
						_c2NetStream = socketForClient.GetStream();
						_c2Writer = new StreamWriter(_c2NetStream);
					}

					worker.ReportProgress(0, "Streams created");

					// Assign a free port to client1;
					port = GetFreePort();

					host.Port = port;
					if (isClient1)
					{
						_writer.Write(port);
						_writer.Flush();
						_writer.Close();
						_netStream.Close();
						socketForClient.Close();
						_listener.Stop();
						_listener = new TcpListener(host);
						_listener.Start();
					}
					else
					{
						_c2Writer.Write(port);
						_c2Writer.Flush();
						_c2Writer.Close();
						_c2NetStream.Close();
						socketForClient.Close();
						_c2Listener.Stop();
						_c2Listener = new TcpListener(host);
						_c2Listener.Start();
					}
					worker.ReportProgress(0, "Assigned port: " + port);

					// close the connection


					// Reconnect using the detected port
					socketForClient = isClient1 ? _listener.AcceptTcpClient() : _c2Listener.AcceptTcpClient();
					if (socketForClient.Connected)
					{
						while (true)
						{
							if (worker.CancellationPending)
							{
								e.Cancel = true;
								if (isClient1)
								{
									_reader?.Close();
									_writer?.Close();
									_netStream?.Close();
								}
								else
								{
									_c2Reader?.Close();
									_c2Writer?.Close();
									_c2NetStream?.Close();
								}
								break;
							}

							// create the _netStream and c1Reader and _writer
							if (isClient1)
							{
								_listener?.Stop();
								_netStream = socketForClient.GetStream();
								_reader = new StreamReader(_netStream);
								_writer = new StreamWriter(_netStream);
							}
							else
							{
								_c2Listener?.Stop();
								_c2NetStream = socketForClient.GetStream();
								_c2Reader = new StreamReader(_c2NetStream);
								_c2Writer = new StreamWriter(_c2NetStream);
							}

							worker.ReportProgress(0, "Streams created");

							// Assign a free port to client1;

							// listen to information recevied from port assigned to client 1
							string result;
							worker.ReportProgress(0, "Listening to client");
							result = isClient1 ? _reader.ReadLine() : _c2Reader.ReadLine();

							// pass information received from port for client 1 to port for client 2 (using _c2Writer)
							worker.ReportProgress(0, "Message Recieved: " + result);

							if (isClient1)
							{
								_c2Writer.WriteLine(result);
								_c2Writer.Flush();
								_c2Writer.Close();
								worker.ReportProgress(0, "Message sent to client2");
							}
							else
							{
								_writer.WriteLine(result);
								_writer.Flush();
								_writer.Close();
								worker.ReportProgress(0, "Message sent to client1");
							}
						}
					}
				}
				// close socketForClient
				socketForClient.Close();
				worker.ReportProgress(0, "Socket closed");
			}
			catch (Exception exception)
			{
				Trace.TraceError(exception.Message);
			}
		}

		private void ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			if (sender == client1)
			{
				Msg1.Text = (string) e.UserState;
			}
			else
			{
				Msg2.Text = (string) e.UserState;
			}
		}

		private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (sender == client1)
			{
				Msg1.Text = "Disconnected.";
				if (!client2.IsBusy)
				{
					Active = false;
				}
			}
			else
			{
				Msg2.Text = "Disconnected.";
				if (!client1.IsBusy)
				{
					Active = false;
				}
			}
		}*/
	}
}