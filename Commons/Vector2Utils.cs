using System;
using System.Numerics;
using JetBrains.Annotations;

namespace Commons
{
	public static class Vector2Utils
	{
		public static Vector2 RotateRad(float radians)
		{
			// positive radians - counterclockwise; negative - clockwise
			return new Vector2(MathF.Cos(radians), MathF.Sin(radians));
		}

		public static Vector2 RotateRad(Vector2 vector, float radians)
		{
			if (!IsFinite(vector)) return NaN();
			
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
		
		// TODO: Angle between vector and (1.0f, 0.0f); opposite to Rotate methods
		
		public static float SignedAngleRad(Vector2 vector1, Vector2 vector2)
		{
			var y = vector1.Y * vector2.X - vector1.X * vector2.Y;
			var x = vector1.X * vector2.X + vector1.Y * vector2.Y;
			var angle = -MathF.Atan2(y, x);
			return angle.EqualTo(-MathF.PI) ? MathF.PI : angle;
		}

		public static float SignedAngleDeg(Vector2 vector1, Vector2 vector2)
		{
			var radians = SignedAngleRad(vector1, vector2);
			return MathFUtils.Rad2Deg(radians);
		}
		
		public static float AngleRad(Vector2 vector1, Vector2 vector2)
		{
			return MathF.Abs(SignedAngleRad(vector1, vector2));
		}

		public static float AngleDeg(Vector2 vector1, Vector2 vector2)
		{
			return MathF.Abs(SignedAngleDeg(vector1, vector2));
		}
		
		public static float SignedAngleRad360(Vector2 vector1, Vector2 vector2, int direction)
		{
			return SignedAngleRad360Internal(vector1, vector2, direction);
		}

		public static float SignedAngleDeg360(Vector2 vector1, Vector2 vector2, int direction)
		{
			return SignedAngleDeg360Internal(vector1, vector2, direction);
		}
		
		public static float AngleRad360(Vector2 vector1, Vector2 vector2, int direction)
		{
			return MathF.Abs(SignedAngleRad360Internal(vector1, vector2, direction));
		}

		public static float AngleDeg360(Vector2 vector1, Vector2 vector2, int direction)
		{
			return MathF.Abs(SignedAngleDeg360Internal(vector1, vector2, direction));
		}
		
		public static bool IsParallel(Vector2 vector1, Vector2 vector2)
		{
			var dot = Vector2.Dot(Vector2.Normalize(vector1), Vector2.Normalize(vector2));
			return MathF.Abs(dot).EqualTo(1.0f);
		}
		
		public static bool IsParallel(Vector2 vector1, Vector2 vector2, float tolerance)
		{
			if (!float.IsFinite(tolerance)) throw new ArithmeticException($"'{nameof(tolerance)}' parameter must be finite");
			if (float.IsNegative(tolerance)) throw new ArithmeticException($"'{nameof(tolerance)}' parameter must be positive");

			var angle = SignedAngleDeg(vector1, vector2);
			return FloatExtensions.EqualToInternal(angle, 0.0f, tolerance) 
			       || FloatExtensions.EqualToInternal(angle, 180.0f, tolerance);
		}
		
		public static bool PointProjectionOnLine(
			out Vector2 projection,
			Vector2 point, 
			Vector2 linePoint1, 
			Vector2 linePoint2)
		{
			projection = NaN();
			// ReSharper disable ConvertIfStatementToReturnStatement
			if (!IsFinite(point)) return false;
			// ReSharper restore ConvertIfStatementToReturnStatement

			return PointProjectionOnLineInternal(out projection, point, linePoint1, linePoint2);
		}

		public static bool PointProjectionOnLineSegment(
			out Vector2? projection,
			Vector2 point,
			Vector2 lineSegmentPoint1,
			Vector2 lineSegmentPoint2)
		{
			projection = NaN();
			if (!IsFinite(point)) return false;
			
			var isProjectOnLine = PointProjectionOnLineInternal(out var projectionOnLine, point, lineSegmentPoint1, lineSegmentPoint2);
			if (!isProjectOnLine) return false;
			
			var dx = lineSegmentPoint2.X - lineSegmentPoint1.X;
			var dy = lineSegmentPoint2.Y - lineSegmentPoint1.Y;
			var innerProduct = (projectionOnLine.X - lineSegmentPoint1.X) * dx 
			                   + (projectionOnLine.Y - lineSegmentPoint1.Y) * dy;
			
			var isProject = innerProduct.MoreOrEqualTo(0.0f) && innerProduct.LessOrEqualTo(dx * dx + dy * dy);

			projection = isProject ? projectionOnLine : null;
			return isProject;
		}
		
		public static Vector2 Perpendicular(Vector2 vector)
		{
			return IsFinite(vector) ? new Vector2(vector.Y, -1 * vector.X) : NaN();
		}
		
		public static Vector2 Perpendicular(Vector2 vector, int direction)
		{
			var directionSign = MathFUtils.Sign(direction);
			return IsFinite(vector) ? new Vector2(-directionSign * vector.Y, directionSign * vector.X): NaN();
		}

		public static Vector2 ExtendTo(Vector2 vector, float value)
		{
			if (!IsFinite(vector) || !float.IsFinite(value)) return NaN();
			return ExtendToInternal(vector, value);
		}
		
		public static Vector2 ExtendTo(Vector2 vector1, Vector2 vector2, float value)
		{
			if (!IsFinite(vector1)) return NaN();
			if (!IsFinite(vector2)) return NaN();
			if (!float.IsFinite(value)) return NaN();
			
			var tempVector = vector2 - vector1;
			var newVector = ExtendToInternal(tempVector, value);
			return newVector + vector1;
		}

		public static Vector2 ExtendBy(Vector2 vector, float value)
		{
			return ExtendTo(vector, vector.Length() + value);
		}
		
		public static Vector2 ExtendBy(Vector2 vector1, Vector2 vector2, float value)
		{
			return ExtendTo(vector1, vector2, Vector2.Distance(vector1, vector2) + value);
		}
		
		public static Vector2 NaN()
		{
			return new Vector2(float.NaN, float.NaN);
		}

		public static bool IsNaN(Vector2 vector)
		{
			return float.IsNaN(vector.X) && float.IsNaN(vector.Y);
		}
		
		[PublicAPI]
		public static bool IsFinite(Vector2 vector)
		{
			return float.IsFinite(vector.X) && float.IsFinite(vector.Y);
		}
		
		private static float SignedAngleRad360Internal(Vector2 vector1, Vector2 vector2, int direction)
		{
			var directionSign = MathFUtils.Sign(direction);
			var y = vector1.Y * vector2.X - vector1.X * vector2.Y;
			var x = vector1.X * vector2.X + vector1.Y * vector2.Y;
			var angle = MathF.Atan2(-y, -x) + -directionSign * MathF.PI;
			return MathF.Abs(angle).EqualTo(2 * MathF.PI) ? 0.0f : angle;
		}
		
		private static float SignedAngleDeg360Internal(Vector2 vector1, Vector2 vector2, int direction)
		{
			var radians = SignedAngleRad360Internal(vector1, vector2, direction);
			return MathFUtils.Rad2Deg(radians);
		}
		
		private static bool PointProjectionOnLineInternal(
			out Vector2 projection,
			Vector2 point, 
			Vector2 linePoint1, 
			Vector2 linePoint2)
		{
			var vector1 = linePoint2 - linePoint1;
			var vector2 = point - linePoint1;
			projection = linePoint1 + vector1 * Vector2.Dot(vector1, vector2) / Vector2.Dot(vector1, vector1);
			return !IsNaN(projection);
		}
		
		private static Vector2 ExtendToInternal(Vector2 vector, float value)
		{
			var normalizedVector = Vector2.Normalize(vector);
			return normalizedVector * value;
		}
	}
}