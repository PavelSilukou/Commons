using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Commons.Intersection2D.CShapes;
using Commons.Intersection2D.CShapes.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace Commons.Intersection2D.Strategies.Internal
{
	internal class IntersectionStrategies
	{
		private readonly Dictionary<IntersectionCShapeTypesPair, IIntersectionStrategy> _strategies;
		
		internal IntersectionStrategies(Approximation.Approximation approximation)
		{
			_strategies = InitStrategies(approximation);
		}
		
		internal IIntersectionStrategy GetStrategy(CShape shape1, CShape shape2)
		{
			var shape1Type = shape1.GetType();
			var shape2Type = shape2.GetType();
			
			return GetStrategy(shape1Type, shape2Type);
		}
		
		private static IEnumerable<IntersectionCShapeTypesPair> GetIntersectionCShapeTypesPairs()
		{
			var assembly = Assembly.GetExecutingAssembly();
			var types = assembly.GetTypes()
				.Where(type =>
					type.IsClass && type.GetCustomAttribute<CShapeAttribute>() != null && type != typeof(CShape)).ToList();
			return types
				.GetAllPairs()
				.Select(pair => new IntersectionCShapeTypesPair(pair.Element1, pair.Element2))
				.Concat(types.Zip(types, (a, b) => new IntersectionCShapeTypesPair(a, b)));
		}
		
		internal IEnumerable<IntersectionCShapeTypesPair> CanIntersect()
		{
			return GetIntersectionCShapeTypesPairs()
				.Where(pair =>
				{
					try
					{
						GetStrategy(pair.Type1, pair.Type2);
						return true;
					}
					catch (Exception)
					{
						return false;
					}
				});
		}
		
		internal IEnumerable<IntersectionCShapeTypesPair> CannotIntersect()
		{
			return GetIntersectionCShapeTypesPairs()
				.Where(pair =>
				{
					try
					{
						GetStrategy(pair.Type1, pair.Type2);
						return false;
					}
					catch (Exception)
					{
						return true;
					}
				});
		}
		
		private IIntersectionStrategy GetStrategy(Type shape1Type, Type shape2Type)
		{
			var pair = new IntersectionCShapeTypesPair(shape1Type, shape2Type);
			var strategy = _strategies.GetValueOrDefault(pair);
			if (strategy != null) return strategy;
			
			strategy = GetStrategyByShapes(shape1Type, shape2Type);
			if (strategy == null)
				throw new IntersectionStrategyException($"There is no strategy for intersection {shape1Type.Name} and {shape2Type.Name}.");
			
			_strategies.Add(pair, strategy);
			return strategy;
		}

		private static IEnumerable<IIntersectionStrategy> FindAllStrategies(Approximation.Approximation approximation)
		{
			var services = new ServiceCollection();
			services.AddSingleton(approximation);
			
			var assembly = Assembly.GetExecutingAssembly();
			var types = assembly
				.GetTypes()
				.Where(type => type.IsClass && type.GetCustomAttribute<IntersectionStrategyAttribute>() != null);
			
			foreach (var type in types)
			{
				services.AddSingleton(type, type);
				
				var interfaces = type.GetInterfaces();
				foreach (var i in interfaces)
				{
					services.AddSingleton(i, x => x.GetService(type));
				}
			}
			
			using var serviceProvider = services.BuildServiceProvider();
			return serviceProvider.GetServices<IIntersectionStrategy>();
		}
		
		private static Dictionary<IntersectionCShapeTypesPair, IIntersectionStrategy> InitStrategies(Approximation.Approximation approximation)
		{
			var strategies = FindAllStrategies(approximation);
			var strategiesDict = new Dictionary<IntersectionCShapeTypesPair, IIntersectionStrategy>();
			foreach (var strategy in strategies)
			{
				var shapeTypes = strategy.GetShapeTypes();
				strategiesDict.Add(shapeTypes, strategy);
				if (shapeTypes.Type2 != shapeTypes.Type1)
				{
					strategiesDict.Add(new IntersectionCShapeTypesPair(shapeTypes.Type2, shapeTypes.Type1), strategy);
				}
			}

			return strategiesDict;
		}

		private IIntersectionStrategy? GetStrategyByShapes(Type shapeType1, Type shapeType2)
		{
			var shapeTypesPairs = GetAllIntersectionShapeTypePairs(shapeType1, shapeType2);
			foreach (var pair in shapeTypesPairs)
			{
				if (_strategies.TryGetValue(pair, out var strategy)) return strategy;
			}
			return null;
		}

		private static IEnumerable<IntersectionCShapeTypesPair> GetAllIntersectionShapeTypePairs(Type shape1Type, Type shape2Type)
		{
			var shape1Types = GetShapeTypes(shape1Type);
			var shape2Types = GetShapeTypes(shape2Type);
			return shape1Types.GetAllPairs(shape2Types).Select(tuple => new IntersectionCShapeTypesPair(tuple.Element1, tuple.Element2));
		}

		private static IEnumerable<Type> GetShapeTypes(Type? type)
		{
			while (type != null && type.IsDefined(typeof(CShapeAttribute), false))
			{
				yield return type;
				type = type.BaseType;
			}
		}
	}
}