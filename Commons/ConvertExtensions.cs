using System;

namespace Commons
{
	public static class ConvertExtensions
	{
		public static T GetValue<T>(this object value)
		{
			if (value == null) throw new ArgumentNullException(nameof(value));
			
			return (T)Convert.ChangeType(value, typeof(T));
		}
	}
}