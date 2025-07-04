using System;
using System.Numerics;

namespace Commons.Intersection2D.Internal.Forms
{
	internal class LineSegment : Form
	{
		public readonly Vector2 Point1;
		public readonly Vector2 Point2;
		
		internal LineSegment(Vector2 point1, Vector2 point2)
		{
			Point1 = point1;
			Point2 = point2;
		}
		
		protected override void OptionalValidation()
		{
			if (!Vector2Utils.IsFinite(Point1)) throw new ArithmeticException("Point1 is not finite.");
			if (!Vector2Utils.IsFinite(Point2)) throw new ArithmeticException("Point2 is not finite.");
		}

		protected override Form OverrideTrueForm()
		{
			if (Vector2.Distance(Point1, Point2).EqualTo(0.0f)) return new Point(Point1);
			return this;
		}
	}
}