using System.Numerics;
using Commons.Intersection2D.Internal.Forms;

namespace Commons.Intersection2D.Internal.IntersectionStrategies
{
	internal abstract class IntersectionStrategy<T1, T2>: IIntersectionStrategy 
		where T1: Form 
		where T2: Form
	{
		public abstract FormTypesPair[] GetFormTypes();

		bool IIntersectionStrategy.IsIntersect(Form form1, Form form2)
		{
			return IsIntersect((T1)form1, (T2)form2);
		}

		bool IIntersectionStrategy.IsIntersect(out Vector2[] intersectionPoints, Form form1, Form form2)
		{
			return IsIntersect(out intersectionPoints, (T1)form1, (T2)form2);
		}

		protected abstract bool IsIntersect(T1 form1, T2 form2);
		protected abstract bool IsIntersect(out Vector2[] intersectionPoints, T1 form1, T2 form2);
	}
}