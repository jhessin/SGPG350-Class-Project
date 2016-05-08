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

namespace Tic_Tac_Toe
{

		public delegate void DisplayProgress(string message);
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
		private DisplayProgress Display;

		// Network Variables
		private TcpClient _client;
		private NetworkStream _netStream;
		private StreamReader _reader;
		private StreamWriter _writer;

		public Client(DisplayProgress callback)
		{
			Display = callback;
		}
	}
}