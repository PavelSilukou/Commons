using System;
using System.Numerics;

namespace Commons
{
	public static class Intersection3DUtils
	{
		public static bool IsLineToLineIntersect(
			out Vector3? intersectionPoint,
			Vector3 point1,
			Vector3 point2,
			Vector3 point3,
			Vector3 point4
		)
		{
			intersectionPoint = null;

			var vector1 = point2 - point1;
			var vector2 = point4 - point3;
			var vector3 = point3 - point1;
			var crossVector1AndVector2 = Vector3.Cross(vector1, vector2);
			var crossVector3AndVector2 = Vector3.Cross(vector3, vector2);

			var planarFactor = Vector3.Dot(vector3, crossVector1AndVector2);
			if (MathF.Abs(planarFactor) >= 0.0001f || crossVector1AndVector2.LengthSquared() <= 0.0001f) return false;
			
			var s = Vector3.Dot(crossVector3AndVector2, crossVector1AndVector2) / crossVector1AndVector2.LengthSquared();
			intersectionPoint = point1 + vector1 * s;
			return true;
		}
		
		public static bool IsLineSegmentToLineSegmentIntersect(
			out Vector3? intersectionPoint,
			Vector3 point1,
			Vector3 point2,
			Vector3 point3,
			Vector3 point4
		)
		{
			intersectionPoint = null;

			var intersection = IsLineToLineIntersect(
				out var lineIntersectionPoint,
				point1,
				point2,
				point3,
				point4
			);

			if (!intersection || lineIntersectionPoint == null)
			{
				return false;
			}

			var vector1 = point2 - point1;
			var vector2 = point4 - point3;
			var vector1SqrMagnitude = vector1.LengthSquared();
			var vector2SqrMagnitude = vector2.LengthSquared();

			if ((lineIntersectionPoint - point1).Value.LengthSquared() > vector1SqrMagnitude
			    || (lineIntersectionPoint - point2).Value.LengthSquared() > vector1SqrMagnitude
			    || (lineIntersectionPoint - point3).Value.LengthSquared() > vector2SqrMagnitude
			    || (lineIntersectionPoint - point4).Value.LengthSquared() > vector2SqrMagnitude)
			{
				return false;
			}
			
			intersectionPoint = lineIntersectionPoint;
			return true;
		}
	}
}