using System;

namespace Commons
{
	public static class FloatExtensions
	{
		public static bool EqualTo(this float a, float b)
		{
			return Math.Abs(a - b) <= Settings.GetEqualsTolerance();
		}
		
		public static bool LessOrEqualTo(this float a, float b)
		{
			return a < b || EqualTo(a, b);
		}
		
		public static bool MoreOrEqualTo(this float a, float b)
		{
			return a > b || EqualTo(a, b);
		}
	}
}