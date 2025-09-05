using System.Numerics;

namespace Commons.Intersection2D.CShapes
{
	[Shape]
	public class CLine : CShape
	{
		public Vector2 Point1 { get; }
		public Vector2 Point2 { get; }
		
		internal CLine(Vector2 point1, Vector2 point2)
		{
			Point1 = point1;
			Point2 = point2;
		}
	}
}