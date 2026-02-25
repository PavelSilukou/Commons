using System.Numerics;
using Commons.Intersection2D.CShapes.Internal;

namespace Commons.Intersection2D.CShapes
{
	[CShape]
	internal class CPolygon : CPolyline
	{
		internal CPolygon(Vector2[] points): base(points)
		{
		}
	}
}