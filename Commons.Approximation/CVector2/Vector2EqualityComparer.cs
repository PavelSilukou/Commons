using System;
using System.Collections.Generic;
using System.Numerics;

namespace Commons.Approximation.CVector2
{
	public class Vector2EqualityComparer : IEqualityComparer<Vector2>
	{
		private readonly Vector2Approximation _vector2Approximation;
		
		internal Vector2EqualityComparer(Vector2Approximation vector2Approximation)
		{
			_vector2Approximation = vector2Approximation;
		}
		
		public bool Equals(Vector2 x, Vector2 y)
		{
			return _vector2Approximation.EqualTo(x, y);
		}

		public int GetHashCode(Vector2 obj)
		{
			return HashCode.Combine(obj.X, obj.Y);
		}
	}
}