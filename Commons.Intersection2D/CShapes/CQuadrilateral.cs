using System.Numerics;
using Commons.Intersection2D.CShapes.Internal;

namespace Commons.Intersection2D.CShapes
{
	[CShape]
	internal class CQuadrilateral : CPolygon
	{
		public Vector2 Point1 { get; }
		public Vector2 Point2 { get; }
		public Vector2 Point3 { get; }
		public Vector2 Point4 { get; }
		
		internal CQuadrilateral(Vector2 point1, Vector2 point2, Vector2 point3, Vector2 point4)
			: base(new[] {point1, point2, point3, point4})
		{
			Point1 = point1;
			Point2 = point2;
			Point3 = point3;
			Point4 = point4;
		}
	}
}