// ========================================================
// 
//   File Name:   Client.cs
// 
//   Author:  Jim Hessin
// 
//   Course and Assignment:   SGPG440 - TicTacToeClient
// 
//   Description:  Describe what is contained in the file
// 
// =========================================================

using System;
using System.Diagnostics;
using System.ServiceModel;
using System.Threading;
using Tic_Tac_Toe.TicTacToeService;

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
		private static TicTacToeCallback _callback;
		private static GameBoard _board;
		private static GameMark _playerSymbol;
		private static GameMark _turn;
		private static GameMark _winMark;
		private TicTacToeClient _client;

		// flags
		private bool _connected;


		public Client(TicTacToeCallback callback)
		{
			_callback = callback;

			_connected = false;
		}

		public void Start()
		{
			if (_connected)
			{
				return;
			}

			_connected = true;

			try
			{
				_client = new TicTacToeClient(
					new InstanceContext(_callback),
					"NetTcpBinding_TicTacToe");
				_client.Open();

				_client.Register();
				
			}
			catch (Exception e)
			{
				Trace.TraceError("An exception occured: {0}", e.Message);
				_client?.Abort();
				_connected = false;
			}
		}

		public void Mark(GameMark mark, int x, int y)
		{
			try
			{
				_client.Mark(mark, x, y);
			}
			catch (Exception e)
			{
				Trace.TraceError("Error: {0}", e.Message);
			}
		}

		public void Stop()
		{
			if (_connected)
			{
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
	}
}