using System;
using System.Linq;
using System.Numerics;
using Commons.Intersection2D.CShapes;

namespace Commons.Intersection2D.Strategies
{
	[IntersectionStrategy]
	internal class ArcToArcIntersectionStrategy: IntersectionStrategy<CArc, CArc>
	{
		private readonly IIntersectionStrategy _circleToCircleIntersectionStrategy =
			new CircleToCircleIntersectionStrategy();

		protected override bool IsIntersect(CArc arc1, CArc arc2)
		{
			return IsIntersect(out _, arc1, arc2);
		}

		protected override bool IsIntersect(out Vector2[] intersectionPoints, CArc arc1, CArc arc2)
		{
			intersectionPoints = Array.Empty<Vector2>();

			var circlesIntersection = _circleToCircleIntersectionStrategy.IsIntersect(
				out var circlesIntersectionPoints,
				new CCircle(arc1.Center, arc1.Radius),
				new CCircle(arc2.Center, arc2.Radius)
			);

			if (!circlesIntersection)
			{
				return false;
			}
			
			var isIntersect = false;
			var point1 = circlesIntersectionPoints[0];
			if (Vector2Utils.IsNaN(point1))
			{
				var areArcsOverlay = CheckArcsOverlay(arc1, arc2);
				if (areArcsOverlay)
				{
					intersectionPoints = new []{ point1 };
					return true;
				}

				var areArcsTouch = CheckArcsTouch(
					out var touchPoint1, 
					out var touchPoint2, 
					arc1, 
					arc2);

				if (!areArcsTouch) return false;

				intersectionPoints = new[] { touchPoint1, touchPoint2 }.ClearNull().Cast<Vector2>().ToArray();
				return true;
			}
			
			intersectionPoints = new Vector2[2];
			if (IsPointsOnArc(point1, arc1) && IsPointsOnArc(point1, arc2))
			{
				intersectionPoints[0] = point1;
				isIntersect = true;
			}

			if (circlesIntersectionPoints.Length > 1)
			{
				var point2 = circlesIntersectionPoints[1];
				if (IsPointsOnArc(point2, arc1) && IsPointsOnArc(point2, arc2))
				{
					intersectionPoints[1] = point2;
					isIntersect = true;
				}
			}
			
			intersectionPoints = intersectionPoints.ClearNull().ToArray();
			return isIntersect;
		}
		
		// TODO
		// ReSharper disable once InvertIf
		private static bool IsPointsOnArc(
			Vector2 point,
			CArc arc
		)
		{
			var anglePoint1 =
				Vector2Utils.SignedAngleDeg360Clamp(arc.Point - arc.Center, point - arc.Center, arc.AngleSign);
			return MathF.Abs(anglePoint1).LessOrEqualTo(MathF.Abs(arc.Angle));
		}
		
		// TODO: rework
		// ReSharper disable once InvertIf
		// ReSharper disable once ConvertIfStatementToReturnStatement
		private static bool CheckArcsOverlay(
			CArc arc1,
			CArc arc2
		)
		{
			var arc1Point2 = Vector2Utils.RotateDeg(arc1.Point - arc1.Center, arc1.Angle) + arc1.Center;
			var arc2Point2 = Vector2Utils.RotateDeg(arc2.Point - arc1.Center, arc2.Angle) + arc1.Center;
			
			var angle1Point1 =
				Vector2Utils.SignedAngleDeg360Clamp(arc1.Point - arc1.Center, arc2.Point - arc1.Center, arc1.AngleSign);
			var angle1Point2 =
				Vector2Utils.SignedAngleDeg360Clamp(arc1.Point - arc1.Center, arc2Point2 - arc1.Center, arc1.AngleSign);
			var angle2Point1 =
				Vector2Utils.SignedAngleDeg360Clamp(arc2.Point - arc1.Center, arc1.Point - arc1.Center, arc2.AngleSign);
			var angle2Point2 =
				Vector2Utils.SignedAngleDeg360Clamp(arc2.Point - arc1.Center, arc1Point2 - arc1.Center, arc2.AngleSign);
			
			if (MathF.Abs(angle1Point1) < MathF.Abs(arc1.Angle) && !angle1Point1.EqualTo(0.0f))
			{
				return true;
			}
			
			if (MathF.Abs(angle1Point2) < MathF.Abs(arc1.Angle) && !angle1Point2.EqualTo(0.0f))
			{
				return true;
			}
			
			if (MathF.Abs(angle2Point1) < MathF.Abs(arc2.Angle) && !angle2Point1.EqualTo(0.0f))
			{
				return true;
			}
			
			if (MathF.Abs(angle2Point2) < MathF.Abs(arc2.Angle) && !angle2Point2.EqualTo(0.0f))
			{
				return true;
			}

			if (arc1.Angle.EqualTo(arc2.Angle) && arc1.Point.EqualTo(arc2.Point) && arc1Point2.EqualTo(arc2Point2))
			{
				return true;
			}
			
			if (MathF.Abs(arc1.Angle).EqualTo(MathF.Abs(arc2.Angle)) && arc1.Point.EqualTo(arc2Point2) && arc1Point2.EqualTo(arc2.Point))
			{
				return true;
			}
			
			return false;
		}
		
		// TODO: rework
		// works only in conjunction with CheckArcsOverlay
		// ReSharper disable once InvertIf
		// ReSharper disable once ConvertIfStatementToReturnStatement
		private static bool CheckArcsTouch(
			out Vector2? touchPoint1,
			out Vector2? touchPoint2,
			CArc arc1,
			CArc arc2
		)
		{
			touchPoint1 = null;
			touchPoint2 = null;

			var arc1Point2 = Vector2Utils.RotateDeg(arc1.Point - arc1.Center, arc1.Angle) + arc1.Center;
			var arc2Point2 = Vector2Utils.RotateDeg(arc2.Point - arc1.Center, arc2.Angle) + arc1.Center;
			
			var isTouch = false;

			if (arc1.Point.EqualTo(arc2.Point) || arc1.Point.EqualTo(arc2Point2))
			{
				touchPoint1 = arc1.Point;
				isTouch = true;
			}
			
			if (arc1Point2.EqualTo(arc2.Point) || arc1Point2.EqualTo(arc2Point2))
			{
				touchPoint2 = arc1Point2;
				isTouch = true;
			}
			
			return isTouch;
		}
	}
}