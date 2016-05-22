using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Service
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
	public class Service1 : IService1
	{
		private static GameBoard _board = new GameBoard();
		private static IServiceCallback Callback => OperationContext.Current.GetCallbackChannel<IServiceCallback>();
		private static IServiceCallback _serverCallback;
		private static int _turn;
		private static readonly GameMark[] Players = { GameMark.X, GameMark.O };
		private static int _numPlayers;

		public Service1()
		{
			Callback.SetSymbol(Players[++_numPlayers%Players.Length]);
			Callback.SetTurn(Players[_turn]);
			Callback.UpdateBoard(_board);
		}

		public void SetServerCallback()
		{
			_serverCallback = Callback;
		}

		public void Mark(int x, int y)
		{
			if (_board.Mark(Players[_turn], x, y))
			{
				_serverCallback?.Progress("Marking {0} at {1}, {2}", GameBoard.MarkToChar(Players[_turn]), x, y);
				Callback.UpdateBoard(_board);
				Callback.Winner(_board.Winner());
				NextTurn();
			}
		}

		public void Reset()
		{
			_serverCallback?.Progress("Clearing the board");
			_board.Clear();
			Callback.UpdateBoard(_board);
		}

		private void NextTurn()
		{
			_turn = ++_turn % 2;
			Callback.SetTurn(Players[_turn]);
		}
	}
}
