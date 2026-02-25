using System;
using System.Numerics;
using Commons.Intersection2D.CShapes;

// TODO: check annotation PublicAPI
// TODO: проверить фигурные кавычки в однострочных if

namespace Commons.Intersection2D.ShapeCreators
{
	public class PolylineCreator
	{
		private readonly Approximation.Approximation _approximation;
		
		internal PolylineCreator(Approximation.Approximation approximation)
		{
			_approximation = approximation;
		}
		
		public CShape Create(Vector2[] points)
		{
			if (points.Length == 0) throw new ArithmeticException($"'{nameof(points)}' is empty.");
			for(var i = 0; i < points.Length; i++)
			{
				if (!_approximation.Vector2.IsFinite(points[i])) 
					throw new ArithmeticException($"'{nameof(points)}' element {i} should be finite.");
			}
			
			return new CPolyline(points);
		}
		
		public CShape TryCreate(Vector2[] points)
		{
			if (IsPoint(points)) return new CPoint(points[0]);
			// TODO: length == 1 return point
			// TODO: length == 2 return segment
			return new CPolyline(points);
		}
		
		private bool IsPoint(Vector2[] points)
		{
			return points.AllEquals(_approximation.Vector2.GetEqualityComparer());
		}
	}
}