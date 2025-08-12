using System;
using JetBrains.Annotations;

namespace Commons.Intersection2D.Shapes
{
	[AttributeUsage(AttributeTargets.Class, Inherited = false)]
	[MeansImplicitUse]
	internal class ShapeAttribute : Attribute
	{
	}
}