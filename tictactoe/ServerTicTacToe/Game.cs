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

using System.ComponentModel;
using ServerTicTacToe;

namespace ServerTicTacToe
{
	internal enum GameMark
	{
		X = 0,
		O = 1,
		None = 2
	}

	internal struct GameBoard
	{
		private GameMark _topLeft;
		private GameMark _topMid;
		private GameMark _topRight;
		private GameMark _midLeft;
		private GameMark _midMid;
		private GameMark _midRight;
		private GameMark _bottomLeft;
		private GameMark _bottomMid;
		private GameMark _bottomRight;

		private void Clear()
		{
			_topLeft =
				_topMid = _topRight = _midLeft = _midMid = _midRight = _bottomLeft = _bottomMid = _bottomRight = GameMark.None;
		}

		private void Mark(GameMark symbol, int x, int y)
		{
			switch (x)
			{
				case 1:
					switch (y)
					{
						case 1:
							_topLeft = symbol;
							return;
						case 2:
							_midLeft = symbol;
							return;
						case 3:
							_bottomLeft = symbol;
							return;
					}
					return;
				case 2:
					switch (y)
					{
						case 1:
							_topMid = symbol;
							return;
						case 2:
							_midMid = symbol;
							return;
						case 3:
							_bottomMid = symbol;
							return;
					}
					return;
				case 3:
					switch (y)
					{
						case 1:
							_topRight = symbol;
							return;
						case 2:
							_midRight = symbol;
							return;
						case 3:
							_bottomRight = symbol;
							return;
					}
					return;
			}
		}
	}
}

//------------------------------------------------------------------------
// Name:  Game
//
// Description: Contains all the information required for a game of tic-tac-toe. Including the placement of all markers currently on the board.
//
//---------------------------------------------------------------------------
public class Game
{
	private GameBoard _board;
	private BackgroundWorker _listenThread;
}