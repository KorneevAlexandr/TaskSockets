using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace TaskSockets
{
	/// <summary>
	/// Class-server
	/// </summary>
	public class Server
	{
		/// <summary>
		/// delegate for processing message
		/// </summary>
		/// <param name="message"></param>
		private delegate void ForProcessing(string message);
		/// <summary>
		/// static event for processing message
		/// </summary>
		private static event ForProcessing Notify;

		/// <summary>
		/// start method
		/// </summary>
		/// <param name="args">arguments Main method</param>
		static void Main(string[] args)
		{
			const string ip = "127.0.0.1";
			const int port = 8080;

			var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

			var tcpSocket = new Socket(
				AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			tcpSocket.Bind(tcpEndPoint);
			tcpSocket.Listen(5);

			// write on console user request(anonymous-method)
			Notify = delegate (string mes)
			{
				Console.WriteLine("Запрос клиента: " + mes);
			};
			// add event (lambda-function)
			Notify += (string strok) => ProcessingMessage.AddMessage(strok);

			while (true)
			{
				var listener = tcpSocket.Accept();
				var buffer = new byte[256];
				var size = 0;
				var data = new StringBuilder();

				do
				{
					size = listener.Receive(buffer);
					data.Append(Encoding.UTF8.GetString(buffer, 0, size));
				}
				while (listener.Available > 0);

				// event
				Notify?.Invoke(data.ToString());

				listener.Send(Encoding.UTF8.GetBytes(data.ToString()));  // server answer

				listener.Shutdown(SocketShutdown.Both);
				listener.Close();
			}
		}
	}
}
