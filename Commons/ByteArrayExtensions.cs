using System.Text;
using JetBrains.Annotations;

namespace Commons
{
	[PublicAPI]
	public static class ByteArrayExtensions
	{
		public static string GetString(this byte[] array, Encoding encoding)
		{
			return encoding.GetString(array);
		}

		public static string GetString(this byte[] array)
		{
			return GetString(array, Encoding.UTF8);
		}
	}
}