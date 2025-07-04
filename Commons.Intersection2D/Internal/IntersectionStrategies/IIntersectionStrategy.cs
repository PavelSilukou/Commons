using System.Numerics;
using Commons.Intersection2D.Internal.Forms;

namespace Commons.Intersection2D.Internal.IntersectionStrategies
{
	internal interface IIntersectionStrategy
	{
		public FormTypesPair[] GetFormTypes();
		bool IsIntersect(Form form1, Form form2);
		bool IsIntersect(out Vector2[] intersectionPoints, Form form1, Form form2);
	}
}