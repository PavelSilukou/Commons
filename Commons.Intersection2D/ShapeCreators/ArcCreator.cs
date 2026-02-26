using System;
using System.Numerics;
using Commons.Intersection2D.CShapes;
using JetBrains.Annotations;

namespace Commons.Intersection2D.ShapeCreators
{
	public class ArcCreator
	{
		private readonly Approximation.Approximation _approximation;
		
		internal ArcCreator(Approximation.Approximation approximation)
		{
			_approximation = approximation;
		}
		
		public CShape Create(Vector2 center, Vector2 point, float angle)
		{
			if (!_approximation.Vector2.IsFinite(center)) 
				throw new ArithmeticException($"'{nameof(center)}' should be finite.");
			if (!_approximation.Vector2.IsFinite(point)) 
				throw new ArithmeticException($"'{nameof(point)}' should be finite.");
			
			if (!float.IsFinite(angle) 
			    || _approximation.Float.MoreOrEqualTo(MathF.Abs(angle), 360.0f) 
			    || _approximation.Float.EqualTo(angle, 0.0f)) 
				throw new ArithmeticException($"'{nameof(angle)}' should be in range (0.0f, 360.0f).");
			var angleSign = GetAngleSign(angle);
			var radius = GetRadius(center, point);
			
			// ReSharper disable once ConvertIfStatementToReturnStatement
			if (_approximation.Float.EqualTo(radius, 0.0f)) 
				throw new ArithmeticException("Arc radius should be more than 0.0f.");
			
			return new CArc(center, point, angle, angleSign, radius);
		}
		
		public CShape TryCreate(Vector2 center, Vector2 point, float angle)
		{
			var angleSign = GetAngleSign(angle);
			var radius = GetRadius(center, point);
			
			if (_approximation.Float.EqualTo(radius, 0.0f)) return new CPoint(center);
			if (_approximation.Float.EqualTo(angle, 0.0f)) return new CPoint(point);
			if (_approximation.Float.EqualTo(MathF.Abs(angle), 360.0f)) return new CCircle(center, radius);
			
			return new CArc(center, point, angle, angleSign, radius);
		}

		[PublicAPI]
		public CShape ForceCreate(Vector2 center, Vector2 point, float angle)
		{
			var angleSign = GetAngleSign(angle);
			var radius = GetRadius(center, point);
			
			return new CArc(center, point, angle, angleSign, radius);
		}

		private static int GetAngleSign(float angle)
		{
			try
			{
				return MathFUtils.Sign(angle);
			}
			catch (ArithmeticException)
			{
				return 0;
			}
		}

		private static float GetRadius(Vector2 center, Vector2 point)
		{
			return Vector2.Distance(center, point);
		}
	}
}