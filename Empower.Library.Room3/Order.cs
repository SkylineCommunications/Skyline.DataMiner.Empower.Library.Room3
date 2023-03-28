namespace Skyline.DataMiner.Empower.Library.Room3
{
	using Nito.AsyncEx.Synchronous;

	using Skyline.DataMiner.CICD.Tools.WinEncryptedKeys.Lib;

	using System;
	using System.Net;
	using System.Net.Http;
	using System.Net.Http.Headers;
	using System.Security;
	using System.Text;
	using System.Threading.Tasks;

	/// <summary>
	///  Allows dispatching of an order to be sent over HTTPS to DataMiner.
	/// </summary>
	internal class Order : IOrder
	{
		private const string endpoint = "https://solutions.skyline.be/api/custom/operations/order";
		private static readonly string keyName = "SLC_EXTERNAL_DISPATCHER_KEY";

		private readonly SecureString apiKey;
		private readonly string suffix;
		private readonly string name;

		/// <summary>
		/// Creates an instance of <see cref="Order"/>.
		/// </summary>
		/// <param name="orderValue">Value of the order.</param>
		public Order(string orderValue)
		{
			// Key was setup using the dotnet tool Skyline.DataMiner.CICD.Tools.WinEncryptedKeys
			try
			{
				apiKey = Keys.RetrieveKey(keyName);
			}
			catch (InvalidOperationException)
			{
				throw new InvalidOperationException("Unauthorized: To run this call you must deploy Package SetupOrderDispatcher https://catalog.dataminer.services/catalog/4276.");
			}


}
