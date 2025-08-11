using System;

namespace Commons.Intersection2D.Shapes
{
	public abstract class CShape
	{
		private CShape? _trueShape;

		public void Validate()
		{
			Validation();
			CheckTrueShape();
		}
		
		public CShape GetTrueShape()
		{
			if (_trueShape != null) return _trueShape;
			_trueShape = OverrideTrueShape();
			return _trueShape;
		}
		
		protected virtual void Validation() {}

		protected virtual CShape OverrideTrueShape()
		{
			return this;
		}

		private void CheckTrueShape()
		{
			var trueShape = GetTrueShape();
			if (trueShape.GetType() != GetType()) throw new ArithmeticException($"Values form a {trueShape.GetType().Name}, not a {GetType().Name}.");
		}
	}
}