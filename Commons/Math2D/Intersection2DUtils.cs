using System;
using System.Numerics;

namespace Commons.Math2D
{
	public static class Intersection2DUtils
	{
		public static bool IsLineToLineIntersect(
			out Vector2? point,
			Vector2 point1,
			Vector2 point2,
			Vector2 point3,
			Vector2 point4
		)
		{
			point = null;

			if (!Vector2Utils.IsFinite(point1)) return false;
			if (!Vector2Utils.IsFinite(point2)) return false;
			if (!Vector2Utils.IsFinite(point3)) return false;
			if (!Vector2Utils.IsFinite(point4)) return false;

			if (Vector2.Distance(point1, point2).EqualTo(0.0f)) return false;
			if (Vector2.Distance(point3, point4).EqualTo(0.0f)) return false;

			var nx = (point1.X * point2.Y - point1.Y * point2.X)
				* (point3.X - point4.X) - (point1.X - point2.X)
				* (point3.X * point4.Y - point3.Y * point4.X);
			var ny = (point1.X * point2.Y - point1.Y * point2.X)
				* (point3.Y - point4.Y) - (point1.Y - point2.Y)
				* (point3.X * point4.Y - point3.Y * point4.X);
			var d = (point1.X - point2.X)
			        * (point3.Y - point4.Y)
			        - (point1.Y - point2.Y)
			        * (point3.X - point4.X);

			if (d.EqualTo(0.0f)) // are parallel
			{
				if (!nx.EqualTo(0.0f) || !ny.EqualTo(0.0f)) return false; // not the same
				point = Vector2Utils.NaN();
				return true;
			}

			point = new Vector2(nx / d, ny / d);
			return true;
		}
		
#pragma warning disable S3776 // Cognitive Complexity of methods should not be too high
		public static bool IsLineSegmentToLineSegmentIntersect(
			out Vector2? point,
			Vector2 point1,
			Vector2 point2,
			Vector2 point3,
			Vector2 point4
		)
		{
			point = null;
			
			if (!Vector2Utils.IsFinite(point1)) return false;
			if (!Vector2Utils.IsFinite(point2)) return false;
			if (!Vector2Utils.IsFinite(point3)) return false;
			if (!Vector2Utils.IsFinite(point4)) return false;
			
			if (Vector2.Distance(point1, point2).EqualTo(0.0f)) return false;
			if (Vector2.Distance(point3, point4).EqualTo(0.0f)) return false;

			var s1X = point2.X - point1.X;
			var s1Y = point2.Y - point1.Y;
			var s2X = point4.X - point3.X;
			var s2Y = point4.Y - point3.Y;

			var denominator = -s2X * s1Y + s1X * s2Y;
			var s = (-s1Y * (point1.X - point3.X) + s1X * (point1.Y - point3.Y)) / denominator;
			var t = (s2X * (point1.Y - point3.Y) - s2Y * (point1.X - point3.X)) / denominator;

			if (denominator.EqualTo(0.0f) && float.IsNaN(s) && float.IsNaN(t)) // parallel and lie on the same line
			{
				if (AreCollinearLineSegmentsTouch(out var touchPoint, point1, point2, point3, point4))
				{
					point = touchPoint;
					return true;
				}
				
				// ReSharper disable once InvertIf
				if (AreCollinearLineSegmentsOverlay(point1, point2, point3, point4))
				{
					point = Vector2Utils.NaN();
					if (Vector2.Distance(point1, point2).EqualTo(0.0f))
					{
						point = point1;
					}
					if (Vector2.Distance(point3, point4).EqualTo(0.0f))
					{
						point = point3;
					}
					
					return true;
				}

				return false;
			}

			if (s is < 0 or > 1 || t is < 0 or > 1) return false;
			point = new Vector2(point1.X + t * s1X, point1.Y + t * s1Y);
			return true;
		}
#pragma warning restore S3776 // Cognitive Complexity of methods should not be too high
		
