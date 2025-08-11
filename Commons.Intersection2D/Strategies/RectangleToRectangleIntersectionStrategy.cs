using System;
using System.Numerics;
using Commons.Intersection2D.Shapes;

namespace Commons.Intersection2D.Strategies
{
	[Strategy]
	internal class RectangleToRectangleIntersectionStrategy: IntersectionStrategy<CRectangle, CRectangle>
	{
		protected override bool IsIntersect(CRectangle rect1, CRectangle rect2)
		{
			return !(rect2.Left > rect1.Right
			         || rect2.Right < rect1.Left
			         || rect2.Top < rect1.Bottom
			         || rect2.Bottom > rect1.Top
			         || (rect2.Left > rect1.Left && rect2.Right < rect1.Right && rect2.Top < rect1.Top && rect2.Bottom > rect1.Bottom)
			         || (rect1.Left > rect2.Left && rect1.Right < rect2.Right && rect1.Top < rect2.Top && rect1.Bottom > rect2.Bottom));
		}

		protected override bool IsIntersect(out Vector2[] intersectionPoints, CRectangle rect1, CRectangle rect2)
		{
			throw new NotImplementedException();
		}
	}
}