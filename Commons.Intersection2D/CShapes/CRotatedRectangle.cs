using System.Numerics;

namespace Commons.Intersection2D.CShapes
{
	[Shape]
	public class CRotatedRectangle : CQuadrilateral
	{
		internal CRotatedRectangle(Vector2 point1, Vector2 point2, Vector2 point3, Vector2 point4) 
			: base(point1, point2, point3, point4)
		{
		}
	}
}