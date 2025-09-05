using System;
using System.Numerics;
using Commons.Intersection2D.CShapes;

namespace Commons.Intersection2D.ShapeCreators
{
	public static class LineCreator
	{
		public static CShape Create(Vector2 point1, Vector2 point2)
		{
			return new CLine(point1, point2);
		}
		
		public static CShape TryCreate(Vector2 point1, Vector2 point2)
		{
			if (Vector2.Distance(point1, point2).EqualTo(0.0f)) return new CPoint(point1);
			return new CLine(point1, point2);
		}

		public static CShape ValidateAndCreate(Vector2 point1, Vector2 point2)
		{
			if (!Vector2Utils.IsFinite(point1)) 
				throw new ArithmeticException($"'{nameof(point1)}' should be finite.");
			if (!Vector2Utils.IsFinite(point2)) 
				throw new ArithmeticException($"'{nameof(point2)}' should be finite.");
			if (Vector2.Distance(point1, point2).EqualTo(0.0f)) 
				throw new ArithmeticException($"Distance between '{nameof(point1)}' and '{nameof(point2)}' should be more than 0.0f.");
			
			return new CLine(point1, point2);
		}
	}
}