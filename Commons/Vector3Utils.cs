using System.Numerics;
using JetBrains.Annotations;

namespace Commons
{
	[PublicAPI]
	public class Vector3Utils
	{
		public Vector3 YNormal(Vector3 v1, Vector3 v2, bool clockwise = true)
		{
			var temp = v1 - v2;
			if (clockwise)
			{
				temp = new Vector3(-temp.Z, 0.0f, temp.X);
				return Vector3.Normalize(temp);
			}

			temp = new Vector3(temp.Z, 0.0f, -temp.X);
			return Vector3.Normalize(temp);
		}
	}
}