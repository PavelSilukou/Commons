using System.Numerics;

namespace Commons
{
	public static class Vector2Extensions
	{
		public static bool EqualTo(this Vector2 vector1, Vector2 vector2)
		{
			return vector1.X.EqualTo(vector2.X) && vector1.Y.EqualTo(vector2.Y);
		}
	}
}