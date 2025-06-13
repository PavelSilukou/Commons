using System.Numerics;
using Commons.Math2D;

namespace Commons.Tests.Intersection.D2;

public partial class Intersection2DUtilsTests
{
	private static IEnumerable<TestCaseData> IsCircleToCircleIntersectTestsParameters()
	{
		var args1 = new object?[] { new Vector2(10.0f, 10.0f), 9.0f, new Vector2(20.0f, 10.0f), 9.0f };
		var args2 = new object?[] { new Vector2(10.0f, 10.0f), 5.0f, new Vector2(20.0f, 10.0f), 5.0f };
		var args3 = new object?[] { new Vector2(10.0f, 10.0f), 4.0f, new Vector2(20.0f, 10.0f), 4.0f };
		var args4 = new object?[] { new Vector2(10.0f, 10.0f), 4.0f, new Vector2(10.0f, 10.0f), 4.0f };
		var args5 = new object?[] { new Vector2(10.0f, 10.0f), 4.0f, new Vector2(10.0f, 10.0f), 3.0f };
		var args6 = new object?[] { new Vector2(10.0f, 10.0f), 3.0f, new Vector2(10.0f, 10.0f), 4.0f };
		var args7 = new object?[] { new Vector2(10.0f, 10.0f), 5.0f, new Vector2(10.0f, 15.0f), 0.0f };
		var args8 = new object?[] { new Vector2(10.0f, 10.0f), 5.0f, new Vector2(10.0f, 16.0f), 0.0f };
		var args9 = new object?[] { new Vector2(10.0f, 10.0f), -9.0f, new Vector2(10.0f, 10.0f), 9.0f };
		var args10 = new object?[] { new Vector2(10.0f, 10.0f), 9.0f, new Vector2(10.0f, 10.0f), -9.0f };
		var args11 = new object?[] { new Vector2(10.0f, 10.0f), -9.0f, new Vector2(10.0f, 10.0f), -9.0f };
		var args12 = new object?[] { new Vector2(10.0f, 10.0f), 0.0f, new Vector2(10.0f, 10.0f), 0.0f };
		var args13 = new object?[] { new Vector2(-10.0f, -10.0f), 9.0f, new Vector2(-20.0f, -10.0f), 9.0f };
		
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
		
		yield return new TestCaseData(args1).Returns(true);
		yield return new TestCaseData(args2).Returns(true);
		yield return new TestCaseData(args3).Returns(false);
		yield return new TestCaseData(args4).Returns(true);
		yield return new TestCaseData(args5).Returns(false);
		yield return new TestCaseData(args6).Returns(false);
		yield return new TestCaseData(args7).Returns(false);
		yield return new TestCaseData(args8).Returns(false);
		yield return new TestCaseData(args9).Returns(false);
		yield return new TestCaseData(args10).Returns(false);
		yield return new TestCaseData(args11).Returns(false);
		yield return new TestCaseData(args12).Returns(false);
		yield return new TestCaseData(args13).Returns(true);
		
		yield return new TestCaseData(argsSpecial1).Returns(false);
		yield return new TestCaseData(argsSpecial2).Returns(false);
		yield return new TestCaseData(argsSpecial3).Returns(false);
		yield return new TestCaseData(argsSpecial4).Returns(false);
		yield return new TestCaseData(argsSpecial5).Returns(false);
		yield return new TestCaseData(argsSpecial6).Returns(false);
		yield return new TestCaseData(argsSpecial7).Returns(false);
		yield return new TestCaseData(argsSpecial8).Returns(false);
		yield return new TestCaseData(argsSpecial9).Returns(false);
		yield return new TestCaseData(argsSpecial10).Returns(false);
		yield return new TestCaseData(argsSpecial11).Returns(false);
		yield return new TestCaseData(argsSpecial12).Returns(false);
		yield return new TestCaseData(argsSpecial13).Returns(false);
		yield return new TestCaseData(argsSpecial14).Returns(false);
		yield return new TestCaseData(argsSpecial15).Returns(false);
		yield return new TestCaseData(argsSpecial16).Returns(false);
		yield return new TestCaseData(argsSpecial17).Returns(false);
		yield return new TestCaseData(argsSpecial18).Returns(false);
	}
	
	[Test, TestCaseSource(nameof(IsCircleToCircleIntersectTestsParameters))]
	public bool IsCircleToCircleIntersectTests(
		Vector2 center1,
		float radius1,
		Vector2 center2,
		float radius2
	)
	{
		return Intersection2DUtils.IsCircleToCircleIntersect(
			center1, 
			radius1, 
			center2, 
			radius2
		);
	}
}