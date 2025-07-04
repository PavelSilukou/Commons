using System;
using System.Numerics;
using Commons.Intersection2D.Internal.Forms;

namespace Commons.Intersection2D.Internal.IntersectionStrategies
{
	internal class QuadrilateralToQuadrilateralIntersectionStrategy: IntersectionStrategy<Quadrilateral, Quadrilateral>
	{
		private readonly IIntersectionStrategy _lineSegmentToQuadrilateralIntersectionStrategy = 
			new LineSegmentToQuadrilateralIntersectionStrategy();
		
		public override FormTypesPair[] GetFormTypes()
		{
			return new[]
			{
				new FormTypesPair(typeof(Quadrilateral), typeof(Quadrilateral)),
				new FormTypesPair(typeof(Quadrilateral), typeof(RotatedRectangle)),
				new FormTypesPair(typeof(Quadrilateral), typeof(Rectangle))
			};
		}

		protected override bool IsIntersect(Quadrilateral quadrilateral1, Quadrilateral quadrilateral2)
		{
			var quadrilateralLineSegments = new[]
			{
				new LineSegment(quadrilateral1.Point1, quadrilateral1.Point2),
				new LineSegment(quadrilateral1.Point2, quadrilateral1.Point3),
				new LineSegment(quadrilateral1.Point3, quadrilateral1.Point4),
				new LineSegment(quadrilateral1.Point4, quadrilateral1.Point1)
			};

			return Array.Exists(quadrilateralLineSegments, segment =>
				_lineSegmentToQuadrilateralIntersectionStrategy.IsIntersect(segment, quadrilateral2));
		}

		protected override bool IsIntersect(out Vector2[] intersectionPoints, Quadrilateral quadrilateral1, Quadrilateral quadrilateral2)
		{
			throw new NotImplementedException();
		}
	}
}