using System.Numerics;

namespace Commons.Math2D
{
	public static class Vector2Extensions
	{
		public static bool EqualTo(this Vector2 vector1, Vector2 vector2)
		{
			return EqualToInternal(vector1, vector2);
		}

		public static bool EqualTo(this Vector2 vector1, Vector2 vector2, float tolerance)
		{
			InternalCheckUtils.IsFiniteValue(tolerance, nameof(tolerance));
			InternalCheckUtils.IsPositiveValue(tolerance, nameof(tolerance));

			return EqualToInternal(vector1, vector2, tolerance);
		}
		
		internal static bool EqualToInternal(Vector2 vector1, Vector2 vector2, float tolerance = 0.000001f)
		{
			return FloatExtensions.EqualToInternal(vector1.X, vector2.X, tolerance) 
			       && FloatExtensions.EqualToInternal(vector1.Y, vector2.Y, tolerance);
		}
	}
}