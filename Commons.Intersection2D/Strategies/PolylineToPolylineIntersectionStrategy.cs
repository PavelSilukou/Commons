using System;
using System.Linq;
using System.Numerics;
using Commons.Intersection2D.Shapes;

namespace Commons.Intersection2D.Strategies
{
	[Strategy]
	internal class PolylineToPolylineIntersectionStrategy: IntersectionStrategy<CPolyline, CPolyline>
	{
		private readonly IIntersectionStrategy _lineSegmentToPolylineIntersectionStrategy = 
			new LineSegmentToPolylineIntersectionStrategy();
		
		protected override bool IsIntersect(CPolyline polyline1, CPolyline polyline2)
		{
			return polyline1.Segments.Any(segment =>
				_lineSegmentToPolylineIntersectionStrategy.IsIntersect(segment, polyline2));
		}

		protected override bool IsIntersect(out Vector2[] intersectionPoints, CPolyline polyline1, CPolyline polyline2)
		{
			throw new NotImplementedException();
		}
	}
}