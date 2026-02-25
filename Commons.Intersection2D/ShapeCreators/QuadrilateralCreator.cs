using System;
using System.Numerics;
using Commons.Intersection2D.CShapes;

namespace Commons.Intersection2D.ShapeCreators
{
	public class QuadrilateralCreator
	{
		private readonly Approximation.Approximation _approximation;
		
		internal QuadrilateralCreator(Approximation.Approximation approximation)
		{
			_approximation = approximation;
		}
		
		public CShape Create(Vector2 point1, Vector2 point2, Vector2 point3, Vector2 point4)
		{
			if (!_approximation.Vector2.IsFinite(point1)) 
				throw new ArithmeticException($"'{nameof(point1)}' should be finite.");
			if (!_approximation.Vector2.IsFinite(point2)) 
				throw new ArithmeticException($"'{nameof(point2)}' should be finite.");
			if (!_approximation.Vector2.IsFinite(point3)) 
				throw new ArithmeticException($"'{nameof(point3)}' should be finite.");
			if (!_approximation.Vector2.IsFinite(point4)) 
				throw new ArithmeticException($"'{nameof(point4)}' should be finite.");
			
			return new CQuadrilateral(point1, point2, point3, point4);
		}
		
		public CShape TryCreate(Vector2 point1, Vector2 point2, Vector2 point3, Vector2 point4)
		{
			if (IsPoint(point1, point2, point3, point4)) return new CPoint(point1);
			return new CQuadrilateral(point1, point2, point3, point4);
		}

		private bool IsPoint(Vector2 point1, Vector2 point2, Vector2 point3, Vector2 point4)
		{
			var points = new[] { point1, point2, point3, point4 };
			return points.AllEquals(_approximation.Vector2.GetEqualityComparer());
		}
	}
}