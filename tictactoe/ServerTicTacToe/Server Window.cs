using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace ServerTicTacToe
{
	public partial class ServerWindow : Form
	{
		private readonly Server _server;

        public ServerWindow()
        {
            InitializeComponent();
			_server = new Server(ReportProgress);
        }

		private void ReportProgress(string msg, object[] args)
		{
			lock (lblMessage)
			{
				lblMessage.Text = string.Format(msg, args);
			}
			Trace.TraceInformation(msg, args);
		}

		private void Connect_Click(object sender, EventArgs e)
		{
			// Instantiate client 1 and client 2 threads. Assign ListenToClient1 to thread 1 and ListenToClient2 to thread 2
			// remember, thread names are client1 and client2
			if (!_server.Active)
			{
				_server.Start(int.Parse(txtClient1Port.Text), int.Parse(txtClient2Port.Text));
				btnStartListening.Enabled = false;
			}
		}

		private void Disconnect_Click(object sender, EventArgs e)
        {
            // make sure you uncomment the below code to release resources
			if (_server.Active)
			{
				_server.Stop();
				btnStartListening.Enabled = true;
			}
        }
		
		private void NumbersOnly_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == '\b');
		}
	}
}
