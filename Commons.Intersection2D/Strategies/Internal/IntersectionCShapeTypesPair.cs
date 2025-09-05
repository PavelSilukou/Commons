using System;

namespace Commons.Intersection2D.Strategies.Internal
{
	internal class IntersectionCShapeTypesPair
	{
		public Type Type1 { get; }
		public Type Type2 { get; }

		public IntersectionCShapeTypesPair(Type type1, Type type2)
		{
			Type1 = type1;
			Type2 = type2;
		}

		private bool Equals(IntersectionCShapeTypesPair other)
		{
			return Type1 == other.Type1 && Type2 == other.Type2;
		}

		public override bool Equals(object? obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			return obj.GetType() == GetType() && Equals((IntersectionCShapeTypesPair)obj);
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Type1, Type2);
		}
	}
}