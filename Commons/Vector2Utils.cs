using System;
using System.Numerics;
using JetBrains.Annotations;

namespace Commons
{
	[PublicAPI]
	public static class Vector2Utils
	{
		public static Vector2 RotateRad(float radians)
		{
			return new Vector2(MathF.Cos(radians), MathF.Sin(radians));
		}

		public static Vector2 RotateRad(Vector2 vector, float radians)
		{
			var cos = MathF.Cos(radians);
			var sin = MathF.Sin(radians);
			var x = vector.X * cos - vector.Y * sin;
			var y = vector.X * sin + vector.Y * cos;
			return new Vector2(x, y);
		}

		public static Vector2 RotateDeg(float degrees)
		{
			var radians = MathFUtils.Deg2Rad(degrees);
			return RotateRad(radians);
		}

		public static Vector2 RotateDeg(Vector2 vector, float degrees)
		{
			var radians = MathFUtils.Deg2Rad(degrees);
			return RotateRad(vector, radians);
		}

		public static float AngleRad360(Vector2 vector1, Vector2 vector2, int direction)
		{
			var y = vector1.Y * vector2.X - vector1.X * vector2.Y;
			var x = vector1.X * vector2.X + vector1.Y * vector2.Y;
			return MathF.Atan2(-y, -x) + MathF.Sign(direction) * MathF.PI;
		}

		public static float AngleDeg360(Vector2 vector1, Vector2 vector2, int direction)
		{
			var radians = AngleRad360(vector1, vector2, direction);
			return MathFUtils.Rad2Deg(radians);
		}

		public static bool IsParallel(Vector2 vector1, Vector2 vector2, float threshold = 0.001f)
		{
			var dot = Vector2.Dot(Vector2.Normalize(vector1), Vector2.Normalize(vector2));
			return 1 - MathF.Abs(dot) <= threshold;
		}

		public static Vector2 PointProjectionOnLine(Vector2 point, Vector2 linePoint1, Vector2 linePoint2)
		{
			var vector1 = linePoint2 - linePoint1;
			var vector2 = point - linePoint1;
			return linePoint1 + vector1 * Vector2.Dot(vector1, vector2) / Vector2.Dot(vector1, vector1);
		}

		public static bool PointProjectionOnLineSegment(
			out Vector2? projection,
			Vector2 point,
			Vector2 lineSegmentPoint1,
			Vector2 lineSegmentPoint2)
		{
			var projectionOnLine = PointProjectionOnLine(point, lineSegmentPoint1, lineSegmentPoint2);
			var dx = lineSegmentPoint2.X - lineSegmentPoint1.X;
			var dy = lineSegmentPoint2.Y - lineSegmentPoint1.Y;
			var innerProduct = (projectionOnLine.X - lineSegmentPoint1.X) * dx 
			                   + (projectionOnLine.Y - lineSegmentPoint1.Y) * dy;
			var isProject = 0 <= innerProduct && innerProduct <= dx * dx + dy * dy;

			projection = isProject ? projectionOnLine : null;
			return isProject;
		}
	}
}