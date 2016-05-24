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
		InstanceContextMode = InstanceContextMode.PerCall,
		ConcurrencyMode = ConcurrencyMode.Multiple)]
	public class TicTacToeService : ITicTacToeService
	{
		private static GameBoard _board = new GameBoard();
		private static Dictionary<GameMark, IServiceCallback> Callback = new Dictionary<GameMark, IServiceCallback>();
		private static GameMark _turn;
		private static readonly GameMark[] Players = { GameMark.X, GameMark.O };
		private static int _numPlayers;
		private GameMark _playerMark = GameMark.None;
		
		public void Register()
		{
			if (!Callback.ContainsKey(GameMark.X))
			{
				_playerMark = GameMark.X;
				Callback[_playerMark] = OperationContext.Current.GetCallbackChannel<IServiceCallback>();
				Callback[_playerMark].SetPlayerMark(_playerMark);
				return;
			}
			if (!Callback.ContainsKey(GameMark.O))
			{
				_playerMark = GameMark.O;
				Callback[_playerMark] = OperationContext.Current.GetCallbackChannel<IServiceCallback>();
				Callback[_playerMark].SetPlayerMark(_playerMark);
			}
		}

		public void Mark(int x, int y)
		{
			if (_playerMark != _turn)
			{
				Callback[_playerMark]?.Progress("It isn't your turn");
				return;
			}

			if (_board.Mark(_turn, x, y))
			{
				foreach (var cb in Callback.Values)
				{
					cb.UpdateBoard(_board);
					cb.Winner(_board.Winner());
				}
				NextTurn();
			}
		}

		public void Reset()
		{
			Callback[_playerMark]?.Progress("Reseting board");

			switch (_playerMark)
			{
				case GameMark.X:
					Callback[GameMark.O]?.Progress("Player X reset the board.");
					break;
				case GameMark.O:
					Callback[GameMark.X]?.Progress("Player O reset the board.");
					break;
			}

			_board.Clear();
			foreach (var cb in Callback.Values)
			{
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
			foreach (var cb in Callback.Values)
			{
				cb.SetTurn(_turn);
			}
		}
	}
}
