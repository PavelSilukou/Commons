using System.Numerics;
using Commons.Intersection2D.CShapes.Internal;

namespace Commons.Intersection2D.CShapes
{
	[CShape]
	internal class CLineSegment : CShape
	{
		public Vector2 Point1 { get; }
		public Vector2 Point2 { get; }
		
		internal CLineSegment(Vector2 point1, Vector2 point2)
		{
			Point1 = point1;
			Point2 = point2;
		}
	}
}