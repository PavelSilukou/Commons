using System.Numerics;
using Commons.Intersection2D.CShapes.Internal;

namespace Commons.Intersection2D.CShapes
{
	[CShape]
	internal class CArc : CShape
	{
		public Vector2 Center { get; }
		public Vector2 Point { get; }
		public float Angle { get; }
		public int AngleSign { get; }
		public float Radius { get; }
		
		internal CArc(Vector2 center, Vector2 point, float angle, int angleSign, float radius)
		{
			Center = center;
			Point = point;
			Angle = angle;
			AngleSign = angleSign;
			Radius = radius;
		}
	}
}