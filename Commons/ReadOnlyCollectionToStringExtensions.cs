using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using JetBrains.Annotations;

namespace Commons
{
	[PublicAPI]
	public static class ReadOnlyCollectionToStringExtensions
	{
		public static string ToString(this IReadOnlyCollection<float> source, string? separator, string? format)
		{
			return source.ToString(separator, element => element.ToString(format));
		}
		
		public static string ToString(this IReadOnlyCollection<Vector2> source, string? separator, string? format)
		{
			return source.ToString(separator, element => element.ToString(format));
		}
        
		public static string ToString<TSource>(this IReadOnlyCollection<TSource> source, string? separator, Func<TSource, string> elementFormatFunc)
		{
			return string.Join(separator, source.Select(elementFormatFunc));
		}
	}
}