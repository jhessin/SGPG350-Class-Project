using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace ServerTicTacToe
{
	public partial class ServerWindow : Form
    {
        //TcpListener tcpClient1Listener;
        //NetworkStream Client1networkStream;
        //StreamReader Client1StreamReader;
        //StreamWriter Client1StreamWriter;

        //TcpListener tcpClient2Listener;
        //NetworkStream Client2networkStream;
        //StreamReader Client2StreamReader;
        //StreamWriter Client2StreamWriter;
        
        //Thread client1;
        //Thread client2; 

        public ServerWindow()
        {
            InitializeComponent();
        }

        private void ListenToClient1()
        {
            try
            {
                // get IP address of server

                // assign IP address to listener (tcpClient1Listener)

                // start tcpClient1Listener

                // if new connection received, accept it
                //if (socketForClient.Connected)
                //{
                //    while (true)
                //    {
                //        // create the Client1networkStream and Client1StreamReader and Client1StreamWriter

                //        // listen to information recevied from port assigned to client 1

                //        // pass information received from port for client 1 to port for client 2 (using Client2StreamWriter)
                //    }
                //}
                // close socketForClient
            }
            catch 
            {
                //MessageBox.Show(ex.Message + " _ Thread 1");
            }
        }

        private void ListenToClient2()
        {
            try
            {
                // get IP address of server

                // assign IP address to listener (tcpClient2Listener)

                // start tcpClient2Listener

                // if new connection received, accept it
                //if (socketForClient.Connected)
                //{
                //    while (true)
                //    {
                //        // create the Client1networkStream and Client1StreamReader and Client1StreamWriter

                //        // listen to information recevied from port assigned to client 2

                //        // pass information received from port for client 2 to port for client 1 (using Client1StreamWriter)
                //    }
                //}
            }
            catch
            {
                //MessageBox.Show(ex.Message + " _ Thread 1");
            }
        }

		private void startListening_Click(object sender, EventArgs e)
		{
			// Instantiate client 1 and client 2 threads. Assign ListenToClient1 to thread 1 and ListenToClient2 to thread 2
			// remember, thread names are client1 and client2
			lblMessage.Text = "Server on...";
			btnStartListening.Enabled = false;
			Trace.TraceInformation("Listening for player 1 on port: " + txtClient1Port.Text);
			Trace.TraceInformation("Listening for player 2 on port: " + txtClient2Port.Text);

			// start threads client1 and client2
        
		}

		private void btnDisconnect_Click(object sender, EventArgs e)
        {
            // make sure you uncomment the below code to release resources

            //client1.Abort();
            //tcpClient1Listener.Stop();
            //if (Client1networkStream != null)
            //    Client1networkStream.Close();
            //if (Client1StreamReader != null)
            //    Client1StreamReader.Close();
            //if (Client1StreamWriter != null)
            //    Client1StreamWriter.Close();

            //client2.Abort();
            //tcpClient2Listener.Stop();
            //if (Client1networkStream != null)
            //    Client1networkStream.Close();
            //if (Client1StreamReader != null)
            //    Client1StreamReader.Close();
            //if (Client1StreamWriter != null)
            //    Client1StreamWriter.Close();

            Application.Exit();
        }

		private void txtClient1Port_TextChanged(object sender, EventArgs e)
		{
	        Trace.TraceInformation(txtClient1Port.Text);

		}

		private void txtClient2Port_TextChanged(object sender, EventArgs e)
		{

			Trace.TraceInformation(txtClient2Port.Text);
		}
    }
}
