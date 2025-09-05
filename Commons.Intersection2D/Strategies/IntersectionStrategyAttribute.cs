using System;
using JetBrains.Annotations;

namespace Commons.Intersection2D.Strategies
{
	[AttributeUsage(AttributeTargets.Class, Inherited = false)]
	[MeansImplicitUse]
	internal class IntersectionStrategyAttribute : Attribute
	{
	}
}