using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Commons.Intersection2D.Shapes;

namespace Commons.Intersection2D.Strategies
{
	[Strategy]
	internal class LineSegmentToPolylineIntersectionStrategy: IntersectionStrategy<CLineSegment, CPolyline>
	{
		private readonly IIntersectionStrategy _lineSegmentToLineSegmentIntersectionStrategy = 
			new LineSegmentToLineSegmentIntersectionStrategy();
		
		// TODO:
		protected override List<IntersectionShapeTypesPair> GetShapeTypes()
		{
			return new List<IntersectionShapeTypesPair>
			{
				new(typeof(CLineSegment), typeof(CQuadrilateral)),
				new(typeof(CLineSegment), typeof(CRotatedRectangle)),
				new(typeof(CLineSegment), typeof(CRectangle))
			};
		}

		protected override bool IsIntersect(CLineSegment lineSegment, CPolyline polyline)
		{
			return polyline.Segments.Any(segment =>
				_lineSegmentToLineSegmentIntersectionStrategy.IsIntersect(lineSegment, segment));
		}

		protected override bool IsIntersect(out Vector2[] intersectionPoints, CLineSegment lineSegment, CPolyline polyline)
		{
			throw new NotImplementedException();
		}
	}
}