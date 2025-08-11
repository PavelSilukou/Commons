using System;
using System.Collections.Generic;
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
		
		public static IEnumerable<int> Split(int value, int splitValue)
		{
			var groupsCount = value / splitValue;
			if (groupsCount * splitValue < value)
			{
				groupsCount++;
			}

			for (var i = 0; i < groupsCount; i++)
			{
				var resultValue = Math.Min(splitValue, value);
				yield return resultValue;
				value -= resultValue;
			}
		}

		public static IEnumerable<int> SplitClosest(int value, int splitValue)
		{
			var groupsCount = value / splitValue;
			if (groupsCount * splitValue < value)
			{
				groupsCount++;
			}

			var groupsLeft = groupsCount;
			while (value > 0)
			{
				var nextGroupValue = value / groupsLeft;
				if (nextGroupValue * groupsLeft < value)
				{
					nextGroupValue++;
				}

				yield return nextGroupValue;
				
				groupsLeft--;
				value -= nextGroupValue;
			}
		}
		
		public static int Sign(int x)
		{
			return Math.Sign(x) == -1 ? -1 : 1;
		}
	}
}