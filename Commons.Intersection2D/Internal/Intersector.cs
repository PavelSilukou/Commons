using System;
using System.Collections.Generic;
using System.Numerics;
using Commons.Intersection2D.Internal.Forms;
using Commons.Intersection2D.Internal.IntersectionStrategies;

namespace Commons.Intersection2D.Internal
{
	internal static class Intersector
	{
		private static readonly IIntersectionStrategy[] Strategies =
		{
			new LineToLineIntersectionStrategy(),
			new LineSegmentToLineSegmentIntersectionStrategy(),
			new CircleToCircleIntersectionStrategy(),
			new ArcToCircleIntersectionStrategy(),
			new ArcToArcIntersectionStrategy(),
			new RectangleToRectangleIntersectionStrategy(),
			new RotatedRectangleToRotatedRectangleIntersectionStrategy(),
			new LineSegmentToQuadrilateralIntersectionStrategy(),
			new QuadrilateralToQuadrilateralIntersectionStrategy(),
			new PointToAnyIntersectionStrategy()
		};
		private static readonly Dictionary<FormTypesPair, StrategyOrder> StrategiesDict = InitStrategiesDict();
		
		public static bool IsIntersect(Form form1, Form form2, bool validate = true)
		{
			if (validate)
			{
				form1.IsValid();
				form2.IsValid();
			}
			
			var trueForm1 = form1.GetTrueForm();
			var trueForm2 = form2.GetTrueForm();
			
			var strategyOrder = GetStrategy(trueForm1, trueForm2);
			if (strategyOrder.Order)
			{
				return strategyOrder.Strategy.IsIntersect(trueForm2, trueForm1);
			}
			return strategyOrder.Strategy.IsIntersect(trueForm1, trueForm2);
		}
		
		public static bool IsIntersect(out Vector2[] intersectionPoints, Form form1, Form form2, bool validate = true)
		{
			if (validate)
			{
				form1.IsValid();
				form2.IsValid();
			}
			
			var trueForm1 = form1.GetTrueForm();
			var trueForm2 = form2.GetTrueForm();
			
			var strategyOrder = GetStrategy(trueForm1, trueForm2);
			if (strategyOrder.Order)
			{
				return strategyOrder.Strategy.IsIntersect(out intersectionPoints, trueForm2, trueForm1);
			}
			return strategyOrder.Strategy.IsIntersect(out intersectionPoints, trueForm1, trueForm2);
		}

		private static Dictionary<FormTypesPair, StrategyOrder> InitStrategiesDict()
		{
			var strategiesDict = new Dictionary<FormTypesPair, StrategyOrder>();
			foreach (var strategy in Strategies)
			{
				var formTypes = strategy.GetFormTypes();
				foreach (var types in formTypes)
				{
					strategiesDict.Add(types, new StrategyOrder(strategy, false));
					if (types.Type1 != types.Type2)
					{
						var order = new StrategyOrder(strategy, true);
						strategiesDict.Add(new FormTypesPair(types.Type2, types.Type1), order);
					}
				}
			}

			return strategiesDict;
		}

		private static StrategyOrder GetStrategy(Form trueForm1, Form trueForm2)
		{
			var trueFormType1 = trueForm1.GetType();
			var trueFormType2 = trueForm2.GetType();
			var formTypesPair = new FormTypesPair(trueFormType1, trueFormType2);

			if (!StrategiesDict.TryGetValue(formTypesPair, out var targetStrategy))
			{
				throw new ArgumentException($"There is no strategy for intersection {trueFormType1.Name} and {trueFormType2.Name}.");
			}
			
			return targetStrategy;
		}
		
		private sealed class StrategyOrder
		{
			public IIntersectionStrategy Strategy { get; }
			public bool Order { get; }

			public StrategyOrder(IIntersectionStrategy strategy, bool order)
			{
				Strategy = strategy;
				Order = order;
			}
		}
	}
}