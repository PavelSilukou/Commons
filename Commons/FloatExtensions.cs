using System;

namespace Commons
{
	public static class FloatExtensions
	{
		public static bool EqualTo(this float a, float b)
		{
			return EqualToInternal(a, b);
		}
		
		public static bool EqualTo(this float a, float b, float tolerance)
		{
			InternalCheckUtils.IsFiniteValue(tolerance, nameof(tolerance));
			InternalCheckUtils.IsPositiveValue(tolerance, nameof(tolerance));
			
			return EqualToInternal(a, b, tolerance);
		}

		internal static bool EqualToInternal(float a, float b, float tolerance = 0.000001f)
		{
			return Math.Abs(a - b) <= tolerance;
		}
	}
}