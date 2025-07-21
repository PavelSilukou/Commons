using System;
using System.Numerics;
using Commons.Intersection2D.Internal.Forms;

namespace Commons.Intersection2D.Internal
{
	internal static class Validator
	{
		public static bool IsValid(Form form1, Form form2)
		{
			return form1.IsValid() && form2.IsValid();
		}

		public static bool IsValid(out Vector2[] intersectionPoints, Form form1, Form form2)
		{
			intersectionPoints = Array.Empty<Vector2>();
			return form1.IsValid() && form2.IsValid();
		}
	}
}