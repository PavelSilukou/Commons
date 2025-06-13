using System.Text;

namespace Commons.Collections
{
	public static class ByteArrayExtensions
	{
		public static string GetString(this byte[] bytes, Encoding encoding)
		{
			InternalCheckUtils.IsNotNull(bytes, nameof(bytes));
			InternalCheckUtils.IsNotNull(encoding, nameof(encoding));
			
			return encoding.GetString(bytes);
		}

		public static string GetString(this byte[] bytes)
		{
			InternalCheckUtils.IsNotNull(bytes, nameof(bytes));
			
			return GetString(bytes, Encoding.UTF8);
		}
	}
}