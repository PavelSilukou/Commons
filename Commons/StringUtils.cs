using System.Text;
using Commons.Collections;
using JetBrains.Annotations;

namespace Commons
{
	[PublicAPI]
	public static class StringUtils
	{
#pragma warning disable S2368 // Public methods should not have multidimensional array parameters
		public static string Join(string separator, object[,] objects)
		{
			var resultStr = new StringBuilder();
			for (var i = 0; i < objects.GetLength(0); i++)
			{
				resultStr.Append(string.Join(separator, objects.GetRow(i)));
			}

			return resultStr.ToString();
		}
#pragma warning restore S2368 // Public methods should not have multidimensional array parameters
	}
}