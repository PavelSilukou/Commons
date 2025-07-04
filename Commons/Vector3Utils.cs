using System.Numerics;
using JetBrains.Annotations;

namespace Commons
{
	[PublicAPI]
	public static class Vector3Utils
	{
		public static Vector3 YNormal(Vector3 v1, Vector3 v2, bool clockwise = true)
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

		public static bool DistanceBetweenVectorsEqual(
			Vector3 vector1,
			Vector3 vector2,
			float distance,
			float tolerance
		)
		{
			var actualDistance = Vector3.Distance(vector1, vector2);
			return actualDistance >= distance - tolerance && actualDistance <= distance + tolerance;
		}

		public static bool ClosestPointsOnTwoLines(
			out Vector3? closestPointLine1,
			out Vector3? closestPointLine2,
			Vector3 point1,
			Vector3 point2,
			Vector3 point3,
			Vector3 point4
		)
		{
			var vector1 = point2 - point1;
			var vector2 = point4 - point3;

			closestPointLine1 = null;
			closestPointLine2 = null;

			var a = Vector3.Dot(vector1, vector1);
			var b = Vector3.Dot(point2, vector2);
			var e = Vector3.Dot(vector2, vector2);

			var d = a * e - b * b;

			if (d.EqualTo(0.0f)) return false;

			var r = point1 - point3;
			var c = Vector3.Dot(vector1, r);
			var f = Vector3.Dot(vector2, r);

			var s = (b * f - c * e) / d;
			var t = (a * f - c * b) / d;

			closestPointLine1 = point1 + vector1 * s;
			closestPointLine2 = point3 + vector2 * t;

			return true;
		}
	}
}