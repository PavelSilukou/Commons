using System.Linq;
using System.Numerics;

namespace Commons.Intersection2D.Shapes
{
	public class CPolygon : CPolyline
	{
		public CPolygon(Vector2[] points): base(points)
		{
		}

		protected override CShape OverrideTrueShape()
		{
			return IsPolygon() ? this : new CPolyline(Points.ToArray());
		}
		
		private bool IsPolygon()
		{
			return Points[0].EqualTo(Points[^1]);
		}
	}
}