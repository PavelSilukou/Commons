using System.Numerics;
using Commons.Intersection2D.CShapes;

namespace Commons.Intersection2D.Strategies.Internal
{
	internal interface IIntersectionStrategy
	{
		public IntersectionCShapeTypesPair GetShapeTypes();
		bool IsIntersect(CShape shape1, CShape shape2);
		bool IsIntersect(out Vector2[] intersectionPoints, CShape shape1, CShape shape2);
	}
}