using System;
using JetBrains.Annotations;

namespace Commons
{
	[PublicAPI]
	public static class MathUtils
	{
		public static int GetBinomialCoefficient(int n, int i)
		{
			return Factorial(n) / (Factorial(i) * Factorial(n - i));
		}

		public static int Factorial(int i)
		{
			if (i <= 1) return 1;
			return i * Factorial(i - 1);
		}

		public static float GetBernsteinBasisPolynomials(int n, int i, float t)
		{
			return GetBinomialCoefficient(n, i) * MathF.Pow(t, i) * MathF.Pow(1 - t, n - i);
		}

		public static int RepeatPositive(int value, int minValue, int maxValue)
		{
			var length = maxValue - minValue + 1;
			var targetValue = value;
			while (targetValue > maxValue)
			{
				targetValue -= length;
			}

			return targetValue;
		}

		public static int RepeatNegative(int value, int minValue, int maxValue)
		{
			var length = maxValue - minValue + 1;
			var targetValue = value;
			while (targetValue < minValue)
			{
				targetValue += length;
			}

			return targetValue;
		}

		public static int Repeat(int value, int minValue, int maxValue)
		{
			return value >= minValue
				? RepeatPositive(value, minValue, maxValue)
				: RepeatNegative(value, minValue, maxValue);
		}

		public static int Clamp(int value, int minValue, int maxValue)
		{
			return Math.Max(minValue, Math.Min(value, maxValue));
		}
	}
}