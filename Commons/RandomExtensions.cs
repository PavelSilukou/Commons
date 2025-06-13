using System;
using JetBrains.Annotations;

namespace Commons
{
	[PublicAPI]
	public static class RandomExtensions
	{
		public static bool Chance01(this Random random, float chance)
		{
			return random.NextDouble() <= chance;
		}

		public static bool Chance0100(this Random random, float chance)
		{
			return random.NextDouble() * 100.0f <= chance;
		}

		public static int NextInclusive(this Random random, int min, int max)
		{
			return random.Next(min, max + 1);
		}

		public static float Next(this Random random, float min, float max)
		{
			var sample = random.NextDouble();
			var scaled = sample * (max - min) + min;
			return (float)scaled;
		}
	}
}