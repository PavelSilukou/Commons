using System;
using System.Collections.Generic;
using System.Numerics;
using Commons.Approximation.CFloat;
using JetBrains.Annotations;

namespace Commons.Approximation.CVector2
{
	[PublicAPI]
    public class Vector2Approximation
    {
        private readonly FloatApproximation _floatApproximation;
        
        internal Vector2Approximation(FloatApproximation floatApproximation)
        {
            _floatApproximation = floatApproximation;
        }
        
        public IEqualityComparer<Vector2> GetEqualityComparer()
        {
            return new Vector2EqualityComparer(this);
        }
        
        public bool EqualTo(Vector2 vector1, Vector2 vector2)
        {
            return _floatApproximation.EqualTo(vector1.X, vector2.X) && _floatApproximation.EqualTo(vector1.Y, vector2.Y);
        }
        
        public Vector2 RotateRad(float radians)
		{
			// positive radians - counterclockwise; negative - clockwise
			return new Vector2(MathF.Cos(radians), MathF.Sin(radians));
		}

		public Vector2 RotateRad(Vector2 vector, float radians)
		{
			if (!IsFinite(vector)) return NaN();
			
			var cos = MathF.Cos(radians);
			var sin = MathF.Sin(radians);
			var x = vector.X * cos - vector.Y * sin;
			var y = vector.X * sin + vector.Y * cos;
			return new Vector2(x, y);
		}

		public Vector2 RotateDeg(float degrees)
		{
			var radians = MathFUtils.Deg2Rad(degrees);
			return RotateRad(radians);
		}

		public Vector2 RotateDeg(Vector2 vector, float degrees)
		{
			var radians = MathFUtils.Deg2Rad(degrees);
			return RotateRad(vector, radians);
		}
		
		// TODO: Angle between vector and (1.0f, 0.0f); opposite to Rotate methods
		
		public float SignedAngleRad(Vector2 vector1, Vector2 vector2)
		{
			var y = vector1.Y * vector2.X - vector1.X * vector2.Y;
			var x = vector1.X * vector2.X + vector1.Y * vector2.Y;
			return -MathF.Atan2(y, x);
		}

		public float SignedAngleDeg(Vector2 vector1, Vector2 vector2)
		{
			var radians = SignedAngleRad(vector1, vector2);
			return MathFUtils.Rad2Deg(radians);
		}
		
		public float AngleRad(Vector2 vector1, Vector2 vector2)
		{
			return MathF.Abs(SignedAngleRad(vector1, vector2));
		}

		public float AngleDeg(Vector2 vector1, Vector2 vector2)
		{
			return MathF.Abs(SignedAngleDeg(vector1, vector2));
		}
		
		public float SignedAngleRadClamp(Vector2 vector1, Vector2 vector2)
		{
			var y = vector1.Y * vector2.X - vector1.X * vector2.Y;
			var x = vector1.X * vector2.X + vector1.Y * vector2.Y;
			var angle = -MathF.Atan2(y, x);
			return _floatApproximation.EqualTo(angle, -MathF.PI) ? MathF.PI : angle;
		}
		
		public float SignedAngleDegClamp(Vector2 vector1, Vector2 vector2)
		{
			var radians = SignedAngleRadClamp(vector1, vector2);
			return MathFUtils.Rad2Deg(radians);
		}
		
		public float SignedAngleRad360(Vector2 vector1, Vector2 vector2, int direction)
		{
			var directionSign = MathUtils.Sign(direction);
			var y = vector1.Y * vector2.X - vector1.X * vector2.Y;
			var x = vector1.X * vector2.X + vector1.Y * vector2.Y;
			return MathF.Atan2(-y, -x) + -directionSign * MathF.PI;
		}

		public float SignedAngleDeg360(Vector2 vector1, Vector2 vector2, int direction)
		{
			var radians = SignedAngleRad360(vector1, vector2, direction);
			return MathFUtils.Rad2Deg(radians);
		}
		
