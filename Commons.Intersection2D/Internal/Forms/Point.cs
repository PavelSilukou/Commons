using System;
using System.Numerics;

namespace Commons.Intersection2D.Internal.Forms
{
	internal class Point : Form
	{
		public readonly Vector2 P;
		
		internal Point(Vector2 point)
		{
			P = point;
		}
		
		protected override void OptionalValidation()
		{
			if (!Vector2Utils.IsFinite(P)) throw new ArithmeticException("Point is not finite.");
		}
	}
}