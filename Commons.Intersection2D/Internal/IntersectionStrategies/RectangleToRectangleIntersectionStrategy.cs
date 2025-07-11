﻿using System;
using System.Numerics;
using Commons.Intersection2D.Internal.Forms;

namespace Commons.Intersection2D.Internal.IntersectionStrategies
{
	internal class RectangleToRectangleIntersectionStrategy: IntersectionStrategy<Rectangle, Rectangle>
	{
		public override FormTypesPair[] GetFormTypes()
		{
			return new[]
			{
				new FormTypesPair(typeof(Rectangle), typeof(Rectangle))
			};
		}

		protected override bool IsIntersect(Rectangle rect1, Rectangle rect2)
		{
			return !(rect2.Left > rect1.Right
			         || rect2.Right < rect1.Left
			         || rect2.Top < rect1.Bottom
			         || rect2.Bottom > rect1.Top
			         || (rect2.Left > rect1.Left && rect2.Right < rect1.Right && rect2.Top < rect1.Top && rect2.Bottom > rect1.Bottom)
			         || (rect1.Left > rect2.Left && rect1.Right < rect2.Right && rect1.Top < rect2.Top && rect1.Bottom > rect2.Bottom));
		}

		protected override bool IsIntersect(out Vector2[] intersectionPoints, Rectangle rect1, Rectangle rect2)
		{
			throw new NotImplementedException();
		}
	}
}