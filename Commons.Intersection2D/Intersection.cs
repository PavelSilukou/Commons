using System;
using System.Numerics;
using Commons.Intersection2D.Shapes;
using Commons.Intersection2D.Strategies;

namespace Commons.Intersection2D
{
	public class Intersection
	{
		private readonly IntersectionStrategies _strategies = new();
		
		public bool IsIntersect(CShape shape1, CShape shape2)
		{
			var trueShape1 = shape1.GetTrueShape();
			var trueShape2 = shape2.GetTrueShape();
			
			var strategy = _strategies.GetStrategy(trueShape1, trueShape2);
			try
			{
				return strategy.IsIntersect(trueShape1, trueShape2);
			}
			catch (NotImplementedException)
			{
				throw new IntersectionStrategyException($"There is no strategy for intersection {shape1.GetType().Name} and {shape2.GetType().Name}.");
			}
		}
		
		public bool IsIntersect(out Vector2[] intersectionPoints, CShape shape1, CShape shape2)
		{
			var trueShape1 = shape1.GetTrueShape();
			var trueShape2 = shape2.GetTrueShape();
			
			var strategy = _strategies.GetStrategy(trueShape1, trueShape2);
			try
			{
				return strategy.IsIntersect(out intersectionPoints, trueShape2, trueShape1);
			}
			catch (NotImplementedException)
			{
				throw new IntersectionStrategyException($"There is no strategy for intersection {shape1.GetType().Name} and {shape2.GetType().Name}.");
			}
		}
	}
}