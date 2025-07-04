using System;
using System.Text;

namespace Commons
{
	public static class ByteArrayExtensions
	{
		public static string GetString(this byte[] bytes, Encoding encoding)
		{
			if (bytes == null) throw new ArgumentNullException(nameof(bytes));
			if (encoding == null) throw new ArgumentNullException(nameof(encoding));
			
			return encoding.GetString(bytes);
		}

		public static string GetString(this byte[] bytes)
		{
			if (bytes == null) throw new ArgumentNullException(nameof(bytes));
			
			return GetString(bytes, Encoding.UTF8);
		}
	}
}