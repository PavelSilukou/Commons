using System;
using System.Numerics;
using Commons.Intersection2D.CShapes;
using Commons.Intersection2D.Strategies;

namespace Commons.Intersection2D
{
	public class Intersection
	{
		private readonly IntersectionStrategies _strategies = new();
		
		public bool IsIntersect(CShape shape1, CShape shape2)
		{
			var strategy = _strategies.GetStrategy(shape1, shape2);
			try
			{
				return strategy.IsIntersect(shape1, shape2);
			}
			catch (NotImplementedException)
			{
				throw new IntersectionStrategyException($"There is no strategy for intersection {shape1.GetType().Name} and {shape2.GetType().Name}.");
			}
		}
		
		public bool IsIntersect(out Vector2[] intersectionPoints, CShape shape1, CShape shape2)
		{
			var strategy = _strategies.GetStrategy(shape1, shape2);
			try
			{
				return strategy.IsIntersect(out intersectionPoints, shape1, shape2);
			}
			catch (NotImplementedException)
			{
				throw new IntersectionStrategyException($"There is no strategy for intersection {shape1.GetType().Name} and {shape2.GetType().Name}.");
			}
		}
	}
}