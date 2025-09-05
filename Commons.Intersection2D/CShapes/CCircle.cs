using System.Numerics;
using Commons.Intersection2D.CShapes.Internal;

namespace Commons.Intersection2D.CShapes
{
	[CShape]
	internal class CCircle : CShape
	{
		public Vector2 Center { get; }
		public float Radius { get; }
		
		internal CCircle(Vector2 center, float radius)
		{
			Center = center;
			Radius = radius;
		}
	}
}