using System;
using System.Numerics;
using Commons.Intersection2D.CShapes;

namespace Commons.Intersection2D.ShapeCreators
{
	public class RectangleCreator
	{
		private readonly Approximation.Approximation _approximation;
		
		internal RectangleCreator(Approximation.Approximation approximation)
		{
			_approximation = approximation;
		}
		
		public CShape Create(float left, float top, float right, float bottom) 
		{
			if (!float.IsFinite(left)) 
				throw new ArithmeticException($"'{nameof(left)}' should be finite.");
			if (!float.IsFinite(top))
				throw new ArithmeticException($"'{nameof(top)}' should be finite.");
			if (!float.IsFinite(right))
				throw new ArithmeticException($"'{nameof(right)}' should be finite.");
			if (!float.IsFinite(bottom))
				throw new ArithmeticException($"'{nameof(bottom)}' should be finite.");
			
			if (_approximation.Float.MoreOrEqualTo(left, right)) 
				throw new ArithmeticException($"'{nameof(left)}' should be less than '{nameof(right)}'.");
			if (_approximation.Float.MoreOrEqualTo(bottom, top))
				throw new ArithmeticException($"'{nameof(bottom)}' should be less than '{nameof(top)}'.");
			
			return new CRectangle(left, top, right, bottom);
		}
		
		public CShape TryCreate(float left, float top, float right, float bottom) 
		{
			if (IsPoint(left, top, right, bottom)) return new CPoint(new Vector2(left, top));
			return new CRectangle(left, top, right, bottom);
		}
		
		private bool IsPoint(float left, float top, float right, float bottom)
		{
			var points = new[] { left, top, right, bottom };
			return points.AllEquals(_approximation.Float.GetEqualityComparer());
		}
	}
}