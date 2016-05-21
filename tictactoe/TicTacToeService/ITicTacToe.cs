using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TicTacToeService
{
	// A delegate for reporting progress.
	public delegate void ProgressDelegate(string format, params object[] args);

	[ServiceContract(CallbackContract = typeof (ITicTacToeCallback))]
	public interface ITicTacToe
	{
		[OperationContract]
		GameMark GetSymbol(int clientNum);

		[OperationContract]
		GameMark GetTurn();

		[OperationContract]
		void Mark(int x, int y);

		[OperationContract]
		GameBoard Update();

		[OperationContract]
		void Reset();
	}
	
	public interface ITicTacToeCallback
	{
		[OperationContract]
		void Progress(string format, params object[] args);
	}
}
