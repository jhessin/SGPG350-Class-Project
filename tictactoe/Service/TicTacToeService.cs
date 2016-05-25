using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TicTacToe.Service
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TicTacToeService" in both code and config file together.
	[ServiceBehavior(
		InstanceContextMode = InstanceContextMode.PerSession,
		ConcurrencyMode = ConcurrencyMode.Single)]
	public class TicTacToeService : ITicTacToeService
	{
		private static GameBoard _board = new GameBoard();
		private static Dictionary<GameMark, IServiceCallback> _callback = new Dictionary<GameMark, IServiceCallback>();
		private static GameMark _turn;
		private static readonly GameMark[] Players = { GameMark.X, GameMark.O };
		private static int _numPlayers;
		
		public void Register()
		{
			if (_callback.ContainsValue(OperationContext.Current.GetCallbackChannel<IServiceCallback>()))
			{
				return;
			}

			GameMark playerMark;

			if (!_callback.ContainsKey(GameMark.X))
			{
				playerMark = GameMark.X;
				_callback[playerMark] = OperationContext.Current.GetCallbackChannel<IServiceCallback>();
				_callback[playerMark].Progress("X Symbol assigned");
				_callback[playerMark].SetPlayerMark(playerMark);
				return;
			}
			if (!_callback.ContainsKey(GameMark.O))
			{
				playerMark = GameMark.O;
				_callback[playerMark] = OperationContext.Current.GetCallbackChannel<IServiceCallback>();
				_callback[playerMark].Progress("O Symbol assigned");
				_callback[playerMark].SetPlayerMark(playerMark);
			}
		}

		public void Mark(GameMark playerMark, int x, int y)
		{
			if (playerMark != _turn)
			{
				_callback[playerMark]?.Progress("It isn't your turn");
				return;
			}

			if (_board.Mark(_turn, x, y))
			{
				foreach (var cb in _callback.Values)
				{
					cb.UpdateBoard(_board);
					cb.Winner(_board.Winner());
				}
				NextTurn();
			}
		}

		public void Reset()
		{
			_board.Clear();
			foreach (var cb in _callback.Values)
			{
				cb.Progress("Board Reset requested.");
				cb.UpdateBoard(_board);
			}
		}

		private void NextTurn()
		{
			if (_turn == GameMark.X)
			{
				_turn = GameMark.O;
			}
			else if (_turn == GameMark.O)
			{
				_turn = GameMark.X;
			}
			else if (_board.Winner() != GameMark.None)
			{
				_turn = GameMark.None;
			}
			foreach (var cb in _callback.Values)
			{
				cb.SetTurn(_turn);
			}
		}
	}
}
