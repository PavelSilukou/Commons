using System;
using System.Numerics;
using Commons.Intersection2D.CShapes;
using JetBrains.Annotations;

namespace Commons.Intersection2D.ShapeCreators
{
	public class PolygonCreator
	{
		private readonly Equality.Equality _equality;
		
		internal PolygonCreator(Equality.Equality equality)
		{
			_equality = equality;
		}
		
		public CShape Create(Vector2[] points)
		{
			if (points.Length == 0) throw new ArithmeticException($"'{nameof(points)}' is empty.");
			for(var i = 0; i < points.Length; i++)
			{
				if (!Vector2Utils.IsFinite(points[i])) 
					throw new ArithmeticException($"'{nameof(points)}' element {i} should be finite.");
			}
			// TODO: check first and last point
			
			return new CPolygon(points);
		}
		
		public CShape TryCreate(Vector2[] points)
		{
			if (IsPoint(points)) return new CPoint(points[0]);
			return new CPolygon(points);
		}
		
		[PublicAPI]
		public CShape ForceCreate(Vector2[] points)
		{
			return new CPolygon(points);
		}
		
		private bool IsPoint(Vector2[] points)
		{
			return points.AllEquals(_equality.Vector2.GetComparer());
		}
	}
}