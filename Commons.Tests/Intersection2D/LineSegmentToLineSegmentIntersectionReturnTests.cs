using System.Numerics;
using Commons.Intersection2D;
using CShapes = Commons.Intersection2D.Shapes;

namespace Commons.Tests.Intersection2D;

public class LineSegmentToLineSegmentIntersectionReturnTests
{
	private static IEnumerable<TestCaseData> IsLineSegmentToLineSegmentIntersectTestsParameters()
	{
		var args1 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(20.0f, 20.0f), new Vector2(10.0f, 20.0f), new Vector2(20.0f, 10.0f) };
		var args2 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(20.0f, 20.0f), new Vector2(50.0f, 10.0f), new Vector2(40.0f, 20.0f) };
		var args3 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 20.0f), new Vector2(30.0f, 10.0f), new Vector2(30.0f, 20.0f) };
		var args4 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(20.0f, 20.0f), new Vector2(10.0f, 0.0f), new Vector2(40.0f, 30.0f) };
		var args5 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(20.0f, 20.0f), new Vector2(20.0f, 20.0f), new Vector2(30.0f, 30.0f) };
		var args6 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(20.0f, 20.0f), new Vector2(30.0f, 30.0f), new Vector2(20.0f, 20.0f) };
		var args7 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(20.0f, 20.0f), new Vector2(10.0f, 10.0f), new Vector2(0.0f, 0.0f) };
		var args8 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(20.0f, 20.0f), new Vector2(0.0f, 0.0f), new Vector2(10.0f, 10.0f) };
		var args9 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(20.0f, 20.0f), new Vector2(30.0f, 30.0f), new Vector2(40.0f, 40.0f) };
		var args10 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(20.0f, 20.0f), new Vector2(15.0f, 15.0f), new Vector2(25.0f, 25.0f) };
		var args11 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(20.0f, 20.0f), new Vector2(20.0f, 20.0f), new Vector2(5.0f, 5.0f) };
		var args12 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(20.0f, 20.0f), new Vector2(0.0f, 0.0f), new Vector2(30.0f, 30.0f) };
		var args13 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(20.0f, 20.0f), new Vector2(20.0f, 20.0f), new Vector2(30.0f, 10.0f) };
		var args14 = new object?[] { new Vector2(-10.0f, -10.0f), new Vector2(20.0f, 20.0f), new Vector2(10.0f, 20.0f), new Vector2(20.0f, 10.0f) };
		var args15 = new object?[] { new Vector2(-10.0f, -10.0f), new Vector2(-20.0f, -20.0f), new Vector2(10.0f, 20.0f), new Vector2(20.0f, 10.0f) };
		var args16 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(20.0f, 20.0f), new Vector2(10.0f, 20.0f), new Vector2(50.0f, -20.0f) };
		var args17 = new object?[] { new Vector2(-10.0f, -10.0f), new Vector2(-20.0f, -20.0f), new Vector2(-10.0f, -20.0f), new Vector2(-20.0f, -10.0f) };
		var args18 = new object?[] { new Vector2(20.0f, 20.0f), new Vector2(20.0f, 20.0f), new Vector2(10.0f, 10.0f), new Vector2(30.0f, 30.0f) };
		var args19 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(30.0f, 30.0f), new Vector2(20.0f, 20.0f), new Vector2(20.0f, 20.0f) };
		var args20 = new object?[] { new Vector2(20.0f, 20.0f), new Vector2(20.0f, 20.0f), new Vector2(20.0f, 10.0f), new Vector2(40.0f, 30.0f) };
		var args21 = new object?[] { new Vector2(20.0f, 10.0f), new Vector2(40.0f, 30.0f), new Vector2(20.0f, 20.0f), new Vector2(20.0f, 20.0f) };
		var args22 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(20.0f, 20.0f), new Vector2(20.0f, 20.0f), new Vector2(20.0f, 20.0f) };
		var args23 = new object?[] { new Vector2(20.0f, 20.0f), new Vector2(20.0f, 20.0f), new Vector2(10.0f, 10.0f), new Vector2(20.0f, 20.0f) };
		
		(bool, Vector2[]) returns1 = (true, [new Vector2(15.0f, 15.0f)]);
		(bool, Vector2[]) returns2 = (false, []);
		(bool, Vector2[]) returns3 = (true, [new Vector2(float.NaN, float.NaN)]);
		(bool, Vector2[]) returns4 = (true, [new Vector2(20.0f, 20.0f)]);
		(bool, Vector2[]) returns5 = (true, [new Vector2(10.0f, 10.0f)]);
		(bool, Vector2[]) returns6 = (true, [new Vector2(-15.0f, -15.0f)]);
		
		yield return new TestCaseData(args1).Returns(returns1);
		yield return new TestCaseData(args2).Returns(returns2);
		yield return new TestCaseData(args3).Returns(returns2);
		yield return new TestCaseData(args4).Returns(returns2);
		yield return new TestCaseData(args5).Returns(returns4);
		yield return new TestCaseData(args6).Returns(returns4);
		yield return new TestCaseData(args7).Returns(returns5);
		yield return new TestCaseData(args8).Returns(returns5);
		yield return new TestCaseData(args9).Returns(returns2);
		yield return new TestCaseData(args10).Returns(returns3);
		yield return new TestCaseData(args11).Returns(returns3);
		yield return new TestCaseData(args12).Returns(returns3);
		yield return new TestCaseData(args13).Returns(returns4);
		yield return new TestCaseData(args14).Returns(returns1);
		yield return new TestCaseData(args15).Returns(returns2);
		yield return new TestCaseData(args16).Returns(returns1);
		yield return new TestCaseData(args17).Returns(returns6);
		yield return new TestCaseData(args18).Returns(returns2);
		yield return new TestCaseData(args19).Returns(returns2);
		yield return new TestCaseData(args20).Returns(returns2);
		yield return new TestCaseData(args21).Returns(returns2);
		yield return new TestCaseData(args22).Returns(returns2);
		yield return new TestCaseData(args23).Returns(returns2);
	}
	
	[Test, TestCaseSource(nameof(IsLineSegmentToLineSegmentIntersectTestsParameters))]
	public (bool, Vector2[]) IsLineSegmentToLineSegmentIntersectTests(
		Vector2 point1,
		Vector2 point2,
		Vector2 point3,
		Vector2 point4
	)
	{
		var intersection = new Intersection();
		var lineSegment1 = CShapes.TryCreateLineSegment(point1, point2);
		var lineSegment2 = CShapes.TryCreateLineSegment(point3, point4);
		var isIntersect = intersection.IsIntersect(out var intersectionPoints, lineSegment1, lineSegment2);
		return (isIntersect, intersectionPoints);
	}
	
	private static IEnumerable<TestCaseData> IsLineSegmentToLineSegmentIntersectSpecialTestsParameters()
	{
		var argsSpecial1 = new object?[] { new Vector2(float.NaN, 10.0f), new Vector2(20.0f, 20.0f), new Vector2(10.0f, 20.0f), new Vector2(20.0f, 10.0f) };
		var argsSpecial2 = new object?[] { new Vector2(10.0f, float.NaN), new Vector2(20.0f, 20.0f), new Vector2(10.0f, 20.0f), new Vector2(20.0f, 10.0f) };
		var argsSpecial3 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(float.NaN, 20.0f), new Vector2(10.0f, 20.0f), new Vector2(20.0f, 10.0f) };
		var argsSpecial4 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(20.0f, float.NaN), new Vector2(10.0f, 20.0f), new Vector2(20.0f, 10.0f) };
		var argsSpecial5 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(20.0f, 20.0f), new Vector2(float.NaN, 20.0f), new Vector2(20.0f, 10.0f) };
		var argsSpecial6 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(20.0f, 20.0f), new Vector2(10.0f, float.NaN), new Vector2(20.0f, 10.0f) };
		var argsSpecial7 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(20.0f, 20.0f), new Vector2(10.0f, 20.0f), new Vector2(float.NaN, 10.0f) };
		var argsSpecial8 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(20.0f, 20.0f), new Vector2(10.0f, 20.0f), new Vector2(20.0f, float.NaN) };
		var argsSpecial9 = new object?[] { new Vector2(float.PositiveInfinity, 10.0f), new Vector2(20.0f, 20.0f), new Vector2(10.0f, 20.0f), new Vector2(20.0f, 10.0f) };
		var argsSpecial10 = new object?[] { new Vector2(10.0f, float.PositiveInfinity), new Vector2(20.0f, 20.0f), new Vector2(10.0f, 20.0f), new Vector2(20.0f, 10.0f) };
		var argsSpecial11 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(float.PositiveInfinity, 20.0f), new Vector2(10.0f, 20.0f), new Vector2(20.0f, 10.0f) };
		var argsSpecial12 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(20.0f, float.PositiveInfinity), new Vector2(10.0f, 20.0f), new Vector2(20.0f, 10.0f) };
		var argsSpecial13 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(20.0f, 20.0f), new Vector2(float.PositiveInfinity, 20.0f), new Vector2(20.0f, 10.0f) };
		var argsSpecial14 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(20.0f, 20.0f), new Vector2(10.0f, float.PositiveInfinity), new Vector2(20.0f, 10.0f) };
		var argsSpecial15 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(20.0f, 20.0f), new Vector2(10.0f, 20.0f), new Vector2(float.PositiveInfinity, 10.0f) };
		var argsSpecial16 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(20.0f, 20.0f), new Vector2(10.0f, 20.0f), new Vector2(20.0f, float.PositiveInfinity) };
		var argsSpecial17 = new object?[] { new Vector2(float.NegativeInfinity, 10.0f), new Vector2(20.0f, 20.0f), new Vector2(10.0f, 20.0f), new Vector2(20.0f, 10.0f) };
		var argsSpecial18 = new object?[] { new Vector2(10.0f, float.NegativeInfinity), new Vector2(20.0f, 20.0f), new Vector2(10.0f, 20.0f), new Vector2(20.0f, 10.0f) };
		var argsSpecial19 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(float.NegativeInfinity, 20.0f), new Vector2(10.0f, 20.0f), new Vector2(20.0f, 10.0f) };
		var argsSpecial20 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(20.0f, float.NegativeInfinity), new Vector2(10.0f, 20.0f), new Vector2(20.0f, 10.0f) };
		var argsSpecial21 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(20.0f, 20.0f), new Vector2(float.NegativeInfinity, 20.0f), new Vector2(20.0f, 10.0f) };
		var argsSpecial22 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(20.0f, 20.0f), new Vector2(10.0f, float.NegativeInfinity), new Vector2(20.0f, 10.0f) };
		var argsSpecial23 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(20.0f, 20.0f), new Vector2(10.0f, 20.0f), new Vector2(float.NegativeInfinity, 10.0f) };
		var argsSpecial24 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(20.0f, 20.0f), new Vector2(10.0f, 20.0f), new Vector2(20.0f, float.NegativeInfinity) };
		
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
		yield return new TestCaseData(argsSpecial19);
		yield return new TestCaseData(argsSpecial20);
		yield return new TestCaseData(argsSpecial21);
		yield return new TestCaseData(argsSpecial22);
		yield return new TestCaseData(argsSpecial23);
		yield return new TestCaseData(argsSpecial24);
	}
	
	[Test, TestCaseSource(nameof(IsLineSegmentToLineSegmentIntersectSpecialTestsParameters))]
	public void IsLineSegmentToLineSegmentIntersectSpecialTests(
		Vector2 point1,
		Vector2 point2,
		Vector2 point3,
		Vector2 point4
	)
	{
		Assert.DoesNotThrow(
			() =>
			{
				var intersection = new Intersection();
				var lineSegment1 = CShapes.TryCreateLineSegment(point1, point2);
				var lineSegment2 = CShapes.TryCreateLineSegment(point3, point4);
				intersection.IsIntersect(out _, lineSegment1, lineSegment2);
			});
	}
}