using System;
using System.Numerics;

namespace Commons
{
	public static class Vector2Extensions
	{
		public static bool EqualTo(this Vector2 vector1, Vector2 vector2)
		{
			return EqualToInternal(vector1, vector2);
		}

		public static bool EqualTo(this Vector2 vector1, Vector2 vector2, float tolerance)
		{
			if (!float.IsFinite(tolerance)) throw new ArithmeticException($"'{nameof(tolerance)}' parameter must be finite");
			if (float.IsNegative(tolerance)) throw new ArithmeticException($"'{nameof(tolerance)}' parameter must be positive");

			return EqualToInternal(vector1, vector2, tolerance);
		}
		
		private static bool EqualToInternal(Vector2 vector1, Vector2 vector2, float tolerance = 0.001f)
		{
			return FloatExtensions.EqualToInternal(vector1.X, vector2.X, tolerance) 
			       && FloatExtensions.EqualToInternal(vector1.Y, vector2.Y, tolerance);
		}
	}
}