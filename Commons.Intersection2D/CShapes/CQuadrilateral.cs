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
		
		// public static CShape Create(Vector2 point1, Vector2 point2, Vector2 point3, Vector2 point4)
		// {
		// 	if (IsPoint(point1, point2, point3, point4)) return new CPoint(point1);
		// 	return new CQuadrilateral(point1, point2, point3, point4);
		// }
		//
		// public static CShape Create(Vector2 point1, Vector2 point2, Vector2 point3, Vector2 point4)
		// {
		// 	if (!Vector2Utils.IsFinite(point1)) 
		// 		throw new ArithmeticException($"'{nameof(point1)}' should be finite.");
		// 	if (!Vector2Utils.IsFinite(point2)) 
		// 		throw new ArithmeticException($"'{nameof(point2)}' should be finite.");
		// 	if (!Vector2Utils.IsFinite(point3)) 
		// 		throw new ArithmeticException($"'{nameof(point3)}' should be finite.");
		// 	if (!Vector2Utils.IsFinite(point4)) 
		// 		throw new ArithmeticException($"'{nameof(point4)}' should be finite.");
		// 	
		// 	return new CQuadrilateral(point1, point2, point3, point4);
		// }
		//
		// private static bool IsPoint(Vector2 point1, Vector2 point2, Vector2 point3, Vector2 point4)
		// {
		// 	var points = new[] { point1, point2, point3, point4 };
		// 	return IsPoint(points);
		// }
	}
}