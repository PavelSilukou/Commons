using System;
using System.Numerics;

namespace Commons.Intersection2D.Internal.Forms
{
	internal class Arc : Form
	{
		public readonly Vector2 Center;
		public readonly Vector2 Point;
		public readonly float Angle;
		public readonly int AngleSign;
		public readonly float Radius;
		
		internal Arc(Vector2 center, Vector2 point, float angle)
		{
			Center = center;
			Point = point;
			Angle = angle;
			AngleSign = MathFUtils.Sign(Angle);
			Radius = Vector2.Distance(Center, Point);
		}
		
		protected override void OptionalValidation()
		{
			if (!Vector2Utils.IsFinite(Center)) throw new ArithmeticException("Center is not finite.");
			if (!Vector2Utils.IsFinite(Point)) throw new ArithmeticException("Point is not finite.");
			if (!float.IsFinite(Angle)) throw new ArithmeticException("Angle is not finite.");
			if (!float.IsFinite(Radius)) throw new ArithmeticException("Radius is not finite.");
			if (MathF.Abs(Angle) > 360.0f) throw new ArithmeticException("Angle is more than 360.0f.");
		}

		protected override Form OverrideTrueForm()
		{
			if (Radius.EqualTo(0.0f)) return new Point(Center);
			if (Angle.EqualTo(0.0f)) return new Point(Point);
			return this;
		}
	}
}