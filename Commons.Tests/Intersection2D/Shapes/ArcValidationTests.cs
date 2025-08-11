using System.Numerics;
using Commons.Intersection2D.Shapes;

namespace Commons.Tests.Intersection2D.Shapes;

public class ArcValidationTests
{
	private static IEnumerable<TestCaseData> DoesNotThrowTestsParameters()
	{
		var args1 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 19.0f), 180.0f };
		var args2 = new object?[] { new Vector2(-10.0f, -10.0f), new Vector2(10.0f, 19.0f), 180.0f };
		var args3 = new object?[] { new Vector2(0.0f, 0.0f), new Vector2(10.0f, 19.0f), 180.0f };
		var args4 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 19.0f), 180.0f };
		var args5 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(-10.0f, -19.0f), 180.0f };
		var args6 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(0.0f, 0.0f), 180.0f };
		var args7 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(-10.0f, -19.0f), -180.0f };
		
		yield return new TestCaseData(args1);
		yield return new TestCaseData(args2);
		yield return new TestCaseData(args3);
		yield return new TestCaseData(args4);
		yield return new TestCaseData(args5);
		yield return new TestCaseData(args6);
		yield return new TestCaseData(args7);
	}
	
	[Test, TestCaseSource(nameof(DoesNotThrowTestsParameters))]
	public void DoesNotThrowTests(Vector2 arcCenter, Vector2 arcPoint, float arcAngleDeg)
	{
		var arc = new CArc(arcCenter, arcPoint, arcAngleDeg);
		Assert.DoesNotThrow(() => arc.Validate());
	}
	
	private static IEnumerable<TestCaseData> AssertThrowTestsParameters()
	{
		var args1 = new object?[] { new Vector2(float.NaN, 10.0f), new Vector2(10.0f, 19.0f), 180.0f };
		var args2 = new object?[] { new Vector2(10.0f, float.NaN), new Vector2(10.0f, 19.0f), 180.0f };
		var args3 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(float.NaN, 19.0f), 180.0f };
		var args4 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, float.NaN), 180.0f };
		var args5 = new object?[] { new Vector2(float.PositiveInfinity, 10.0f), new Vector2(10.0f, 19.0f), 180.0f };
		var args6 = new object?[] { new Vector2(10.0f, float.PositiveInfinity), new Vector2(10.0f, 19.0f), 180.0f };
		var args7 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(float.PositiveInfinity, 19.0f), 180.0f };
		var args8 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, float.PositiveInfinity), 180.0f };
		var args9 = new object?[] { new Vector2(float.NegativeInfinity, 10.0f), new Vector2(10.0f, 19.0f), 180.0f, };
		var args10 = new object?[] { new Vector2(10.0f, float.NegativeInfinity), new Vector2(10.0f, 19.0f), 180.0f };
		var args11 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(float.NegativeInfinity, 19.0f), 180.0f };
		var args12 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, float.NegativeInfinity), 180.0f };
		var args13 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 19.0f), float.NaN };
		var args14 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 19.0f), float.PositiveInfinity };
		var args15 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 19.0f), float.NegativeInfinity };
		var args16 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 19.0f), 361.0f };
		var args17 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 19.0f), -361.0f };
		var args18 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 10.0f), 180.0f };
		var args19 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 19.0f), 0.0f };
		var args20 = new object?[] { new Vector2(10.0f, 10.0f), new Vector2(10.0f, 19.0f), 360.0f };

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
		yield return new TestCaseData(args12);
		yield return new TestCaseData(args13);
		yield return new TestCaseData(args14);
		yield return new TestCaseData(args15);
		yield return new TestCaseData(args16);
		yield return new TestCaseData(args17);
		yield return new TestCaseData(args18);
		yield return new TestCaseData(args19);
		yield return new TestCaseData(args20);
	}
	
	[Test, TestCaseSource(nameof(AssertThrowTestsParameters))]
	public void AssertThrowTests(Vector2 arcCenter, Vector2 arcPoint, float arcAngleDeg)
	{
		var arc = new CArc(arcCenter, arcPoint, arcAngleDeg);
		var exception = Assert.Throws<ArithmeticException>(() => arc.Validate());
		Assert.That(exception.Source, Is.EqualTo("Commons.Intersection2D"));
	}
}