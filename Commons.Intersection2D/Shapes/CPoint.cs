using System;
using System.Numerics;

namespace Commons.Intersection2D.Shapes
{
	[Shape]
	public class CPoint : CShape
	{
		public Vector2 P { get; }
		
		public CPoint(Vector2 point)
		{
			P = point;
		}
		
		protected override void Validation()
		{
			if (!Vector2Utils.IsFinite(P)) throw new ArithmeticException("Point is not finite.");
		}
	}
}