using System;
using System.Numerics;
using Commons.Intersection2D.CShapes;
using Commons.Intersection2D.ShapeCreators;
using Commons.Intersection2D.Strategies.Internal;

namespace Commons.Intersection2D
{
	public class Intersection
	{
		public ArcCreator Arc { get; }

		private readonly IntersectionStrategies _strategies;

		public Intersection(float tolerance)
		{
			var approximation = new Approximation.Approximation(tolerance);
			Arc = new ArcCreator(approximation);
			_strategies = new IntersectionStrategies(approximation);
		}
		
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