using System;
using System.Numerics;

namespace Commons.Intersection2D.Shapes
{
	public class CArc : CShape
	{
		public readonly Vector2 Center;
		public readonly Vector2 Point;
		public readonly float Angle;
		public readonly int AngleSign;
		public readonly float Radius;
		
		public CArc(Vector2 center, Vector2 point, float angle)
		{
			Center = center;
			Point = point;
			Angle = angle;
			try
			{
				AngleSign = MathFUtils.Sign(Angle);
			}
			catch (ArithmeticException)
			{
				AngleSign = 0;
			}
			
			Radius = Vector2.Distance(Center, Point);
		}
		
		protected override void Validation()
		{
			if (!Vector2Utils.IsFinite(Center)) throw new ArithmeticException("Center is not finite.");
			if (!Vector2Utils.IsFinite(Point)) throw new ArithmeticException("Point is not finite.");
			if (!float.IsFinite(Angle)) throw new ArithmeticException("Angle is not finite.");
			if (MathF.Abs(Angle) > 360.0f) throw new ArithmeticException("Angle is more than 360.0f.");
		}

		protected override CShape OverrideTrueShape()
		{
			if (Radius.EqualTo(0.0f)) return new CPoint(Center);
			if (Angle.EqualTo(0.0f)) return new CPoint(Point);
			if (MathF.Abs(Angle).EqualTo(360.0f)) return new CCircle(Center, Radius);
			return this;
		}
	}
}