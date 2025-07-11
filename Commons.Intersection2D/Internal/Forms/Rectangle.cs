﻿using System;
using System.Numerics;

namespace Commons.Intersection2D.Internal.Forms
{
	internal class Rectangle : RotatedRectangle
	{
		public readonly float Left;
		public readonly float Top;
		public readonly float Right;
		public readonly float Bottom;
		
		internal Rectangle(float left, float top, float right, float bottom) 
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
		
		protected override void OptionalValidation()
		{
			if (!float.IsFinite(Left)) throw new ArithmeticException("Left value is not finite.");
			if (!float.IsFinite(Top)) throw new ArithmeticException("Top value is not finite.");
			if (!float.IsFinite(Right)) throw new ArithmeticException("Right value is not finite.");
			if (!float.IsFinite(Bottom)) throw new ArithmeticException("Bottom value is not finite.");
			
			if (Left > Right) throw new ArithmeticException("Left value should be less than Right value.");
			if (Bottom > Top) throw new ArithmeticException("Bottom value should be less than Top value.");
		}

		protected override Form OverrideTrueForm()
		{
			if (Left.EqualTo(Right) && Top.EqualTo(Bottom)) return new Point(new Vector2(Left, Left));
			if (Left.EqualTo(Right)) return new LineSegment(new Vector2(Left, Top), new Vector2(Right, Bottom));
			if (Top.EqualTo(Bottom)) return new LineSegment(new Vector2(Left, Top), new Vector2(Right, Bottom));

			return this;
		}
	}
}