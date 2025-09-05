using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Commons.Intersection2D.CShapes;

namespace Commons.Intersection2D.Strategies
{
	internal class IntersectionStrategies
	{
		private readonly Dictionary<IntersectionShapeTypesPair, IIntersectionStrategy> _strategies = InitStrategies();
		
		internal IIntersectionStrategy GetStrategy(CShape shape1, CShape shape2)
		{
			var pair = new IntersectionShapeTypesPair(shape1.GetType(), shape2.GetType());
			var strategy = _strategies.GetValueOrDefault(pair);
			if (strategy != null) return strategy;
			
			strategy = GetStrategyByShapes(shape1, shape2);
			if (strategy == null) {
				throw new IntersectionStrategyException($"There is no strategy for intersection {shape1.GetType().Name} and {shape2.GetType().Name}.");
			}
			
			_strategies.Add(pair, strategy);
			return strategy;
		}

		private static IEnumerable<IIntersectionStrategy> FindAllStrategies()
		{
			var assembly = Assembly.GetExecutingAssembly();
			var classesWithAttribute = assembly.GetTypes()
				.Where(type => type.IsClass && type.GetCustomAttribute<IntersectionStrategyAttribute>() != null);
			foreach (var type in classesWithAttribute)
			{
				yield return (IIntersectionStrategy)Activator.CreateInstance(type);
			}
		}
		
		private static Dictionary<IntersectionShapeTypesPair, IIntersectionStrategy> InitStrategies()
		{
			var strategies = FindAllStrategies();
			var strategiesDict = new Dictionary<IntersectionShapeTypesPair, IIntersectionStrategy>();
			foreach (var strategy in strategies)
			{
				var shapeTypes = strategy.GetShapeTypes();
				strategiesDict.Add(shapeTypes, strategy);
				if (shapeTypes.Type2 != shapeTypes.Type1)
				{
					strategiesDict.Add(new IntersectionShapeTypesPair(shapeTypes.Type2, shapeTypes.Type1), strategy);
				}
			}

			return strategiesDict;
		}

		private IIntersectionStrategy? GetStrategyByShapes(CShape shape1, CShape shape2)
		{
			var shapeTypesPairs = GetAllIntersectionShapeTypePairs(shape1, shape2);
			foreach (var pair in shapeTypesPairs)
			{
				if (_strategies.TryGetValue(pair, out var strategy)) return strategy;
			}
			return null;
		}

		private static IEnumerable<IntersectionShapeTypesPair> GetAllIntersectionShapeTypePairs(CShape shape1, CShape shape2)
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
			} while (type != null && type.IsDefined(typeof(ShapeAttribute), false));
		}
	}
}