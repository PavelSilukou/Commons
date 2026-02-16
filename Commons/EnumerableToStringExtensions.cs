using System;
using System.Collections.Generic;
using System.Linq;

namespace Commons
{
	public static class EnumerableToStringExtensions
	{
		public static string ToString(this IEnumerable<float> source, string? separator, string? format)
		{
			return source.ToString(separator, element => element.ToString(format));
		}
        
		private static string ToString<T>(this IEnumerable<T> source, string? separator, Func<T, string> elementFormatFunc)
		{
			return string.Join(separator, source.Select(elementFormatFunc));
		}
	}
}