using System;
using System.Collections.Generic;
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

		public static IEnumerable<float> Split(float value, float splitValue)
		{
			var groupsCount = (int)(value / splitValue);
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
		
		public static IEnumerable<float> SplitClosestMin(float value, float splitValue)
		{
			var groupsCount = (int)(value / splitValue);
			if (groupsCount * splitValue < value)
			{
				groupsCount++;
			}

			var resultValue = value / groupsCount;
			for (var i = 0; i < groupsCount; i++)
			{
				yield return resultValue;
			}
		}
		
		public static IEnumerable<float> SplitClosestMin(float value, float splitValue, float tolerance)
		{
			var minValue = splitValue - tolerance;
			var groupsCount = (int)(value / minValue);
			if (groupsCount * (tolerance * 2) > value % minValue)
			{
				var resultValue = value / groupsCount;
				for (var i = 0; i < groupsCount; i++)
				{
					yield return resultValue;
				}
			}
			else
			{
				for (var i = 0; i < groupsCount; i++)
				{
					yield return minValue;
				}

				yield return value - minValue * groupsCount;
			}
		}
		
		public static IEnumerable<float> SplitClosestMax(float value, float splitValue)
		{
			var groupsCount = (int)(value / splitValue);

			var resultValue = value / groupsCount;
			for (var i = 0; i < groupsCount; i++)
			{
				yield return resultValue;
			}
		}
		
		public static IEnumerable<float> SplitClosestMax(float value, float splitValue, float tolerance)
		{
			var maxValue = splitValue + tolerance;
			var groupsCount = (int)(value / maxValue);
			if (value / (groupsCount + 1) > splitValue - tolerance)
			{
				groupsCount++;
				var resultValue = value / groupsCount;
				for (var i = 0; i < groupsCount; i++)
				{
					yield return resultValue;
				}
			}
			else
			{
				for (var i = 0; i < groupsCount; i++)
				{
					yield return maxValue;
				}

				yield return value - maxValue * groupsCount;
			}
		}

		public static int Sign(float x)
		{
			if (!float.IsFinite(x)) throw new ArithmeticException("Value is not finite.");
			return MathF.Sign(x) == -1 ? -1 : 1;
		}
	}
}