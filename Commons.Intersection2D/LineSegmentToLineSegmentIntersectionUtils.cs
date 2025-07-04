using System.Numerics;
using Commons.Intersection2D.Internal;
using Commons.Intersection2D.Internal.Forms;

namespace Commons.Intersection2D
{
	public static partial class IntersectionUtils
	{
		public static bool IsLineSegmentToLineSegmentIntersect(
			Vector2 lineSegment1Point1,
			Vector2 lineSegment1Point2,
			Vector2 lineSegment2Point1,
			Vector2 lineSegment2Point2,
			bool validate = true
		)
		{
			var lineSegment1 = new LineSegment(lineSegment1Point1, lineSegment1Point2);
			var lineSegment2 = new LineSegment(lineSegment2Point1, lineSegment2Point2);
			
			return Intersector.IsIntersect(lineSegment1, lineSegment2, validate);
		}
		
		public static bool IsLineSegmentToLineSegmentIntersect(
			out Vector2[] intersectionPoints,
			Vector2 lineSegment1Point1,
			Vector2 lineSegment1Point2,
			Vector2 lineSegment2Point1,
			Vector2 lineSegment2Point2,
			bool validate = true
		)
		{
			var lineSegment1 = new LineSegment(lineSegment1Point1, lineSegment1Point2);
			var lineSegment2 = new LineSegment(lineSegment2Point1, lineSegment2Point2);
			
			return Intersector.IsIntersect(out intersectionPoints, lineSegment1, lineSegment2, validate);
		}
	}
}