using System;
using System.Numerics;

namespace Commons.Intersection2D.Shapes
{
	public class CLine : CShape
	{
		public readonly Vector2 Point1;
		public readonly Vector2 Point2;
		
		public CLine(Vector2 point1, Vector2 point2)
		{
			Point1 = point1;
			Point2 = point2;
		}

		protected override void Validation()
		{
			if (!Vector2Utils.IsFinite(Point1)) throw new ArithmeticException("Point1 is not finite.");
			if (!Vector2Utils.IsFinite(Point2)) throw new ArithmeticException("Point2 is not finite.");
		}

		protected override CShape OverrideTrueShape()
		{
			if (Vector2.Distance(Point1, Point2).EqualTo(0.0f)) return new CPoint(Point1);
			return this;
		}
	}
}