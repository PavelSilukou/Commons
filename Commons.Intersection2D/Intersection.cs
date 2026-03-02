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
		public CircleCreator Circle { get; }
		public LineSegmentCreator LineSegment { get; }
		public LineCreator Line { get; }
		public RectangleCreator Rectangle { get; }
		public RotatedRectangleCreator RotatedRectangle { get; }

		private readonly IntersectionStrategies _strategies;

		public Intersection(float tolerance) : this(new Equality.Equality(tolerance)) { }
		
		public Intersection(Equality.Equality equality)
		{
			Arc = new ArcCreator(equality);
			Circle = new CircleCreator(equality);
			LineSegment = new LineSegmentCreator(equality);
			Line = new LineCreator(equality);
			Rectangle = new RectangleCreator(equality);
			RotatedRectangle = new RotatedRectangleCreator(equality);
			_strategies = new IntersectionStrategies(equality);
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