using System.Numerics;
using Commons.Intersection2D.ShapeCreators;

namespace Commons.Tests.Intersection2D.Shapes;

public class CircleValidationTests
{
	private static IEnumerable<TestCaseData> DoesNotThrowTestsParameters()
	{
		var args1 = new object?[] { new Vector2(10.0f, 10.0f), 9.0f };
		var args2 = new object?[] { new Vector2(-10.0f, -10.0f), 9.0f };
		var args3 = new object?[] { new Vector2(0.0f, 0.0f), 9.0f };
		
		yield return new TestCaseData(args1);
		yield return new TestCaseData(args2);
		yield return new TestCaseData(args3);
	}
	
	[Test, TestCaseSource(nameof(DoesNotThrowTestsParameters))]
	public void DoesNotThrowTests(Vector2 circleCenter, float circleRadius)
	{
		Assert.DoesNotThrow(() => CircleCreator.Create(circleCenter, circleRadius));
	}
	
	private static IEnumerable<TestCaseData> AssertThrowTestsParameters()
	{
		var args1 = new object?[] { new Vector2(float.NaN, 10.0f), 9.0f };
		var args2 = new object?[] { new Vector2(20.0f, float.NaN), 9.0f };
		var args3 = new object?[] { new Vector2(20.0f, 10.0f), float.NaN };
		var args4 = new object?[] { new Vector2(float.PositiveInfinity, 10.0f), 9.0f };
		var args5 = new object?[] { new Vector2(20.0f, float.PositiveInfinity), 9.0f };
		var args6 = new object?[] { new Vector2(20.0f, 10.0f), float.PositiveInfinity };
		var args7 = new object?[] { new Vector2(float.NegativeInfinity, 10.0f), 9.0f };
		var args8 = new object?[] { new Vector2(20.0f, float.NegativeInfinity), 9.0f };
		var args9 = new object?[] { new Vector2(20.0f, 10.0f), float.NegativeInfinity };
		var args10 = new object?[] { new Vector2(10.0f, 10.0f), 0.0f };
		var args11 = new object?[] { new Vector2(10.0f, 10.0f), -1.0f };

		yield return new TestCaseData(args1);
		yield return new TestCaseData(args2);
		yield return new TestCaseData(args3);
		yield return new TestCaseData(args4);
		yield return new TestCaseData(args5);
		yield return new TestCaseData(args6);
		yield return new TestCaseData(args7);
		yield return new TestCaseData(args8);
		yield return new TestCaseData(args9);
		yield return new TestCaseData(args10);
		yield return new TestCaseData(args11);
	}
	
	[Test, TestCaseSource(nameof(AssertThrowTestsParameters))]
	public void AssertThrowTests(Vector2 circleCenter, float circleRadius)
	{
		var exception = Assert.Throws<ArithmeticException>(() => CircleCreator.Create(circleCenter, circleRadius));
		Assert.That(exception.Source, Is.EqualTo("Commons.Intersection2D"));
	}
}