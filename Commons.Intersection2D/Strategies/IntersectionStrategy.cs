using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Commons.Intersection2D.Shapes;

namespace Commons.Intersection2D.Strategies
{
	internal abstract class IntersectionStrategy<T1, T2>: IIntersectionStrategy 
		where T1: CShape 
		where T2: CShape
	{
		List<IntersectionShapeTypesPair> IIntersectionStrategy.GetShapeTypes()
		{
			var shapeTypes = GetShapeTypes();
			var mirroredShapes = 
				from pair in shapeTypes 
				where pair.Type1 != pair.Type2 
				select new IntersectionShapeTypesPair(pair.Type2, pair.Type1);
			shapeTypes.AddRange(mirroredShapes.ToList());
			return shapeTypes;
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

		protected abstract List<IntersectionShapeTypesPair> GetShapeTypes();
		protected abstract bool IsIntersect(T1 shape1, T2 shape2);
		protected abstract bool IsIntersect(out Vector2[] intersectionPoints, T1 shape1, T2 shape2);

		private static (T1 LeftShape, T2 RightShape) GetOrderedShapes(CShape shape1, CShape shape2)
		{
			return shape1 is T1 shape ? (shape, (T2)shape2) : ((T1)shape2, (T2)shape1);
		}
	}
}