using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace ServerTicTacToe
{
	public partial class ServerWindow : Form
	{
		private Server _server;
		private int _port;

        public ServerWindow()
        {
            InitializeComponent();
			_server = new Server(ReportProgress);
	        _port = 32;
        }

		private void ReportProgress(string format, object[] args)
		{
			Trace.TraceInformation(format, args);
		}

		private void startListening_Click(object sender, EventArgs e)
		{
			// Instantiate client 1 and client 2 threads. Assign ListenToClient1 to thread 1 and ListenToClient2 to thread 2
			// remember, thread names are client1 and client2
			_server.Start();
			btnStartListening.Enabled = false;
		}

		private void btnDisconnect_Click(object sender, EventArgs e)
        {
			_server.Stop();
			btnStartListening.Enabled = true;
        }
	}
}
