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
	}
}