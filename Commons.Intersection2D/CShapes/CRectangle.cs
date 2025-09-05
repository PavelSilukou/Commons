using System.Numerics;
using Commons.Intersection2D.CShapes.Internal;

namespace Commons.Intersection2D.CShapes
{
	[CShape]
	internal class CRectangle : CRotatedRectangle
	{
		public float Left { get; }
		public float Top { get; }
		public float Right { get; }
		public float Bottom { get; }
		
		internal CRectangle(float left, float top, float right, float bottom) 
			: base(
				new Vector2(left, top),
				new Vector2(right, top),
				new Vector2(right, bottom),
				new Vector2(left, bottom))
		{
			Left = left;
			Top = top;
			Right = right;
			Bottom = bottom;
		}
	}
}