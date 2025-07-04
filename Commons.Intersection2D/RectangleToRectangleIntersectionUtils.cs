using Commons.Intersection2D.Internal;
using Commons.Intersection2D.Internal.Forms;

namespace Commons.Intersection2D
{
	public static partial class IntersectionUtils
	{
#pragma warning disable S107 // Methods should not have too many parameters
		public static bool IsRectangleToRectangleIntersect(
			float rect1Left, float rect1Top, float rect1Right, float rect1Bottom,
			float rect2Left, float rect2Top, float rect2Right, float rect2Bottom,
			bool validate = true
		)
		{
			var rect1 = new Rectangle(rect1Left, rect1Top, rect1Right, rect1Bottom);
			var rect2 = new Rectangle(rect2Left, rect2Top, rect2Right, rect2Bottom);
			
			return Intersector.IsIntersect(rect1, rect2, validate);
		}
#pragma warning restore S107 // Methods should not have too many parameters
	}
}