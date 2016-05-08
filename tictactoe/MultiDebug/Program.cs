using System;
using System.Windows.Forms;
using Tic_Tac_Toe;
using ServerTicTacToe;

namespace MultiDebug
{

	static class Program
	{
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MultiFormContext(new ServerWindow(), new TicTacToeWindow(), new TicTacToeWindow()));
		}
	}

}