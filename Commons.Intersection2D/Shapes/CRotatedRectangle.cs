using System;
using System.Numerics;

namespace Commons.Intersection2D.Shapes
{
	public class CRotatedRectangle : CQuadrilateral
	{
		public CRotatedRectangle(Vector2 point1, Vector2 point2, Vector2 point3, Vector2 point4) 
			: base(point1, point2, point3, point4)
		{
		}

		protected override CShape OverrideTrueShape()
		{
			if (Point1.EqualTo(Point2) && Point1.EqualTo(Point3) && Point1.EqualTo(Point4)) return new CPoint(Point1);
			if (Point1.EqualTo(Point4) && Point2.EqualTo(Point3)) return new CLineSegment(Point1, Point2);
			if (Point1.EqualTo(Point2) && Point3.EqualTo(Point4)) return new CLineSegment(Point1, Point3);
			return IsRotatedRectangle() ? this : new CQuadrilateral(Point1, Point2, Point3, Point4);
		}
		
		private bool IsRotatedRectangle()
		{
			var cx = (Point1.X + Point2.X + Point3.X + Point4.X) / 4;
			var cy = (Point1.Y + Point2.Y + Point3.Y + Point4.Y) / 4;

			var dd1 = MathF.Pow(cx - Point1.X, 2.0f) + MathF.Pow(cy - Point1.Y, 2.0f);
			var dd2 = MathF.Pow(cx - Point2.X, 2.0f) + MathF.Pow(cy - Point2.Y, 2.0f);
			var dd3 = MathF.Pow(cx - Point3.X, 2.0f) + MathF.Pow(cy - Point3.Y, 2.0f);
			var dd4 = MathF.Pow(cx - Point4.X, 2.0f) + MathF.Pow(cy - Point4.Y, 2.0f);
			return dd1.EqualTo(dd2) && dd1.EqualTo(dd3) && dd1.EqualTo(dd4);
		}
	}
}