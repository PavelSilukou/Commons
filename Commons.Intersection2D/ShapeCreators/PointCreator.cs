using System;
using System.Numerics;
using Commons.Intersection2D.CShapes;
using JetBrains.Annotations;

namespace Commons.Intersection2D.ShapeCreators
{
	public class PointCreator
	{
		private readonly Approximation.Approximation _approximation;
		
		internal PointCreator(Approximation.Approximation approximation)
		{
			_approximation = approximation;
		}
		
		public CShape Create(Vector2 point)
		{
			// ReSharper disable once ConvertIfStatementToReturnStatement
			if (!_approximation.Vector2.IsFinite(point)) throw new ArithmeticException("Point should be finite.");
			
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