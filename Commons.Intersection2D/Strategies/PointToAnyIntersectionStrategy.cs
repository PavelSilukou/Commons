using System;
using System.Collections.Generic;
using System.Numerics;
using Commons.Intersection2D.Shapes;

namespace Commons.Intersection2D.Strategies
{
	[Strategy]
	internal class PointToAnyIntersectionStrategy: IntersectionStrategy<CPoint, CShape>
	{
		protected override List<IntersectionShapeTypesPair> GetShapeTypes()
		{
			return new List<IntersectionShapeTypesPair>
			{
				new(typeof(CPoint), typeof(CPoint)),
				new(typeof(CPoint), typeof(CLine)),
				new(typeof(CPoint), typeof(CLineSegment)),
				new(typeof(CPoint), typeof(CArc)),
				new(typeof(CPoint), typeof(CCircle)),
				new(typeof(CPoint), typeof(CPolyline)),
				new(typeof(CPoint), typeof(CPolygon)),
				new(typeof(CPoint), typeof(CQuadrilateral)),
				new(typeof(CPoint), typeof(CRectangle)),
				new(typeof(CPoint), typeof(CRotatedRectangle))
			};
		}
		
		protected override bool IsIntersect(CPoint point, CShape shape)
		{
			return false;
		}
		
		protected override bool IsIntersect(out Vector2[] intersectionPoints, CPoint point, CShape shape)
		{
			intersectionPoints = Array.Empty<Vector2>();
			return false;
		}
	}
}