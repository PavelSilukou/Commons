using System;
using System.Collections.Generic;
using System.Numerics;

namespace Commons.Equality.CVector2
{
	public class Vector2EqualityComparer : IEqualityComparer<Vector2>
	{
		private readonly Vector2Equality _vector2Equality;
		
		internal Vector2EqualityComparer(Vector2Equality vector2Equality)
		{
			_vector2Equality = vector2Equality;
		}
		
		public bool Equals(Vector2 x, Vector2 y)
		{
			return _vector2Equality.EqualTo(x, y);
		}

		public int GetHashCode(Vector2 obj)
		{
			return HashCode.Combine(obj.X, obj.Y);
		}
	}
}