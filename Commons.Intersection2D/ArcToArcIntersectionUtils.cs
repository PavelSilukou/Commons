using System.Numerics;
using Commons.Intersection2D.Internal;
using Commons.Intersection2D.Internal.Forms;

namespace Commons.Intersection2D
{
	public static partial class IntersectionUtils
	{
		public static bool IsArcToArcIntersect(
			Vector2 arc1Center,
			Vector2 arc1Point,
			float arc1AngleDeg, // signed angle: minus - clockwise; plus - counterclockwise
			Vector2 arc2Center,
			Vector2 arc2Point,
			float arc2AngleDeg, // signed angle: minus - clockwise; plus - counterclockwise,
			bool validate = true
		)
		{
			var arc1 = new Arc(arc1Center, arc1Point, arc1AngleDeg);
			var arc2 = new Arc(arc2Center, arc2Point, arc2AngleDeg);
			
			return Intersector.IsIntersect(arc1, arc2, validate);
		}
		
#pragma warning disable S107 // Methods should not have too many parameters
		public static bool IsArcToArcIntersect(
			out Vector2[] intersectionPoints,
			Vector2 arc1Center,
			Vector2 arc1Point,
			float arc1AngleDeg, // signed angle: minus - clockwise; plus - counterclockwise
			Vector2 arc2Center,
			Vector2 arc2Point,
			float arc2AngleDeg, // signed angle: minus - clockwise; plus - counterclockwise,
			bool validate = true
		)
		{
			var arc1 = new Arc(arc1Center, arc1Point, arc1AngleDeg);
			var arc2 = new Arc(arc2Center, arc2Point, arc2AngleDeg);
			
			return Intersector.IsIntersect(out intersectionPoints, arc1, arc2, validate);
		}
#pragma warning restore S107 // Methods should not have too many parameters
	}
}