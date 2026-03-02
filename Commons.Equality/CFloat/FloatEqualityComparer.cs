using System.Collections.Generic;

namespace Commons.Equality.CFloat
{
	public class FloatEqualityComparer : IEqualityComparer<float>
	{
		private readonly FloatEquality _floatEquality;
		
		internal FloatEqualityComparer(FloatEquality floatEquality)
		{
			_floatEquality = floatEquality;
		}
		
		public bool Equals(float x, float y)
		{
			return _floatEquality.EqualTo(x, y);
		}

		public int GetHashCode(float obj)
		{
			return obj.GetHashCode();
		}
	}
}