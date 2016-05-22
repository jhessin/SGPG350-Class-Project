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
//------------------------------------------------------------------------
// Name:  Client
//
// Description: Connects to server and handles all communications.
//
//---------------------------------------------------------------------------
	public class Client
	{
		private static ProgressDelegate _callback;
		private TicTacToeClient _client;
		private static GameBoard _board;
		private static GameMark _playerSymbol;
		private static GameMark _turn;
		private static GameMark _winMark;

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
				return _playerSymbol == GameMark.X ? "X" : "O";
		}

		public string GetOponentMark()
		{
				return _playerSymbol == GameMark.X ? "O" : "X";
		}

		public bool YourTurn()
		{
			return _playerSymbol == _turn;
		}

		public GameBoard UpdateBoard()
		{
				return _board;
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
				return _winMark;
			}
			return GameMark.None;
		}

		// Delegates and Network variables
		private class ServiceDelegate : TicTacToeCallback
		{
			public void Progress(string format, object[] args)
			{
				_callback(format, args);
			}

			public void UpdateBoard(GameBoard board)
			{
				_board = board;
			}

			public void SetSymbol(GameMark symbol)
			{
				_playerSymbol = symbol;
			}

			public void SetTurn(GameMark symbol)
			{
				_turn = symbol;
			}

			public void Winner(GameMark winMark)
			{
				_winMark = winMark;
			}
		}
	}
}