using System;
using JetBrains.Annotations;

namespace Commons
{
	[PublicAPI]
	public static class MathFUtils
	{
		public static float Clamp(float value, float minValue, float maxValue)
		{
			return Math.Max(minValue, Math.Min(value, maxValue));
		}

		public static float Clamp01(float value)
		{
			return Clamp(value, 0.0f, 1.0f);
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
			return degrees * (MathF.PI / 180);
		}

		public static float Rad2Deg(float radians)
		{
			return radians * (180 / MathF.PI);
		}
	}
}