using System;
using System.Text;
using JetBrains.Annotations;

namespace Commons
{
	[PublicAPI]
	public static class StringExtensions
	{
		public static string CapitalizeFirstLetter(this string str)
		{
			return char.ToUpper(str[0]) + str[1..];
		}

		public static byte[] ToByteArray(this string str, Encoding encoding)
		{
			return encoding.GetBytes(str);
		}

		public static byte[] ToByteArray(this string str)
		{
			return ToByteArray(str, Encoding.UTF8);
		}

		public static string ToBase64String(this string str)
		{
			return Convert.ToBase64String(str.ToByteArray());
		}

		public static string ToStringFromBase64(this string str)
		{
			var data = Convert.FromBase64String(str);
			return data.GetString(Encoding.UTF8);
		}
	}
}