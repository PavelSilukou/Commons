using System;
using System.Numerics;
using Commons.Intersection2D.CShapes;

namespace Commons.Intersection2D.ShapeCreators
{
	public class RotatedRectangleCreator
	{
		private readonly Approximation.Approximation _approximation;
		
		internal RotatedRectangleCreator(Approximation.Approximation approximation)
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
		
			if (_approximation.Vector2.EqualTo(point1, point2)
			    || _approximation.Vector2.EqualTo(point1, point3)
			    || _approximation.Vector2.EqualTo(point1, point4)
			    || _approximation.Vector2.EqualTo(point2, point3)
			    || _approximation.Vector2.EqualTo(point2, point4)
			    || _approximation.Vector2.EqualTo(point3, point4)
			    || !IsRotatedRectangle(point1, point2, point3, point4))
				throw new ArithmeticException("Points do not form a rotated rectangle.");
			
			return new CRotatedRectangle(point1, point2, point3, point4);
		}
		
		public CShape TryCreate(Vector2 point1, Vector2 point2, Vector2 point3, Vector2 point4)
		{
			if (IsPoint(point1, point2, point3, point4)) return new CPoint(point1);
			if (_approximation.Vector2.EqualTo(point1, point4) 
			    && _approximation.Vector2.EqualTo(point2, point3)) return new CLineSegment(point1, point2);
			if (_approximation.Vector2.EqualTo(point1, point2) 
			    && _approximation.Vector2.EqualTo(point3, point4)) return new CLineSegment(point1, point3);
			if (!IsRotatedRectangle(point1, point2, point3, point4)) return new CQuadrilateral(point1, point2, point3, point4);
			return new CRotatedRectangle(point1, point2, point3, point4);
		}
		
		private bool IsPoint(Vector2 point1, Vector2 point2, Vector2 point3, Vector2 point4)
		{
			var points = new[] { point1, point2, point3, point4 };
			return points.AllEquals(_approximation.Vector2.GetEqualityComparer());
		}
		
		private bool IsRotatedRectangle(Vector2 point1, Vector2 point2, Vector2 point3, Vector2 point4)
		{
			var cx = (point1.X + point2.X + point3.X + point4.X) / 4;
			var cy = (point1.Y + point2.Y + point3.Y + point4.Y) / 4;
		
			var dd1 = MathF.Pow(cx - point1.X, 2.0f) + MathF.Pow(cy - point1.Y, 2.0f);
			var dd2 = MathF.Pow(cx - point2.X, 2.0f) + MathF.Pow(cy - point2.Y, 2.0f);
			var dd3 = MathF.Pow(cx - point3.X, 2.0f) + MathF.Pow(cy - point3.Y, 2.0f);
			var dd4 = MathF.Pow(cx - point4.X, 2.0f) + MathF.Pow(cy - point4.Y, 2.0f);
			return _approximation.Float.EqualTo(dd1, dd2)
			       && _approximation.Float.EqualTo(dd1, dd3)
			       && _approximation.Float.EqualTo(dd1, dd4);
		}
	}
}