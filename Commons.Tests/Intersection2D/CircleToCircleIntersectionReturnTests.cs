using System.Numerics;
using Commons.Intersection2D;
using Commons.Intersection2D.Shapes;

namespace Commons.Tests.Intersection2D;

public class CircleToCircleIntersectionReturnTests
{
	private static IEnumerable<TestCaseData> IsCircleToCircleIntersectTestsParameters()
	{
		var args1 = new object?[] { new Vector2(10.0f, 10.0f), 9.0f, new Vector2(20.0f, 10.0f), 9.0f };
		var args2 = new object?[] { new Vector2(10.0f, 10.0f), 5.0f, new Vector2(20.0f, 10.0f), 5.0f };
		var args3 = new object?[] { new Vector2(10.0f, 10.0f), 4.0f, new Vector2(20.0f, 10.0f), 4.0f };
		var args4 = new object?[] { new Vector2(10.0f, 10.0f), 4.0f, new Vector2(10.0f, 10.0f), 4.0f };
		var args5 = new object?[] { new Vector2(10.0f, 10.0f), 4.0f, new Vector2(10.0f, 10.0f), 3.0f };
		var args6 = new object?[] { new Vector2(10.0f, 10.0f), 3.0f, new Vector2(10.0f, 10.0f), 4.0f };
		var args7 = new object?[] { new Vector2(-10.0f, -10.0f), 9.0f, new Vector2(-20.0f, -10.0f), 9.0f };
		var args8 = new object?[] { new Vector2(10.0f, 10.0f), 5.0f, new Vector2(10.0f, 15.0f), 0.0f };
		var args9 = new object?[] { new Vector2(10.0f, 10.0f), 5.0f, new Vector2(10.0f, 16.0f), 0.0f };
		var args10 = new object?[] { new Vector2(10.0f, 10.0f), -9.0f, new Vector2(10.0f, 10.0f), 9.0f };
		var args11 = new object?[] { new Vector2(10.0f, 10.0f), 9.0f, new Vector2(10.0f, 10.0f), -9.0f };
		var args12 = new object?[] { new Vector2(10.0f, 10.0f), -9.0f, new Vector2(10.0f, 10.0f), -9.0f };
		var args13 = new object?[] { new Vector2(10.0f, 10.0f), 0.0f, new Vector2(10.0f, 10.0f), 0.0f };
		
		(bool, Vector2[]) returns1 = (true, [new Vector2(15.0f, 17.483315f), new Vector2(15.0f, 2.516685f)]);
		(bool, Vector2[]) returns2 = (true, [new Vector2(15.0f, 10.0f)]);
		(bool, Vector2[]) returns3 = (false, []);
		(bool, Vector2[]) returns4 = (true, [new Vector2(float.NaN, float.NaN)]);
		(bool, Vector2[]) returns5 = (true, [new Vector2(-15.0f, -17.483315f), new Vector2(-15.0f, -2.516685f)]);
		
		yield return new TestCaseData(args1).Returns(returns1);
		yield return new TestCaseData(args2).Returns(returns2);
		yield return new TestCaseData(args3).Returns(returns3);
		yield return new TestCaseData(args4).Returns(returns4);
		yield return new TestCaseData(args5).Returns(returns3);
		yield return new TestCaseData(args6).Returns(returns3);
		yield return new TestCaseData(args7).Returns(returns5);
		yield return new TestCaseData(args8).Returns(returns3);
		yield return new TestCaseData(args9).Returns(returns3);
		yield return new TestCaseData(args10).Returns(returns3);
		yield return new TestCaseData(args11).Returns(returns3);
		yield return new TestCaseData(args12).Returns(returns3);
		yield return new TestCaseData(args13).Returns(returns3);
	}
	
	[Test, TestCaseSource(nameof(IsCircleToCircleIntersectTestsParameters))]
	public (bool, Vector2[]) IsCircleToCircleIntersectTests(
		Vector2 center1,
		float radius1,
		Vector2 center2,
		float radius2
	)
	{
		var intersection = new Intersection();
		var circle1 = new CCircle(center1, radius1);
		var circle2 = new CCircle(center2, radius2);
		var isIntersect = intersection.IsIntersect(out var intersectionPoints, circle1, circle2);
		return (isIntersect, intersectionPoints);
	}
	
