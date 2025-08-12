using System.Numerics;

namespace Commons.Intersection2D.Shapes
{
	[Shape]
	public class CPolygon : CPolyline
	{
		public CPolygon(Vector2[] points): base(points)
		{
		}
	}
}