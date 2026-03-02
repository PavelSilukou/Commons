using System;
using System.Numerics;
using Commons.Intersection2D.CShapes;
using JetBrains.Annotations;

namespace Commons.Intersection2D.ShapeCreators
{
	public class QuadrilateralCreator
	{
		private readonly Equality.Equality _equality;
		
		internal QuadrilateralCreator(Equality.Equality equality)
		{
			_equality = equality;
		}
		
		public CShape Create(Vector2 point1, Vector2 point2, Vector2 point3, Vector2 point4)
		{
			if (!Vector2Utils.IsFinite(point1)) 
				throw new ArithmeticException($"'{nameof(point1)}' should be finite.");
			if (!Vector2Utils.IsFinite(point2)) 
				throw new ArithmeticException($"'{nameof(point2)}' should be finite.");
			if (!Vector2Utils.IsFinite(point3)) 
				throw new ArithmeticException($"'{nameof(point3)}' should be finite.");
			// ReSharper disable once ConvertIfStatementToReturnStatement
			if (!Vector2Utils.IsFinite(point4)) 
				throw new ArithmeticException($"'{nameof(point4)}' should be finite.");
			
			return new CQuadrilateral(point1, point2, point3, point4);
		}
		
		public CShape TryCreate(Vector2 point1, Vector2 point2, Vector2 point3, Vector2 point4)
		{
			if (IsPoint(point1, point2, point3, point4)) return new CPoint(point1);
			return new CQuadrilateral(point1, point2, point3, point4);
		}
		
		[PublicAPI]
		public CShape ForceCreate(Vector2 point1, Vector2 point2, Vector2 point3, Vector2 point4)
		{
			return new CQuadrilateral(point1, point2, point3, point4);
		}

		private bool IsPoint(Vector2 point1, Vector2 point2, Vector2 point3, Vector2 point4)
		{
			var points = new[] { point1, point2, point3, point4 };
			return points.AllEquals(_equality.Vector2.GetComparer());
		}
	}
}