// ========================================================
// 
//   File Name:   Client.cs
// 
//   Author:  Jim Hessin
// 
//   Course and Assignment:   SGPG440 - Tic Tac Toe
// 
//   Description:  Describe what is contained in the file
// 
// =========================================================

using System.IO;
using System.Net.Sockets;
using System.Threading;
using ServerTicTacToe;

namespace Tic_Tac_Toe
{

//------------------------------------------------------------------------
// Name:  Client
//
// Description: Connects to server and handles all communications.
//
//---------------------------------------------------------------------------
	public class Client
	{
		// Threading variables
		private Thread _listener;
		private ProgressDelegate Progress;

		// Network Variables
		private TcpClient _client;
		private NetworkStream _netStream;
		private StreamReader _reader;
		private StreamWriter _writer;

		public Client(ProgressDelegate callback)
		{
			Progress = callback;
		}
	}
}