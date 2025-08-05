namespace Commons.Tests;

public class FloatExtensionsTests
{
	private static IEnumerable<TestCaseData> EqualToTestsParameters()
	{
		yield return new TestCaseData(10.01f, 10.01f).Returns(true);
		yield return new TestCaseData(10.01f, 10.02f).Returns(false);
		
		yield return new TestCaseData(float.NaN, float.NaN).Returns(false);
		yield return new TestCaseData(float.NegativeInfinity, float.NegativeInfinity).Returns(false);
		yield return new TestCaseData(float.PositiveInfinity, float.PositiveInfinity).Returns(false);
	}
	
	[Test, TestCaseSource(nameof(EqualToTestsParameters))]
	public bool EqualToTests(float a, float b)
	{
		return a.EqualTo(b);
	}
	
	private static IEnumerable<TestCaseData> EqualToToleranceTestsParameters()
	{
		yield return new TestCaseData(10.001f, 10.001f, 0.00001f).Returns(true);
		yield return new TestCaseData(10.001f, 10.002f, 0.01f).Returns(true);
		yield return new TestCaseData(10.001f, 10.002f, 0.00001f).Returns(false);
		yield return new TestCaseData(20.001f, 20.001f, 0.0f).Returns(true);
		
		yield return new TestCaseData(float.NaN, float.NaN, 0.00001f).Returns(false);
		yield return new TestCaseData(float.NegativeInfinity, float.NegativeInfinity, 0.00001f).Returns(false);
		yield return new TestCaseData(float.PositiveInfinity, float.PositiveInfinity, 0.00001f).Returns(false);
	}
	
	[Test, TestCaseSource(nameof(EqualToToleranceTestsParameters))]
	public bool EqualToToleranceTests(float a, float b, float tolerance)
	{
		Settings.SetEqualsTolerance(tolerance);
		var value = a.EqualTo(b);
		Settings.SetEqualsTolerance(0.001f);
		return value;
	}
	
	private static IEnumerable<TestCaseData> SetEqualsTolerance_ExceptionsParameters()
	{
		yield return new TestCaseData(float.NaN);
		yield return new TestCaseData(float.NegativeInfinity);
		yield return new TestCaseData(float.PositiveInfinity);
		yield return new TestCaseData(-0.001f);
	}
	
	[Test, TestCaseSource(nameof(SetEqualsTolerance_ExceptionsParameters))]
	public void SetEqualsTolerance_Exceptions_ReturnException(float tolerance)
	{
		var exception = Assert.Throws<ArithmeticException>(
			() => Settings.SetEqualsTolerance(tolerance)
		);
		Assert.That(exception.Source, Is.EqualTo("Commons"));
	}
}