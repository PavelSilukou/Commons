using System;

namespace Commons.Intersection2D
{
	public static class Settings
	{
		public static float GetEqualsTolerance()
		{
			return Commons.Settings.GetEqualsTolerance();
		}

		public static void SetEqualsTolerance(float tolerance)
		{
			if (!float.IsFinite(tolerance) || float.IsNegative(tolerance)) 
				throw new ArithmeticException($"'{nameof(tolerance)}' should be finite and positive.");
			
			Commons.Settings.SetEqualsTolerance(tolerance);
		}
	}
}