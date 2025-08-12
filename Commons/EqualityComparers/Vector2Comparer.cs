using System;
using System.Collections.Generic;
using System.Numerics;

namespace Commons.EqualityComparers
{
	public class Vector2EqualityComparer : IEqualityComparer<Vector2>
	{
		public bool Equals(Vector2 x, Vector2 y)
		{
			return x.EqualTo(y);
		}

		public int GetHashCode(Vector2 obj)
		{
			return HashCode.Combine(obj.X, obj.Y);
		}
	}
}