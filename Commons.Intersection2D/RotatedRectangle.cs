using System;
using System.Numerics;
using Commons.EqualityComparers;
using Commons.Intersection2D.CShapes;

namespace Commons.Intersection2D
{
	public static partial class Shapes
	{
		public static CShape CreateRotatedRectangle(Vector2 point1, Vector2 point2, Vector2 point3, Vector2 point4)
		{
			return new CRotatedRectangle(point1, point2, point3, point4);
		}
		
		public static CShape TryCreateRotatedRectangle(Vector2 point1, Vector2 point2, Vector2 point3, Vector2 point4)
		{
			if (IsPoint(point1, point2, point3, point4)) return new CPoint(point1);
			if (point1.EqualTo(point4) && point2.EqualTo(point3)) return new CLineSegment(point1, point2);
			if (point1.EqualTo(point2) && point3.EqualTo(point4)) return new CLineSegment(point1, point3);
			if (!IsRotatedRectangle(point1, point2, point3, point4)) return new CQuadrilateral(point1, point2, point3, point4);
			return new CRotatedRectangle(point1, point2, point3, point4);
		}

		public static CShape ValidateAndCreateRotatedRectangle(Vector2 point1, Vector2 point2, Vector2 point3, Vector2 point4)
		{
			if (!Vector2Utils.IsFinite(point1)) 
				throw new ArithmeticException($"'{nameof(point1)}' should be finite.");
			if (!Vector2Utils.IsFinite(point2)) 
				throw new ArithmeticException($"'{nameof(point2)}' should be finite.");
			if (!Vector2Utils.IsFinite(point3)) 
				throw new ArithmeticException($"'{nameof(point3)}' should be finite.");
			if (!Vector2Utils.IsFinite(point4)) 
				throw new ArithmeticException($"'{nameof(point4)}' should be finite.");

			// TODO
			if (IsPoint(point1, point2, point3, point4)) 
				throw new ArithmeticException("Points do not form a rotated rectangle.");
			if (point1.EqualTo(point4) && point2.EqualTo(point3))
				throw new ArithmeticException("Points do not form a rotated rectangle.");
			if (point1.EqualTo(point2) && point3.EqualTo(point4))
				throw new ArithmeticException("Points do not form a rotated rectangle.");
			if (!IsRotatedRectangle(point1, point2, point3, point4))
				throw new ArithmeticException("Points do not form a rotated rectangle.");
			
			return new CRotatedRectangle(point1, point2, point3, point4);
		}
		
		private static bool IsPoint(Vector2 point1, Vector2 point2, Vector2 point3, Vector2 point4)
		{
			var points = new[] { point1, point2, point3, point4 };
			return points.AllEquals(new Vector2EqualityComparer());
		}
		
		private static bool IsRotatedRectangle(Vector2 point1, Vector2 point2, Vector2 point3, Vector2 point4)
		{
			var cx = (point1.X + point2.X + point3.X + point4.X) / 4;
			var cy = (point1.Y + point2.Y + point3.Y + point4.Y) / 4;

			var dd1 = MathF.Pow(cx - point1.X, 2.0f) + MathF.Pow(cy - point1.Y, 2.0f);
			var dd2 = MathF.Pow(cx - point2.X, 2.0f) + MathF.Pow(cy - point2.Y, 2.0f);
			var dd3 = MathF.Pow(cx - point3.X, 2.0f) + MathF.Pow(cy - point3.Y, 2.0f);
			var dd4 = MathF.Pow(cx - point4.X, 2.0f) + MathF.Pow(cy - point4.Y, 2.0f);
			return dd1.EqualTo(dd2) && dd1.EqualTo(dd3) && dd1.EqualTo(dd4);
		}
	}
}