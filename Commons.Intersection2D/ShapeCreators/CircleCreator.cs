using System;
using System.Numerics;
using Commons.Intersection2D.CShapes;
using JetBrains.Annotations;

namespace Commons.Intersection2D.ShapeCreators
{
	public class CircleCreator
	{
		private readonly Equality.Equality _equality;
		
		internal CircleCreator(Equality.Equality equality)
		{
			_equality = equality;
		}
		
		public CShape Create(Vector2 center, float radius)
		{
			if (!Vector2Utils.IsFinite(center)) 
				throw new ArithmeticException($"'{nameof(center)}' should be finite.");
			if (!float.IsFinite(radius) || float.IsNegative(radius) || _equality.Float.EqualTo(radius, 0.0f)) 
				throw new ArithmeticException($"'{nameof(radius)}' should be finite and more than zero.");
			return new CCircle(center, radius);
		}
		
		public CShape TryCreate(Vector2 center, float radius)
		{
			if (float.IsNegative(radius) || _equality.Float.EqualTo(radius, 0.0f)) return new CPoint(center);
			return new CCircle(center, radius);
		}
		
		[PublicAPI]
		public CShape ForceCreate(Vector2 center, float radius)
		{
			return new CCircle(center, radius);
		}
	}
}