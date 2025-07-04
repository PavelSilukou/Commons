using System;
using System.Numerics;

// TODO:
namespace Commons.Intersection2D.Internal.Forms
{
	internal class Quadrilateral : Form
	{
		public readonly Vector2 Point1;
		public readonly Vector2 Point2;
		public readonly Vector2 Point3;
		public readonly Vector2 Point4;
		
		internal Quadrilateral(Vector2 point1, Vector2 point2, Vector2 point3, Vector2 point4)
		{
			Point1 = point1;
			Point2 = point2;
			Point3 = point3;
			Point4 = point4;
		}
		
		protected override void OptionalValidation()
		{
			if (!Vector2Utils.IsFinite(Point1)) throw new ArithmeticException("Point1 is not finite.");
			if (!Vector2Utils.IsFinite(Point2)) throw new ArithmeticException("Point2 is not finite.");
			if (!Vector2Utils.IsFinite(Point3)) throw new ArithmeticException("Point3 is not finite.");
			if (!Vector2Utils.IsFinite(Point4)) throw new ArithmeticException("Point4 is not finite.");
		}

		protected override Form OverrideTrueForm()
		{
			return this;
		}
	}
}