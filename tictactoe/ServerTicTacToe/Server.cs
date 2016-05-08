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
		private TcpListener _c1Listener;
		private NetworkStream _c1NetStream;
		private StreamReader _c1Reader;
		private StreamWriter _c1Writer;

		private TcpListener _c2Listener;
		private NetworkStream _c2NetStream;
		private StreamReader _c2Reader;
		private StreamWriter _c2Writer;

		// Client threads
		private readonly BackgroundWorker client1;
		private readonly BackgroundWorker client2;

		public Server()
		{
			Active = false;

			client1 = new BackgroundWorker();
			client2 = new BackgroundWorker();

			client1.DoWork += ListenToClient;
			client1.ProgressChanged += ProgressChanged;
			client1.RunWorkerCompleted += RunWorkerCompleted;

			client2.DoWork += ListenToClient;
			client2.ProgressChanged += ProgressChanged;
			client2.RunWorkerCompleted += RunWorkerCompleted;
		}

		// Is the server active
		public bool Active { get; private set; }

		// The port to connect to.
		public int ConnectionPort { private get; set; }

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

		public void Start()
		{
			client1.RunWorkerAsync();
			Active = true;
//			client2.RunWorkerAsync();
		}

		public void Stop()
		{
			client1.CancelAsync();
			client2.CancelAsync();
		}

		private void ListenToClient(object sender, DoWorkEventArgs e)
		{
			bool isClient1 = sender == client1;
			BackgroundWorker worker = (BackgroundWorker) sender;
			int port;

			try
			{
				// get IP address of server
				IPEndPoint host;
				host = new IPEndPoint(IPAddress.Any, ConnectionPort);


				// assign IP address to listener (_c1Listener)
				if (isClient1)
				{
					_c1Listener = new TcpListener(host);

					// start _c1Listener
					_c1Listener.Start();
				}
				else
				{
					_c2Listener = new TcpListener(host);
					_c2Listener.Start();
				}
				worker.ReportProgress(0, "Listener started.");


				// if new connection received, accept it
				var socketForClient = isClient1 ? _c1Listener.AcceptTcpClient() : _c2Listener.AcceptTcpClient();
				if (socketForClient.Connected)
				{
					// create the _c1NetStream and c1Reader and _c1Writer
					if (isClient1)
					{
						_c1Listener?.Stop();
						_c1NetStream = socketForClient.GetStream();
						_c1Writer = new StreamWriter(_c1NetStream);
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
						_c1Writer.Write(port);
						_c1Writer.Flush();
						_c1Writer.Close();
						_c1NetStream.Close();
						socketForClient.Close();
						_c1Listener.Stop();
						_c1Listener = new TcpListener(host);
						_c1Listener.Start();
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
					socketForClient = isClient1 ? _c1Listener.AcceptTcpClient() : _c2Listener.AcceptTcpClient();
					if (socketForClient.Connected)
					{
						while (true)
						{
							if (worker.CancellationPending)
							{
								e.Cancel = true;
								if (isClient1)
								{
									_c1Reader?.Close();
									_c1Writer?.Close();
									_c1NetStream?.Close();
								}
								else
								{
									_c2Reader?.Close();
									_c2Writer?.Close();
									_c2NetStream?.Close();
								}
								break;
							}

							// create the _c1NetStream and c1Reader and _c1Writer
							if (isClient1)
							{
								_c1Listener?.Stop();
								_c1NetStream = socketForClient.GetStream();
								_c1Reader = new StreamReader(_c1NetStream);
								_c1Writer = new StreamWriter(_c1NetStream);
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
							result = isClient1 ? _c1Reader.ReadLine() : _c2Reader.ReadLine();

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
								_c1Writer.WriteLine(result);
								_c1Writer.Flush();
								_c1Writer.Close();
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
		}
	}
}