using System;
using System.Numerics;
using Commons.Intersection2D.CShapes;

namespace Commons.Intersection2D.Strategies
{
	[IntersectionStrategy]
	internal class PointToAnyIntersectionStrategy: IntersectionStrategy<CPoint, CShape>
	{
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