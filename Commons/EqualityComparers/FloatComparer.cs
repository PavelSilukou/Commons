using System.Collections.Generic;

namespace Commons.EqualityComparers
{
	public class FloatEqualityComparer : IEqualityComparer<float>
	{
		public bool Equals(float x, float y)
		{
			return x.EqualTo(y);
		}

		public int GetHashCode(float obj)
		{
			return obj.GetHashCode();
		}
	}
}