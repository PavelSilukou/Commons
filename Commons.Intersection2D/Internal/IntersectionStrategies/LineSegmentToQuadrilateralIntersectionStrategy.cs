using System;
using System.Numerics;
using Commons.Intersection2D.Internal.Forms;

namespace Commons.Intersection2D.Internal.IntersectionStrategies
{
	internal class LineSegmentToQuadrilateralIntersectionStrategy: IntersectionStrategy<LineSegment, Quadrilateral>
	{
		private readonly IIntersectionStrategy _lineSegmentToLineSegmentIntersectionStrategy = 
			new LineSegmentToLineSegmentIntersectionStrategy();
		
		public override FormTypesPair[] GetFormTypes()
		{
			return new[]
			{
				new FormTypesPair(typeof(LineSegment), typeof(Quadrilateral)),
				new FormTypesPair(typeof(LineSegment), typeof(RotatedRectangle)),
				new FormTypesPair(typeof(LineSegment), typeof(Rectangle))
			};
		}

		protected override bool IsIntersect(LineSegment lineSegment, Quadrilateral quadrilateral)
		{
			var quadrilateralLineSegments = new[]
			{
				new LineSegment(quadrilateral.Point1, quadrilateral.Point2),
				new LineSegment(quadrilateral.Point2, quadrilateral.Point3),
				new LineSegment(quadrilateral.Point3, quadrilateral.Point4),
				new LineSegment(quadrilateral.Point4, quadrilateral.Point1)
			};

			return Array.Exists(quadrilateralLineSegments, segment =>
				_lineSegmentToLineSegmentIntersectionStrategy.IsIntersect(lineSegment, segment));
		}

		protected override bool IsIntersect(out Vector2[] intersectionPoints, LineSegment lineSegment, Quadrilateral quadrilateral)
		{
			throw new NotImplementedException();
		}
	}
}