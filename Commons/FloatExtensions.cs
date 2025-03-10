using System;
using JetBrains.Annotations;

namespace Commons
{
	[PublicAPI]
	public static class FloatExtensions
	{
		public static float Round(this float value, int digits)
		{
			var rank = Math.Pow(10.0, digits);
			var result = Math.Truncate(rank * value) / rank;
			return (float)result;
		}
	}
}