using System.Numerics;
using Commons.Intersection2D.Internal;
using Commons.Intersection2D.Internal.Forms;

namespace Commons.Intersection2D
{
	public static partial class IntersectionUtils
	{
		public static bool IsCircleToCircleIntersect(
			Vector2 circle1Center,
			float circle1Radius,
			Vector2 circle2Center,
			float circle2Radius,
			bool validate = true
		)
		{
			var circle1 = new Circle(circle1Center, circle1Radius);
			var circle2 = new Circle(circle2Center, circle2Radius);
			
			return Intersector.IsIntersect(circle1, circle2, validate);
		}
		
		public static bool IsCircleToCircleIntersect(
			out Vector2[] intersectionPoints,
			Vector2 circle1Center,
			float circle1Radius,
			Vector2 circle2Center,
			float circle2Radius,
			bool validate = true
		)
		{
			var circle1 = new Circle(circle1Center, circle1Radius);
			var circle2 = new Circle(circle2Center, circle2Radius);
			
			return Intersector.IsIntersect(out intersectionPoints, circle1, circle2, validate);
		}
	}
}