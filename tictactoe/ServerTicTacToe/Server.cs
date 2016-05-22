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
using System.ServiceModel;
using System.ServiceModel.Description;
using Service;

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
		private readonly ProgressCallback _callback;

		// Flags
		private bool _active;
		// The network variables.
		private ServiceHost _host;

		private class ProgressCallback : IServiceCallback
		{
			private readonly ProgressDelegate _progress;

			public ProgressCallback(ProgressDelegate result)
			{
				_progress = result;
			}

			public void Progress(string format, params object[] args)
			{
				_progress(format, args);
			}
		}

		public Server(ProgressDelegate callback)
		{
			_callback = new ProgressCallback(callback);

			_active = false;
		}

		private void ReportException(Exception ce)
		{
			_callback.Progress("An Exception occured: " + ce.Message);
			Trace.TraceError("An Exception occured: " + ce.Message);
		}

		public void Start(int port)
		{
			// Can only be started once.
			if (_active)
			{
				return;
			}

			_active = true;


			// Step 2 Create a ServiceHost instance
			_host = new ServiceHost(typeof (Service1));
			_host.AddServiceEndpoint(
				typeof (IService1),
				new NetTcpBinding(),
				"net.tcp://localhost:" + port);
			try
			{
				// Step 4 Enable metadata exchange
//				ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
//				smb.HttpGetEnabled = false;
//				_host.Description.Behaviors.Add(smb);

				// step 5 Start the service
				_host.Open();

				// Create client to assign the progress delegate.
				DuplexChannelFactory<IService1> scf;
				scf = new DuplexChannelFactory<IService1>(_callback,
					new NetTcpBinding(),
					"net.tcp://localhost:" + port);

				IService1 s = scf.CreateChannel();
				
				(s as ICommunicationObject)?.Close();

				_callback.Progress("Service Started on port {0}", port);
			}
			catch (Exception ce)
			{
				ReportException(ce);
				_host.Abort();
				_active = false;
			}
		}

		public void Stop()
		{
			if (_active)
			{
				_host.Close();
				_callback.Progress("Service Stopped");
				_active = false;
			}
		}
	}
}