		public float AngleRad360(Vector2 vector1, Vector2 vector2, int direction)
		{
			return MathF.Abs(SignedAngleRad360(vector1, vector2, direction));
		}

		public float AngleDeg360(Vector2 vector1, Vector2 vector2, int direction)
		{
			return MathF.Abs(SignedAngleDeg360(vector1, vector2, direction));
		}
		
		public float SignedAngleRad360Clamp(Vector2 vector1, Vector2 vector2, int direction)
		{
			var angle = SignedAngleRad360(vector1, vector2, direction);
			return _floatApproximation.EqualTo(MathF.Abs(angle), 2 * MathF.PI) ? 0.0f : angle;
		}

		public float SignedAngleDeg360Clamp(Vector2 vector1, Vector2 vector2, int direction)
		{
			var radians = SignedAngleRad360Clamp(vector1, vector2, direction);
			return MathFUtils.Rad2Deg(radians);
		}
		
		public float AngleRad360Clamp(Vector2 vector1, Vector2 vector2, int direction)
		{
			return MathF.Abs(SignedAngleRad360Clamp(vector1, vector2, direction));
		}

		public float AngleDeg360Clamp(Vector2 vector1, Vector2 vector2, int direction)
		{
			return MathF.Abs(SignedAngleDeg360Clamp(vector1, vector2, direction));
		}
		
		public bool IsParallel(Vector2 vector1, Vector2 vector2)
		{
			var angle = SignedAngleDeg(vector1, vector2);
			return _floatApproximation.EqualTo(angle, 0.0f) || _floatApproximation.EqualTo(angle, 180.0f);
		}
		
		public bool PointProjectionOnLine(
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

		public bool PointProjectionOnLineSegment(
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
			
			var isProject = _floatApproximation.MoreOrEqualTo(innerProduct, 0.0f) 
			                && _floatApproximation.LessOrEqualTo(innerProduct, dx * dx + dy * dy);

			projection = isProject ? projectionOnLine : null;
			return isProject;
		}
		
		public Vector2 Perpendicular(Vector2 vector)
		{
			return IsFinite(vector) ? new Vector2(vector.Y, -1 * vector.X) : NaN();
		}
		
		public Vector2 Perpendicular(Vector2 vector, int direction)
		{
			var directionSign = MathUtils.Sign(direction);
			return IsFinite(vector) ? new Vector2(-directionSign * vector.Y, directionSign * vector.X): NaN();
		}

		public Vector2 ExtendTo(Vector2 vector, float value)
		{
			if (!IsFinite(vector) || !float.IsFinite(value)) return NaN();
			return ExtendToInternal(vector, value);
		}
		
		public Vector2 ExtendTo(Vector2 vector1, Vector2 vector2, float value)
		{
			if (!IsFinite(vector1) || !IsFinite(vector2) || !float.IsFinite(value)) return NaN();

			var tempVector = vector2 - vector1;
			var newVector = ExtendToInternal(tempVector, value);
			return newVector + vector1;
		}

		public Vector2 ExtendBy(Vector2 vector, float value)
		{
			return ExtendTo(vector, vector.Length() + value);
		}
		
		public Vector2 ExtendBy(Vector2 vector1, Vector2 vector2, float value)
		{
			return ExtendTo(vector1, vector2, Vector2.Distance(vector1, vector2) + value);
		}
		
		public Vector2 NaN()
		{
			return new Vector2(float.NaN, float.NaN);
		}

		public bool IsNaN(Vector2 vector)
		{
			return float.IsNaN(vector.X) && float.IsNaN(vector.Y);
		}
		
		public bool IsFinite(Vector2 vector)
		{
			return float.IsFinite(vector.X) && float.IsFinite(vector.Y);
		}
		
		private bool PointProjectionOnLineInternal(
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
		
		private Vector2 ExtendToInternal(Vector2 vector, float value)
		{
			var normalizedVector = Vector2.Normalize(vector);
			return normalizedVector * value;
		}
    }
}