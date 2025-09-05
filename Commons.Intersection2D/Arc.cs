using System;
using System.Numerics;
using Commons.Intersection2D.CShapes;

namespace Commons.Intersection2D
{
	public static partial class Shapes
	{
		public static CShape CreateArc(Vector2 center, Vector2 point, float angle)
		{
			var angleSign = GetAngleSign(angle);
			var radius = GetRadius(center, point);
			return new CArc(center, point, angle, angleSign, radius);
		}
		
		public static CShape TryCreateArc(Vector2 center, Vector2 point, float angle)
		{
			var angleSign = GetAngleSign(angle);
			var radius = GetRadius(center, point);
			
			if (radius.EqualTo(0.0f)) return new CPoint(center);
			if (angle.EqualTo(0.0f)) return new CPoint(point);
			if (MathF.Abs(angle).EqualTo(360.0f)) return new CCircle(center, radius);
			
			return new CArc(center, point, angle, angleSign, radius);
		}

		public static CShape ValidateAndCreateArc(Vector2 center, Vector2 point, float angle)
		{
			if (!Vector2Utils.IsFinite(center)) 
				throw new ArithmeticException($"'{nameof(center)}' should be finite.");
			if (!Vector2Utils.IsFinite(point)) 
				throw new ArithmeticException($"'{nameof(point)}' should be finite.");
			
			if (!float.IsFinite(angle) || MathF.Abs(angle).MoreOrEqualTo(360.0f) || angle.EqualTo(0.0f)) 
				throw new ArithmeticException($"'{nameof(angle)}' should be in range (0.0f, 360.0f).");
			var angleSign = GetAngleSign(angle);
			var radius = GetRadius(center, point);
			if (radius.EqualTo(0.0f)) throw new ArithmeticException("Arc radius should be more than 0.0f.");
			
			return new CArc(center, point, angle, angleSign, radius);
		}

		private static int GetAngleSign(float angle)
		{
			try
			{
				return MathFUtils.Sign(angle);
			}
			catch (ArithmeticException)
			{
				return 0;
			}
		}

		private static float GetRadius(Vector2 center, Vector2 point)
		{
			return Vector2.Distance(center, point);
		}
	}
}