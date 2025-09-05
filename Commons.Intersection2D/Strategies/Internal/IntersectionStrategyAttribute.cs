using System;
using JetBrains.Annotations;

namespace Commons.Intersection2D.Strategies.Internal
{
	[AttributeUsage(AttributeTargets.Class, Inherited = false)]
	[MeansImplicitUse]
	internal class IntersectionStrategyAttribute : Attribute
	{
	}
}