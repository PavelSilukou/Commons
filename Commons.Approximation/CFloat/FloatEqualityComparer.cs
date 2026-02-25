using System.Collections.Generic;

namespace Commons.Approximation.CFloat
{
	public class FloatEqualityComparer : IEqualityComparer<float>
	{
		private readonly FloatApproximation _floatApproximation;
		
		internal FloatEqualityComparer(FloatApproximation floatApproximation)
		{
			_floatApproximation = floatApproximation;
		}
		
		public bool Equals(float x, float y)
		{
			return _floatApproximation.EqualTo(x, y);
		}

		public int GetHashCode(float obj)
		{
			return obj.GetHashCode();
		}
	}
}