		public static bool IsCircleToCircleIntersect(
			Vector2 center1,
			float radius1,
			Vector2 center2,
			float radius2
		)
		{
			if (float.IsNegative(radius1) || radius1.EqualTo(0.0f)) return false;
			if (float.IsNegative(radius2) || radius2.EqualTo(0.0f)) return false;
			
			var distance = Vector2.Distance(center1, center2);
			if (distance.EqualTo(0.0f) && radius1.EqualTo(radius2))
			{
				return true;
			}
			
			return distance <= radius1 + radius2 && distance >= MathF.Abs(radius1 - radius2);
		}

		public static bool IsCircleToCircleIntersect(
			out Vector2? intersectionPoint1,
			out Vector2? intersectionPoint2,
			Vector2 center1,
			float radius1,
			Vector2 center2,
			float radius2
		)
		{
			intersectionPoint1 = null;
			intersectionPoint2 = null;

			if (!IsCircleToCircleIntersect(center1, radius1, center2, radius2))
			{
				return false;
			}

			var x1 = center1.X;
			var y1 = center1.Y;
			var x2 = center2.X;
			var y2 = center2.Y;

			var r = MathF.Sqrt(MathF.Pow(x2 - x1, 2) + MathF.Pow(y2 - y1, 2));
			var r2 = r * r;
			var r4 = r2 * r2;
			var k = radius1 * radius1 - radius2 * radius2;
			var k2 = k * k;
			var j = radius1 * radius1 + radius2 * radius2;

			var sqrt = MathF.Sqrt(2 * j / r2 - k2 / r4 - 1);
			var xPart1 = (x1 + x2) / 2 + k / (2 * r2) * (x2 - x1);
			var xPart2 = sqrt / 2 * (y2 - y1);
			var yPart1 = (y1 + y2) / 2 + k / (2 * r2) * (y2 - y1);
			var yPart2 = sqrt / 2 * (x1 - x2);

			var x00 = xPart1 + xPart2;
			var x01 = xPart1 - xPart2;
			var y00 = yPart1 + yPart2;
			var y01 = yPart1 - yPart2;

			intersectionPoint1 = new Vector2(x00, y00);
			intersectionPoint2 = new Vector2(x01, y01);
			return true;
		}
		
#pragma warning disable S107 // Methods should not have too many parameters
		// ReSharper disable once InvertIf
		public static bool IsArcToCircleIntersect(
			out Vector2? intersectionPoint1,
			out Vector2? intersectionPoint2,
			Vector2 arcCenter,
			Vector2 arcPoint,
			float arcAngleDeg, // signed angle: minus - clockwise; plus - counterclockwise
			Vector2 circleCenter,
			float circleRadius
		)
		{
			intersectionPoint1 = null;
			intersectionPoint2 = null;

			arcAngleDeg = MathFUtils.ClampAngleDeg(arcAngleDeg);
			if (!float.IsFinite(arcAngleDeg) || arcAngleDeg.EqualTo(0.0f)) return false;
			if (!float.IsFinite(circleRadius) || circleRadius.EqualTo(0.0f)) return false;

			var arcRadius = Vector2.Distance(arcCenter, arcPoint);
			if (!float.IsFinite(arcRadius) || arcRadius.EqualTo(0.0f)) return false;
			
			var circlesIntersection = IsCircleToCircleIntersect(
				out var circlesIntersectionPoint1,
				out var circlesIntersectionPoint2,
				arcCenter,
				arcRadius,
				circleCenter,
				circleRadius
			);

			if (!circlesIntersection)
			{
				return false;
			}

			var point1 = circlesIntersectionPoint1!.Value;
			var point2 = circlesIntersectionPoint2!.Value;

			if (Vector2Utils.IsNaN(point1) && Vector2Utils.IsNaN(point2))
			{
				intersectionPoint1 = point1;
				intersectionPoint2 = point2;
				return true;
			}

			var isIntersect = false;
			if (IsPointsOnArc(point1, arcCenter, arcPoint, arcAngleDeg))
			{
				intersectionPoint1 = point1;
				isIntersect = true;
			}
			
			if (IsPointsOnArc(point2, arcCenter, arcPoint, arcAngleDeg))
			{
				intersectionPoint2 = point2;
				isIntersect = true;
			}

			return isIntersect;
		}
#pragma warning restore S107 // Methods should not have too many parameters

#pragma warning disable S107 // Methods should not have too many parameters
#pragma warning disable S3776 // Cognitive Complexity of methods should not be too high
		// ReSharper disable once InvertIf
		public static bool IsArcToArcIntersect(
			out Vector2? intersectionPoint1,
			out Vector2? intersectionPoint2,
			Vector2 arc1Center,
			Vector2 arc1Point,
			float arc1AngleDeg, // signed angle: minus - clockwise; plus - counterclockwise
			Vector2 arc2Center,
			Vector2 arc2Point,
			float arc2AngleDeg // signed angle: minus - clockwise; plus - counterclockwise
		)
		{
			intersectionPoint1 = null;
			intersectionPoint2 = null;
			
			arc1AngleDeg = MathFUtils.ClampAngleDeg(arc1AngleDeg);
			arc2AngleDeg = MathFUtils.ClampAngleDeg(arc2AngleDeg);
			if (!float.IsFinite(arc1AngleDeg) || arc1AngleDeg.EqualTo(0.0f)) return false;
			if (!float.IsFinite(arc2AngleDeg) || arc2AngleDeg.EqualTo(0.0f)) return false;
			
			var arc1Radius = Vector2.Distance(arc1Center, arc1Point);
			var arc2Radius = Vector2.Distance(arc2Center, arc2Point);
			
			if (!float.IsFinite(arc1Radius) || arc1Radius.EqualTo(0.0f)) return false;
			if (!float.IsFinite(arc2Radius) || arc2Radius.EqualTo(0.0f)) return false;

			var circlesIntersection = IsCircleToCircleIntersect(
				out var circlesIntersectionPoint1,
				out var circlesIntersectionPoint2,
				arc1Center,
				arc1Radius,
				arc2Center,
				arc2Radius
			);

			if (!circlesIntersection)
			{
				return false;
			}
			
			var point1 = circlesIntersectionPoint1!.Value;
			var point2 = circlesIntersectionPoint2!.Value;

			var isIntersect = false;
			if (Vector2Utils.IsNaN(point1) && Vector2Utils.IsNaN(point2))
			{
				var areArcsOverlay = CheckArcsOverlay(arc1Center, arc1Point, arc1AngleDeg, arc2Point, arc2AngleDeg);
				if (areArcsOverlay)
				{
					intersectionPoint1 = point1;
					intersectionPoint2 = point2;
					return true;
				}

				var areArcsTouch = CheckArcsTouch(
					out var touchPoint1, 
					out var touchPoint2, 
					arc1Center, 
					arc1Point,
					arc1AngleDeg, 
					arc2Point, 
					arc2AngleDeg);

				if (!areArcsTouch) return false;
				
				intersectionPoint1 = touchPoint1;
				intersectionPoint2 = touchPoint2;
				return true;
			}
			
			if (IsPointsOnArc(point1, arc1Center, arc1Point, arc1AngleDeg)
			    && IsPointsOnArc(point1, arc2Center, arc2Point, arc2AngleDeg))
			{
				intersectionPoint1 = point1;
				isIntersect = true;
			}
			
			if (IsPointsOnArc(point2, arc1Center, arc1Point, arc1AngleDeg)
			    && IsPointsOnArc(point2, arc2Center, arc2Point, arc2AngleDeg))
			{
				intersectionPoint2 = point2;
				isIntersect = true;
			}

			return isIntersect;
		}
#pragma warning restore S107 // Methods should not have too many parameters
#pragma warning restore S3776 // Cognitive Complexity of methods should not be too high

#pragma warning disable S107 // Methods should not have too many parameters
		public static bool IsRectangleToRectangleIntersect(
			float left1, float top1, float right1, float bottom1,
			float left2, float top2, float right2, float bottom2
		)
		{
			if (!float.IsFinite(left1)) return false;
			if (!float.IsFinite(top1)) return false;
			if (!float.IsFinite(right1)) return false;
			if (!float.IsFinite(bottom1)) return false;
			if (!float.IsFinite(left2)) return false;
			if (!float.IsFinite(top2)) return false;
			if (!float.IsFinite(right2)) return false;
			if (!float.IsFinite(bottom2)) return false;
			if (left1.EqualTo(right1) && left1.EqualTo(top1) && left1.EqualTo(bottom1)) return false;
			if (left2.EqualTo(right2) && left2.EqualTo(top2) && left2.EqualTo(bottom2)) return false;
			
			InternalCheckUtils.IsLessValueOrEqual(left1, right1, nameof(left1), nameof(right1));
			InternalCheckUtils.IsLessValueOrEqual(bottom1, top1, nameof(bottom1), nameof(top1));
			InternalCheckUtils.IsLessValueOrEqual(left2, right2, nameof(left2), nameof(right2));
			InternalCheckUtils.IsLessValueOrEqual(bottom2, top2, nameof(bottom2), nameof(top2));
			
			return !(left2 > right1
			         || right2 < left1
			         || top2 < bottom1
			         || bottom2 > top1
			         || (left2 > left1 && right2 < right1 && top2 < top1 && bottom2 > bottom1)
			         || (left1 > left2 && right1 < right2 && top1 < top2 && bottom1 > bottom2));
			
		}
#pragma warning restore S107 // Methods should not have too many parameters
		
#pragma warning disable S3776 // Cognitive Complexity of methods should not be too high
		public static bool IsRotatedRectangleToRotatedRectangleIntersect(Vector2[] rect1Points, Vector2[] rect2Points)
		{
			// TODO: check is rectangle
			// TODO: check line to rectangle intersection
			
			if (rect1Points.Length != 4) throw new ArgumentException("Rectangle points length should be 4", nameof(rect1Points));
			if (rect2Points.Length != 4) throw new ArgumentException("Rectangle points length should be 4", nameof(rect2Points));
			
			if (!Vector2Utils.IsFinite(rect1Points[0])) return false;
			if (!Vector2Utils.IsFinite(rect1Points[1])) return false;
			if (!Vector2Utils.IsFinite(rect1Points[2])) return false;
			if (!Vector2Utils.IsFinite(rect1Points[3])) return false;
			if (!Vector2Utils.IsFinite(rect2Points[0])) return false;
			if (!Vector2Utils.IsFinite(rect2Points[1])) return false;
			if (!Vector2Utils.IsFinite(rect2Points[2])) return false;
			if (!Vector2Utils.IsFinite(rect2Points[3])) return false;
			if (rect1Points[0].EqualTo(rect1Points[1]) 
			    && rect1Points[0].EqualTo(rect1Points[2]) 
			    && rect1Points[0].EqualTo(rect1Points[3])) return false;
			if (rect2Points[0].EqualTo(rect2Points[1]) 
			    && rect2Points[0].EqualTo(rect2Points[2]) 
			    && rect2Points[0].EqualTo(rect2Points[3])) return false;
			
			for (var i = 0; i < 2; i++)
			{
				var intersection = false;
				for (var j = 0; j < 4; j++)
				{
					var isProject = Vector2Utils.PointProjectionOnLineSegment(
						out _,
						rect2Points[j],
						rect1Points[i],
						rect1Points[i + 1]
					);
					intersection |= isProject;
				}

				if (!intersection) return false;
			}

			for (var i = 0; i < 2; i++)
			{
				var intersection = false;
				for (var j = 0; j < 4; j++)
				{
					var isProject = Vector2Utils.PointProjectionOnLineSegment(
						out _,
						rect1Points[j],
						rect2Points[i],
						rect2Points[i + 1]
					);
					intersection |= isProject;
				}

				if (!intersection) return false;
			}

			return true;
		}
#pragma warning restore S3776 // Cognitive Complexity of methods should not be too high

#pragma warning disable S107 // Methods should not have too many parameters
		public static bool IsRotatedRectangleToRotatedRectangleIntersect(
			Vector2 rect1Point1, Vector2 rect1Point2, Vector2 rect1Point3, Vector2 rect1Point4,
			Vector2 rect2Point1, Vector2 rect2Point2, Vector2 rect2Point3, Vector2 rect2Point4
		)
		{
			var rect1Points = new[] { rect1Point1, rect1Point2, rect1Point3, rect1Point4 };
			var rect2Points = new[] { rect2Point1, rect2Point2, rect2Point3, rect2Point4 };
			return IsRotatedRectangleToRotatedRectangleIntersect(rect1Points, rect2Points);
		}
#pragma warning restore S107 // Methods should not have too many parameters
		
