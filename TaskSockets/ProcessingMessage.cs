using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSockets
{
	/// <summary>
	/// class for handling messages from the client
	/// </summary>
	public static class ProcessingMessage
	{
		/// <summary>
		/// list of messages from client
		/// </summary>
		private static List<string> ListMessage = new List<string>();

		/// <summary>
		/// method for adding a message to the message list
		/// </summary>
		/// <param name="message">client message</param>
		public static void AddMessage(string message)
		{
			ListMessage.Add(message);
		}

		/// <summary>
		/// displaying a list of messages from the client
		/// </summary>
		/// <returns>text list (int type StringBuilder)</returns>
		public static StringBuilder StringList()
		{
			StringBuilder strok = new StringBuilder();
			for (int i = 0; i < ListMessage.Count; i++)
			{
				strok.AppendLine(ListMessage[i]);
			}
			return strok;
		}

	}
}
