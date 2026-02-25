using System;
using System.Numerics;
using Commons.Intersection2D.CShapes;

namespace Commons.Intersection2D.ShapeCreators
{
	public class CircleCreator
	{
		private readonly Approximation.Approximation _approximation;
		
		internal CircleCreator(Approximation.Approximation approximation)
		{
			_approximation = approximation;
		}
		
		public CShape Create(Vector2 center, float radius)
		{
			if (!_approximation.Vector2.IsFinite(center)) 
				throw new ArithmeticException($"'{nameof(center)}' should be finite.");
			if (!float.IsFinite(radius) || float.IsNegative(radius) || _approximation.Float.EqualTo(radius, 0.0f)) 
				throw new ArithmeticException($"'{nameof(radius)}' should be finite and more than zero.");
			return new CCircle(center, radius);
		}
		
		public CShape TryCreate(Vector2 center, float radius)
		{
			if (float.IsNegative(radius) || _approximation.Float.EqualTo(radius, 0.0f)) return new CPoint(center);
			return new CCircle(center, radius);
		}
	}
}