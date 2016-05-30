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

using System.Diagnostics;

namespace ServerTicTacToe
{
	public enum GameMark
	{
		None = 0,
		X = 1,
		O = 2,
		Draw
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

		public void Clear()
		{
			_topLeft =
				_topMid = _topRight = _midLeft = _midMid = _midRight = _bottomLeft = _bottomMid = _bottomRight = GameMark.None;
		}

		public bool Mark(GameMark symbol, int x, int y)
		{
			switch (x)
			{
				case 1:
					switch (y)
					{
						case 1:
							return CopySymbol(symbol, ref _topLeft);
						case 2:
							return CopySymbol(symbol, ref _topMid);
						case 3:
							return CopySymbol(symbol, ref _topRight);
					}
					return false;
				case 2:
					switch (y)
					{
						case 1:
							return CopySymbol(symbol, ref _midLeft);
						case 2:
							return CopySymbol(symbol, ref _midMid);
						case 3:
							return CopySymbol(symbol, ref _midRight);
					}
					return false;
				case 3:
					switch (y)
					{
						case 1:
							return CopySymbol(symbol, ref _bottomLeft);
						case 2:
							return CopySymbol(symbol, ref _bottomMid);
						case 3:
							return CopySymbol(symbol, ref _bottomRight);
					}
					return false;
				default:
					return false;
			}
		}

		private bool CopySymbol(GameMark from, ref GameMark to)
		{
			if (to == GameMark.None)
			{
				to = from;
				return true;
			}
			return false;
		}

		public GameMark Winner()
		{
			GameMark[] winMarks = {GameMark.X, GameMark.O};
			foreach (GameMark winMark in winMarks)
			{
				if (_topLeft == winMark && _topMid == winMark && _topRight == winMark ||
				    _midLeft == winMark && _midMid == winMark && _midRight == winMark ||
				    _bottomLeft == winMark && _bottomMid == winMark && _bottomRight == winMark ||
				    _topLeft == winMark && _midLeft == winMark && _bottomLeft == winMark ||
				    _topMid == winMark && _midMid == winMark && _bottomMid == winMark ||
				    _topRight == winMark && _midRight == winMark && _bottomRight == winMark ||
				    _topLeft == winMark && _midMid == winMark && _bottomRight == winMark ||
				    _bottomLeft == winMark && _midMid == winMark && _topRight == winMark)
				{
					return winMark;
				}
			}
			if (_topLeft != GameMark.None && _topMid != GameMark.None && _topRight != GameMark.None &&
			    _midLeft != GameMark.None && _midMid != GameMark.None && _midRight != GameMark.None &&
			    _bottomLeft != GameMark.None && _bottomMid != GameMark.None && _bottomRight != GameMark.None)
			{
				return GameMark.Draw;
			}

			return GameMark.None;
		}


		public override string ToString()
		{
			return Game.MarkToString(
				_topLeft, _topMid, _topRight,
				_midLeft, _midMid, _midRight,
				_bottomLeft, _bottomMid, _bottomRight);
		}

		public void LoadFromString(string fromString)
		{
			if (fromString.Length < 9)
			{
				Trace.TraceError("Invalid Gameboard string - returning empty gameboard");
				_topLeft = _topMid = _topRight =
					_midLeft = _midMid = _midRight =
					_bottomLeft = _bottomMid = _bottomRight = GameMark.None;
				return;
			}
			_topLeft = Game.MarkFromChar(fromString[0]);
			_topMid = Game.MarkFromChar(fromString[1]);
			_topRight = Game.MarkFromChar(fromString[2]);
			_midLeft = Game.MarkFromChar(fromString[3]);
			_midMid = Game.MarkFromChar(fromString[4]);
			_midRight = Game.MarkFromChar(fromString[5]);
			_bottomLeft = Game.MarkFromChar(fromString[6]);
			_bottomMid = Game.MarkFromChar(fromString[7]);
			_bottomRight = Game.MarkFromChar(fromString[8]);
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
		// The game board
		private GameBoard _board;
		public GameMark Turn { get; private set; }

		public Game()
		{
			_board = new GameBoard();
			Restart();
		}


		public static string MarkToString(params GameMark[] marks)
		{
			string value = "";
			foreach (var mark in marks)
			{
				switch (mark)
				{
					case GameMark.X:
						value += "X";
						break;
					case GameMark.O:
						value += "O";
						break;
					default:
						value += " ";
						break;
				}
			}
			return value;
		}

		public static GameMark MarkFromChar(char input)
		{
			switch (input)
			{
				case 'X':
					return GameMark.X;
				case 'O':
					return GameMark.O;
				default:
					return GameMark.None;
			}
		}

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

		public override string ToString()
		{
			return 
				_board + 
				MarkToString(Turn) ;
		}

		public void LoadFromString(string fromString)
		{
			_board.LoadFromString(fromString);
			Turn = MarkFromChar(fromString[9]);
		}
	}
}