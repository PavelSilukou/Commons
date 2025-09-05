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
		
		// public new static CShape Create(Vector2[] points)
		// {
		// 	if (IsPoint(points)) return new CPoint(points[0]);
		// 	return new CPolygon(points);
		// }
		//
		// public new static CShape ValidateAndCreate(Vector2[] points)
		// {
		// 	if (points.Length == 0) throw new ArithmeticException($"'{nameof(points)}' is empty.");
		// 	for(var i = 0; i < points.Length; i++)
		// 	{
		// 		if (!Vector2Utils.IsFinite(points[i])) 
		// 			throw new ArithmeticException($"'{nameof(points)}' element {i} should be finite.");
		// 	}
		// 	// TODO: check first and last point
		// 	
		// 	return new CPolygon(points);
		// }
	}
}