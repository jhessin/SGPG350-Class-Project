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
using System.ServiceModel;
using System.Threading;
using ServerTicTacToe;
using Tic_Tac_Toe.ServiceReference1;

namespace Tic_Tac_Toe
{
	internal class ServiceDelegate : TicTacToeCallback
	{
		public void Progress(string format, object[] args)
		{
		}
	}

//------------------------------------------------------------------------
// Name:  Client
//
// Description: Connects to server and handles all communications.
//
//---------------------------------------------------------------------------
	public class Client
	{
		// Delegates and Network variables
		private readonly ProgressDelegate _callback;
		private TicTacToeClient _client;

		// flags
		private bool _connected;


		public Client(ProgressDelegate callback)
		{
			_callback = callback;

			_connected = false;
		}

		public void Start(int port)
		{
			if (_connected)
			{
				return;
			}

			_connected = true;

			try
			{
				_client = new TicTacToeClient(
					new InstanceContext(new ServiceDelegate()),
					new NetTcpBinding(),
					new EndpointAddress("net.tcp://localhost:" + port));
				_callback("Connected. Player {0}", GetMark());
			}
			catch (Exception e)
			{
				_callback("An exception occured: {0}", e.Message);
				_client?.Close();
				_connected = false;
			}
		}

		public string GetMark()
		{
			try
			{
				return _client.GetSymbol() == GameMark.X ? "X" : "O";
			}
			catch (Exception e)
			{
				_callback("Error: {0}", e.Message);
				return "";
			}
		}

		public string GetOponentMark()
		{
			try
			{
				return _client.GetSymbol() == GameMark.X ? "O" : "X";
			}
			catch (Exception e)
			{
				_callback("Error: {0}", e.Message);
				return "";
			}
		}

		public bool YourTurn()
		{
			try
			{
				return _client.GetSymbol() == _client.GetTurn();
			}
			catch (Exception e)
			{
				_callback("Error: {0}", e.Message);
				return false;
			}
		}

		public GameBoard UpdateBoard()
		{
			try
			{
				return _client.Update();
			}
			catch (Exception)
			{
				return new GameBoard();
			}
		}

		public void Mark(int x, int y)
		{
			try
			{
				_client.Mark(x, y);
			}
			catch (Exception e)
			{
				_callback("Error: {0}", e.Message);
			}
		}

		public void Stop()
		{
			if (_connected)
			{
				Thread.Sleep(5000);
				_client.Close();
				_connected = false;
			}
		}

		public void Reset()
		{
			if (_connected)
			{
				_client.Reset();
			}
		}

		public GameMark Winner()
		{
			if (_connected)
			{
				return _client.Winner();
			}
			return GameMark.None;
		}
	}
}