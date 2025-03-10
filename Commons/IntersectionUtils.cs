using System;
using System.Numerics;
using JetBrains.Annotations;

namespace Commons
{
	[PublicAPI]
	public static class IntersectionUtils
	{
		public static bool Line2ToLine2Intersection(
			out Vector2? point,
			Vector2 point1,
			Vector2 point2,
			Vector2 point3,
			Vector2 point4
		)
		{
			point = null;

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

			if (FloatUtils.EqualsApproximately(d, 0.0f))
			{
				return false;
			}

			point = new Vector2(nx / d, ny / d);
			return true;
		}

		public static bool LineSegment2ToLineSegment2Intersection(
			out Vector2? point,
			Vector2 point1,
			Vector2 point2,
			Vector2 point3,
			Vector2 point4
		)
		{
			point = null;

			var isParallel = Vector2Utils.IsParallel(point2 - point1, point4 - point3);
			if (isParallel)
			{
				return false;
			}

			float x1 = point1.X, y1 = point1.Y;
			float x2 = point2.X, y2 = point2.Y;
			float x3 = point3.X, y3 = point3.Y;
			float x4 = point4.X, y4 = point4.Y;

			var s1X = x2 - x1;
			var s1Y = y2 - y1;
			var s2X = x4 - x3;
			var s2Y = y4 - y3;

			var denominator = -s2X * s1Y + s1X * s2Y;
			var s = (-s1Y * (x1 - x3) + s1X * (y1 - y3)) / denominator;
			var t = (s2X * (y1 - y3) - s2Y * (x1 - x3)) / denominator;

			if (s is < 0 or > 1 || t is < 0 or > 1) return false;
			point = new Vector2(x1 + t * s1X, y1 + t * s1Y);
			return true;
		}

		public static bool Line3ToLine3Intersection(
			out Vector3? intersection,
			Vector3 point1,
			Vector3 point2,
			Vector3 point3,
			Vector3 point4
		)
		{
			intersection = null;

			var vector1 = point2 - point1;
			var vector2 = point4 - point3;
			var vector3 = point3 - point1;
			var crossVector1AndVector2 = Vector3.Cross(vector1, vector2);
			var crossVector3AndVector2 = Vector3.Cross(vector3, vector2);

			var planarFactor = Vector3.Dot(vector3, crossVector1AndVector2);
			if (MathF.Abs(planarFactor) >= 0.0001f || crossVector1AndVector2.Length() <= 0.0001f) return false;
			
			var s = Vector3.Dot(crossVector3AndVector2, crossVector1AndVector2) / crossVector1AndVector2.Length();
			intersection = point1 + vector1 * s;
			return true;
		}

		public static bool IsCircleToCircleIntersect(
			Vector2 center1,
			float radius1,
			Vector2 center2,
			float radius2
		)
		{
			return Vector2.Distance(center1, center2) <= radius1 + radius2;
		}

		public static bool CircleToCircleIntersection(
			out Vector2? intersection1,
			out Vector2? intersection2,
			Vector2 center1,
			float radius1,
			Vector2 center2,
			float radius2
		)
		{
			intersection1 = null;
			intersection2 = null;

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

			intersection1 = new Vector2(x00, y00);
			intersection2 = new Vector2(x01, y01);
			return true;
		}

#pragma warning disable S107 // Methods should not have too many parameters
		// ReSharper disable once InvertIf
		public static bool ArcToArcIntersection(
			out Vector2? intersection1,
			out Vector2? intersection2,
			Vector2 center1,
			float radius1,
			Vector2 center2,
			float radius2,
			Vector2 arc1Point,
			float arc1AngleDeg // signed angle: minus - counterclockwise; plus - clockwise
		)
		{
			intersection1 = null;
			intersection2 = null;
			var isIntersect = false;

			var circlesIntersection = CircleToCircleIntersection(
				out var circlesIntersection1,
				out var circlesIntersection2,
				center1,
				radius1,
				center2,
				radius2
			);

			if (!circlesIntersection)
			{
				return isIntersect;
			}

			var angleSign = MathF.Sign(arc1AngleDeg) == 0 ? 1 : -1;
			var anglePoint1 =
				Vector2Utils.AngleDeg360(arc1Point - center1, circlesIntersection1!.Value - center1, angleSign);
			var anglePoint2 =
				Vector2Utils.AngleDeg360(arc1Point - center1, circlesIntersection2!.Value - center1, angleSign);

			if (MathF.Abs(anglePoint1) < MathF.Abs(arc1AngleDeg))
			{
				intersection1 = circlesIntersection1;
				isIntersect = true;
			}

			if (MathF.Abs(anglePoint2) < MathF.Abs(arc1AngleDeg))
			{
				intersection2 = circlesIntersection2;
				isIntersect = true;
			}

			return isIntersect;
		}
#pragma warning restore S107 // Methods should not have too many parameters

#pragma warning disable S107 // Methods should not have too many parameters
		public static bool IsRectangleToRectangleIntersect(
			float left1, float top1, float right1, float bottom1,
			float left2, float top2, float right2, float bottom2
		)
		{
			return !(left2 > right1
			         || right2 < left1
			         || top2 < bottom1
			         || bottom2 > top1);
		}
#pragma warning restore S107 // Methods should not have too many parameters

		public static bool IsRotatedRectangleToRotatedRectangleIntersect(Vector2[] rect1Points, Vector2[] rect2Points)
		{
			for (var i = 0; i < 1; i++)
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

			for (var i = 0; i < 1; i++)
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
	}
}