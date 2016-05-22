// ========================================================
// 
//   File Name:   IService1.cs
// 
//   Author:  Jim Hessin
// 
//   Course and Assignment:   SGPG440 - Service
// 
//   Description:  Describe what is contained in the file
// 
// =========================================================

using System.Runtime.Serialization;
using System.ServiceModel;

namespace Service
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
	[ServiceContract(
		Name = "TicTacToe",
		SessionMode = SessionMode.Required,
		CallbackContract = typeof (IServiceCallback))]
	public interface IService1
	{
		[OperationContract(IsOneWay = false)]
		GameMark GetSymbol();

		[OperationContract(IsOneWay = false)]
		GameMark GetTurn();

		[OperationContract(IsOneWay = true)]
		void Mark(int x, int y);

		[OperationContract(IsOneWay = false)]
		GameBoard Update();

		[OperationContract(IsOneWay = false)]
		GameMark Winner();

		[OperationContract(IsOneWay = true)]
		void Reset();
	}

	[ServiceContract]
	public interface IServiceCallback
	{
		// Use a data contract as illustrated in the sample below to add composite types to service operations.
		// You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "Service.ContractType".
		[OperationContract(IsOneWay = true)]
		void Progress(string format, params object[] args);
	}

	[DataContract]
	public class CompositeType
	{
		[DataMember]
		public bool BoolValue { get; set; } = true;

		[DataMember]
		public string StringValue { get; set; } = "Hello ";
	}
}