using System;
using System.Numerics;
using Commons.Intersection2D.CShapes;

namespace Commons.Intersection2D.ShapeCreators
{
	public class LineCreator
	{
		private readonly Approximation.Approximation _approximation;
		
		internal LineCreator(Approximation.Approximation approximation)
		{
			_approximation = approximation;
		}
		
		public CShape Create(Vector2 point1, Vector2 point2)
		{
			if (!_approximation.Vector2.IsFinite(point1)) 
				throw new ArithmeticException($"'{nameof(point1)}' should be finite.");
			if (!_approximation.Vector2.IsFinite(point2)) 
				throw new ArithmeticException($"'{nameof(point2)}' should be finite.");
			if (_approximation.Float.EqualTo(Vector2.Distance(point1, point2), 0.0f)) 
				throw new ArithmeticException($"Distance between '{nameof(point1)}' and '{nameof(point2)}' should be more than 0.0f.");
			
			return new CLine(point1, point2);
		}
		
		public CShape TryCreate(Vector2 point1, Vector2 point2)
		{
			if (_approximation.Float.EqualTo(Vector2.Distance(point1, point2), 0.0f)) return new CPoint(point1);
			return new CLine(point1, point2);
		}
	}
}