	private static IEnumerable<TestCaseData> IsCircleToCircleIntersectSpecialTestsParameters()
	{
		var argsSpecial1 = new object?[] { new Vector2(float.NaN, 10.0f), 9.0f, new Vector2(20.0f, 10.0f), 9.0f };
		var argsSpecial2 = new object?[] { new Vector2(10.0f, float.NaN), 9.0f, new Vector2(20.0f, 10.0f), 9.0f };
		var argsSpecial3 = new object?[] { new Vector2(10.0f, 10.0f), float.NaN, new Vector2(20.0f, 10.0f), 9.0f };
		var argsSpecial4 = new object?[] { new Vector2(10.0f, 10.0f), 9.0f, new Vector2(float.NaN, 10.0f), 9.0f };
		var argsSpecial5 = new object?[] { new Vector2(10.0f, 10.0f), 9.0f, new Vector2(20.0f, float.NaN), 9.0f };
		var argsSpecial6 = new object?[] { new Vector2(10.0f, 10.0f), 9.0f, new Vector2(20.0f, 10.0f), float.NaN };
		
		var argsSpecial7 = new object?[] { new Vector2(float.PositiveInfinity, 10.0f), 9.0f, new Vector2(20.0f, 10.0f), 9.0f };
		var argsSpecial8 = new object?[] { new Vector2(10.0f, float.PositiveInfinity), 9.0f, new Vector2(20.0f, 10.0f), 9.0f };
		var argsSpecial9 = new object?[] { new Vector2(10.0f, 10.0f), float.PositiveInfinity, new Vector2(20.0f, 10.0f), 9.0f };
		var argsSpecial10 = new object?[] { new Vector2(10.0f, 10.0f), 9.0f, new Vector2(float.PositiveInfinity, 10.0f), 9.0f };
		var argsSpecial11 = new object?[] { new Vector2(10.0f, 10.0f), 9.0f, new Vector2(20.0f, float.PositiveInfinity), 9.0f };
		var argsSpecial12 = new object?[] { new Vector2(10.0f, 10.0f), 9.0f, new Vector2(20.0f, 10.0f), float.PositiveInfinity };
		
		var argsSpecial13 = new object?[] { new Vector2(float.NegativeInfinity, 10.0f), 9.0f, new Vector2(20.0f, 10.0f), 9.0f };
		var argsSpecial14 = new object?[] { new Vector2(10.0f, float.NegativeInfinity), 9.0f, new Vector2(20.0f, 10.0f), 9.0f };
		var argsSpecial15 = new object?[] { new Vector2(10.0f, 10.0f), float.NegativeInfinity, new Vector2(20.0f, 10.0f), 9.0f };
		var argsSpecial16 = new object?[] { new Vector2(10.0f, 10.0f), 9.0f, new Vector2(float.NegativeInfinity, 10.0f), 9.0f };
		var argsSpecial17 = new object?[] { new Vector2(10.0f, 10.0f), 9.0f, new Vector2(20.0f, float.NegativeInfinity), 9.0f };
		var argsSpecial18 = new object?[] { new Vector2(10.0f, 10.0f), 9.0f, new Vector2(20.0f, 10.0f), float.NegativeInfinity };
		
		yield return new TestCaseData(argsSpecial1);
		yield return new TestCaseData(argsSpecial2);
		yield return new TestCaseData(argsSpecial3);
		yield return new TestCaseData(argsSpecial4);
		yield return new TestCaseData(argsSpecial5);
		yield return new TestCaseData(argsSpecial6);
		yield return new TestCaseData(argsSpecial7);
		yield return new TestCaseData(argsSpecial8);
		yield return new TestCaseData(argsSpecial9);
		yield return new TestCaseData(argsSpecial10);
		yield return new TestCaseData(argsSpecial11);
		yield return new TestCaseData(argsSpecial12);
		yield return new TestCaseData(argsSpecial13);
		yield return new TestCaseData(argsSpecial14);
		yield return new TestCaseData(argsSpecial15);
		yield return new TestCaseData(argsSpecial16);
		yield return new TestCaseData(argsSpecial17);
		yield return new TestCaseData(argsSpecial18);
	}
	
	[Test, TestCaseSource(nameof(IsCircleToCircleIntersectSpecialTestsParameters))]
	public void IsCircleToCircleIntersectSpecial2Tests(
		Vector2 center1,
		float radius1,
		Vector2 center2,
		float radius2
	)
	{
		Assert.DoesNotThrow(
			() =>
			{
				var intersection = new Intersection();
				var circle1 = new CCircle(center1, radius1);
				var circle2 = new CCircle(center2, radius2);
				intersection.IsIntersect(out _, circle1, circle2);
			});
	}
}