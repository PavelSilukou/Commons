using System;
using System.Numerics;
using Commons.Intersection2D.Shapes;

namespace Commons.Intersection2D.Strategies
{
	[Strategy]
	internal class LineToLineIntersectionStrategy: IntersectionStrategy<CLine, CLine>
	{
		protected override bool IsIntersect(CLine line1, CLine line2)
		{
			return IsIntersect(out _, line1, line2);
		}

		protected override bool IsIntersect(out Vector2[] intersectionPoints, CLine line1, CLine line2)
		{
			var nx = (line1.Point1.X * line1.Point2.Y - line1.Point1.Y * line1.Point2.X)
				* (line2.Point1.X - line2.Point2.X) - (line1.Point1.X - line1.Point2.X)
				* (line2.Point1.X * line2.Point2.Y - line2.Point1.Y * line2.Point2.X);
			var ny = (line1.Point1.X * line1.Point2.Y - line1.Point1.Y * line1.Point2.X)
				* (line2.Point1.Y - line2.Point2.Y) - (line1.Point1.Y - line1.Point2.Y)
				* (line2.Point1.X * line2.Point2.Y - line2.Point1.Y * line2.Point2.X);
			var d = (line1.Point1.X - line1.Point2.X)
			        * (line2.Point1.Y - line2.Point2.Y)
			        - (line1.Point1.Y - line1.Point2.Y)
			        * (line2.Point1.X - line2.Point2.X);

			if (d.EqualTo(0.0f)) // are parallel
			{
				if (!nx.EqualTo(0.0f) || !ny.EqualTo(0.0f)) // not the same
				{
					intersectionPoints = Array.Empty<Vector2>();
					return false; 
				}

				intersectionPoints = new[] { Vector2Utils.NaN() };
				return true;
			}

			intersectionPoints = new[] { new Vector2(nx / d, ny / d) };
			return true;
		}
	}
}