using System;
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