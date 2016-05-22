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
		private static GameBoard _board;
		private static int _turn;
		private static readonly GameMark[] _players = { GameMark.X, GameMark.O };
		private static int _numPlayers;
		private readonly int _playerNumber;

		public Service1()
		{
			_playerNumber = _numPlayers;
			_numPlayers = ++_numPlayers % 2;
		}

		private static IServiceCallback callback => OperationContext.Current.GetCallbackChannel<IServiceCallback>();

		public GameMark GetSymbol()
		{
			return GetSymbol(_playerNumber);
		}

		private GameMark GetSymbol(int turn)
		{
			if (turn >= 0 && turn < _players.Length)
			{
				callback?.Progress("Sending Sybol for client {0}: {1}", turn, GameBoard.MarkToChar(_players[_playerNumber]));
				return _players[turn];
			}
			return GameMark.None;
		}

		public GameMark GetTurn()
		{
			return GetSymbol(_turn);
		}

		public void Mark(int x, int y)
		{
			if (_board.Mark(_players[_turn], x, y))
			{
				callback?.Progress("Marking {0} at {1}, {2}", GameBoard.MarkToChar(_players[_turn]), x, y);
				NextTurn();
			}
		}

		public GameBoard Update()
		{
			callback?.Progress("Updating board");
			return _board;
		}

		public GameMark Winner()
		{
			return _board.Winner();
		}

		public void Reset()
		{
			callback?.Progress("Clearing the board");
			_board.Clear();
		}

		private void NextTurn()
		{
			_turn = ++_turn % 2;
		}
	}
}
