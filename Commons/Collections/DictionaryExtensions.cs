using System.Collections.Generic;
using System.Linq;

namespace Commons.Collections
{
	public static class DictionaryExtensions
	{
		public static void AddToListValue<T, TU>(this IDictionary<T, List<TU>> dict, T key, TU value)
		{
			InternalCheckUtils.IsNotNull(dict, nameof(dict));
			
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
			InternalCheckUtils.IsNotNull(dict, nameof(dict));
			
			return dict.First(x => Equals(value, x.Value)).Key;
		}
	}
}