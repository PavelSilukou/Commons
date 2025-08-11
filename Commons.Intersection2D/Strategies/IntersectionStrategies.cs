using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Commons.Intersection2D.Shapes;

namespace Commons.Intersection2D.Strategies
{
	public class IntersectionStrategies
	{
		private readonly Dictionary<IntersectionShapeTypesPair, IIntersectionStrategy> _strategies = InitStrategies();
		
		internal IIntersectionStrategy GetStrategy(CShape shape1, CShape shape2)
		{
			var strategy = GetStrategyByShapes(shape1, shape2);
			if (strategy != null) return strategy;
			throw new IntersectionStrategyException($"There is no strategy for intersection {shape1.GetType().Name} and {shape2.GetType().Name}.");
		}

		private static IEnumerable<IIntersectionStrategy> FindStrategies()
		{
			var assembly = Assembly.GetExecutingAssembly();
			var classesWithAttribute = assembly.GetTypes()
				.Where(type => type.IsClass && type.GetCustomAttribute<StrategyAttribute>() != null);
			foreach (var type in classesWithAttribute)
			{
				yield return (IIntersectionStrategy)Activator.CreateInstance(type);
			}
		}
		
		private static Dictionary<IntersectionShapeTypesPair, IIntersectionStrategy> InitStrategies()
		{
			var strategies = FindStrategies();
			var strategiesDict = new Dictionary<IntersectionShapeTypesPair, IIntersectionStrategy>();
			foreach (var strategy in strategies)
			{
				var shapeTypes = strategy.GetShapeTypes();
				foreach (var types in shapeTypes)
				{
					strategiesDict.Add(types, strategy);
				}
			}

			return strategiesDict;
		}

		private IIntersectionStrategy? GetStrategyByShapes(CShape shape1, CShape shape2)
		{
			var shapeTypesPairs = GetAllIntersectionShapeTypesPairs(shape1, shape2);
			foreach (var pair in shapeTypesPairs)
			{
				if (_strategies.TryGetValue(pair, out var strategy)) return strategy;
			}
			return null;
		}

		private static IEnumerable<IntersectionShapeTypesPair> GetAllIntersectionShapeTypesPairs(CShape shape1, CShape shape2)
		{
			var shape1Types = GetShapeTypes(shape1);
			var shape2Types = GetShapeTypes(shape2);
			return shape1Types.GetAllPairs(shape2Types).Select(tuple => new IntersectionShapeTypesPair(tuple.Item1, tuple.Item2));
		}

		private static IEnumerable<Type> GetShapeTypes(CShape shape)
		{
			var type = shape.GetType();
			do
			{
				yield return type;
				type = type.BaseType;
			} while (type != null);
		}
	}
}