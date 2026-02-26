using System.Numerics;
using Commons.Intersection2D.CShapes;

namespace Commons.Intersection2D.Strategies.Internal
{
	internal abstract class IntersectionStrategy<T1, T2>: IIntersectionStrategy 
		where T1: CShape 
		where T2: CShape
	{
		IntersectionCShapeTypesPair IIntersectionStrategy.GetShapeTypes()
		{
			return new IntersectionCShapeTypesPair(typeof(T1), typeof(T2));
		}

		bool IIntersectionStrategy.IsIntersect(CShape shape1, CShape shape2)
		{
			var orderedShapes = GetOrderedShapes(shape1, shape2);
			return IsIntersect(orderedShapes.LeftShape, orderedShapes.RightShape);
		}

		bool IIntersectionStrategy.IsIntersect(out Vector2[] intersectionPoints, CShape shape1, CShape shape2)
		{
			var orderedShapes = GetOrderedShapes(shape1, shape2);
			return IsIntersect(out intersectionPoints, orderedShapes.LeftShape, orderedShapes.RightShape);
		}

		protected abstract bool IsIntersect(T1 shape1, T2 shape2);
		protected abstract bool IsIntersect(out Vector2[] intersectionPoints, T1 shape1, T2 shape2);

		private static (T1 LeftShape, T2 RightShape) GetOrderedShapes(CShape shape1, CShape shape2)
		{
			// ReSharper disable once MergeCastWithTypeCheck
			return shape1 is T1 ? ((T1)shape1, (T2)shape2) : ((T1)shape2, (T2)shape1);
		}
	}
}