using System;

namespace Commons
{
	// TODO
	public static class Settings
	{
		private static float _equalsTolerance = 0.001f;

		public static float GetEqualsTolerance()
		{
			return _equalsTolerance;
		}

		public static void SetEqualsTolerance(float tolerance)
		{
			if (!float.IsFinite(tolerance) || float.IsNegative(tolerance)) 
				throw new ArithmeticException($"'{nameof(tolerance)}' should be finite and positive.");
			
			_equalsTolerance = tolerance;
		}
	}
}