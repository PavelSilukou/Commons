using System;

namespace Commons
{
	public static class ConvertExtensions
	{
		public static TSource GetValue<TSource>(this object value)
		{
			if (value == null) throw new ArgumentNullException(nameof(value));
			
			return (TSource)Convert.ChangeType(value, typeof(TSource));
		}
	}
}