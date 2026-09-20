using System;
using System.Collections.Generic;
using System.Linq;

namespace Commons
{
	public static class DictionaryExtensions
	{
		public static void AddToListValue<TKey, TValue>(this IDictionary<TKey, List<TValue>> dict, TKey key, TValue value)
		{
			if (dict == null) throw new ArgumentNullException(nameof(dict));
			
			if (dict.TryGetValue(key, out var items))
			{
				items.Add(value);
			}
			else
			{
				dict.Add(key, new List<TValue> { value });
			}
		}
		
		public static TKey FindKeyByValue<TKey, TValue>(this IDictionary<TKey, TValue> dict, TValue value)
		{
			// ReSharper disable once ConvertIfStatementToReturnStatement
			if (dict == null) throw new ArgumentNullException(nameof(dict));
			
			return dict.First(x => Equals(value, x.Value)).Key;
		}
	}
}