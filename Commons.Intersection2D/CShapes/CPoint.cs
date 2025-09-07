using System.Numerics;
using Commons.Intersection2D.CShapes.Internal;

namespace Commons.Intersection2D.CShapes
{
	[CShape]
	internal class CPoint : CShape
	{
		public Vector2 Point { get; }
		
		internal CPoint(Vector2 point)
		{
			Point = point;
		}
		
		// public static CShape Create(Vector2 point)
		// {
		// 	return new CPoint(point);
		// }
		//
		// public static CShape Create(Vector2 point)
		// {
		// 	if (!Vector2Utils.IsFinite(point)) throw new ArithmeticException("Point should be finite.");
		// 	
		// 	return new CPoint(point);
		// }
	}
}