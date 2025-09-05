using System;
using System.Numerics;
using Commons.Intersection2D.CShapes;

namespace Commons.Intersection2D.Strategies
{
	[IntersectionStrategy]
	internal class CircleToCircleIntersectionStrategy: IntersectionStrategy<CCircle, CCircle>
	{
		protected override bool IsIntersect(CCircle circle1, CCircle circle2)
		{
			var distance = Vector2.Distance(circle1.Center, circle2.Center);
			if (distance.EqualTo(0.0f) && circle1.Radius.EqualTo(circle2.Radius))
			{
				return true;
			}
			
			return distance.LessOrEqualTo(circle1.Radius + circle2.Radius) 
			       && distance.MoreOrEqualTo(MathF.Abs(circle1.Radius - circle2.Radius));
		}

		protected override bool IsIntersect(out Vector2[] intersectionPoints, CCircle circle1, CCircle circle2)
		{
			intersectionPoints = Array.Empty<Vector2>();
			if (!IsIntersect(circle1, circle2))
			{
				return false;
			}

			var r = MathF.Sqrt(MathF.Pow(circle2.Center.X - circle1.Center.X, 2) 
			                   + MathF.Pow(circle2.Center.Y - circle1.Center.Y, 2));
			var r2 = r * r;
			var r4 = r2 * r2;
			var k = circle1.Radius * circle1.Radius - circle2.Radius * circle2.Radius;
			var k2 = k * k;
			var j = circle1.Radius * circle1.Radius + circle2.Radius * circle2.Radius;

			var sqrt = MathF.Sqrt(2 * j / r2 - k2 / r4 - 1);
			var xPart1 = (circle1.Center.X + circle2.Center.X) / 2 
			             + k / (2 * r2) * (circle2.Center.X - circle1.Center.X);
			var xPart2 = sqrt / 2 * (circle2.Center.Y - circle1.Center.Y);
			var yPart1 = (circle1.Center.Y + circle2.Center.Y) / 2 
			             + k / (2 * r2) * (circle2.Center.Y - circle1.Center.Y);
			var yPart2 = sqrt / 2 * (circle1.Center.X - circle2.Center.X);

			var x00 = xPart1 + xPart2;
			var x01 = xPart1 - xPart2;
			var y00 = yPart1 + yPart2;
			var y01 = yPart1 - yPart2;

			var intersectionPoint1 = new Vector2(x00, y00);
			var intersectionPoint2 = new Vector2(x01, y01);
			intersectionPoints = intersectionPoint1.Equals(intersectionPoint2) ? new[] { intersectionPoint1 } : new[] { intersectionPoint1, intersectionPoint2 };
			return true;
		}
	}
}