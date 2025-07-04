using System.Numerics;
using Commons.Intersection2D.Internal;
using Commons.Intersection2D.Internal.Forms;

namespace Commons.Intersection2D
{
	public static partial class IntersectionUtils
	{
#pragma warning disable S107 // Methods should not have too many parameters
		public static bool IsRotatedRectangleToRotatedRectangleIntersect(
			Vector2 rect1Point1, Vector2 rect1Point2, Vector2 rect1Point3, Vector2 rect1Point4,
			Vector2 rect2Point1, Vector2 rect2Point2, Vector2 rect2Point3, Vector2 rect2Point4,
			bool validate = true
		)
		{
			var rotatedRect1 = new RotatedRectangle(rect1Point1, rect1Point2, rect1Point3, rect1Point4);
			var rotatedRect2 = new RotatedRectangle(rect2Point1, rect2Point2, rect2Point3, rect2Point4);
			
			return Intersector.IsIntersect(rotatedRect1, rotatedRect2, validate);
		}
#pragma warning restore S107 // Methods should not have too many parameters
	}
}