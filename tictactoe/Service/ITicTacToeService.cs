// ========================================================
// 
//   File Name:   ITicTacToeService.cs
// 
//   Author:  Jim Hessin
// 
//   Course and Assignment:   SGPG440 - Service
// 
//   Description:  Describe what is contained in the file
// 
// =========================================================

using System.Runtime.Serialization;
using System.ServiceModel;

namespace TicTacToe.Service
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITicTacToeService" in both code and config file together.
	[ServiceContract(
		Name = "TicTacToe",
		Namespace = "TicTacToe.Service",
		SessionMode = SessionMode.Required,
		CallbackContract = typeof (IServiceCallback))]
	public interface ITicTacToeService
	{
		[OperationContract(IsOneWay = true)]
		void Register();

		[OperationContract(IsOneWay = true)]
		void Mark(GameMark playerMark, int x, int y);

		[OperationContract(IsOneWay = true)]
		void Reset();
	}

	[ServiceContract]
	public interface IServiceCallback
	{
		[OperationContract(IsOneWay = true)]
		void Progress(string format, params object[] args);

		[OperationContract(IsOneWay = true)]
		void SetPlayerMark(GameMark mark);

		[OperationContract(IsOneWay = true)]
		void UpdateBoard(GameBoard board);

		[OperationContract(IsOneWay = true)]
		void SetTurn(GameMark symbol);

		[OperationContract(IsOneWay = true)]
		void Winner(GameMark winMark);
	}

	[DataContract]
	public enum GameMark
	{
		[EnumMember]
		None = 0,
		[EnumMember]
		X = 1,
		[EnumMember]
		O = 2,
		[EnumMember]
		Draw = 3
	}

	[DataContract]
	public struct GameBoard
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

		[DataMember]
		public string TopLeft => MarkToChar(_topLeft).ToString();

		[DataMember]
		public string TopMid => MarkToChar(_topMid).ToString();

		[DataMember]
		public string TopRight => MarkToChar(_topRight).ToString();

		[DataMember]
		public string MidLeft => MarkToChar(_midLeft).ToString();

		[DataMember]
		public string MidRight => MarkToChar(_midRight).ToString();

		[DataMember]
		public string MidMid => MarkToChar(_midMid).ToString();

		[DataMember]
		public string BottomLeft => MarkToChar(_bottomLeft).ToString();

		[DataMember]
		public string BottomMid => MarkToChar(_bottomMid).ToString();

		[DataMember]
		public string BottomRight => MarkToChar(_bottomRight).ToString();
		
		public static char MarkToChar(GameMark mark)
		{
			return mark == GameMark.X ? 'X' : mark == GameMark.O ? 'O' : ' ';
		}

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
							if (_topLeft == GameMark.None)
							{
								_topLeft = symbol;
								return true;
							}
							return false;
						case 2:
							if (_midLeft == GameMark.None)
							{
								_midLeft = symbol;
								return true;
							}
							return false;
						case 3:
							if (_bottomLeft == GameMark.None)
							{
								_bottomLeft = symbol;
								return true;
							}
							return false;
					}
					return false;
				case 2:
					switch (y)
					{
						case 1:
							if (_topMid == GameMark.None)
							{
								_topMid = symbol;
								return true;
							}
							return false;
						case 2:
							if (_midMid == GameMark.None)
							{
								_midMid = symbol;
								return true;
							}
							return false;
						case 3:
							if (_bottomMid == GameMark.None)
							{
								_bottomMid = symbol;
								return true;
							}
							return false;
					}
					return false;
				case 3:
					switch (y)
					{
						case 1:
							if (_topRight == GameMark.None)
							{
								_topRight = symbol;
								return true;
							}
							return false;
						case 2:
							if (_midRight == GameMark.None)
							{
								_midRight = symbol;
								return true;
							}
							return false;
						case 3:
							if (_bottomRight == GameMark.None)
							{
								_bottomRight = symbol;
								return true;
							}
							return false;
					}
					return false;
				default:
					return false;
			}
		}

		public GameMark Winner()
		{
			GameMark[] winMarks = new[] { GameMark.X, GameMark.O };
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
	}
}