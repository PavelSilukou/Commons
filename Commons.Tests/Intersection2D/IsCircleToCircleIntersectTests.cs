using System.Numerics;
using Commons.Intersection2D;

namespace Commons.Tests.Intersection2D;

public partial class IntersectionUtilsTests
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
		
		yield return new TestCaseData(args1).Returns(true);
		yield return new TestCaseData(args2).Returns(true);
		yield return new TestCaseData(args3).Returns(false);
		yield return new TestCaseData(args4).Returns(true);
		yield return new TestCaseData(args5).Returns(false);
		yield return new TestCaseData(args6).Returns(false);
		yield return new TestCaseData(args7).Returns(true);
	}
	
	[Test, TestCaseSource(nameof(IsCircleToCircleIntersectTestsParameters))]
	public bool IsCircleToCircleIntersectValidateTests(
		Vector2 center1,
		float radius1,
		Vector2 center2,
		float radius2
	)
	{
		return IntersectionUtils.IsCircleToCircleIntersect(
			center1, 
			radius1, 
			center2, 
			radius2
		);
	}
	
	[Test, TestCaseSource(nameof(IsCircleToCircleIntersectTestsParameters))]
	public bool IsCircleToCircleIntersectDoesNotValidateTests(
		Vector2 center1,
		float radius1,
		Vector2 center2,
		float radius2
	)
	{
		return IntersectionUtils.IsCircleToCircleIntersect(
			center1, 
			radius1, 
			center2, 
			radius2,
			false
		);
	}
	
	private static IEnumerable<TestCaseData> IsCircleToCircleIntersect2TestsParameters()
	{
		var args1 = new object?[] { new Vector2(10.0f, 10.0f), 9.0f, new Vector2(20.0f, 10.0f), 9.0f };
		var args2 = new object?[] { new Vector2(10.0f, 10.0f), 5.0f, new Vector2(20.0f, 10.0f), 5.0f };
		var args3 = new object?[] { new Vector2(10.0f, 10.0f), 4.0f, new Vector2(20.0f, 10.0f), 4.0f };
		var args4 = new object?[] { new Vector2(10.0f, 10.0f), 4.0f, new Vector2(10.0f, 10.0f), 4.0f };
		var args5 = new object?[] { new Vector2(10.0f, 10.0f), 4.0f, new Vector2(10.0f, 10.0f), 3.0f };
		var args6 = new object?[] { new Vector2(10.0f, 10.0f), 3.0f, new Vector2(10.0f, 10.0f), 4.0f };
		var args7 = new object?[] { new Vector2(-10.0f, -10.0f), 9.0f, new Vector2(-20.0f, -10.0f), 9.0f };
		
		(bool, Vector2[]) returns1 = (true, [new Vector2(15.0f, 2.516685f), new Vector2(15.0f, 17.483315f)]);
		(bool, Vector2[]) returns2 = (true, [new Vector2(15.0f, 10.0f)]);
		(bool, Vector2[]) returns3 = (false, []);
		(bool, Vector2[]) returns4 = (true, [new Vector2(float.NaN, float.NaN)]);
		(bool, Vector2[]) returns5 = (true, [new Vector2(-15.0f, -2.516685f), new Vector2(-15.0f, -17.483315f)]);
		
		yield return new TestCaseData(args1).Returns(returns1);
		yield return new TestCaseData(args2).Returns(returns2);
		yield return new TestCaseData(args3).Returns(returns3);
		yield return new TestCaseData(args4).Returns(returns4);
		yield return new TestCaseData(args5).Returns(returns3);
		yield return new TestCaseData(args6).Returns(returns3);
		yield return new TestCaseData(args7).Returns(returns5);
	}
	
	[Test, TestCaseSource(nameof(IsCircleToCircleIntersect2TestsParameters))]
	public (bool, Vector2[]) IsCircleToCircleIntersectValidate2Tests(
		Vector2 center1,
		float radius1,
		Vector2 center2,
		float radius2
	)
	{
		var isIntersect = IntersectionUtils.IsCircleToCircleIntersect(
			out var intersectionPoint, 
			center1, 
			radius1, 
			center2, 
			radius2
		);
		
		return (isIntersect, intersectionPoint);
	}
	
	[Test, TestCaseSource(nameof(IsCircleToCircleIntersect2TestsParameters))]
	public (bool, Vector2[]) IsCircleToCircleIntersectDoesNotValidate2Tests(
		Vector2 center1,
		float radius1,
		Vector2 center2,
		float radius2
	)
	{
		var isIntersect = IntersectionUtils.IsCircleToCircleIntersect(
			out var intersectionPoint, 
			center1, 
			radius1, 
			center2, 
			radius2,
			false
		);
		
		return (isIntersect, intersectionPoint);
	}
	
	private static IEnumerable<TestCaseData> IsCircleToCircleIntersect3TestsParameters()
	{
		var args1 = new object?[] { new Vector2(10.0f, 10.0f), 5.0f, new Vector2(10.0f, 15.0f), 0.0f };
		var args2 = new object?[] { new Vector2(10.0f, 10.0f), 5.0f, new Vector2(10.0f, 16.0f), 0.0f };
		var args3 = new object?[] { new Vector2(10.0f, 10.0f), -9.0f, new Vector2(10.0f, 10.0f), 9.0f };
		var args4 = new object?[] { new Vector2(10.0f, 10.0f), 9.0f, new Vector2(10.0f, 10.0f), -9.0f };
		var args5 = new object?[] { new Vector2(10.0f, 10.0f), -9.0f, new Vector2(10.0f, 10.0f), -9.0f };
		var args6 = new object?[] { new Vector2(10.0f, 10.0f), 0.0f, new Vector2(10.0f, 10.0f), 0.0f };
		
		yield return new TestCaseData(args1).Returns(false);
		yield return new TestCaseData(args2).Returns(false);
		yield return new TestCaseData(args3).Returns(false);
		yield return new TestCaseData(args4).Returns(false);
		yield return new TestCaseData(args5).Returns(false);
		yield return new TestCaseData(args6).Returns(false);
	}
	
	[Test, TestCaseSource(nameof(IsCircleToCircleIntersect3TestsParameters))]
	public bool IsCircleToCircleIntersectValidate3Tests(
		Vector2 center1,
		float radius1,
		Vector2 center2,
		float radius2
	)
	{
		var isIntersect = false;
		var exception = Assert.Throws<ArithmeticException>(
			() => isIntersect = IntersectionUtils.IsCircleToCircleIntersect(
				center1, 
				radius1, 
				center2, 
				radius2
			)
		);
		Assert.That(exception.Source, Is.EqualTo("Commons.Intersection2D"));
		return isIntersect;
	}
	
	[Test, TestCaseSource(nameof(IsCircleToCircleIntersect3TestsParameters))]
	public bool IsCircleToCircleIntersectDoesNotValidate3Tests(
		Vector2 center1,
		float radius1,
		Vector2 center2,
		float radius2
	)
	{
		var isIntersect = false;
		Assert.DoesNotThrow(
			() => isIntersect = IntersectionUtils.IsCircleToCircleIntersect(
				center1, 
				radius1, 
				center2, 
				radius2,
				false
			)
		);
		return isIntersect;
	}
	
	private static IEnumerable<TestCaseData> IsCircleToCircleIntersect4TestsParameters()
	{
		var args1 = new object?[] { new Vector2(10.0f, 10.0f), 5.0f, new Vector2(10.0f, 15.0f), 0.0f };
		var args2 = new object?[] { new Vector2(10.0f, 10.0f), 5.0f, new Vector2(10.0f, 16.0f), 0.0f };
		var args3 = new object?[] { new Vector2(10.0f, 10.0f), -9.0f, new Vector2(10.0f, 10.0f), 9.0f };
		var args4 = new object?[] { new Vector2(10.0f, 10.0f), 9.0f, new Vector2(10.0f, 10.0f), -9.0f };
		var args5 = new object?[] { new Vector2(10.0f, 10.0f), -9.0f, new Vector2(10.0f, 10.0f), -9.0f };
		var args6 = new object?[] { new Vector2(10.0f, 10.0f), 0.0f, new Vector2(10.0f, 10.0f), 0.0f };
		
		(bool, Vector2[]) returns = (false, []);
		
		yield return new TestCaseData(args1).Returns(returns);
		yield return new TestCaseData(args2).Returns(returns);
		yield return new TestCaseData(args3).Returns(returns);
		yield return new TestCaseData(args4).Returns(returns);
		yield return new TestCaseData(args5).Returns(returns);
		yield return new TestCaseData(args6).Returns(returns);
	}
	
	[Test, TestCaseSource(nameof(IsCircleToCircleIntersect4TestsParameters))]
	public (bool, Vector2[]) IsCircleToCircleIntersectValidate4Tests(
		Vector2 center1,
		float radius1,
		Vector2 center2,
		float radius2
	)
	{
		var isIntersect = false;
		var intersectionPoints = Array.Empty<Vector2>();
		var exception = Assert.Throws<ArithmeticException>(
			() => isIntersect = IntersectionUtils.IsCircleToCircleIntersect(
				out intersectionPoints,
				center1, 
				radius1, 
				center2, 
				radius2
			)
		);
		Assert.That(exception.Source, Is.EqualTo("Commons.Intersection2D"));
		return (isIntersect, intersectionPoints);
	}
	
	[Test, TestCaseSource(nameof(IsCircleToCircleIntersect4TestsParameters))]
	public (bool, Vector2[]) IsCircleToCircleIntersectDoesNotValidate4Tests(
		Vector2 center1,
		float radius1,
		Vector2 center2,
		float radius2
	)
	{
		var isIntersect = false;
		var intersectionPoints = Array.Empty<Vector2>();
		Assert.DoesNotThrow(
			() => isIntersect = IntersectionUtils.IsCircleToCircleIntersect(
				out intersectionPoints,
				center1, 
				radius1, 
				center2, 
				radius2,
				false
			)
		);
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
	public void IsCircleToCircleIntersectSpecialTests(
		Vector2 center1,
		float radius1,
		Vector2 center2,
		float radius2
	)
	{
		var exception = Assert.Throws<ArithmeticException>(
			() => IntersectionUtils.IsCircleToCircleIntersect(
				center1, 
				radius1, 
				center2, 
				radius2
			)
		);
		Assert.That(exception.Source, Is.EqualTo("Commons.Intersection2D"));
	}
	
	[Test, TestCaseSource(nameof(IsCircleToCircleIntersectSpecialTestsParameters))]
	public void IsCircleToCircleIntersectDoesNotValidateSpecialTests(
		Vector2 center1,
		float radius1,
		Vector2 center2,
		float radius2
	)
	{
		Assert.DoesNotThrow(
			() => IntersectionUtils.IsCircleToCircleIntersect(
				center1, 
				radius1, 
				center2, 
				radius2,
				false
			)
		);
	}
	
	[Test, TestCaseSource(nameof(IsCircleToCircleIntersectSpecialTestsParameters))]
	public void IsCircleToCircleIntersectSpecial2Tests(
		Vector2 center1,
		float radius1,
		Vector2 center2,
		float radius2
	)
	{
		var exception = Assert.Throws<ArithmeticException>(
			() => IntersectionUtils.IsCircleToCircleIntersect(
				out _,
				center1, 
				radius1, 
				center2, 
				radius2
			)
		);
		Assert.That(exception.Source, Is.EqualTo("Commons.Intersection2D"));
	}
	
	[Test, TestCaseSource(nameof(IsCircleToCircleIntersectSpecialTestsParameters))]
	public void IsCircleToCircleIntersectDoesNotValidateSpecial2Tests(
		Vector2 center1,
		float radius1,
		Vector2 center2,
		float radius2
	)
	{
		Assert.DoesNotThrow(
			() => IntersectionUtils.IsCircleToCircleIntersect(
				out _,
				center1, 
				radius1, 
				center2, 
				radius2,
				false
			)
		);
	}
}