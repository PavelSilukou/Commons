using System;
using System.Numerics;

namespace Commons.Intersection2D.Shapes
{
	[Shape]
	public class CCircle : CShape
	{
		public readonly Vector2 Center;
		public readonly float Radius;
		
		public CCircle(Vector2 center, float radius)
		{
			Center = center;
			Radius = radius;
		}
		
		protected override void Validation()
		{
			if (!Vector2Utils.IsFinite(Center)) throw new ArithmeticException("Center is not finite.");
			if (!float.IsFinite(Radius)) throw new ArithmeticException("Radius is not finite.");
		}

		protected override CShape OverrideTrueShape()
		{
			if (float.IsNegative(Radius) || Radius.EqualTo(0.0f)) return new CPoint(Center);
			return this;
		}
	}
}