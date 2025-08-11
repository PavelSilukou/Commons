using System.Numerics;

namespace Commons.Intersection2D.Shapes
{
	public class CQuadrilateral : CPolygon
	{
		public readonly Vector2 Point1;
		public readonly Vector2 Point2;
		public readonly Vector2 Point3;
		public readonly Vector2 Point4;
		
		public CQuadrilateral(Vector2 point1, Vector2 point2, Vector2 point3, Vector2 point4)
			: base(new[] {point1, point2, point3, point4})
		{
			Point1 = point1;
			Point2 = point2;
			Point3 = point3;
			Point4 = point4;
		}
		
		protected override CShape OverrideTrueShape()
		{
			return this;
		}
	}
}