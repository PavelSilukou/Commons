using System;
using System.Collections.Generic;
using System.Numerics;
using Commons.Intersection2D.Shapes;

namespace Commons.Intersection2D.Strategies
{
	[Strategy]
	internal class RotatedRectangleToRotatedRectangleIntersectionStrategy: IntersectionStrategy<CRotatedRectangle, CRotatedRectangle>
	{
		protected override List<IntersectionShapeTypesPair> GetShapeTypes()
		{
			return new List<IntersectionShapeTypesPair>
			{
				new(typeof(CRotatedRectangle), typeof(CRotatedRectangle))
			};
		}

		protected override bool IsIntersect(CRotatedRectangle rect1, CRotatedRectangle rect2)
		{
			var rect1Points = new[] { rect1.Point1, rect1.Point2, rect1.Point3, rect1.Point4 };
			var rect2Points = new[] { rect2.Point1, rect2.Point2, rect2.Point3, rect2.Point4 };
			
			for (var i = 0; i < 2; i++)
			{
				var intersection = false;
				for (var j = 0; j < 4; j++)
				{
					var isProject = Vector2Utils.PointProjectionOnLineSegment(
						out _,
						rect2Points[j],
						rect1Points[i],
						rect1Points[i + 1]
					);
					intersection |= isProject;
				}

				if (!intersection) return false;
			}

			for (var i = 0; i < 2; i++)
			{
				var intersection = false;
				for (var j = 0; j < 4; j++)
				{
					var isProject = Vector2Utils.PointProjectionOnLineSegment(
						out _,
						rect1Points[j],
						rect2Points[i],
						rect2Points[i + 1]
					);
					intersection |= isProject;
				}

				if (!intersection) return false;
			}

			return true;
		}

		protected override bool IsIntersect(out Vector2[] intersectionPoints, CRotatedRectangle rect1, CRotatedRectangle rect2)
		{
			throw new NotImplementedException();
		}
	}
}