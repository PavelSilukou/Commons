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
				.Select(pair => new CLineSegment(pair.Item1, pair.Item2))
				.ToReadOnlyArray();
		}
		
		// public static CShape Create(Vector2[] points)
		// {
		// 	if (IsPoint(points)) return new CPoint(points[0]);
		// 	// TODO: length == 1 return point
		// 	// TODO: length == 2 return segment
		// 	return new CPolyline(points);
		// }
		//
		// public static CShape ValidateAndCreate(Vector2[] points)
		// {
		// 	if (points.Length == 0) throw new ArithmeticException($"'{nameof(points)}' is empty.");
		// 	for(var i = 0; i < points.Length; i++)
		// 	{
		// 		if (!Vector2Utils.IsFinite(points[i])) 
		// 			throw new ArithmeticException($"'{nameof(points)}' element {i} should be finite.");
		// 	}
		// 	
		// 	return new CPolyline(points);
		// }
		//
		// protected static bool IsPoint(Vector2[] points)
		// {
		// 	return points.AllEquals(new Vector2EqualityComparer());
		// }
	}
}