		// ReSharper disable once InvertIf
		private static bool IsPointsOnArc(
			Vector2 point,
			Vector2 arcCenter,
			Vector2 arcPoint,
			float arcAngleDeg
		)
		{
			var angleSign = MathFUtils.SignDirection(arcAngleDeg);
			var anglePoint1 =
				Vector2Utils.SignedAngleDeg360(arcPoint - arcCenter, point - arcCenter, angleSign);
			return MathF.Abs(anglePoint1) <= MathF.Abs(arcAngleDeg);
		}

		// TODO: rework
		// ReSharper disable once InvertIf
		// ReSharper disable once ConvertIfStatementToReturnStatement
		private static bool CheckArcsOverlay(
			Vector2 center,
			Vector2 arc1Point,
			float arc1AngleDeg,
			Vector2 arc2Point,
			float arc2AngleDeg
		)
		{
			var arc1Point2 = Vector2Utils.RotateDeg(arc1Point - center, arc1AngleDeg) + center;
			var arc2Point2 = Vector2Utils.RotateDeg(arc2Point - center, arc2AngleDeg) + center;
			
			var arc1AngleSign = MathFUtils.SignDirection(arc1AngleDeg);
			var arc2AngleSign = MathFUtils.SignDirection(arc2AngleDeg);
			var angle1Point1 =
				Vector2Utils.SignedAngleDeg360(arc1Point - center, arc2Point - center, arc1AngleSign);
			var angle1Point2 =
				Vector2Utils.SignedAngleDeg360(arc1Point - center, arc2Point2 - center, arc1AngleSign);
			var angle2Point1 =
				Vector2Utils.SignedAngleDeg360(arc2Point - center, arc1Point - center, arc2AngleSign);
			var angle2Point2 =
				Vector2Utils.SignedAngleDeg360(arc2Point - center, arc1Point2 - center, arc2AngleSign);
			
			if (MathF.Abs(angle1Point1) < MathF.Abs(arc1AngleDeg) && !angle1Point1.EqualTo(0.0f))
			{
				return true;
			}
			
			if (MathF.Abs(angle1Point2) < MathF.Abs(arc1AngleDeg) && !angle1Point2.EqualTo(0.0f))
			{
				return true;
			}
			
			if (MathF.Abs(angle2Point1) < MathF.Abs(arc2AngleDeg) && !angle2Point1.EqualTo(0.0f))
			{
				return true;
			}
			
			if (MathF.Abs(angle2Point2) < MathF.Abs(arc2AngleDeg) && !angle2Point2.EqualTo(0.0f))
			{
				return true;
			}

			if (arc1AngleDeg.EqualTo(arc2AngleDeg) && arc1Point.EqualTo(arc2Point) && arc1Point2.EqualTo(arc2Point2))
			{
				return true;
			}
			
			if (MathF.Abs(arc1AngleDeg).EqualTo(MathF.Abs(arc2AngleDeg)) && arc1Point.EqualTo(arc2Point2) && arc1Point2.EqualTo(arc2Point))
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
			Vector2 center,
			Vector2 arc1Point,
			float arc1AngleDeg,
			Vector2 arc2Point,
			float arc2AngleDeg
		)
		{
			touchPoint1 = null;
			touchPoint2 = null;

			var arc1Point2 = Vector2Utils.RotateDeg(arc1Point - center, arc1AngleDeg) + center;
			var arc2Point2 = Vector2Utils.RotateDeg(arc2Point - center, arc2AngleDeg) + center;
			
			var isTouch = false;

			if (arc1Point.EqualTo(arc2Point) || arc1Point.EqualTo(arc2Point2))
			{
				touchPoint1 = arc1Point;
				isTouch = true;
			}
			
			if (arc1Point2.EqualTo(arc2Point) || arc1Point2.EqualTo(arc2Point2))
			{
				touchPoint2 = arc1Point2;
				isTouch = true;
			}
			
			return isTouch;
		}

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
			return dotProduct <= squaredLength;
		}
	}
}