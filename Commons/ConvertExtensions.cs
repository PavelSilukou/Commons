using System;

namespace Commons
{
	public static class ConvertExtensions
	{
		public static T GetValue<T>(this object value)
		{
			InternalCheckUtils.IsNotNull(value, nameof(value));
			
			return (T)Convert.ChangeType(value, typeof(T));
		}
	}
}