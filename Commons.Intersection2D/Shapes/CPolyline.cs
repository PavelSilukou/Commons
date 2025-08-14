using System;
using System.Numerics;
using System.Linq;
using Commons.EqualityComparers;

namespace Commons.Intersection2D.Shapes
{
	[Shape]
	public class CPolyline : CShape
	{
		public Vector2[] Points { get; }
		public CLineSegment[] Segments { get; }

		public CPolyline(Vector2[] points)
		{
			Points = points;
			Segments = Points
				.GetPairs()
				.Select(pair => new CLineSegment(pair.Item1, pair.Item2))
				.ToArray();
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