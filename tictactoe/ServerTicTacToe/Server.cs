// ========================================================
// 
//   File Name:   Server.cs
// 
//   Author:  Jim Hessin
// 
//   Course and Assignment:   SGPG440 - ServerTicTacToe
// 
//   Description:  Describe what is contained in the file
// 
// =========================================================

using System;
using System.Diagnostics;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
using TicTacToe.Service;

namespace ServerTicTacToe
{
	// A delegate for reporting progress.
	public delegate void ProgressDelegate(string format, params object[] args);

	//------------------------------------------------------------------------
	// Name:  Server
	//
	// Description: The server that handles negotiating the connection with each client and communication between them.
	//
	//---------------------------------------------------------------------------
	public class Server
	{
		private readonly ProgressDelegate _callback;

		// Flags
		private bool _active;
		// The network variables.
		private ServiceHost _host;

		public Server(ProgressDelegate callback)
		{
			_callback = callback;

			_active = false;
		}

		private void ReportException(Exception ce)
		{
			_callback("An Exception occured: " + ce.Message);
			Trace.TraceError("An Exception occured: " + ce.Message);
		}

		public void Start()
		{
			// Can only be started once.
			if (_active)
			{
				return;
			}

			_active = true;


			// Step 2 Create a ServiceHost instance
			_host = new ServiceHost(typeof(TicTacToeService));

			try
			{
				// step 5 Start the service
				_host.Open();
				_callback("Service Started");
			}
			catch (Exception ce)
			{
				ReportException(ce);
				_host?.Abort();
				_active = false;
			}
		}

		public void Stop()
		{
			if (_active)
			{
				_host?.Close();
				_callback("Service Stopped");
				_active = false;
			}
		}
	}
}