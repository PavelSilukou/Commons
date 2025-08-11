using System;
using System.Numerics;
using System.Collections.Immutable;
using System.Linq;

namespace Commons.Intersection2D.Shapes
{
	public class CPolyline : CShape
	{
		public readonly ImmutableArray<Vector2> Points;
		public readonly ImmutableArray<CLineSegment> Segments;
		
		public CPolyline(Vector2[] points)
		{
			Points = points.ToImmutableArray();
			Segments = Points
				.GetPairs()
				.Select(pair => new CLineSegment(pair.Item1, pair.Item2))
				.ToImmutableArray();
		}

		protected override void Validation()
		{
			if (Points.Length == 0) throw new ArithmeticException("Points length is 0.");
			for(var i = 1; i <= Points.Length; i++)
			{
				if (!Vector2Utils.IsFinite(Points[i - 1])) throw new ArithmeticException($"Point{i} is not finite.");
			}
		}
	}
}