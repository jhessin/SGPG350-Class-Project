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
using System.IO;
using System.Net.Sockets;
using System.Runtime.InteropServices;
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
		// Threading variables
		private BackgroundWorker _listener;
		private ProgressDelegate Progress;

		// Network Variables
		private TcpClient _client;
		private int _port;
		private NetworkStream _netStream;
		private StreamReader _reader;
		private StreamWriter _writer;

		public Client(ProgressDelegate callback)
		{
			Progress = callback;

			_listener = new BackgroundWorker();
		}

		public void Start(int port)
		{
			_listener.DoWork += Connect;
			_listener.RunWorkerCompleted += Connected;

			_listener.RunWorkerAsync(port);

			while (_listener.IsBusy)
			{
				Progress("Connecting...");
			}

			Progress("Connected!");
			_listener.DoWork -= Connect;
			_listener.RunWorkerCompleted -= Connected;

			_listener.DoWork += GetMessage;
			_listener.ProgressChanged += ProcessMessage;

			try
			{
				_client = new TcpClient();
				_client.Connect("localhost", _port);
				_netStream = _client.GetStream();
				_reader = new StreamReader(_netStream);
				_writer = new StreamWriter(_netStream);

				_listener.RunWorkerAsync();
			}
			catch (Exception)
			{
				Progress("Network Error");
			}
			finally
			{
				if (!_listener.IsBusy)
				{
					_writer.Close();
					_reader.Close();
					_netStream.Close();
					_client.Close();
				}
			}
		}

		private void Connect(object sender, DoWorkEventArgs e)
		{
			int port = (int) e.Argument;
			TcpClient client = new TcpClient();
			StreamReader reader = null;
			try
			{
				reader = new StreamReader(client.GetStream());
				client.Connect("localhost", port);

				e.Result = reader.ReadLine();
			}
			finally
			{
				client.Close();
				reader?.Close();
			}
		}

		private void Connected(object sender, RunWorkerCompletedEventArgs e)
		{
			_port = (int) e.Result;
		}

		private void GetMessage(object sender, DoWorkEventArgs e)
		{
			_listener.ReportProgress(0, _reader.ReadLine());
		}

		private void ProcessMessage(object sender, ProgressChangedEventArgs progressChangedEventArgs)
		{
			throw new System.NotImplementedException();
		}
	}
}