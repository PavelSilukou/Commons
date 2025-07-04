using System;
using JetBrains.Annotations;

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
			if (!float.IsFinite(tolerance)) throw new ArithmeticException($"'{nameof(tolerance)}' parameter must be finite");
			if (float.IsNegative(tolerance)) throw new ArithmeticException($"'{nameof(tolerance)}' parameter must be positive");
			
			return EqualToInternal(a, b, tolerance);
		}
		
		public static bool LessOrEqualTo(this float a, float b)
		{
			return a < b || EqualToInternal(a, b);
		}
		
		[PublicAPI]
		public static bool LessOrEqualTo(this float a, float b, float tolerance)
		{
			if (!float.IsFinite(tolerance)) throw new ArithmeticException($"'{nameof(tolerance)}' parameter must be finite");
			if (float.IsNegative(tolerance)) throw new ArithmeticException($"'{nameof(tolerance)}' parameter must be positive");
			
			return a < b || EqualToInternal(a, b, tolerance);
		}
		
		public static bool MoreOrEqualTo(this float a, float b)
		{
			return a > b || EqualToInternal(a, b);
		}
		
		[PublicAPI]
		public static bool MoreOrEqualTo(this float a, float b, float tolerance)
		{
			if (!float.IsFinite(tolerance)) throw new ArithmeticException($"'{nameof(tolerance)}' parameter must be finite");
			if (float.IsNegative(tolerance)) throw new ArithmeticException($"'{nameof(tolerance)}' parameter must be positive");
			
			return a > b || EqualToInternal(a, b, tolerance);
		}

		internal static bool EqualToInternal(float a, float b, float tolerance = 0.001f)
		{
			return Math.Abs(a - b) <= tolerance;
		}
	}
}