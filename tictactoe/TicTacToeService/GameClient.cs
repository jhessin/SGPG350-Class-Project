using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TicTacToeService
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
/*	public class Service1 : IService1
	{
		public string GetData(int value)
		{
			return string.Format("You entered: {0}", value);
		}

		public CompositeType GetDataUsingDataContract(CompositeType composite)
		{
			if (composite == null)
			{
				throw new ArgumentNullException("composite");
			}
			if (composite.BoolValue)
			{
				composite.StringValue += "Suffix";
			}
			return composite;
		}
	}*/

	public class GameClient : ITicTacToe
	{
		private GameBoard _board;
		private GameMark _turn;
		private GameMark[] _players = new[] {GameMark.X, GameMark.O};

		ITicTacToeCallback callback => OperationContext.Current.GetCallbackChannel<ITicTacToeCallback>();

		public GameMark GetSymbol(int clientNum)
		{
			if (clientNum >= 0 && clientNum < _players.Length)
			{
				callback.Progress("Sending Client symbol for client {0}", clientNum);
				return _players[clientNum];
			}
			else
			{
				return GameMark.None;
			}
		}

		public GameMark GetTurn()
		{
			return _turn;
		}

		public void Mark(int x, int y)
		{
			if (_board.Mark(_turn, x, y))
			{
				callback.Progress("Marking {0} at {1}, {2}", _turn, x, y);
				NextTurn();
			}
		}

		public GameBoard Update()
		{
			callback.Progress("Updating board");
			return _board;
		}

		public void Reset()
		{
			callback.Progress("Clearing the board");
			_board.Clear();
		}

		private void NextTurn()
		{
			if (_turn == GameMark.O)
			{
				callback.Progress("Changing to player X's turn");
				_turn = GameMark.X;
			}
			else
			{
				callback.Progress("Changing to player O's turn");
				_turn = GameMark.O;
			}
		}
	}
}
