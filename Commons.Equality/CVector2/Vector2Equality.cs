using System;
using System.Collections.Generic;
using System.Numerics;
using Commons.Equality.CFloat;
using JetBrains.Annotations;

namespace Commons.Equality.CVector2
{
	[PublicAPI]
    public class Vector2Equality
    {
        private readonly FloatEquality _floatEquality;
        
        internal Vector2Equality(FloatEquality floatEquality)
        {
            _floatEquality = floatEquality;
        }
        
        public IEqualityComparer<Vector2> GetComparer()
        {
            return new Vector2EqualityComparer(this);
        }
        
        public bool EqualTo(Vector2 vector1, Vector2 vector2)
        {
            return _floatEquality.EqualTo(vector1.X, vector2.X) && _floatEquality.EqualTo(vector1.Y, vector2.Y);
        }
        
		public float SignedAngleRadClamp(Vector2 vector1, Vector2 vector2)
		{
			var y = vector1.Y * vector2.X - vector1.X * vector2.Y;
			var x = vector1.X * vector2.X + vector1.Y * vector2.Y;
			var angle = -MathF.Atan2(y, x);
			return _floatEquality.EqualTo(angle, -MathF.PI) ? MathF.PI : angle;
		}
		
		public float SignedAngleDegClamp(Vector2 vector1, Vector2 vector2)
		{
			var radians = SignedAngleRadClamp(vector1, vector2);
			return MathFUtils.Rad2Deg(radians);
		}
		
		public float SignedAngleRad360Clamp(Vector2 vector1, Vector2 vector2, int direction)
		{
			var angle = Vector2Utils.SignedAngleRad360(vector1, vector2, direction);
			return _floatEquality.EqualTo(MathF.Abs(angle), 2 * MathF.PI) ? 0.0f : angle;
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
			var angle = Vector2Utils.SignedAngleDeg(vector1, vector2);
			return _floatEquality.EqualTo(angle, 0.0f) || _floatEquality.EqualTo(angle, 180.0f);
		}
		
		public bool PointProjectionOnLineSegment(
			out Vector2? projection,
			Vector2 point,
			Vector2 lineSegmentPoint1,
			Vector2 lineSegmentPoint2)
		{
			projection = Vector2Utils.NaN();
			if (!Vector2Utils.IsFinite(point)) return false;
			
			var isProjectOnLine = PointProjectionOnLineInternal(out var projectionOnLine, point, lineSegmentPoint1, lineSegmentPoint2);
			if (!isProjectOnLine) return false;
			
			var dx = lineSegmentPoint2.X - lineSegmentPoint1.X;
			var dy = lineSegmentPoint2.Y - lineSegmentPoint1.Y;
			var innerProduct = (projectionOnLine.X - lineSegmentPoint1.X) * dx 
			                   + (projectionOnLine.Y - lineSegmentPoint1.Y) * dy;
			
			var isProject = _floatEquality.MoreOrEqualTo(innerProduct, 0.0f) 
			                && _floatEquality.LessOrEqualTo(innerProduct, dx * dx + dy * dy);
		
			projection = isProject ? projectionOnLine : null;
			return isProject;
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
			return !Vector2Utils.IsNaN(projection);
		}
    }
}