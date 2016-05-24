// ========================================================
// 
//   File Name:   Game.cs
// 
//   Author:  Jim Hessin
// 
//   Course and Assignment:   SGPG440 - ServerTicTacToe
// 
//   Description:  Describe what is contained in the file
// 
// =========================================================

using System.Runtime.Serialization;
using System.ServiceModel;

namespace TicTacToe.Service
{
	

	//------------------------------------------------------------------------
	// Name:  Game
	//
	// Description: Contains all the information required for a game of tic-tac-toe. Including the placement of all markers currently on the board.
	//
	//---------------------------------------------------------------------------
	public class Game
	{
		// The game board
		private GameBoard _board;

		public Game()
		{
			_board = new GameBoard();
			Restart();
		}

		// Who's turn is it?
		public GameMark Turn { get; private set; }

		public void Restart()
		{
			_board.Clear();
			Turn = GameMark.X;
		}

		public void Mark(int x, int y)
		{
			if (_board.Mark(Turn, x, y))
			{
				NextTurn();
			}
		}

		public GameMark CheckWin()
		{
			return _board.Winner();
		}

		private void NextTurn()
		{
			switch (Turn)
			{
				case GameMark.X:
					Turn = GameMark.O;
					return;
				case GameMark.O:
					Turn = GameMark.X;
					return;
			}
		}
	}
}