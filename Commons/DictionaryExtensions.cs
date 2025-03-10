using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace Commons
{
	[PublicAPI]
	public static class DictionaryExtensions
	{
		public static void AddToListValue<T, TU>(this IDictionary<T, List<TU>> dict, T key, TU value)
		{
			if (dict.TryGetValue(key, out var items))
			{
				items.Add(value);
			}
			else
			{
				dict.Add(key, new List<TU> { value });
			}
		}

		public static IEnumerable<T> FindKeysByValue<T, TU>(this IDictionary<T, TU> source, TU value)
		{
			return source.Where(pair => pair.Value!.Equals(value)).Select(pair => pair.Key);
		}
	}
}