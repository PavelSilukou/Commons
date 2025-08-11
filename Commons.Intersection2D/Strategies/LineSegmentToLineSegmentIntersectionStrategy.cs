using System;
using System.Numerics;
using Commons.Intersection2D.Shapes;

namespace Commons.Intersection2D.Strategies
{
	[Strategy]
	internal class LineSegmentToLineSegmentIntersectionStrategy: IntersectionStrategy<CLineSegment, CLineSegment>
	{
		protected override bool IsIntersect(CLineSegment lineSegment1, CLineSegment lineSegment2)
		{
			return IsIntersect(out _, lineSegment1, lineSegment2);
		}

#pragma warning disable S3776 // Cognitive Complexity of methods should not be too high
		protected override bool IsIntersect(out Vector2[] intersectionPoints, CLineSegment lineSegment1, CLineSegment lineSegment2)
		{
			intersectionPoints = Array.Empty<Vector2>();
			
			var s1X = lineSegment1.Point2.X - lineSegment1.Point1.X;
			var s1Y = lineSegment1.Point2.Y - lineSegment1.Point1.Y;
			var s2X = lineSegment2.Point2.X - lineSegment2.Point1.X;
			var s2Y = lineSegment2.Point2.Y - lineSegment2.Point1.Y;

			var denominator = -s2X * s1Y + s1X * s2Y;
			var s = (-s1Y * (lineSegment1.Point1.X - lineSegment2.Point1.X) + s1X * (lineSegment1.Point1.Y - lineSegment2.Point1.Y)) / denominator;
			var t = (s2X * (lineSegment1.Point1.Y - lineSegment2.Point1.Y) - s2Y * (lineSegment1.Point1.X - lineSegment2.Point1.X)) / denominator;

			if (denominator.EqualTo(0.0f) && float.IsNaN(s) && float.IsNaN(t)) // parallel and lie on the same line
			{
				if (AreCollinearLineSegmentsTouch(out var touchPoint, lineSegment1.Point1, lineSegment1.Point2, lineSegment2.Point1, lineSegment2.Point2))
				{
					if (touchPoint != null)
					{
						intersectionPoints = new[] { touchPoint.Value };
					}
					return true;
				}
				
				// ReSharper disable once InvertIf
				if (AreCollinearLineSegmentsOverlay(lineSegment1.Point1, lineSegment1.Point2, lineSegment2.Point1, lineSegment2.Point2))
				{
					intersectionPoints = new []{ Vector2Utils.NaN() };
					if (Vector2.Distance(lineSegment1.Point1, lineSegment1.Point2).EqualTo(0.0f))
					{
						intersectionPoints[0] = lineSegment1.Point1;
					}
					if (Vector2.Distance(lineSegment2.Point1, lineSegment2.Point2).EqualTo(0.0f))
					{
						intersectionPoints[0] = lineSegment2.Point1;
					}
					return true;
				}

				return false;
			}

			if (s is < 0 or > 1 || t is < 0 or > 1) return false;
			intersectionPoints = new[] { new Vector2(lineSegment1.Point1.X + t * s1X, lineSegment1.Point1.Y + t * s1Y) };
			return true;
		}
#pragma warning restore S3776 // Cognitive Complexity of methods should not be too high
		
		// TODO: rework
		// ReSharper disable once InvertIf
		private static bool AreCollinearLineSegmentsTouch(
			out Vector2? touchPoint,
			Vector2 point1,
			Vector2 point2,
			Vector2 point3,
			Vector2 point4)
		{
			touchPoint = null;
			
			if (AreCollinearLineSegmentsTouch(point1, point3, point2, point4))
			{
				touchPoint = point1;
				return true;
			}
			
			if (AreCollinearLineSegmentsTouch(point1, point4, point2, point3))
			{
				touchPoint = point1;
				return true;
			}
			
			if (AreCollinearLineSegmentsTouch(point2, point3, point1, point4))
			{
				touchPoint = point2;
				return true;
			}
			
			if (AreCollinearLineSegmentsTouch(point2, point4, point1, point3))
			{
				touchPoint = point2;
				return true;
			}

			return false;
		}

		private static bool AreCollinearLineSegmentsTouch(Vector2 a, Vector2 b, Vector2 c, Vector2 d)
		{
			if (!(a - b).EqualTo(Vector2.Zero)) return false;
			
			var t1 = a - c;
			var t2 = b - d;
			return Vector2Utils.AngleRad(t1, t2).EqualTo(MathF.PI);
		}
		
		// TODO: rework
		// ReSharper disable once ConvertIfStatementToReturnStatement
		private static bool AreCollinearLineSegmentsOverlay(
			Vector2 point1,
			Vector2 point2,
			Vector2 point3,
			Vector2 point4)
		{
			if (IsCollinearPointOnLineSegment(point1, point3, point4)) return true;
			if (IsCollinearPointOnLineSegment(point2, point3, point4)) return true;
			if (IsCollinearPointOnLineSegment(point3, point1, point2)) return true;
			if (IsCollinearPointOnLineSegment(point4, point1, point2)) return true;

			return false;
		}
		
		private static bool IsCollinearPointOnLineSegment(Vector2 point, Vector2 lineSegmentPoint1, Vector2 lineSegmentPoint2)
		{
			var dotProduct = (point.X - lineSegmentPoint1.X) * (lineSegmentPoint2.X - lineSegmentPoint1.X) +
			                 (point.Y - lineSegmentPoint1.Y) * (lineSegmentPoint2.Y - lineSegmentPoint1.Y);
			if (dotProduct < 0.0f) return false;

			var squaredLength = Vector2.DistanceSquared(lineSegmentPoint1, lineSegmentPoint2);
			return dotProduct.LessOrEqualTo(squaredLength);
		}
	}
}