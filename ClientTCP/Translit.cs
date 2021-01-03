using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientTCP
{
	/// <summary>
	/// static class for translit
	/// </summary>
	public static class Translit
	{
		/// <summary>
		/// a dictionary containing keys for converting each Russian character into the corresponding English
		/// </summary>
		private static Dictionary<char, string> word = new Dictionary<char, string>
			 {
				{'а', "a"},
				{'б', "b"},
				{'в', "v"},
				{'г', "g"},
				{'д', "d"},
				{'е', "ie"},
				{'ё', "yo"},
				{'ж', "j"},
				{'з', "z"},
				{'и', "i"},
				{'й', "iy"},
				{'к', "k"},
				{'л', "l"},
				{'м', "m"},
				{'н', "n"},
				{'о', "o"},
				{'п', "p"},
				{'р', "r"},
				{'с', "s"},
				{'т', "t"},
				{'у', "u"},
				{'ф', "f"},
				{'х', "kh"},
				{'ц', "c"},
				{'ч', "ch"},
				{'ш', "sh"},
				{'щ', "sch"},
				{'ъ', "'"},
				{'ы', "y"},
				{'ь', "'"},
				{'э', "e"},
				{'ю', "yu"},
				{'я', "ya"}
			};

		/// <summary>
		/// method that encodes a message character by character
		/// </summary>
		/// <param name="message">message for recoding</param>
		/// <returns>recoding message</returns>
		public static string TranslitRusInEng(string message)
		{
			string res = "";

			foreach (char c in message)
			{
				try
				{
					if (c.ToString().ToLower().Equals(c.ToString()))
						res += word[c];
					else
						res += word[c.ToString().ToLower().ToCharArray()[0]].ToUpper();
				}
				catch
				{
					res += c.ToString();
				}
			}

			return res;
		}

	}
}
