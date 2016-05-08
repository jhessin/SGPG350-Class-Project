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
        TcpListener _c1Listener;
        NetworkStream _c1NetStream;
        StreamReader _c1Reader;
        StreamWriter _c1Writer;

        TcpListener _c2Listener;
        NetworkStream _c2NetStream;
        StreamReader _c2Reader;
        StreamWriter _c2Writer;

        public ServerWindow()
        {
            InitializeComponent();
        }

		private void ListenToClient(object sender, System.ComponentModel.DoWorkEventArgs e)
		{
			bool isClient1 = (sender == client1);
			BackgroundWorker worker = (BackgroundWorker) sender;

			try
			{
				// get IP address of server
				IPEndPoint host;
				host = isClient1 ? new IPEndPoint(IPAddress.Any, int.Parse(txtClient1Port.Text)) : new IPEndPoint(IPAddress.Any, int.Parse(txtClient2Port.Text));


				// assign IP address to listener (_c1Listener)
				if (isClient1)
				{
					_c1Listener = new TcpListener(host);

					// start _c1Listener
					_c1Listener.Start();
				}
				else
				{
					_c2Listener = new TcpListener(host);
					_c2Listener.Start();
				}
				worker.ReportProgress(0, "Listener started.");
				

				// if new connection received, accept it
				var socketForClient = isClient1? _c1Listener.AcceptTcpClient() : _c2Listener.AcceptTcpClient();
				if (socketForClient.Connected)
				{
				    while (true)
				    {
					    if (worker.CancellationPending)
					    {
							e.Cancel = true;
						    if (isClient1)
						    {
							    _c1Reader?.Close();
							    _c1Writer?.Close();
							    _c1NetStream?.Close();
						    }
						    else
						    {
							    _c2Reader?.Close();
								_c2Writer?.Close();
								_c2NetStream?.Close();
						    }
						    break;
					    }

				        // create the _c1NetStream and c1Reader and _c1Writer
					    if (isClient1)
					    {
							_c1Listener?.Stop();
						    _c1NetStream = socketForClient.GetStream();
							_c1Reader = new StreamReader(_c1NetStream);
							_c1Writer = new StreamWriter(_c1NetStream);
					    }
					    else
					    {
							_c2Listener?.Stop();
						    _c2NetStream = socketForClient.GetStream();
							_c2Reader = new StreamReader(_c2NetStream);
							_c2Writer = new StreamWriter(_c2NetStream);
					    }

						worker.ReportProgress(0, "Streams created");

				        // listen to information recevied from port assigned to client 1
					    string result;
						worker.ReportProgress(0, "Listening to client");
					    result = isClient1 ? _c1Reader.ReadLine() : _c2Reader.ReadLine();

				        // pass information received from port for client 1 to port for client 2 (using _c2Writer)
						worker.ReportProgress(0, "Message Recieved: " + result);

					    if (isClient1)
					    {
						    _c2Writer.WriteLine(result);
							_c2Writer.Flush();
							worker.ReportProgress(0, "Message sent to client2");
					    }
					    else
					    {
						    _c1Writer.WriteLine(result);
							_c1Writer.Flush();
							worker.ReportProgress(0, "Message sent to client1");
					    }
				    }
				}
				// close socketForClient
				socketForClient.Close();
				worker.ReportProgress(0, "Socket closed");
			}
			catch (Exception exception)
			{
				Trace.TraceError(exception.Message);
			}
		}

		private void startListening_Click(object sender, EventArgs e)
		{
			// Instantiate client 1 and client 2 threads. Assign ListenToClient1 to thread 1 and ListenToClient2 to thread 2
			// remember, thread names are client1 and client2
			lblMessage1.Text = "Server on...";
			btnStartListening.Enabled = false;
			Trace.TraceInformation("Listening for player 1 on port: " + txtClient1Port.Text);
			Trace.TraceInformation("Listening for player 2 on port: " + txtClient2Port.Text);

			// start threads client1 and client2
			client1.RunWorkerAsync();
			client2.RunWorkerAsync();
        
		}

		private void btnDisconnect_Click(object sender, EventArgs e)
        {
            // make sure you uncomment the below code to release resources

            client1.CancelAsync();

			client2.CancelAsync();
        }

		private void txtClient1Port_TextChanged(object sender, EventArgs e)
		{
	        Trace.TraceInformation(txtClient1Port.Text);

		}

		private void txtClient2Port_TextChanged(object sender, EventArgs e)
		{

			Trace.TraceInformation(txtClient2Port.Text);
		}

		private void ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
		{
			if (sender == client1)
			{
				lblMessage1.Text = (string)e.UserState;
			}
			else
			{
				lblMessage2.Text = (string)e.UserState;
			}
		}

		private void WorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
		{
			if (sender == client1)
			{
				lblMessage1.Text = "Disconnected.";
				if (!client2.IsBusy)
				{
					btnStartListening.Enabled = true;
				}
			}
			else
			{
				lblMessage2.Text = "Disconnected.";
				if (!client1.IsBusy)
				{
					btnStartListening.Enabled = true;
				}
			}
		}
    }
}
