using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ClientTCP
{
	class Client
	{
		/// <summary>
		/// delegate class for translit
		/// </summary>
		/// <param name="message">string answer server</param>
		/// <returns>translit server</returns>
		private delegate string ForTranslit(string message);
		/// <summary>
		/// event for processing server answer
		/// </summary>
		private static event ForTranslit Notify;
		/// <summary>
		/// delegate for write in console recoded answer server
		/// </summary>
		/// <param name="mes"></param>
		private delegate void ForRecieve(string mes);

		/// <summary>
		/// start method client
		/// </summary>
		/// <param name="args">arguments Main method</param>
		static void Main(string[] args)
		{
			const string ip = "127.0.0.1";
			const int port = 8080;

			var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

			// write on console recoded answer (anonymous-method)
			ForRecieve recieve = delegate (string mes)
			{
				Console.WriteLine("Перекодированный ответ: " + mes);
			};
			// add event (lambda-function)
			Notify += (string strok) => Translit.TranslitRusInEng(strok);

			while (true)
			{
				var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

				Console.WriteLine("\nВведите сообщение: ");
				var message = Console.ReadLine();

				var data = Encoding.UTF8.GetBytes(message);

				tcpSocket.Connect(tcpEndPoint);
				tcpSocket.Send(data);

				var buffer = new byte[256];
				var size = 0;
				var answer = new StringBuilder();

				do
				{
					size = tcpSocket.Receive(buffer);
					answer.Append(Encoding.UTF8.GetString(buffer, 0, size));
				}
				while (tcpSocket.Available > 0);

				// Write and traslit with help event
				recieve(Notify?.Invoke(answer.ToString()));

				tcpSocket.Shutdown(SocketShutdown.Both);
				tcpSocket.Close();
			}
		}
	}
}
