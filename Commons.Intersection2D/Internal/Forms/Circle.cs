using System;
using System.Numerics;

namespace Commons.Intersection2D.Internal.Forms
{
	internal class Circle : Form
	{
		public readonly Vector2 Center;
		public readonly float Radius;
		
		internal Circle(Vector2 center, float radius)
		{
			Center = center;
			Radius = radius;
		}
		
		protected override void OptionalValidation()
		{
			if (!Vector2Utils.IsFinite(Center)) throw new ArithmeticException("Center is not finite.");
			if (!float.IsFinite(Radius)) throw new ArithmeticException("Radius is not finite.");
		}

		protected override Form OverrideTrueForm()
		{
			if (float.IsNegative(Radius) || Radius.EqualTo(0.0f)) return new Point(Center);
			return this;
		}
	}
}