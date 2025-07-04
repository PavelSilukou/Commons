using System.Numerics;
using Commons.Intersection2D.Internal;
using Commons.Intersection2D.Internal.Forms;

namespace Commons.Intersection2D
{
	public static partial class IntersectionUtils
	{
		public static bool IsArcToCircleIntersect(
			Vector2 arcCenter,
			Vector2 arcPoint,
			float arcAngleDeg, // signed angle: minus - clockwise; plus - counterclockwise,
			Vector2 circleCenter,
			float circleRadius,
			bool validate = true
		)
		{
			var arc = new Arc(arcCenter, arcPoint, arcAngleDeg);
			var circle = new Circle(circleCenter, circleRadius);
			
			return Intersector.IsIntersect(arc, circle, validate);
		}
		
		public static bool IsArcToCircleIntersect(
			out Vector2[] intersectionPoints,
			Vector2 arcCenter,
			Vector2 arcPoint,
			float arcAngleDeg, // signed angle: minus - clockwise; plus - counterclockwise,
			Vector2 circleCenter,
			float circleRadius,
			bool validate = true
		)
		{
			var arc = new Arc(arcCenter, arcPoint, arcAngleDeg);
			var circle = new Circle(circleCenter, circleRadius);
			
			return Intersector.IsIntersect(out intersectionPoints, arc, circle, validate);
		}
	}
}