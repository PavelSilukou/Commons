using System;
using System.Numerics;

namespace Commons.Intersection2D.Shapes
{
	public class CRectangle : CRotatedRectangle
	{
		public readonly float Left;
		public readonly float Top;
		public readonly float Right;
		public readonly float Bottom;
		
		public CRectangle(float left, float top, float right, float bottom) 
			: base(
				new Vector2(left, top),
				new Vector2(right, top),
				new Vector2(right, bottom),
				new Vector2(left, bottom))
		{
			Left = left;
			Top = top;
			Right = right;
			Bottom = bottom;
		}
		
		protected override void Validation()
		{
			if (!float.IsFinite(Left)) throw new ArithmeticException("Left value is not finite.");
			if (!float.IsFinite(Top)) throw new ArithmeticException("Top value is not finite.");
			if (!float.IsFinite(Right)) throw new ArithmeticException("Right value is not finite.");
			if (!float.IsFinite(Bottom)) throw new ArithmeticException("Bottom value is not finite.");
			
			if (Left > Right) throw new ArithmeticException("Left value should be less than Right value.");
			if (Bottom > Top) throw new ArithmeticException("Bottom value should be less than Top value.");
		}

		protected override CShape OverrideTrueShape()
		{
			if (Left.EqualTo(Right) && Top.EqualTo(Bottom)) return new CPoint(new Vector2(Left, Left));
			if (Left.EqualTo(Right)) return new CLineSegment(new Vector2(Left, Top), new Vector2(Right, Bottom));
			if (Top.EqualTo(Bottom)) return new CLineSegment(new Vector2(Left, Top), new Vector2(Right, Bottom));

			return this;
		}
	}
}