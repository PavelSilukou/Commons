using System.Numerics;
using Commons.Intersection2D.Shapes;

namespace Commons.Intersection2D.Strategies
{
	internal interface IIntersectionStrategy
	{
		public IntersectionShapeTypesPair GetShapeTypes();
		bool IsIntersect(CShape shape1, CShape shape2);
		bool IsIntersect(out Vector2[] intersectionPoints, CShape shape1, CShape shape2);
	}
}