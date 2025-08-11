using Commons.Intersection2D.Shapes;

namespace Commons.Tests.Intersection2D.Shapes;

public class RectangleValidationTests
{
	private static IEnumerable<TestCaseData> DoesNotThrowTestsParameters()
	{
		var rect1 = new[] { 30.0f, 40.0f, 50.0f, 30.0f };
		var rect2 = new[] { -50.0f, -30.0f, -30.0f, -40.0f };
		
		yield return new TestCaseData(rect1);
		yield return new TestCaseData(rect2);
	}
	
	[Test, TestCaseSource(nameof(DoesNotThrowTestsParameters))]
	public void DoesNotThrowTests(float[] rect)
	{
		var rectangle = new CRectangle(rect[0], rect[1], rect[2], rect[3]);
		Assert.DoesNotThrow(() => rectangle.Validate());
	}
	
	private static IEnumerable<TestCaseData> AssertThrowTestsParameters()
	{
		var rect1 = new[] { 30.0f, 40.0f, 20.0f, 30.0f };
		var rect2 = new[] { 30.0f, 20.0f, 50.0f, 30.0f };
		var rect3 = new[] { 20.0f, 20.0f, 20.0f, 20.0f };
		var rect4 = new[] { 20.0f, 40.0f, 20.0f, 30.0f };
		var rect5 = new[] { 30.0f, 30.0f, 50.0f, 30.0f };
		var rect6 = new[] { float.NaN, 40.0f, 40.0f, 30.0f };
		var rect7 = new[] { 30.0f, float.NaN, 40.0f, 30.0f };
		var rect8 = new[] { 30.0f, 40.0f, float.NaN, 30.0f };
		var rect9 = new[] { 30.0f, 40.0f, 40.0f, float.NaN };
		var rect10 = new[] { float.PositiveInfinity, 40.0f, 40.0f, 30.0f };
		var rect11 = new[] { 30.0f, float.PositiveInfinity, 40.0f, 30.0f };
		var rect12 = new[] { 30.0f, 40.0f, float.PositiveInfinity, 30.0f };
		var rect13 = new[] { 30.0f, 40.0f, 40.0f, float.PositiveInfinity };
		var rect14 = new[] { float.NegativeInfinity, 40.0f, 40.0f, 30.0f };
		var rect15 = new[] { 30.0f, float.NegativeInfinity, 40.0f, 30.0f };
		var rect16 = new[] { 30.0f, 40.0f, float.NegativeInfinity, 30.0f };
		var rect17 = new[] { 30.0f, 40.0f, 40.0f, float.NegativeInfinity };
		
		yield return new TestCaseData(rect1);
		yield return new TestCaseData(rect2);
		yield return new TestCaseData(rect3);
		yield return new TestCaseData(rect4);
		yield return new TestCaseData(rect5);
		yield return new TestCaseData(rect6);
		yield return new TestCaseData(rect7);
		yield return new TestCaseData(rect8);
		yield return new TestCaseData(rect9);
		yield return new TestCaseData(rect10);
		yield return new TestCaseData(rect11);
		yield return new TestCaseData(rect12);
		yield return new TestCaseData(rect13);
		yield return new TestCaseData(rect14);
		yield return new TestCaseData(rect15);
		yield return new TestCaseData(rect16);
		yield return new TestCaseData(rect17);
	}
	
	[Test, TestCaseSource(nameof(AssertThrowTestsParameters))]
	public void AssertThrowTests(float[] rect)
	{
		var rectangle = new CRectangle(rect[0], rect[1], rect[2], rect[3]);
		var exception = Assert.Throws<ArithmeticException>(() => rectangle.Validate());
		Assert.That(exception.Source, Is.EqualTo("Commons.Intersection2D"));
	}
}