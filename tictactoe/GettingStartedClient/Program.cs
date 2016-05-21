using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GettingStartedClient.ServiceReference1;

namespace GettingStartedClient
{
	class Program
	{
		static void Main(string[] args)
		{
			// step 1: Create an instance of the WCF proxy.
			CalculatorClient client = new CalculatorClient();

			// step 2: Call the service operations
			// Call the add service operation.
			double v1, v2, r;
			v1 = 100;
			v2 = 15.99;
			r = client.Add(v1, v2);
			Console.WriteLine("Add({0},{1}) = {2}", v1, v2, r);

			// Call the subtract service operation.
			v1 = 145;
			v2 = 76.54;
			r = client.Subtract(v1, v2);
			Console.WriteLine("Subtract({0},{1}) = {2}", v1, v2, r);

			// Cass the Multiply service operation.
			v1 = 9;
			v2 = 81.25;
			r = client.Multiply(v1, v2);
			Console.WriteLine("Multiply({0},{1}) = {2}", v1, v2, r);

			// Cass the Divide service operation.
			v1 = 22;
			v2 = 7;
			r = client.Divide(v1, v2);
			Console.WriteLine("Divide({0},{1}) = {2}", v1, v2, r);

			// Step 3: Closing the client gracefully closes the connection and cleans up resources
			Console.ReadLine();
			client.Close();
		}
	}
}
