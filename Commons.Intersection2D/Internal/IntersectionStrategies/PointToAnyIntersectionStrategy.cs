using System;
using System.Numerics;
using Commons.Intersection2D.Internal.Forms;

namespace Commons.Intersection2D.Internal.IntersectionStrategies
{
	internal class PointToAnyIntersectionStrategy: IntersectionStrategy<Point, Form>
	{
		public override FormTypesPair[] GetFormTypes()
		{
			return new[]
			{
				new FormTypesPair(typeof(Point), typeof(Point)),
				new FormTypesPair(typeof(Point), typeof(Line)),
				new FormTypesPair(typeof(Point), typeof(LineSegment)),
				new FormTypesPair(typeof(Point), typeof(Arc)),
				new FormTypesPair(typeof(Point), typeof(Circle)),
				new FormTypesPair(typeof(Point), typeof(Quadrilateral)),
				new FormTypesPair(typeof(Point), typeof(Rectangle)),
				new FormTypesPair(typeof(Point), typeof(RotatedRectangle))
			};
		}
		
		protected override bool IsIntersect(Point point, Form form)
		{
			return false;
		}
		
		protected override bool IsIntersect(out Vector2[] intersectionPoints, Point point, Form form)
		{
			intersectionPoints = Array.Empty<Vector2>();
			return false;
		}
	}
}