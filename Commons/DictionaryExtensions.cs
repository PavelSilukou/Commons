using System;
using System.Collections.Generic;
using System.Linq;

namespace Commons
{
	public static class DictionaryExtensions
	{
		public static void AddToListValue<T, TU>(this IDictionary<T, List<TU>> dict, T key, TU value)
		{
			if (dict == null) throw new ArgumentNullException(nameof(dict));
			
			if (dict.TryGetValue(key, out var items))
			{
				items.Add(value);
			}
			else
			{
				dict.Add(key, new List<TU> { value });
			}
		}
		
		public static T FindKeyByValue<T, TU>(this IDictionary<T, TU> dict, TU value)
		{
			if (dict == null) throw new ArgumentNullException(nameof(dict));
			
			return dict.First(x => Equals(value, x.Value)).Key;
		}
	}
}