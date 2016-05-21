using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using TicTacToeService;

namespace GettingStartedHost
{
	class Program
	{
		static void Main(string[] args)
		{
			// Step 1 Create a URI to serve as the base address.
			Uri baseAddress = new Uri("http://localhost:8000/GettingStarted/");

			// Step 2 Create a ServiceHost instance
			ServiceHost selfHost = new ServiceHost(typeof(GameClient), baseAddress);

			try
			{
				// Step 3 Add a service endpoint (optional)
				// selfHost.AddServiceEndpoint(typeof (ITicTacToe), new WSHttpBinding(), "CalculatorService");

				// Step 4 Enable metadata exchange
				ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
				smb.HttpGetEnabled = true;
				selfHost.Description.Behaviors.Add(smb);

				// step 5 Start the service
				selfHost.Open();
				Console.WriteLine("The service is ready.");
				Console.WriteLine("Press <ENTER> to terminate service.");
				Console.WriteLine();
				Console.ReadLine();

				// Close the ServiceHostBase to shutdown the service.
				selfHost.Close();
			}
			catch (Exception ce)
			{
				Console.WriteLine("An Exception occured: {0}", ce.Message);
				selfHost.Abort();
				Console.ReadLine();
			}
		}
	}
}
