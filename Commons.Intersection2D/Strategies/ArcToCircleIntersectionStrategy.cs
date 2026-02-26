using System;
using System.Linq;
using System.Numerics;
using Commons.Intersection2D.CShapes;
using Commons.Intersection2D.Strategies.Internal;

namespace Commons.Intersection2D.Strategies
{
	[IntersectionStrategy]
	internal class ArcToCircleIntersectionStrategy: IntersectionStrategy<CArc, CCircle>
	{
		private readonly Approximation.Approximation _approximation;
		private readonly IIntersectionStrategy _circleToCircleIntersectionStrategy;
		
		public ArcToCircleIntersectionStrategy(Approximation.Approximation approximation, CircleToCircleIntersectionStrategy circleToCircleIntersectionStrategy)
		{
			_approximation = approximation;
			_circleToCircleIntersectionStrategy = circleToCircleIntersectionStrategy;
		}

		protected override bool IsIntersect(CArc arc, CCircle circle)
		{
			return IsIntersect(out _, arc, circle);
		}

		protected override bool IsIntersect(out Vector2[] intersectionPoints, CArc arc, CCircle circle)
		{
			intersectionPoints = Array.Empty<Vector2>();
			
			var circlesIntersection = _circleToCircleIntersectionStrategy.IsIntersect(
				out var circlesIntersectionPoints,
				new CCircle(arc.Center, arc.Radius),
				circle
			);

			if (!circlesIntersection) return false;

			var point1 = circlesIntersectionPoints[0];
			if (_approximation.Vector2.IsNaN(point1))
			{
				intersectionPoints = new []{ point1 };
				return true;
			}

			intersectionPoints = new Vector2[2];
			var isIntersect = false;
			if (IsPointsOnArc(point1, arc))
			{
				intersectionPoints[0] = point1;
				isIntersect = true;
			}

			if (circlesIntersectionPoints.Length > 1)
			{
				var point2 = circlesIntersectionPoints[1];
				if (IsPointsOnArc(point2, arc))
				{
					intersectionPoints[1] = point2;
					isIntersect = true;
				}
			}

			intersectionPoints = intersectionPoints.ClearNull().ToArray();
			return isIntersect;
		}
		
		private bool IsPointsOnArc(
			Vector2 point,
			CArc arc
		)
		{
			var anglePoint1 =
				_approximation.Vector2.SignedAngleDeg360Clamp(arc.Point - arc.Center, point - arc.Center, arc.AngleSign);
			return _approximation.Float.LessOrEqualTo(MathF.Abs(anglePoint1), MathF.Abs(arc.Angle));
		}
	}
}