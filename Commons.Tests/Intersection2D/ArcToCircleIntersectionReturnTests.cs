using System.Numerics;
using Commons.Intersection2D;
using Commons.Intersection2D.ShapeCreators;

namespace Commons.Tests.Intersection2D;

public class ArcToCircleIntersectionReturnTests
{
	private static IEnumerable<TestCaseData> IsArcToCircleIntersectTestsParameters()
	{
		var args1 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 19.0f), -180.0f, new Vector2(20.0f, 10.0f), 9.0f };
		var args2 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 19.0f), -90.0f, new Vector2(20.0f, 10.0f), 9.0f };
		var args3 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 1.0f), 90.0f, new Vector2(20.0f, 10.0f), 9.0f };
		var args4 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 19.0f), 180.0f, new Vector2(20.0f, 10.0f), 9.0f };
		var args5 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 19.0f), 90.0f, new Vector2(20.0f, 10.0f), 9.0f };
		var args6 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 1.0f), -90.0f, new Vector2(20.0f, 10.0f), 9.0f };
		var args7 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 15.0f), -180.0f, new Vector2(20.0f, 10.0f), 5.0f };
		var args8 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 15.0f), 180.0f, new Vector2(20.0f, 10.0f), 5.0f };
		var args9 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 14.0f), -180.0f, new Vector2(20.0f, 10.0f), 4.0f };
		var args10 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 14.0f), -180.0f, new Vector2(10.0f, 10.0f), 4.0f };
		var args11 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 13.0f), -180.0f, new Vector2(10.0f, 10.0f), 4.0f };
		var args12 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 14.0f), -180.0f, new Vector2(10.0f, 10.0f), 3.0f };
		var args13 = new object?[] { new Vector2(-10.0f, -10.0f), new Vector2(-10.0f, -19.0f), -180.0f, new Vector2(-20.0f, -10.0f), 9.0f };
		var args14 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 19.0f), 360.0f, new Vector2(20.0f, 10.0f), 9.0f };
		var args15 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(5.0f, 10.0f), -180.0f, new Vector2(10.0f, 15.0f), 0.0f };
		var args16 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(5.0f, 10.0f), -180.0f, new Vector2(10.0f, 16.0f), 0.0f };
		var args17 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(5.0f, 10.0f), -180.0f, new Vector2(10.0f, 10.0f), -9.0f };
		var args18 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 15.0f), 0.0f, new Vector2(10.0f, 15.0f), 0.0f };
		var args19 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 15.0f), 0.0f, new Vector2(10.0f, 16.0f), 0.0f };
		var args20 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 10.0f), 0.0f, new Vector2(10.0f, 10.0f), 0.0f };
		var args21 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 10.0f), 0.0f, new Vector2(15.0f, 15.0f), 0.0f };
		var args22 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 10.0f), 180.0f, new Vector2(10.0f, 10.0f), 0.0f };
		var args23 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 19.0f), -540.0f, new Vector2(20.0f, 10.0f), 9.0f };
		
		(bool, Vector2[]) returns1 = (true, [new Vector2(15.0f, 2.516685f), new Vector2(15.0f, 17.483315f)]);
		(bool, Vector2[]) returns2 = (true, [new Vector2(15.0f, 17.483315f)]);
		(bool, Vector2[]) returns3 = (true, [new Vector2(15.0f, 2.516685f)]);
		(bool, Vector2[]) returns4 = (false, []);
		(bool, Vector2[]) returns5 = (true, [new Vector2(15.0f, 10.0f)]);
		(bool, Vector2[]) returns6 = (true, [new Vector2(float.NaN, float.NaN)]);
		(bool, Vector2[]) returns7 = (true, [new Vector2(-15.0f, -2.516685f), new Vector2(-15.0f, -17.483315f)]);
		(bool, Vector2[]) returns8 = (true, [new Vector2(15.0f, 2.516685f), new Vector2(15.0f, 17.483315f)]);
	
		yield return new TestCaseData(args1).Returns(returns1);
		yield return new TestCaseData(args2).Returns(returns2);
		yield return new TestCaseData(args3).Returns(returns3);
		yield return new TestCaseData(args4).Returns(returns4);
		yield return new TestCaseData(args5).Returns(returns4);
		yield return new TestCaseData(args6).Returns(returns4);
		yield return new TestCaseData(args7).Returns(returns5);
		yield return new TestCaseData(args8).Returns(returns4);
		yield return new TestCaseData(args9).Returns(returns4);
		yield return new TestCaseData(args10).Returns(returns6);
		yield return new TestCaseData(args11).Returns(returns4);
		yield return new TestCaseData(args11).Returns(returns4);
		yield return new TestCaseData(args12).Returns(returns4);
		yield return new TestCaseData(args13).Returns(returns7);
		yield return new TestCaseData(args14).Returns(returns8);
		yield return new TestCaseData(args15).Returns(returns4);
		yield return new TestCaseData(args16).Returns(returns4);
		yield return new TestCaseData(args17).Returns(returns4);
		yield return new TestCaseData(args18).Returns(returns4);
		yield return new TestCaseData(args19).Returns(returns4);
		yield return new TestCaseData(args20).Returns(returns4);
		yield return new TestCaseData(args21).Returns(returns4);
		yield return new TestCaseData(args22).Returns(returns4);
		yield return new TestCaseData(args23).Returns(returns1);
	}
	
	[Test, TestCaseSource(nameof(IsArcToCircleIntersectTestsParameters))]
	public (bool, Vector2[]) IsArcToCircleIntersectTests(
		Vector2 arcCenter,
		Vector2 arcPoint, 
		float arcAngleDeg,
		Vector2 circleCenter,
		float circleRadius
	)
	{
		var intersection = new Intersection();
		var arc = ArcCreator.TryCreate(arcCenter, arcPoint, arcAngleDeg);
		var circle = CircleCreator.TryCreate(circleCenter, circleRadius);
		var isIntersect = intersection.IsIntersect(out var intersectionPoints, arc, circle);
		return (isIntersect, intersectionPoints);
	}
	
	private static IEnumerable<TestCaseData> IsArcToCircleIntersectSpecialTestsParameters()
	{
		var argsSpecial1 = new object?[] { new Vector2(float.NaN, 10.0f), new Vector2(10.0f, 19.0f), -180.0f, new Vector2(20.0f, 10.0f), 9.0f };
		var argsSpecial2 = new object?[] { new Vector2(10.0f, float.NaN), new Vector2(10.0f, 19.0f), -180.0f, new Vector2(20.0f, 10.0f), 9.0f };
		var argsSpecial3 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(float.NaN, 19.0f), -180.0f, new Vector2(20.0f, 10.0f), 9.0f };
		var argsSpecial4 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, float.NaN), -180.0f, new Vector2(20.0f, 10.0f), 9.0f };
		var argsSpecial6 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 19.0f), -180.0f, new Vector2(float.NaN, 10.0f), 9.0f };
		var argsSpecial7 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 19.0f), -180.0f, new Vector2(20.0f, float.NaN), 9.0f };
		var argsSpecial8 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 19.0f), -180.0f, new Vector2(20.0f, 10.0f), float.NaN };
		var argsSpecial9 = new object?[] { new Vector2(float.PositiveInfinity, 10.0f), new Vector2(10.0f, 19.0f), -180.0f, new Vector2(20.0f, 10.0f), 9.0f };
		var argsSpecial10 = new object?[] { new Vector2(10.0f, float.PositiveInfinity), new Vector2(10.0f, 19.0f), -180.0f, new Vector2(20.0f, 10.0f), 9.0f };
		var argsSpecial11 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(float.PositiveInfinity, 19.0f), -180.0f, new Vector2(20.0f, 10.0f), 9.0f };
		var argsSpecial12 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, float.PositiveInfinity), -180.0f, new Vector2(20.0f, 10.0f), 9.0f };
		var argsSpecial14 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 19.0f), -180.0f, new Vector2(float.PositiveInfinity, 10.0f), 9.0f };
		var argsSpecial15 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 19.0f), -180.0f, new Vector2(20.0f, float.PositiveInfinity), 9.0f };
		var argsSpecial16 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 19.0f), -180.0f, new Vector2(20.0f, 10.0f), float.PositiveInfinity };
		var argsSpecial17 = new object?[] { new Vector2(float.NegativeInfinity, 10.0f), new Vector2(10.0f, 19.0f), -180.0f, new Vector2(20.0f, 10.0f), 9.0f };
		var argsSpecial18 = new object?[] { new Vector2(10.0f, float.NegativeInfinity), new Vector2(10.0f, 19.0f), -180.0f, new Vector2(20.0f, 10.0f), 9.0f };
		var argsSpecial19 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(float.NegativeInfinity, 19.0f), -180.0f, new Vector2(20.0f, 10.0f), 9.0f };
		var argsSpecial20 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, float.NegativeInfinity), -180.0f, new Vector2(20.0f, 10.0f), 9.0f };
		var argsSpecial22 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 19.0f), -180.0f, new Vector2(float.NegativeInfinity, 10.0f), 9.0f };
		var argsSpecial23 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 19.0f), -180.0f, new Vector2(20.0f, float.NegativeInfinity), 9.0f };
		var argsSpecial24 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 19.0f), -180.0f, new Vector2(20.0f, 10.0f), float.NegativeInfinity };
		var argsSpecial25 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 19.0f), float.NaN, new Vector2(20.0f, 10.0f), 9.0f };
		var argsSpecial26 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 19.0f), float.PositiveInfinity, new Vector2(20.0f, 10.0f), 9.0f };
		var argsSpecial27 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 19.0f), float.NegativeInfinity, new Vector2(20.0f, 10.0f), 9.0f };
	
		yield return new TestCaseData(argsSpecial1);
		yield return new TestCaseData(argsSpecial2);
		yield return new TestCaseData(argsSpecial3);
		yield return new TestCaseData(argsSpecial4);
		yield return new TestCaseData(argsSpecial6);
		yield return new TestCaseData(argsSpecial7);
		yield return new TestCaseData(argsSpecial8);
		yield return new TestCaseData(argsSpecial9);
		yield return new TestCaseData(argsSpecial10);
		yield return new TestCaseData(argsSpecial11);
		yield return new TestCaseData(argsSpecial12);
		yield return new TestCaseData(argsSpecial14);
		yield return new TestCaseData(argsSpecial15);
		yield return new TestCaseData(argsSpecial16);
		yield return new TestCaseData(argsSpecial17);
		yield return new TestCaseData(argsSpecial18);
		yield return new TestCaseData(argsSpecial19);
		yield return new TestCaseData(argsSpecial20);
		yield return new TestCaseData(argsSpecial22);
		yield return new TestCaseData(argsSpecial23);
		yield return new TestCaseData(argsSpecial24);
		yield return new TestCaseData(argsSpecial25);
		yield return new TestCaseData(argsSpecial26);
		yield return new TestCaseData(argsSpecial27);
	}
	
	[Test, TestCaseSource(nameof(IsArcToCircleIntersectSpecialTestsParameters))]
	public void IsArcToCircleIntersectSpecialTests(
		Vector2 arcCenter,
		Vector2 arcPoint, 
		float arcAngleDeg,
		Vector2 circleCenter,
		float circleRadius
	)
	{
		Assert.DoesNotThrow(
			() =>
			{
				var intersection = new Intersection();
				var arc = ArcCreator.TryCreate(arcCenter, arcPoint, arcAngleDeg);
				var circle = CircleCreator.TryCreate(circleCenter, circleRadius);
				intersection.IsIntersect(out _, arc, circle);
			});
	}
}