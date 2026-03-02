using System.Numerics;
using Commons.Equality.CFloat;
using JetBrains.Annotations;

namespace Commons.Equality.CVector3
{
	// TODO: rework
	[PublicAPI]
	public class Vector3Equality
	{
		private readonly FloatEquality _floatEquality;
        
		internal Vector3Equality(FloatEquality floatEquality)
		{
			_floatEquality = floatEquality;
		}
		
		public bool DistanceBetweenVectorsEqual(
			Vector3 vector1,
			Vector3 vector2,
			float distance,
			float tolerance = 0.001f
		)
		{
			var actualDistance = Vector3.Distance(vector1, vector2);
			return actualDistance >= distance - tolerance && actualDistance <= distance + tolerance;
		}

		public bool ClosestPointsOnTwoLines(
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

			if (_floatEquality.EqualTo(d, 0.0f)) return false;

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