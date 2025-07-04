using System.Numerics;
using Commons.Intersection2D.Internal;
using Commons.Intersection2D.Internal.Forms;

namespace Commons.Intersection2D
{
	public static partial class IntersectionUtils
	{
		public static bool IsLineToLineIntersect(
			Vector2 line1Point1,
			Vector2 line1Point2,
			Vector2 line2Point1,
			Vector2 line2Point2,
			bool validate = true
		)
		{
			var line1 = new Line(line1Point1, line1Point2);
			var line2 = new Line(line2Point1, line2Point2);
			
			return Intersector.IsIntersect(line1, line2, validate);
		}
		
		public static bool IsLineToLineIntersect(
			out Vector2[] intersectionPoints,
			Vector2 line1Point1,
			Vector2 line1Point2,
			Vector2 line2Point1,
			Vector2 line2Point2,
			bool validate = true
		)
		{
			var line1 = new Line(line1Point1, line1Point2);
			var line2 = new Line(line2Point1, line2Point2);
			
			return Intersector.IsIntersect(out intersectionPoints, line1, line2, validate);
		}
	}
}