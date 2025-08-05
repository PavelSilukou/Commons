using System;

namespace Commons
{
	public static class Settings
	{
		private static float _equalsTolerance = 0.001f;

		public static float GetEqualsTolerance()
		{
			return _equalsTolerance;
		}

		public static void SetEqualsTolerance(float tolerance)
		{
			if (!float.IsFinite(tolerance)) throw new ArithmeticException($"'{nameof(tolerance)}' parameter must be finite");
			if (float.IsNegative(tolerance)) throw new ArithmeticException($"'{nameof(tolerance)}' parameter must be positive");
			_equalsTolerance = tolerance;
		}
	}
}