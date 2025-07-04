using System.Numerics;

namespace Commons.Tests;

public class Vector2ExtensionsTests
{
	private static IEnumerable<TestCaseData> EqualToTestsParameters()
	{
		yield return new TestCaseData(new Vector2(10.01f, 20.01f), new Vector2(10.01f, 20.01f)).Returns(true);
		yield return new TestCaseData(new Vector2(-10.01f, -20.01f), new Vector2(-10.01f, -20.01f)).Returns(true);
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(0.0f, 0.0f)).Returns(true);
		yield return new TestCaseData(new Vector2(-0.0f, -0.0f), new Vector2(-0.0f, -0.0f)).Returns(true);
		yield return new TestCaseData(new Vector2(10.01f, 20.01f), new Vector2(10.02f, 20.01f)).Returns(false);
		yield return new TestCaseData(new Vector2(10.01f, 20.01f), new Vector2(10.01f, 20.02f)).Returns(false);
		yield return new TestCaseData(new Vector2(float.NaN, float.NaN), new Vector2(float.NaN, float.NaN)).Returns(false);
		yield return new TestCaseData(new Vector2(float.NegativeInfinity, float.NegativeInfinity), new Vector2(float.NegativeInfinity, float.NegativeInfinity)).Returns(false);
		yield return new TestCaseData(new Vector2(float.PositiveInfinity, float.PositiveInfinity), new Vector2(float.PositiveInfinity, float.PositiveInfinity)).Returns(false);
	}
	
	[Test, TestCaseSource(nameof(EqualToTestsParameters))]
	public bool EqualToTests(Vector2 vector1, Vector2 vector2)
	{
		return vector1.EqualTo(vector2);
	}
	
	private static IEnumerable<TestCaseData> EqualToToleranceTestsParameters()
	{
		yield return new TestCaseData(new Vector2(10.001f, 20.001f), new Vector2(10.001f, 20.001f), 0.0001f).Returns(true);
		yield return new TestCaseData(new Vector2(-10.001f, -20.001f), new Vector2(-10.001f, -20.001f), 0.0001f).Returns(true);
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(0.0f, 0.0f), 0.0001f).Returns(true);
		yield return new TestCaseData(new Vector2(-0.0f, -0.0f), new Vector2(-0.0f, -0.0f), 0.0001f).Returns(true);
		yield return new TestCaseData(new Vector2(10.001f, 20.001f), new Vector2(10.002f, 20.001f), 0.0001f).Returns(false);
		yield return new TestCaseData(new Vector2(10.001f, 20.001f), new Vector2(10.009f, 20.001f), 0.01f).Returns(true);
		yield return new TestCaseData(new Vector2(10.001f, 20.001f), new Vector2(10.001f, 20.002f), 0.0001f).Returns(false);
		yield return new TestCaseData(new Vector2(10.001f, 20.001f), new Vector2(10.001f, 20.001f), 0.0f).Returns(true);
		yield return new TestCaseData(new Vector2(float.NaN, float.NaN), new Vector2(float.NaN, float.NaN), 0.0001f).Returns(false);
		yield return new TestCaseData(new Vector2(float.NegativeInfinity, float.NegativeInfinity), new Vector2(float.NegativeInfinity, float.NegativeInfinity), 0.0001f).Returns(false);
		yield return new TestCaseData(new Vector2(float.PositiveInfinity, float.PositiveInfinity), new Vector2(float.PositiveInfinity, float.PositiveInfinity), 0.0001f).Returns(false);
	}
	
	[Test, TestCaseSource(nameof(EqualToToleranceTestsParameters))]
	public bool EqualToToleranceTests(Vector2 vector1, Vector2 vector2, float tolerance)
	{
		return vector1.EqualTo(vector2, tolerance);
	}
}