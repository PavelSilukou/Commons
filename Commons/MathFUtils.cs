using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace Commons
{
	[PublicAPI]
	public static class MathFUtils
	{
		// TODO
		// Math.Clamp(t, 0.0f, 1.0f)
		public static float Clamp(float value, float minValue, float maxValue)
		{
			return Math.Max(minValue, Math.Min(value, maxValue));
		}

		public static float Clamp01(float value)
		{
			return Clamp(value, 0.0f, 1.0f);
		}

		public static float ClampAngleDeg(float angle)
		{
			return angle % 360.0f;
		}

		public static float Lerp(float a, float b, float t)
		{
			return a * (1.0f - t) + b * t;
		}

		public static float InverseLerp(float a, float b, float value)
		{
			return (value - a) / (b - a);
		}

		public static float Repeat(float t, float length)
		{
			return Clamp(t - MathF.Floor(t / length) * length, 0.0f, length);
		}

		public static float Repeat(float value, float minValue, float maxValue)
		{
			return value >= minValue
				? RepeatPositive(value, minValue, maxValue)
				: RepeatNegative(value, minValue, maxValue);
		}

		public static float RepeatPositive(float value, float minValue, float maxValue)
		{
			var length = maxValue - minValue + 1;
			var targetValue = value;
			while (targetValue > maxValue)
			{
				targetValue -= length;
			}

			return targetValue;
		}

		public static float RepeatNegative(float value, float minValue, float maxValue)
		{
			var length = maxValue - minValue + 1;
			var targetValue = value;
			while (targetValue < minValue)
			{
				targetValue += length;
			}

			return targetValue;
		}

		public static float PingPong(float t, float length)
		{
			t = Repeat(t, length * 2f);
			return length - MathF.Abs(t - length);
		}

		public static float PingPong(float t, float minValue, float maxValue)
		{
			return minValue + PingPong(t, maxValue - minValue);
		}

		public static float Deg2Rad(float degrees)
		{
			return degrees * (MathF.PI / 180.0f);
		}

		public static float Rad2Deg(float radians)
		{
			return radians * (180.0f / MathF.PI);
		}

		public static IEnumerable<float> Split(float numerator, float denominator)
		{
			var quotient = MathUtils.Ceiling(numerator / denominator);

			for (var i = 0; i < quotient; i++)
			{
				var resultValue = Math.Min(denominator, numerator);
				yield return resultValue;
				numerator -= resultValue;
			}
		}

		public static float GetClosestDenominator(float numerator, float initialDenominator)
		{
			var minDenominator = GetClosestMinDenominator(numerator, initialDenominator);
			var maxDenominator = GetClosestMaxDenominator(numerator, initialDenominator);

			return Math.Abs(minDenominator - initialDenominator) <= Math.Abs(maxDenominator - initialDenominator) 
				? minDenominator 
				: maxDenominator;
		}
		
		public static float GetClosestDenominator(float numerator, float initialDenominator, float tolerance)
		{
			var minDenominator = GetClosestMinDenominator(numerator, initialDenominator);
			var maxDenominator = GetClosestMaxDenominator(numerator, initialDenominator);
			
			var minValue = initialDenominator - tolerance;
			var maxValue = initialDenominator + tolerance;

			if (minDenominator >= minValue && maxDenominator <= maxValue)
			{
				return Math.Abs(minDenominator - initialDenominator) <= Math.Abs(maxDenominator - initialDenominator) 
					? minDenominator 
					: maxDenominator;
			}

			if (minDenominator >= minValue)
			{
				return minDenominator;
			}

			// ReSharper disable once ConvertIfStatementToReturnStatement
			if (maxDenominator <= maxValue)
			{
				return maxDenominator;
			}

			return minValue;
		}
		
		public static float GetClosestMinDenominator(float numerator, float initialDenominator)
		{
			var quotient = MathUtils.Ceiling(numerator / initialDenominator);
			return numerator / quotient;
		}
		
		public static float GetClosestMinDenominator(float numerator, float initialDenominator, float tolerance)
		{
			var minDenominator = GetClosestMinDenominator(numerator, initialDenominator);
			var minValue = initialDenominator - tolerance;
			return minDenominator >= minValue ? minDenominator : minValue;
		}
		
		public static float GetClosestMaxDenominator(float numerator, float initialDenominator)
		{
			var quotient = MathUtils.Floor(numerator / initialDenominator);
			return numerator / quotient;
		}
		
		public static float GetClosestMaxDenominator(float numerator, float initialDenominator, float tolerance)
		{
			var maxDenominator = GetClosestMaxDenominator(numerator, initialDenominator);
			var maxValue = initialDenominator + tolerance;
			return maxDenominator <= maxValue ? maxDenominator : initialDenominator;
		}

		public static int Sign(float value)
		{
			return MathF.Sign(value) == -1 ? -1 : 1;
		}
	}
}