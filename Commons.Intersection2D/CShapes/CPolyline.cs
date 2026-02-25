using System.Collections.ObjectModel;
using System.Numerics;
using System.Linq;
using Commons.Intersection2D.CShapes.Internal;

namespace Commons.Intersection2D.CShapes
{
	[CShape]
	internal class CPolyline : CShape
	{
		public ReadOnlyCollection<Vector2> Points { get; }
		public ReadOnlyCollection<CLineSegment> Segments { get; }

		internal CPolyline(Vector2[] points)
		{
			Points = points.AsReadOnly();
			Segments = Points
				.GetPairs()
				.Select(pair => new CLineSegment(pair.Element1, pair.Element2))
				.ToReadOnlyArray();
		}
	}
}