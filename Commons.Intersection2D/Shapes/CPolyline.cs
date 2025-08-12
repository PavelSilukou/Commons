using System;
using System.Numerics;
using System.Collections.Immutable;
using System.Linq;
using Commons.EqualityComparers;

namespace Commons.Intersection2D.Shapes
{
	[Shape]
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
			for(var i = 0; i < Points.Length; i++)
			{
				if (!Vector2Utils.IsFinite(Points[i])) throw new ArithmeticException($"Point{i + 1} is not finite.");
			}
		}

		protected override CShape OverrideTrueShape()
		{
			if (IsPoint()) return new CPoint(Points[0]);
			return this;
		}

		protected bool IsPoint()
		{
			return Points.AllEquals(new Vector2EqualityComparer());
		}
	}
}