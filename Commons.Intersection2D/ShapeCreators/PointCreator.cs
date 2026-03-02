using System;
using System.Numerics;
using Commons.Intersection2D.CShapes;
using JetBrains.Annotations;

namespace Commons.Intersection2D.ShapeCreators
{
	public class PointCreator
	{
		public CShape Create(Vector2 point)
		{
			// ReSharper disable once ConvertIfStatementToReturnStatement
			if (!Vector2Utils.IsFinite(point)) throw new ArithmeticException("Point should be finite.");
			
			return new CPoint(point);
		}
		
		public CShape TryCreate(Vector2 point)
		{
			return new CPoint(point);
		}
		
		[PublicAPI]
		public CShape ForceCreate(Vector2 point)
		{
			return new CPoint(point);
		}
	}
}