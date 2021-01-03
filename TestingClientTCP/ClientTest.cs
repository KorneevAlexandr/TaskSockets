using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientTCP;

namespace TestingClientTCP
{
	/// <summary>
	/// Class for testing job class for transliteration
	/// </summary>
	[TestClass]
	public class ClientTest
	{
		/// <summary>
		/// testing the transliteration method for a regular message
		/// </summary>
		[TestMethod]
		public void TestingTransliterS1()
		{
			string rus = "Привет, меня зовут Саша";
			string expect = "Priviet, mienya zovut Sasha";

			string actual = Translit.TranslitRusInEng(rus);

			Assert.AreEqual(expect, actual);
		}

		/// <summary>
		/// testing the transliteration method for a message with many other symbols
		/// </summary>
		[TestMethod]
		public void TestingTransliterS2()
		{
			string rus = "Строка, в которой используются цифры: 12366; и другие символы: $%! ";
			string expect = "Stroka, v kotoroiy ispol'zuyutsya cifry: 12366; i drugiie simvoly: $%! ";

			string actual = Translit.TranslitRusInEng(rus);

			Assert.AreEqual(expect, actual);
		}

	}
}
