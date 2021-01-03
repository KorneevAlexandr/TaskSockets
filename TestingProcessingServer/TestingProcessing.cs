using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskSockets;
using System.Collections.Generic;

namespace TestingProcessingServer
{
	/// <summary>
	/// class for testig Processing request
	/// </summary>
	[TestClass]
	public class TestingProcessing
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
		/// testing the work of maintaining lists of messages from the client
		/// </summary>
		[TestMethod]
		public void ListMessage()
		{
			List<string> messages = new List<string> { "Привет", "Запрос", "Пока" };

			StringBuilder expect = new StringBuilder();
			foreach (string s in messages)
				expect.AppendLine(s);

			Notify += (string strok) => ProcessingMessage.AddMessage(strok);
			foreach (string s in messages)
				Notify?.Invoke(s);
			StringBuilder actual = ProcessingMessage.StringList();

			Assert.AreEqual(expect.ToString(), actual.ToString());
		}
	}
}
