﻿using System;
using System.Linq;
using System.Numerics;
using Commons.Intersection2D.Internal.Forms;

namespace Commons.Intersection2D.Internal.IntersectionStrategies
{
	internal class ArcToCircleIntersectionStrategy: IntersectionStrategy<Arc, Circle>
	{
		private readonly IIntersectionStrategy _circleToCircleIntersectionStrategy =
			new CircleToCircleIntersectionStrategy();
		
		public override FormTypesPair[] GetFormTypes()
		{
			return new[]
			{
				new FormTypesPair(typeof(Arc), typeof(Circle))
			};
		}

		protected override bool IsIntersect(Arc arc, Circle circle)
		{
			return IsIntersect(out _, arc, circle);
		}

		protected override bool IsIntersect(out Vector2[] intersectionPoints, Arc arc, Circle circle)
		{
			intersectionPoints = Array.Empty<Vector2>();
			
			var circlesIntersection = _circleToCircleIntersectionStrategy.IsIntersect(
				out var circlesIntersectionPoints,
				new Circle(arc.Center, arc.Radius),
				circle
			);

			if (!circlesIntersection)
			{
				return false;
			}

			var point1 = circlesIntersectionPoints[0];
			if (Vector2Utils.IsNaN(point1))
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
		
		// ReSharper disable once InvertIf
		private static bool IsPointsOnArc(
			Vector2 point,
			Arc arc
		)
		{
			var anglePoint1 =
				Vector2Utils.SignedAngleDeg360(arc.Point - arc.Center, point - arc.Center, arc.AngleSign);
			return MathF.Abs(anglePoint1).LessOrEqualTo(MathF.Abs(arc.Angle));
		}
	}
}