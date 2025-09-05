using System;
using System.Numerics;
using Commons.Intersection2D.CShapes;

namespace Commons.Intersection2D
{
	public static partial class Shapes
	{
		public static CShape CreateCircle(Vector2 center, float radius)
		{
			return new CCircle(center, radius);
		}
		
		public static CShape TryCreateCircle(Vector2 center, float radius)
		{
			if (float.IsNegative(radius) || radius.EqualTo(0.0f)) return new CPoint(center);
			return new CCircle(center, radius);
		}

		public static CShape ValidateAndCreateCircle(Vector2 center, float radius)
		{
			if (!Vector2Utils.IsFinite(center)) 
				throw new ArithmeticException($"'{nameof(center)}' should be finite.");
			if (!float.IsFinite(radius) || float.IsNegative(radius) || radius.EqualTo(0.0f)) 
				throw new ArithmeticException($"'{nameof(radius)}' should be finite and more than zero.");
			return new CCircle(center, radius);
		}
	}
}