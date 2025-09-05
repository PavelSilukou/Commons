using System.Numerics;

namespace Commons.Intersection2D.CShapes
{
	[Shape]
	public class CCircle : CShape
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