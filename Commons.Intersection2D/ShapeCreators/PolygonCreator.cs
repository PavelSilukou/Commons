using System;
using System.Numerics;
using Commons.Intersection2D.CShapes;

// TODO: check annotation PublicAPI
// TODO: проверить фигурные кавычки в однострочных if

namespace Commons.Intersection2D.ShapeCreators
{
	public class PolygonCreator
	{
		private readonly Approximation.Approximation _approximation;
		
		internal PolygonCreator(Approximation.Approximation approximation)
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
			// TODO: check first and last point
			
			return new CPolygon(points);
		}
		
		public CShape TryCreate(Vector2[] points)
		{
			if (IsPoint(points)) return new CPoint(points[0]);
			return new CPolygon(points);
		}
		
		private bool IsPoint(Vector2[] points)
		{
			return points.AllEquals(_approximation.Vector2.GetEqualityComparer());
		}
	}
}