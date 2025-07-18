using System.Numerics;
using Commons.Intersection2D;

namespace Commons.Tests.Intersection2D;

#pragma warning disable S107 // Methods should not have too many parameters
public partial class IntersectionUtilsTests
{
	private static IEnumerable<TestCaseData> IsArcToArcIntersectTestsParameters()
	{
		var args1 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 19.0f), -180.0f, new Vector2(20.0f, 10.0f), new Vector2(20.0f, 19.0f), 180.0f };
		var args2 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 19.0f), -90.0f, new Vector2(20.0f, 10.0f), new Vector2(20.0f, 19.0f), 90.0f };
		var args3 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 1.0f), 90.0f, new Vector2(20.0f, 10.0f), new Vector2(20.0f, 1.0f), -90.0f };
		var args4 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 1.0f), 90.0f, new Vector2(20.0f, 10.0f), new Vector2(20.0f, 19.0f), 90.0f };
		var args5 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 19.0f), -90.0f, new Vector2(20.0f, 10.0f), new Vector2(20.0f, 1.0f), -90.0f };
		var args6 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 19.0f), -180.0f, new Vector2(20.0f, 10.0f), new Vector2(20.0f, 19.0f), -180.0f };
		var args7 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 19.0f), 180.0f, new Vector2(20.0f, 10.0f), new Vector2(20.0f, 19.0f), 180.0f };
		var args8 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 19.0f), 180.0f, new Vector2(20.0f, 10.0f), new Vector2(20.0f, 19.0f), -180.0f };
		var args9 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 15.0f), -180.0f, new Vector2(20.0f, 10.0f), new Vector2(20.0f, 15.0f), 180.0f };
		var args10 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 14.0f), -180.0f, new Vector2(20.0f, 10.0f), new Vector2(20.0f, 14.0f), 180.0f };
		var args11 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 14.0f), 180.0f, new Vector2(10.0f, 10.0f), new Vector2(10.0f, 14.0f), 180.0f };
		var args12 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 14.0f), -180.0f, new Vector2(10.0f, 10.0f), new Vector2(10.0f, 14.0f), 180.0f };
		var args13 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 14.0f), -180.0f, new Vector2(10.0f, 10.0f), new Vector2(12.828427f, 12.828427f), -90.0f };
		var args14 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 14.0f), -180.0f, new Vector2(10.0f, 10.0f), new Vector2(10.0f, 14.0f), -135.0f };
		var args15 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(7.171573f, 12.828427f), 90.0f, new Vector2(10.0f, 10.0f), new Vector2(12.828427f, 12.828427f), -90.0f };
		var args16 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 14.0f), 90.0f, new Vector2(10.0f, 10.0f), new Vector2(6.0f, 10.0f), 90.0f };
		var args17 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 14.0f), 135.0f, new Vector2(10.0f, 10.0f), new Vector2(10.0f, 6.0f), -135.0f };
		var args18 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 14.0f), 90.0f, new Vector2(10.0f, 10.0f), new Vector2(10.0f, 6.0f), -90.0f };
		var args19 = new object?[] { new Vector2(-10.0f, -10.0f), new Vector2(-10.0f, -19.0f), -180.0f, new Vector2(-20.0f, -10.0f), new Vector2(-20.0f, -19.0f), 180.0f };
		var args20 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 19.0f), 360.0f, new Vector2(20.0f, 10.0f), new Vector2(20.0f, 19.0f), 180.0f };
		var args21 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 19.0f), -180.0f, new Vector2(20.0f, 10.0f), new Vector2(20.0f, 19.0f), 360.0f };
		
		yield return new TestCaseData(args1).Returns(true);
		yield return new TestCaseData(args2).Returns(true);
		yield return new TestCaseData(args3).Returns(true);
		yield return new TestCaseData(args4).Returns(false);
		yield return new TestCaseData(args5).Returns(false);
		yield return new TestCaseData(args6).Returns(false);
		yield return new TestCaseData(args7).Returns(false);
		yield return new TestCaseData(args8).Returns(false);
		yield return new TestCaseData(args9).Returns(true);
		yield return new TestCaseData(args10).Returns(false);
		yield return new TestCaseData(args11).Returns(true);
		yield return new TestCaseData(args12).Returns(true);
		yield return new TestCaseData(args13).Returns(true);
		yield return new TestCaseData(args14).Returns(true);
		yield return new TestCaseData(args15).Returns(false);
		yield return new TestCaseData(args16).Returns(true);
		yield return new TestCaseData(args17).Returns(true);
		yield return new TestCaseData(args18).Returns(true);
		yield return new TestCaseData(args19).Returns(true);
		yield return new TestCaseData(args20).Returns(true);
		yield return new TestCaseData(args21).Returns(true);
	}
	
	[Test, TestCaseSource(nameof(IsArcToArcIntersectTestsParameters))]
	public bool IsArcToArcIntersectValidateTests(
		Vector2 arc1Center,
		Vector2 arc1Point, 
		float arc1AngleDeg,
		Vector2 arc2Center,
		Vector2 arc2Point, 
		float arc2AngleDeg
	)
	{
		var isIntersect = IntersectionUtils.IsArcToArcIntersect(
			arc1Center,
			arc1Point, 
			arc1AngleDeg,
			arc2Center,
			arc2Point, 
			arc2AngleDeg
		);

		return isIntersect;
	}
	
	[Test, TestCaseSource(nameof(IsArcToArcIntersectTestsParameters))]
	public bool IsArcToArcIntersectDoesNotValidateTests(
		Vector2 arc1Center,
		Vector2 arc1Point, 
		float arc1AngleDeg,
		Vector2 arc2Center,
		Vector2 arc2Point, 
		float arc2AngleDeg
	)
	{
		var isIntersect = IntersectionUtils.IsArcToArcIntersect( 
			arc1Center,
			arc1Point, 
			arc1AngleDeg,
			arc2Center,
			arc2Point, 
			arc2AngleDeg,
			false
		);

		return isIntersect;
	}
	
	private static IEnumerable<TestCaseData> IsArcToArcIntersect2TestsParameters()
	{
		var args1 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 19.0f), -180.0f, new Vector2(20.0f, 10.0f), new Vector2(20.0f, 19.0f), 180.0f };
		
		var args2 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 19.0f), -90.0f, new Vector2(20.0f, 10.0f), new Vector2(20.0f, 19.0f), 90.0f };
		var args3 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 1.0f), 90.0f, new Vector2(20.0f, 10.0f), new Vector2(20.0f, 1.0f), -90.0f };
		var args4 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 1.0f), 90.0f, new Vector2(20.0f, 10.0f), new Vector2(20.0f, 19.0f), 90.0f };
		var args5 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 19.0f), -90.0f, new Vector2(20.0f, 10.0f), new Vector2(20.0f, 1.0f), -90.0f };
		
		var args6 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 19.0f), -180.0f, new Vector2(20.0f, 10.0f), new Vector2(20.0f, 19.0f), -180.0f };
		var args7 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 19.0f), 180.0f, new Vector2(20.0f, 10.0f), new Vector2(20.0f, 19.0f), 180.0f };
		var args8 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 19.0f), 180.0f, new Vector2(20.0f, 10.0f), new Vector2(20.0f, 19.0f), -180.0f };
		
		var args9 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 15.0f), -180.0f, new Vector2(20.0f, 10.0f), new Vector2(20.0f, 15.0f), 180.0f };
		var args10 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 14.0f), -180.0f, new Vector2(20.0f, 10.0f), new Vector2(20.0f, 14.0f), 180.0f };
		
		var args11 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 14.0f), 180.0f, new Vector2(10.0f, 10.0f), new Vector2(10.0f, 14.0f), 180.0f };
		var args12 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 14.0f), -180.0f, new Vector2(10.0f, 10.0f), new Vector2(10.0f, 14.0f), 180.0f };
		var args13 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 14.0f), -180.0f, new Vector2(10.0f, 10.0f), new Vector2(12.828427f, 12.828427f), -90.0f };
		var args14 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 14.0f), -180.0f, new Vector2(10.0f, 10.0f), new Vector2(10.0f, 14.0f), -135.0f };
		var args15 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(7.171573f, 12.828427f), 90.0f, new Vector2(10.0f, 10.0f), new Vector2(12.828427f, 12.828427f), -90.0f };
		var args16 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 14.0f), 90.0f, new Vector2(10.0f, 10.0f), new Vector2(6.0f, 10.0f), 90.0f };
		var args17 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 14.0f), 135.0f, new Vector2(10.0f, 10.0f), new Vector2(10.0f, 6.0f), -135.0f };
		var args18 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 14.0f), 90.0f, new Vector2(10.0f, 10.0f), new Vector2(10.0f, 6.0f), -90.0f };
		var args19 = new object?[] { new Vector2(-10.0f, -10.0f), new Vector2(-10.0f, -19.0f), -180.0f, new Vector2(-20.0f, -10.0f), new Vector2(-20.0f, -19.0f), 180.0f };
		
		var args20 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 19.0f), 360.0f, new Vector2(20.0f, 10.0f), new Vector2(20.0f, 19.0f), 180.0f };
		var args21 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 19.0f), -180.0f, new Vector2(20.0f, 10.0f), new Vector2(20.0f, 19.0f), 360.0f };
		
		(bool, Vector2[]) returns1 = (true, [new Vector2(15.0f, 2.516685f), new Vector2(15.0f, 17.483315f)]);
		(bool, Vector2[]) returns2 = (true, [new Vector2(15.0f, 17.483315f)]);
		(bool, Vector2[]) returns3 = (true, [new Vector2(15.0f, 2.516685f)]);
		(bool, Vector2[]) returns4 = (false, []);
		(bool, Vector2[]) returns5 = (true, [new Vector2(15.0f, 10.0f)]);
		(bool, Vector2[]) returns6 = (true, [new Vector2(10.0f, 14.0f), new Vector2(10.0f, 6.0f)]);
		(bool, Vector2[]) returns7 = (true, [new Vector2(6.0f, 10.0f)]);
		(bool, Vector2[]) returns8 = (true, [new Vector2(float.NaN, float.NaN)]);
		(bool, Vector2[]) returns9 = (true, [new Vector2(-15.0f, -2.516685f), new Vector2(-15.0f, -17.483315f)]);
	
		yield return new TestCaseData(args1).Returns(returns1);
		
		yield return new TestCaseData(args2).Returns(returns2);
		yield return new TestCaseData(args3).Returns(returns3);
		yield return new TestCaseData(args4).Returns(returns4);
		yield return new TestCaseData(args5).Returns(returns4);
		
		yield return new TestCaseData(args6).Returns(returns4);
		yield return new TestCaseData(args7).Returns(returns4);
		yield return new TestCaseData(args8).Returns(returns4);
		
		yield return new TestCaseData(args9).Returns(returns5);
		yield return new TestCaseData(args10).Returns(returns4);
		
		yield return new TestCaseData(args11).Returns(returns8);
		yield return new TestCaseData(args12).Returns(returns6);
		yield return new TestCaseData(args13).Returns(returns8);
		yield return new TestCaseData(args14).Returns(returns8);
		yield return new TestCaseData(args15).Returns(returns4);
		yield return new TestCaseData(args16).Returns(returns7);
		yield return new TestCaseData(args17).Returns(returns8);
		yield return new TestCaseData(args18).Returns(returns7);
		yield return new TestCaseData(args19).Returns(returns9);
		
		yield return new TestCaseData(args20).Returns(returns1);
		yield return new TestCaseData(args21).Returns(returns1);
	}
	
	[Test, TestCaseSource(nameof(IsArcToArcIntersect2TestsParameters))]
	public (bool, Vector2[]) IsArcToArcIntersectValidate2Tests(
		Vector2 arc1Center,
		Vector2 arc1Point, 
		float arc1AngleDeg,
		Vector2 arc2Center,
		Vector2 arc2Point, 
		float arc2AngleDeg
	)
	{
		var isIntersect = IntersectionUtils.IsArcToArcIntersect(
			out var intersectionPoints, 
			arc1Center,
			arc1Point, 
			arc1AngleDeg,
			arc2Center,
			arc2Point, 
			arc2AngleDeg
		);

		return (isIntersect, intersectionPoints);
	}
	
	[Test, TestCaseSource(nameof(IsArcToArcIntersect2TestsParameters))]
	public (bool, Vector2[]) IsArcToArcIntersectDoesNotValidate2Tests(
		Vector2 arc1Center,
		Vector2 arc1Point, 
		float arc1AngleDeg,
		Vector2 arc2Center,
		Vector2 arc2Point, 
		float arc2AngleDeg
	)
	{
		var isIntersect = IntersectionUtils.IsArcToArcIntersect(
			out var intersectionPoints, 
			arc1Center,
			arc1Point, 
			arc1AngleDeg,
			arc2Center,
			arc2Point, 
			arc2AngleDeg,
			false
		);

		return (isIntersect, intersectionPoints);
	}
	
	private static IEnumerable<TestCaseData> IsArcToArcIntersect3TestsParameters()
	{
		var args1 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 15.0f), 0.0f, new Vector2(10.0f, 10.0f), new Vector2(10.0f, 15.0f), 0.0f };
		var args2 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 10.0f), 0.0f, new Vector2(10.0f, 10.0f), new Vector2(10.0f, 10.0f), 0.0f };
		var args3 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 10.0f), 180.0f, new Vector2(10.0f, 10.0f), new Vector2(10.0f, 10.0f), 180.0f };
		var args4 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 19.0f), 540.0f, new Vector2(20.0f, 10.0f), new Vector2(20.0f, 19.0f), 180.0f };
		var args5 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 19.0f), -180.0f, new Vector2(20.0f, 10.0f), new Vector2(20.0f, 19.0f), 540.0f };
		
		yield return new TestCaseData(args1);
		yield return new TestCaseData(args2);
		yield return new TestCaseData(args3);
		yield return new TestCaseData(args4);
		yield return new TestCaseData(args5);
	}
	
	[Test, TestCaseSource(nameof(IsArcToArcIntersect3TestsParameters))]
	public void IsArcToArcIntersectValidate3Tests(
		Vector2 arc1Center,
		Vector2 arc1Point, 
		float arc1AngleDeg,
		Vector2 arc2Center,
		Vector2 arc2Point, 
		float arc2AngleDeg
	)
	{
		var exception = Assert.Throws<ArithmeticException>(
			() => IntersectionUtils.IsArcToArcIntersect(
				arc1Center,
				arc1Point, 
				arc1AngleDeg,
				arc2Center,
				arc2Point, 
				arc2AngleDeg
			)
		);
		Assert.That(exception.Source, Is.EqualTo("Commons.Intersection2D"));
	}
	
	private static IEnumerable<TestCaseData> IsArcToArcIntersect5TestsParameters()
	{
		var args1 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 15.0f), 0.0f, new Vector2(10.0f, 10.0f), new Vector2(10.0f, 15.0f), 0.0f };
		var args2 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 10.0f), 0.0f, new Vector2(10.0f, 10.0f), new Vector2(10.0f, 10.0f), 0.0f };
		var args3 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 10.0f), 180.0f, new Vector2(10.0f, 10.0f), new Vector2(10.0f, 10.0f), 180.0f };
		var args4 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 19.0f), 540.0f, new Vector2(20.0f, 10.0f), new Vector2(20.0f, 19.0f), 180.0f };
		var args5 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 19.0f), -180.0f, new Vector2(20.0f, 10.0f), new Vector2(20.0f, 19.0f), 540.0f };
		
		yield return new TestCaseData(args1).Returns(false);
		yield return new TestCaseData(args2).Returns(false);
		yield return new TestCaseData(args3).Returns(false);
		yield return new TestCaseData(args4).Returns(true);
		yield return new TestCaseData(args5).Returns(true);
	}
	
	[Test, TestCaseSource(nameof(IsArcToArcIntersect5TestsParameters))]
	public bool IsArcToArcIntersectDoesNotValidate3Tests(
		Vector2 arc1Center,
		Vector2 arc1Point, 
		float arc1AngleDeg,
		Vector2 arc2Center,
		Vector2 arc2Point, 
		float arc2AngleDeg
	)
	{
		var isIntersect = false;
		Assert.DoesNotThrow(
			() => isIntersect = IntersectionUtils.IsArcToArcIntersect(
				arc1Center,
				arc1Point, 
				arc1AngleDeg,
				arc2Center,
				arc2Point, 
				arc2AngleDeg,
				false
			)
		);
		return isIntersect;
	}
	
	private static IEnumerable<TestCaseData> IsArcToArcIntersect4TestsParameters()
	{
		var args1 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 15.0f), 0.0f, new Vector2(10.0f, 10.0f), new Vector2(10.0f, 15.0f), 0.0f };
		var args2 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 10.0f), 0.0f, new Vector2(10.0f, 10.0f), new Vector2(10.0f, 10.0f), 0.0f };
		var args3 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 10.0f), 180.0f, new Vector2(10.0f, 10.0f), new Vector2(10.0f, 10.0f), 180.0f };
		var args4 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 19.0f), 540.0f, new Vector2(20.0f, 10.0f), new Vector2(20.0f, 19.0f), 180.0f };
		var args5 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 19.0f), -180.0f, new Vector2(20.0f, 10.0f), new Vector2(20.0f, 19.0f), 540.0f };
		
		yield return new TestCaseData(args1);
		yield return new TestCaseData(args2);
		yield return new TestCaseData(args3);
		yield return new TestCaseData(args4);
		yield return new TestCaseData(args5);
	}
	
	[Test, TestCaseSource(nameof(IsArcToArcIntersect4TestsParameters))]
	public void IsArcToArcIntersectValidate4Tests(
		Vector2 arc1Center,
		Vector2 arc1Point, 
		float arc1AngleDeg,
		Vector2 arc2Center,
		Vector2 arc2Point, 
		float arc2AngleDeg
	)
	{
		var exception = Assert.Throws<ArithmeticException>(
			() => IntersectionUtils.IsArcToArcIntersect(
				out _,
				arc1Center,
				arc1Point, 
				arc1AngleDeg,
				arc2Center,
				arc2Point, 
				arc2AngleDeg
			)
		);
		Assert.That(exception.Source, Is.EqualTo("Commons.Intersection2D"));
	}
	
	private static IEnumerable<TestCaseData> IsArcToArcIntersect6TestsParameters()
	{
		var args1 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 15.0f), 0.0f, new Vector2(10.0f, 10.0f), new Vector2(10.0f, 15.0f), 0.0f };
		var args2 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 10.0f), 0.0f, new Vector2(10.0f, 10.0f), new Vector2(10.0f, 10.0f), 0.0f };
		var args3 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 10.0f), 180.0f, new Vector2(10.0f, 10.0f), new Vector2(10.0f, 10.0f), 180.0f };
		var args4 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 19.0f), 540.0f, new Vector2(20.0f, 10.0f), new Vector2(20.0f, 19.0f), 180.0f };
		var args5 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 19.0f), -180.0f, new Vector2(20.0f, 10.0f), new Vector2(20.0f, 19.0f), 540.0f };
		
		(bool, Vector2[]) returns1 = (false, []);
		(bool, Vector2[]) returns2 = (true, [new Vector2(15.0f, 2.516685f), new Vector2(15.0f, 17.483315f)]);
		
		yield return new TestCaseData(args1).Returns(returns1);
		yield return new TestCaseData(args2).Returns(returns1);
		yield return new TestCaseData(args3).Returns(returns1);
		yield return new TestCaseData(args4).Returns(returns2);
		yield return new TestCaseData(args5).Returns(returns2);
	}
	
	[Test, TestCaseSource(nameof(IsArcToArcIntersect6TestsParameters))]
	public (bool, Vector2[]) IsArcToArcIntersectDoesNotValidate4Tests(
		Vector2 arc1Center,
		Vector2 arc1Point, 
		float arc1AngleDeg,
		Vector2 arc2Center,
		Vector2 arc2Point, 
		float arc2AngleDeg
	)
	{
		var isIntersect = false;
		var intersectionPoints = Array.Empty<Vector2>();
		Assert.DoesNotThrow(
			() => isIntersect = IntersectionUtils.IsArcToArcIntersect(
				out intersectionPoints,
				arc1Center,
				arc1Point, 
				arc1AngleDeg,
				arc2Center,
				arc2Point, 
				arc2AngleDeg,
				false
			)
		);
		return (isIntersect, intersectionPoints);
	}
	
	private static IEnumerable<TestCaseData> IsArcToArcIntersectSpecialTestsParameters()
	{
		var argsSpecial1 = new object?[] { new Vector2(float.NaN, 10.0f), new Vector2(10.0f, 19.0f), -180.0f, new Vector2(20.0f, 10.0f), new Vector2(20.0f, 19.0f), 180.0f };
		var argsSpecial2 = new object?[] { new Vector2(10.0f, float.NaN), new Vector2(10.0f, 19.0f), -180.0f, new Vector2(20.0f, 10.0f), new Vector2(20.0f, 19.0f), 180.0f };
		var argsSpecial3 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(float.NaN, 19.0f), -180.0f, new Vector2(20.0f, 10.0f), new Vector2(20.0f, 19.0f), 180.0f };
		var argsSpecial4 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, float.NaN), -180.0f, new Vector2(20.0f, 10.0f), new Vector2(20.0f, 19.0f), 180.0f };
		var argsSpecial6 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 19.0f), -180.0f, new Vector2(float.NaN, 10.0f), new Vector2(20.0f, 19.0f), 180.0f };
		var argsSpecial7 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 19.0f), -180.0f, new Vector2(20.0f, float.NaN), new Vector2(20.0f, 19.0f), 180.0f };
		var argsSpecial8 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 19.0f), -180.0f, new Vector2(20.0f, 10.0f), new Vector2(float.NaN, 19.0f), 180.0f };
		var argsSpecial9 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 19.0f), -180.0f, new Vector2(20.0f, 10.0f), new Vector2(20.0f, float.NaN), 180.0f };
		
		var argsSpecial11 = new object?[] { new Vector2(float.PositiveInfinity, 10.0f), new Vector2(10.0f, 19.0f), -180.0f, new Vector2(20.0f, 10.0f), new Vector2(20.0f, 19.0f), 180.0f };
		var argsSpecial12 = new object?[] { new Vector2(10.0f, float.PositiveInfinity), new Vector2(10.0f, 19.0f), -180.0f, new Vector2(20.0f, 10.0f), new Vector2(20.0f, 19.0f), 180.0f };
		var argsSpecial13 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(float.PositiveInfinity, 19.0f), -180.0f, new Vector2(20.0f, 10.0f), new Vector2(20.0f, 19.0f), 180.0f };
		var argsSpecial14 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, float.PositiveInfinity), -180.0f, new Vector2(20.0f, 10.0f), new Vector2(20.0f, 19.0f), 180.0f };
		var argsSpecial16 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 19.0f), -180.0f, new Vector2(float.PositiveInfinity, 10.0f), new Vector2(20.0f, 19.0f), 180.0f };
		var argsSpecial17 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 19.0f), -180.0f, new Vector2(20.0f, float.PositiveInfinity), new Vector2(20.0f, 19.0f), 180.0f };
		var argsSpecial18 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 19.0f), -180.0f, new Vector2(20.0f, 10.0f), new Vector2(float.PositiveInfinity, 19.0f), 180.0f };
		var argsSpecial19 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 19.0f), -180.0f, new Vector2(20.0f, 10.0f), new Vector2(20.0f, float.PositiveInfinity), 180.0f };
		
		var argsSpecial21 = new object?[] { new Vector2(float.NegativeInfinity, 10.0f), new Vector2(10.0f, 19.0f), -180.0f, new Vector2(20.0f, 10.0f), new Vector2(20.0f, 19.0f), 180.0f };
		var argsSpecial22 = new object?[] { new Vector2(10.0f, float.NegativeInfinity), new Vector2(10.0f, 19.0f), -180.0f, new Vector2(20.0f, 10.0f), new Vector2(20.0f, 19.0f), 180.0f };
		var argsSpecial23 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(float.NegativeInfinity, 19.0f), -180.0f, new Vector2(20.0f, 10.0f), new Vector2(20.0f, 19.0f), 180.0f };
		var argsSpecial24 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, float.NegativeInfinity), -180.0f, new Vector2(20.0f, 10.0f), new Vector2(20.0f, 19.0f), 180.0f };
		
		var argsSpecial26 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 19.0f), -180.0f, new Vector2(float.NegativeInfinity, 10.0f), new Vector2(20.0f, 19.0f), 180.0f };
		var argsSpecial27 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 19.0f), -180.0f, new Vector2(20.0f, float.NegativeInfinity), new Vector2(20.0f, 19.0f), 180.0f };
		var argsSpecial28 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 19.0f), -180.0f, new Vector2(20.0f, 10.0f), new Vector2(float.NegativeInfinity, 19.0f), 180.0f };
		var argsSpecial29 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 19.0f), -180.0f, new Vector2(20.0f, 10.0f), new Vector2(20.0f, float.NegativeInfinity), 180.0f };

		yield return new TestCaseData(argsSpecial1);
		yield return new TestCaseData(argsSpecial2);
		yield return new TestCaseData(argsSpecial3);
		yield return new TestCaseData(argsSpecial4);
		yield return new TestCaseData(argsSpecial6);
		yield return new TestCaseData(argsSpecial7);
		yield return new TestCaseData(argsSpecial8);
		yield return new TestCaseData(argsSpecial9);
		
		yield return new TestCaseData(argsSpecial11);
		yield return new TestCaseData(argsSpecial12);
		yield return new TestCaseData(argsSpecial13);
		yield return new TestCaseData(argsSpecial14);
		yield return new TestCaseData(argsSpecial16);
		yield return new TestCaseData(argsSpecial17);
		yield return new TestCaseData(argsSpecial18);
		yield return new TestCaseData(argsSpecial19);
		
		yield return new TestCaseData(argsSpecial21);
		yield return new TestCaseData(argsSpecial22);
		yield return new TestCaseData(argsSpecial23);
		yield return new TestCaseData(argsSpecial24);
		yield return new TestCaseData(argsSpecial26);
		yield return new TestCaseData(argsSpecial27);
		yield return new TestCaseData(argsSpecial28);
		yield return new TestCaseData(argsSpecial29);
	}
	
	[Test, TestCaseSource(nameof(IsArcToArcIntersectSpecialTestsParameters))]
	public void IsArcToArcIntersectSpecialTests(
		Vector2 arc1Center,
		Vector2 arc1Point, 
		float arc1AngleDeg,
		Vector2 arc2Center,
		Vector2 arc2Point, 
		float arc2AngleDeg
	)
	{
		var exception = Assert.Throws<ArithmeticException>(
			() => IntersectionUtils.IsArcToArcIntersect(
				arc1Center,
				arc1Point, 
				arc1AngleDeg,
				arc2Center,
				arc2Point, 
				arc2AngleDeg
			)
		);
		Assert.That(exception.Source, Is.EqualTo("Commons.Intersection2D"));
	}
	
	[Test, TestCaseSource(nameof(IsArcToArcIntersectSpecialTestsParameters))]
	public void IsArcToArcIntersectDoesNotValidateSpecialTests(
		Vector2 arc1Center,
		Vector2 arc1Point, 
		float arc1AngleDeg,
		Vector2 arc2Center,
		Vector2 arc2Point, 
		float arc2AngleDeg
	)
	{
		Assert.DoesNotThrow(
			() => IntersectionUtils.IsArcToArcIntersect(
				arc1Center,
				arc1Point, 
				arc1AngleDeg,
				arc2Center,
				arc2Point, 
				arc2AngleDeg,
				false
			)
		);
	}
	
	[Test, TestCaseSource(nameof(IsArcToArcIntersectSpecialTestsParameters))]
	public void IsArcToArcIntersectSpecial2Tests(
		Vector2 arc1Center,
		Vector2 arc1Point, 
		float arc1AngleDeg,
		Vector2 arc2Center,
		Vector2 arc2Point, 
		float arc2AngleDeg
	)
	{
		var exception = Assert.Throws<ArithmeticException>(
			() => IntersectionUtils.IsArcToArcIntersect(
				out _,
				arc1Center,
				arc1Point, 
				arc1AngleDeg,
				arc2Center,
				arc2Point, 
				arc2AngleDeg
			)
		);
		Assert.That(exception.Source, Is.EqualTo("Commons.Intersection2D"));
	}
	
	[Test, TestCaseSource(nameof(IsArcToArcIntersectSpecialTestsParameters))]
	public void IsArcToArcIntersectDoesNotValidateSpecial2Tests(
		Vector2 arc1Center,
		Vector2 arc1Point, 
		float arc1AngleDeg,
		Vector2 arc2Center,
		Vector2 arc2Point, 
		float arc2AngleDeg
	)
	{
		Assert.DoesNotThrow(
			() => IntersectionUtils.IsArcToArcIntersect(
				out _,
				arc1Center,
				arc1Point, 
				arc1AngleDeg,
				arc2Center,
				arc2Point, 
				arc2AngleDeg,
				false
			)
		);
	}
	
	private static IEnumerable<TestCaseData> IsArcToArcIntersectSpecialTests2Parameters()
	{
		var argsSpecial1 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 19.0f), float.NaN, new Vector2(20.0f, 10.0f), new Vector2(20.0f, 19.0f), 180.0f };
		var argsSpecial2 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 19.0f), float.PositiveInfinity, new Vector2(20.0f, 10.0f), new Vector2(20.0f, 19.0f), 180.0f };
		var argsSpecial3 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 19.0f), float.NegativeInfinity, new Vector2(20.0f, 10.0f), new Vector2(20.0f, 19.0f), 180.0f };
		var argsSpecial4 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 19.0f), -180.0f, new Vector2(20.0f, 10.0f), new Vector2(20.0f, 19.0f), float.NaN };
		var argsSpecial5 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 19.0f), -180.0f, new Vector2(20.0f, 10.0f), new Vector2(20.0f, 19.0f), float.PositiveInfinity };
		var argsSpecial6 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 19.0f), -180.0f, new Vector2(20.0f, 10.0f), new Vector2(20.0f, 19.0f), float.NegativeInfinity };

		yield return new TestCaseData(argsSpecial1);
		yield return new TestCaseData(argsSpecial2);
		yield return new TestCaseData(argsSpecial3);
		yield return new TestCaseData(argsSpecial4);
		yield return new TestCaseData(argsSpecial5);
		yield return new TestCaseData(argsSpecial6);
	}
	
	[Test, TestCaseSource(nameof(IsArcToArcIntersectSpecialTests2Parameters))]
	public void IsArcToArcIntersectSpecialTests2(
		Vector2 arc1Center,
		Vector2 arc1Point, 
		float arc1AngleDeg,
		Vector2 arc2Center,
		Vector2 arc2Point, 
		float arc2AngleDeg
	)
	{
		var exception = Assert.Throws<ArithmeticException>(
			() => IntersectionUtils.IsArcToArcIntersect(
				arc1Center,
				arc1Point, 
				arc1AngleDeg,
				arc2Center,
				arc2Point, 
				arc2AngleDeg
			)
		);
		Assert.That(exception.Source, Is.EqualTo("Commons"));
	}
	
	[Test, TestCaseSource(nameof(IsArcToArcIntersectSpecialTests2Parameters))]
	public void IsArcToArcIntersectDoesNotValidateSpecialTests2(
		Vector2 arc1Center,
		Vector2 arc1Point, 
		float arc1AngleDeg,
		Vector2 arc2Center,
		Vector2 arc2Point, 
		float arc2AngleDeg
	)
	{
		var exception = Assert.Throws<ArithmeticException>(
			() => IntersectionUtils.IsArcToArcIntersect(
				arc1Center,
				arc1Point, 
				arc1AngleDeg,
				arc2Center,
				arc2Point, 
				arc2AngleDeg,
				false
			)
		);
		Assert.That(exception.Source, Is.EqualTo("Commons"));
	}
	
	[Test, TestCaseSource(nameof(IsArcToArcIntersectSpecialTests2Parameters))]
	public void IsArcToArcIntersectSpecial2Tests2(
		Vector2 arc1Center,
		Vector2 arc1Point, 
		float arc1AngleDeg,
		Vector2 arc2Center,
		Vector2 arc2Point, 
		float arc2AngleDeg
	)
	{
		var exception = Assert.Throws<ArithmeticException>(
			() => IntersectionUtils.IsArcToArcIntersect(
				out _,
				arc1Center,
				arc1Point, 
				arc1AngleDeg,
				arc2Center,
				arc2Point, 
				arc2AngleDeg
			)
		);
		Assert.That(exception.Source, Is.EqualTo("Commons"));
	}
	
	[Test, TestCaseSource(nameof(IsArcToArcIntersectSpecialTests2Parameters))]
	public void IsArcToArcIntersectDoesNotValidateSpecial2Tests2(
		Vector2 arc1Center,
		Vector2 arc1Point, 
		float arc1AngleDeg,
		Vector2 arc2Center,
		Vector2 arc2Point, 
		float arc2AngleDeg
	)
	{
		var exception = Assert.Throws<ArithmeticException>(
			() => IntersectionUtils.IsArcToArcIntersect(
				out _,
				arc1Center,
				arc1Point, 
				arc1AngleDeg,
				arc2Center,
				arc2Point, 
				arc2AngleDeg,
				false
			)
		);
		Assert.That(exception.Source, Is.EqualTo("Commons"));
	}
}