using System.Numerics;
using Commons.Math2D;

namespace Commons.Tests;

// TODO: rework to TestCaseData.Returns
public class Vector2UtilsTests
{
	private const float EqualityPrecision = 0.00001f;
	
	private static IEnumerable<TestCaseData> RotateRadTestsParameters()
	{
		yield return new TestCaseData(0.0f, new Vector2(1.0f, 0.0f));
		yield return new TestCaseData(MathF.PI / 2.0f, new Vector2(0.0f, 1.0f));
		yield return new TestCaseData(MathF.PI, new Vector2(-1.0f, 0.0f));
		yield return new TestCaseData(MathF.PI * 3.0f / 2.0f, new Vector2(0.0f, -1.0f));
		yield return new TestCaseData(2 * MathF.PI, new Vector2(1.0f, 0.0f));
		yield return new TestCaseData(MathF.PI / 4.0f, new Vector2(0.70710677f, 0.70710677f));
		yield return new TestCaseData(MathF.PI * 3.0f / 4.0f, new Vector2(-0.70710677f, 0.70710677f));
		yield return new TestCaseData(-MathF.PI / 2.0f, new Vector2(0.0f, -1.0f));
	}
	
	[Test, TestCaseSource(nameof(RotateRadTestsParameters))]
	public void RotateRadTests(float radians, Vector2 expectedVector)
	{
		var actualVector = Vector2Utils.RotateRad(radians);
		var actual = actualVector.EqualTo(expectedVector, EqualityPrecision);
		Assert.That(actual, Is.True, $"{"Expected:", 9} {expectedVector}\n{"Actual:", 9} {actualVector}");
	}
	
	private static IEnumerable<TestCaseData> RotateRadSpecialCasesTestsParameters()
	{
		yield return new TestCaseData(float.NaN);
		yield return new TestCaseData(float.NegativeInfinity);
		yield return new TestCaseData(float.PositiveInfinity);
	}
	
	[Test, TestCaseSource(nameof(RotateRadSpecialCasesTestsParameters))]
	public void RotateRad_SpecialCases_ReturnNaN(float radians)
	{
		var actualVector = Vector2Utils.RotateRad(radians);
		var actual = Vector2Utils.IsNaN(actualVector);
		Assert.That(actual, Is.True);
	}
	
	private static IEnumerable<TestCaseData> RotateVectorRadTestsParameters()
	{
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), 0.0f, new Vector2(1.0f, 0.0f));
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), MathF.PI / 2.0f, new Vector2(0.0f, 1.0f));
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), MathF.PI, new Vector2(-1.0f, 0.0f));
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), MathF.PI * 3.0f / 2.0f, new Vector2(0.0f, -1.0f));
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), 2 * MathF.PI, new Vector2(1.0f, 0.0f));
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), MathF.PI / 4.0f, new Vector2(0.70710677f, 0.70710677f));
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), MathF.PI * 3.0f / 4.0f, new Vector2(-0.70710677f, 0.70710677f));
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), -MathF.PI / 2.0f, new Vector2(0.0f, -1.0f));
		yield return new TestCaseData(new Vector2(2.0f, 0.0f), MathF.PI / 2.0f, new Vector2(0.0f, 2.0f));
		
		yield return new TestCaseData(new Vector2(0.70710677f, 0.70710677f), 0.0f, new Vector2(0.70710677f, 0.70710677f));
		yield return new TestCaseData(new Vector2(0.70710677f, 0.70710677f), MathF.PI / 2.0f, new Vector2(-0.70710677f, 0.70710677f));
		yield return new TestCaseData(new Vector2(0.70710677f, 0.70710677f), MathF.PI, new Vector2(-0.70710677f, -0.70710677f));
		yield return new TestCaseData(new Vector2(0.70710677f, 0.70710677f), MathF.PI * 3.0f / 2.0f, new Vector2(0.70710677f, -0.70710677f));
		yield return new TestCaseData(new Vector2(0.70710677f, 0.70710677f), 2 * MathF.PI, new Vector2(0.70710677f, 0.70710677f));
		yield return new TestCaseData(new Vector2(0.70710677f, 0.70710677f), MathF.PI / 4.0f, new Vector2(0.0f, 1.0f));
		yield return new TestCaseData(new Vector2(0.70710677f, 0.70710677f), MathF.PI * 3.0f / 4.0f, new Vector2(-1.0f, 0.0f));
		yield return new TestCaseData(new Vector2(0.70710677f, 0.70710677f), -MathF.PI / 2.0f, new Vector2(0.70710677f, -0.70710677f));
		
		yield return new TestCaseData(new Vector2(-0.70710677f, -0.70710677f), 0.0f, new Vector2(-0.70710677f, -0.70710677f));
		yield return new TestCaseData(new Vector2(-0.70710677f, -0.70710677f), MathF.PI / 2.0f, new Vector2(0.70710677f, -0.70710677f));
		yield return new TestCaseData(new Vector2(-0.70710677f, -0.70710677f), MathF.PI, new Vector2(0.70710677f, 0.70710677f));
		yield return new TestCaseData(new Vector2(-0.70710677f, -0.70710677f), MathF.PI * 3.0f / 2.0f, new Vector2(-0.70710677f, 0.70710677f));
		yield return new TestCaseData(new Vector2(-0.70710677f, -0.70710677f), 2 * MathF.PI, new Vector2(-0.70710677f, -0.70710677f));
		yield return new TestCaseData(new Vector2(-0.70710677f, -0.70710677f), MathF.PI / 4.0f, new Vector2(0.0f, -1.0f));
		yield return new TestCaseData(new Vector2(-0.70710677f, -0.70710677f), MathF.PI * 3.0f / 4.0f, new Vector2(1.0f, 0.0f));
		yield return new TestCaseData(new Vector2(-0.70710677f, -0.70710677f), -MathF.PI / 2.0f, new Vector2(-0.70710677f, 0.70710677f));
	}
	
	[Test, TestCaseSource(nameof(RotateVectorRadTestsParameters))]
	public void RotateVectorRadTests(Vector2 initialVector, float radians, Vector2 expectedVector)
	{
		var actualVector = Vector2Utils.RotateRad(initialVector, radians);
		var actual = actualVector.EqualTo(expectedVector, EqualityPrecision);
		Assert.That(actual, Is.True, $"{"Expected:", 9} {expectedVector}\n{"Actual:", 9} {actualVector}");
	}
	
	private static IEnumerable<TestCaseData> RotateVectorRadSpecialCasesTestsParameters()
	{
		yield return new TestCaseData(new Vector2(float.NaN, 0.0f), 0.0f);
		yield return new TestCaseData(new Vector2(0.0f, float.NaN), 0.0f);
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), float.NaN);
		yield return new TestCaseData(new Vector2(float.PositiveInfinity, 0.0f), 0.0f);
		yield return new TestCaseData(new Vector2(0.0f, float.PositiveInfinity), 0.0f);
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), float.PositiveInfinity);
		yield return new TestCaseData(new Vector2(float.NegativeInfinity, 0.0f), 0.0f);
		yield return new TestCaseData(new Vector2(0.0f, float.NegativeInfinity), 0.0f);
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), float.NegativeInfinity);
	}
	
	[Test, TestCaseSource(nameof(RotateVectorRadSpecialCasesTestsParameters))]
	public void RotateVectorRadSpecialCasesTests(Vector2 initialVector, float radians)
	{
		var actualVector = Vector2Utils.RotateRad(initialVector, radians);
		var actual = Vector2Utils.IsNaN(actualVector);
		Assert.That(actual, Is.True, $"{"Expected:", 9} {Vector2Utils.NaN()}\n{"Actual:", 9} {actualVector}");
	}
	
	private static IEnumerable<TestCaseData> RotateDegTestsParameters()
	{
		yield return new TestCaseData(0.0f, new Vector2(1.0f, 0.0f));
		yield return new TestCaseData(90.0f, new Vector2(0.0f, 1.0f));
		yield return new TestCaseData(180.0f, new Vector2(-1.0f, 0.0f));
		yield return new TestCaseData(270.0f, new Vector2(0.0f, -1.0f));
		yield return new TestCaseData(360.0f, new Vector2(1.0f, 0.0f));
		yield return new TestCaseData(45.0f, new Vector2(0.70710677f, 0.70710677f));
		yield return new TestCaseData(135.0f, new Vector2(-0.70710677f, 0.70710677f));
		yield return new TestCaseData(-90.0f, new Vector2(0.0f, -1.0f));
	}
	
	[Test, TestCaseSource(nameof(RotateDegTestsParameters))]
	public void RotateDegTests(float degrees, Vector2 expectedVector)
	{
		var actualVector = Vector2Utils.RotateDeg(degrees);
		var actual = actualVector.EqualTo(expectedVector, EqualityPrecision);
		Assert.That(actual, Is.True, $"{"Expected:", 9} {expectedVector}\n{"Actual:", 9} {actualVector}");
	}
	
#pragma warning disable S4144 // Methods should not have identical implementations
	private static IEnumerable<TestCaseData> RotateDegSpecialCasesTestsParameters()
	{
		yield return new TestCaseData(float.NaN);
		yield return new TestCaseData(float.NegativeInfinity);
		yield return new TestCaseData(float.PositiveInfinity);
	}
#pragma warning restore S4144 // Methods should not have identical implementations
	
	[Test, TestCaseSource(nameof(RotateDegSpecialCasesTestsParameters))]
	public void RotateDeg_SpecialCases_ReturnNaN(float degrees)
	{
		var actualVector = Vector2Utils.RotateDeg(degrees);
		var actual = Vector2Utils.IsNaN(actualVector);
		Assert.That(actual, Is.True);
	}
	
	private static IEnumerable<TestCaseData> RotateVectorDegTestsParameters()
	{
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), 0.0f, new Vector2(1.0f, 0.0f));
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), 90.0f, new Vector2(0.0f, 1.0f));
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), 180.0f, new Vector2(-1.0f, 0.0f));
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), 270.0f, new Vector2(0.0f, -1.0f));
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), 360.0f, new Vector2(1.0f, 0.0f));
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), 45.0f, new Vector2(0.70710677f, 0.70710677f));
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), 135.0f, new Vector2(-0.70710677f, 0.70710677f));
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), -90.0f, new Vector2(0.0f, -1.0f));
		yield return new TestCaseData(new Vector2(2.0f, 0.0f), 90.0f, new Vector2(0.0f, 2.0f));
		
		yield return new TestCaseData(new Vector2(0.70710677f, 0.70710677f), 0.0f, new Vector2(0.70710677f, 0.70710677f));
		yield return new TestCaseData(new Vector2(0.70710677f, 0.70710677f), 90.0f, new Vector2(-0.70710677f, 0.70710677f));
		yield return new TestCaseData(new Vector2(0.70710677f, 0.70710677f), 180.0f, new Vector2(-0.70710677f, -0.70710677f));
		yield return new TestCaseData(new Vector2(0.70710677f, 0.70710677f), 270.0f, new Vector2(0.70710677f, -0.70710677f));
		yield return new TestCaseData(new Vector2(0.70710677f, 0.70710677f), 360.0f, new Vector2(0.70710677f, 0.70710677f));
		yield return new TestCaseData(new Vector2(0.70710677f, 0.70710677f), 45.0f, new Vector2(0.0f, 1.0f));
		yield return new TestCaseData(new Vector2(0.70710677f, 0.70710677f), 135.0f, new Vector2(-1.0f, 0.0f));
		yield return new TestCaseData(new Vector2(0.70710677f, 0.70710677f), -90.0f, new Vector2(0.70710677f, -0.70710677f));
		
		yield return new TestCaseData(new Vector2(-0.70710677f, -0.70710677f), 0.0f, new Vector2(-0.70710677f, -0.70710677f));
		yield return new TestCaseData(new Vector2(-0.70710677f, -0.70710677f), 90.0f, new Vector2(0.70710677f, -0.70710677f));
		yield return new TestCaseData(new Vector2(-0.70710677f, -0.70710677f), 180.0f, new Vector2(0.70710677f, 0.70710677f));
		yield return new TestCaseData(new Vector2(-0.70710677f, -0.70710677f), 270.0f, new Vector2(-0.70710677f, 0.70710677f));
		yield return new TestCaseData(new Vector2(-0.70710677f, -0.70710677f), 360.0f, new Vector2(-0.70710677f, -0.70710677f));
		yield return new TestCaseData(new Vector2(-0.70710677f, -0.70710677f), 45.0f, new Vector2(0.0f, -1.0f));
		yield return new TestCaseData(new Vector2(-0.70710677f, -0.70710677f), 135.0f, new Vector2(1.0f, 0.0f));
		yield return new TestCaseData(new Vector2(-0.70710677f, -0.70710677f), -90.0f, new Vector2(-0.70710677f, 0.70710677f));
	}
	
	[Test, TestCaseSource(nameof(RotateVectorDegTestsParameters))]
	public void RotateVectorDegTests(Vector2 initialVector, float degrees, Vector2 expectedVector)
	{
		var actualVector = Vector2Utils.RotateDeg(initialVector, degrees);
		var actual = actualVector.EqualTo(expectedVector, EqualityPrecision);
		Assert.That(actual, Is.True, $"{"Expected:", 9} {expectedVector}\n{"Actual:", 9} {actualVector}");
	}
	
#pragma warning disable S4144 // Methods should not have identical implementations
	private static IEnumerable<TestCaseData> RotateVectorDegSpecialCasesTestsParameters()
	{
		yield return new TestCaseData(new Vector2(float.NaN, 0.0f), 0.0f);
		yield return new TestCaseData(new Vector2(0.0f, float.NaN), 0.0f);
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), float.NaN);
		yield return new TestCaseData(new Vector2(float.PositiveInfinity, 0.0f), 0.0f);
		yield return new TestCaseData(new Vector2(0.0f, float.PositiveInfinity), 0.0f);
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), float.PositiveInfinity);
		yield return new TestCaseData(new Vector2(float.NegativeInfinity, 0.0f), 0.0f);
		yield return new TestCaseData(new Vector2(0.0f, float.NegativeInfinity), 0.0f);
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), float.NegativeInfinity);
	}
#pragma warning restore S4144 // Methods should not have identical implementations
	
	[Test, TestCaseSource(nameof(RotateVectorDegSpecialCasesTestsParameters))]
	public void RotateVectorDegSpecialCasesTests(Vector2 initialVector, float degrees)
	{
		var actualVector = Vector2Utils.RotateDeg(initialVector, degrees);
		var actual = Vector2Utils.IsNaN(actualVector);
		Assert.That(actual, Is.True);
	}
	
	private static IEnumerable<TestCaseData> SignedAngleRadTestsParameters()
	{
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(1.0f, 0.0f), 0.0f);
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(0.0f, 1.0f), MathF.PI / 2.0f);
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(-1.0f, 0.0f), MathF.PI);
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(0.0f, -1.0f), -MathF.PI / 2.0f);
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(0.70710677f, 0.70710677f), MathF.PI / 4.0f);
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(-0.70710677f, 0.70710677f), MathF.PI * 3.0f / 4.0f);
		
		yield return new TestCaseData(new Vector2(0.0f, 1.0f), new Vector2(1.0f, 0.0f), -MathF.PI / 2.0f);
		yield return new TestCaseData(new Vector2(-1.0f, 0.0f), new Vector2(1.0f, 0.0f), MathF.PI);
		yield return new TestCaseData(new Vector2(0.0f, -1.0f), new Vector2(1.0f, 0.0f), MathF.PI / 2.0f);
		yield return new TestCaseData(new Vector2(2.0f, 0.0f), new Vector2(0.0f, 2.0f), MathF.PI / 2.0f);
		yield return new TestCaseData(new Vector2(0.70710677f, 0.70710677f), new Vector2(1.0f, 0.0f), -MathF.PI / 4.0f);
		yield return new TestCaseData(new Vector2(-0.70710677f, 0.70710677f), new Vector2(1.0f, 0.0f), -MathF.PI * 3.0f / 4.0f);
	}
	
	[Test, TestCaseSource(nameof(SignedAngleRadTestsParameters))]
	public void SignedAngleRadTests(Vector2 vector1, Vector2 vector2, float expectedAngle)
	{
		var actualAngle = Vector2Utils.SignedAngleRad(vector1, vector2);
		var actual = actualAngle.EqualTo(expectedAngle);
		Assert.That(actual, Is.True, $"{"Expected:", 9} {expectedAngle:F2}\n{"Actual:", 9} {actualAngle:F2}");
	}
	
#pragma warning disable S4144 // Methods should not have identical implementations
	private static IEnumerable<TestCaseData> SignedAngleRadSpecialCasesTestsParameters()
	{
		yield return new TestCaseData(new Vector2(float.NaN, 0.0f), new Vector2(0.0f, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, float.NaN), new Vector2(0.0f, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(float.NaN, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(0.0f, float.NaN));
		
		yield return new TestCaseData(new Vector2(float.PositiveInfinity, 0.0f), new Vector2(0.0f, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, float.PositiveInfinity), new Vector2(0.0f, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(float.PositiveInfinity, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(0.0f, float.PositiveInfinity));
		
		yield return new TestCaseData(new Vector2(float.NegativeInfinity, 0.0f), new Vector2(0.0f, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, float.NegativeInfinity), new Vector2(0.0f, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(float.NegativeInfinity, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(0.0f, float.NegativeInfinity));
	}
#pragma warning restore S4144 // Methods should not have identical implementations
	
	[Test, TestCaseSource(nameof(SignedAngleRadSpecialCasesTestsParameters))]
	public void SignedAngleRadSpecialCasesTests(Vector2 vector1, Vector2 vector2)
	{
		var actualAngle = Vector2Utils.SignedAngleRad(vector1, vector2);
		var actual = float.IsNaN(actualAngle);
		Assert.That(actual, Is.True);
	}
	
	private static IEnumerable<TestCaseData> SignedAngleDegTestsParameters()
	{
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(1.0f, 0.0f), 0.0f);
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(0.0f, 1.0f), 90.0f);
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(-1.0f, 0.0f), 180.0f);
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(0.0f, -1.0f), -90.0f);
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(0.70710677f, 0.70710677f), 45.0f);
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(-0.70710677f, 0.70710677f), 135.0f);
		
		yield return new TestCaseData(new Vector2(0.0f, 1.0f), new Vector2(1.0f, 0.0f), -90.0f);
		yield return new TestCaseData(new Vector2(-1.0f, 0.0f), new Vector2(1.0f, 0.0f), 180.0f);
		yield return new TestCaseData(new Vector2(0.0f, -1.0f), new Vector2(1.0f, 0.0f), 90.0f);
		yield return new TestCaseData(new Vector2(2.0f, 0.0f), new Vector2(0.0f, 2.0f), 90.0f);
		yield return new TestCaseData(new Vector2(0.70710677f, 0.70710677f), new Vector2(1.0f, 0.0f), -45.0f);
		yield return new TestCaseData(new Vector2(-0.70710677f, 0.70710677f), new Vector2(1.0f, 0.0f), -135.0f);
	}
	
	[Test, TestCaseSource(nameof(SignedAngleDegTestsParameters))]
	public void SignedAngleDegTests(Vector2 vector1, Vector2 vector2, float expectedAngle)
	{
		var actualAngle = Vector2Utils.SignedAngleDeg(vector1, vector2);
		var actual = actualAngle.EqualTo(expectedAngle);
		Assert.That(actual, Is.True, $"{"Expected:", 9} {expectedAngle:F2}\n{"Actual:", 9} {actualAngle:F2}");
	}
	
#pragma warning disable S4144 // Methods should not have identical implementations
	private static IEnumerable<TestCaseData> SignedAngleDegSpecialCasesTestsParameters()
	{
		yield return new TestCaseData(new Vector2(float.NaN, 0.0f), new Vector2(0.0f, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, float.NaN), new Vector2(0.0f, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(float.NaN, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(0.0f, float.NaN));
		
		yield return new TestCaseData(new Vector2(float.PositiveInfinity, 0.0f), new Vector2(0.0f, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, float.PositiveInfinity), new Vector2(0.0f, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(float.PositiveInfinity, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(0.0f, float.PositiveInfinity));
		
		yield return new TestCaseData(new Vector2(float.NegativeInfinity, 0.0f), new Vector2(0.0f, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, float.NegativeInfinity), new Vector2(0.0f, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(float.NegativeInfinity, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(0.0f, float.NegativeInfinity));
	}
#pragma warning restore S4144 // Methods should not have identical implementations
	
	[Test, TestCaseSource(nameof(SignedAngleDegSpecialCasesTestsParameters))]
	public void SignedAngleDegSpecialCasesTests(Vector2 vector1, Vector2 vector2)
	{
		var actualAngle = Vector2Utils.SignedAngleDeg(vector1, vector2);
		var actual = float.IsNaN(actualAngle);
		Assert.That(actual, Is.True);
	}
	
	private static IEnumerable<TestCaseData> AngleRadTestsParameters()
	{
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(1.0f, 0.0f), 0.0f);
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(0.0f, 1.0f), MathF.PI / 2.0f);
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(-1.0f, 0.0f), MathF.PI);
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(0.0f, -1.0f), MathF.PI / 2.0f);
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(0.70710677f, 0.70710677f), MathF.PI / 4.0f);
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(-0.70710677f, 0.70710677f), MathF.PI * 3.0f / 4.0f);
		
		yield return new TestCaseData(new Vector2(0.0f, 1.0f), new Vector2(1.0f, 0.0f), MathF.PI / 2.0f);
		yield return new TestCaseData(new Vector2(-1.0f, 0.0f), new Vector2(1.0f, 0.0f), MathF.PI);
		yield return new TestCaseData(new Vector2(0.0f, -1.0f), new Vector2(1.0f, 0.0f), MathF.PI / 2.0f);
		yield return new TestCaseData(new Vector2(2.0f, 0.0f), new Vector2(0.0f, 2.0f), MathF.PI / 2.0f);
		yield return new TestCaseData(new Vector2(0.70710677f, 0.70710677f), new Vector2(1.0f, 0.0f), MathF.PI / 4.0f);
		yield return new TestCaseData(new Vector2(-0.70710677f, 0.70710677f), new Vector2(1.0f, 0.0f), MathF.PI * 3.0f / 4.0f);
	}
	
	[Test, TestCaseSource(nameof(AngleRadTestsParameters))]
	public void AngleRadTests(Vector2 vector1, Vector2 vector2, float expectedAngle)
	{
		var actualAngle = Vector2Utils.AngleRad(vector1, vector2);
		var actual = actualAngle.EqualTo(expectedAngle);
		Assert.That(actual, Is.True, $"{"Expected:", 9} {expectedAngle:F2}\n{"Actual:", 9} {actualAngle:F2}");
	}
	
#pragma warning disable S4144 // Methods should not have identical implementations
	private static IEnumerable<TestCaseData> AngleRadSpecialCasesTestsParameters()
	{
		yield return new TestCaseData(new Vector2(float.NaN, 0.0f), new Vector2(0.0f, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, float.NaN), new Vector2(0.0f, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(float.NaN, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(0.0f, float.NaN));
		
		yield return new TestCaseData(new Vector2(float.PositiveInfinity, 0.0f), new Vector2(0.0f, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, float.PositiveInfinity), new Vector2(0.0f, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(float.PositiveInfinity, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(0.0f, float.PositiveInfinity));
		
		yield return new TestCaseData(new Vector2(float.NegativeInfinity, 0.0f), new Vector2(0.0f, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, float.NegativeInfinity), new Vector2(0.0f, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(float.NegativeInfinity, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(0.0f, float.NegativeInfinity));
	}
#pragma warning restore S4144 // Methods should not have identical implementations
	
	[Test, TestCaseSource(nameof(AngleRadSpecialCasesTestsParameters))]
	public void AngleRadSpecialCasesTests(Vector2 vector1, Vector2 vector2)
	{
		var actualAngle = Vector2Utils.AngleRad(vector1, vector2);
		var actual = float.IsNaN(actualAngle);
		Assert.That(actual, Is.True);
	}
	
	private static IEnumerable<TestCaseData> AngleDegTestsParameters()
	{
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(1.0f, 0.0f), 0.0f);
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(0.0f, 1.0f), 90.0f);
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(-1.0f, 0.0f), 180.0f);
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(0.0f, -1.0f), 90.0f);
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(0.70710677f, 0.70710677f), 45.0f);
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(-0.70710677f, 0.70710677f), 135.0f);
		
		yield return new TestCaseData(new Vector2(0.0f, 1.0f), new Vector2(1.0f, 0.0f), 90.0f);
		yield return new TestCaseData(new Vector2(-1.0f, 0.0f), new Vector2(1.0f, 0.0f), 180.0f);
		yield return new TestCaseData(new Vector2(0.0f, -1.0f), new Vector2(1.0f, 0.0f), 90.0f);
		yield return new TestCaseData(new Vector2(2.0f, 0.0f), new Vector2(0.0f, 2.0f), 90.0f);
		yield return new TestCaseData(new Vector2(0.70710677f, 0.70710677f), new Vector2(1.0f, 0.0f), 45.0f);
		yield return new TestCaseData(new Vector2(-0.70710677f, 0.70710677f), new Vector2(1.0f, 0.0f), 135.0f);
	}
	
	[Test, TestCaseSource(nameof(AngleDegTestsParameters))]
	public void AngleDegTests(Vector2 vector1, Vector2 vector2, float expectedAngle)
	{
		var actualAngle = Vector2Utils.AngleDeg(vector1, vector2);
		var actual = actualAngle.EqualTo(expectedAngle);
		Assert.That(actual, Is.True, $"{"Expected:", 9} {expectedAngle:F2}\n{"Actual:", 9} {actualAngle:F2}");
	}
	
#pragma warning disable S4144 // Methods should not have identical implementations
	private static IEnumerable<TestCaseData> AngleDegSpecialCasesTestsParameters()
	{
		yield return new TestCaseData(new Vector2(float.NaN, 0.0f), new Vector2(0.0f, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, float.NaN), new Vector2(0.0f, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(float.NaN, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(0.0f, float.NaN));
		
		yield return new TestCaseData(new Vector2(float.PositiveInfinity, 0.0f), new Vector2(0.0f, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, float.PositiveInfinity), new Vector2(0.0f, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(float.PositiveInfinity, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(0.0f, float.PositiveInfinity));
		
		yield return new TestCaseData(new Vector2(float.NegativeInfinity, 0.0f), new Vector2(0.0f, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, float.NegativeInfinity), new Vector2(0.0f, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(float.NegativeInfinity, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(0.0f, float.NegativeInfinity));
	}
#pragma warning restore S4144 // Methods should not have identical implementations
	
	[Test, TestCaseSource(nameof(AngleDegSpecialCasesTestsParameters))]
	public void AngleDegSpecialCasesTests(Vector2 vector1, Vector2 vector2)
	{
		var actualAngle = Vector2Utils.AngleDeg(vector1, vector2);
		var actual = float.IsNaN(actualAngle);
		Assert.That(actual, Is.True);
	}
	
private static IEnumerable<TestCaseData> SignedAngleRad360TestsParameters()
	{
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(1.0f, 0.0f), Direction.Clockwise, 0.0f);
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(0.0f, 1.0f), Direction.Clockwise, MathF.PI * 3.0f / 2.0f);
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(-1.0f, 0.0f), Direction.Clockwise, MathF.PI);
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(0.0f, -1.0f), Direction.Clockwise, MathF.PI / 2.0f);
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(0.70710677f, 0.70710677f), Direction.Clockwise, MathF.PI * 3.5f / 2.0f);
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(0.70710677f, -0.70710677f), Direction.Clockwise, MathF.PI / 4.0f);
		
		yield return new TestCaseData(new Vector2(0.0f, 1.0f), new Vector2(1.0f, 0.0f), Direction.Clockwise, MathF.PI / 2.0f);
		yield return new TestCaseData(new Vector2(-1.0f, 0.0f), new Vector2(1.0f, 0.0f), Direction.Clockwise, MathF.PI);
		yield return new TestCaseData(new Vector2(0.0f, -1.0f), new Vector2(1.0f, 0.0f), Direction.Clockwise, MathF.PI * 3.0f / 2.0f);
		yield return new TestCaseData(new Vector2(2.0f, 0.0f), new Vector2(0.0f, 2.0f), Direction.Clockwise, MathF.PI * 3.0f / 2.0f);
		yield return new TestCaseData(new Vector2(0.70710677f, 0.70710677f), new Vector2(1.0f, 0.0f), Direction.Clockwise, MathF.PI / 4.0f);
		yield return new TestCaseData(new Vector2(0.70710677f, -0.70710677f), new Vector2(1.0f, 0.0f), Direction.Clockwise, MathF.PI * 3.5f / 2.0f);
		
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(1.0f, 0.0f), Direction.Counterclockwise, 0.0f);
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(0.0f, 1.0f), Direction.Counterclockwise, -MathF.PI / 2.0f);
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(-1.0f, 0.0f), Direction.Counterclockwise, -MathF.PI);
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(0.0f, -1.0f), Direction.Counterclockwise, -MathF.PI * 3.0f / 2.0f);
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(0.70710677f, 0.70710677f), Direction.Counterclockwise, -MathF.PI / 4.0f);
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(0.70710677f, -0.70710677f), Direction.Counterclockwise, -MathF.PI * 3.5f / 2.0f);
		
		yield return new TestCaseData(new Vector2(0.0f, 1.0f), new Vector2(1.0f, 0.0f), Direction.Counterclockwise, -MathF.PI * 3.0f / 2.0f);
		yield return new TestCaseData(new Vector2(-1.0f, 0.0f), new Vector2(1.0f, 0.0f), Direction.Counterclockwise, -MathF.PI);
		yield return new TestCaseData(new Vector2(0.0f, -1.0f), new Vector2(1.0f, 0.0f), Direction.Counterclockwise, -MathF.PI / 2.0f);
		yield return new TestCaseData(new Vector2(2.0f, 0.0f), new Vector2(0.0f, 2.0f), Direction.Counterclockwise, -MathF.PI / 2.0f);
		yield return new TestCaseData(new Vector2(0.70710677f, 0.70710677f), new Vector2(1.0f, 0.0f), Direction.Counterclockwise, -MathF.PI * 3.5f / 2.0f);
		yield return new TestCaseData(new Vector2(0.70710677f, -0.70710677f), new Vector2(1.0f, 0.0f), Direction.Counterclockwise, -MathF.PI / 4.0f);
	}
	
	[Test, TestCaseSource(nameof(SignedAngleRad360TestsParameters))]
	public void SignedAngleRad360Tests(Vector2 vector1, Vector2 vector2, Direction direction, float expectedAngle)
	{
		var actualAngle = Vector2Utils.SignedAngleRad360(vector1, vector2, direction);
		var actual = actualAngle.EqualTo(expectedAngle, EqualityPrecision);
		Assert.That(actual, Is.True, $"{"Expected:", 9} {expectedAngle:F2}\n{"Actual:", 9} {actualAngle:F2}");
	}
	
#pragma warning disable S4144 // Methods should not have identical implementations
	private static IEnumerable<TestCaseData> SignedAngleRad360SpecialCasesTestsParameters()
	{
		yield return new TestCaseData(new Vector2(float.NaN, 0.0f), new Vector2(0.0f, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, float.NaN), new Vector2(0.0f, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(float.NaN, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(0.0f, float.NaN));
		
		yield return new TestCaseData(new Vector2(float.PositiveInfinity, 0.0f), new Vector2(0.0f, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, float.PositiveInfinity), new Vector2(0.0f, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(float.PositiveInfinity, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(0.0f, float.PositiveInfinity));
		
		yield return new TestCaseData(new Vector2(float.NegativeInfinity, 0.0f), new Vector2(0.0f, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, float.NegativeInfinity), new Vector2(0.0f, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(float.NegativeInfinity, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(0.0f, float.NegativeInfinity));
	}
#pragma warning restore S4144 // Methods should not have identical implementations
	
	[Test, TestCaseSource(nameof(SignedAngleRad360SpecialCasesTestsParameters))]
	public void SignedAngleRad360SpecialCasesTests(Vector2 vector1, Vector2 vector2)
	{
		var actualAngle = Vector2Utils.SignedAngleRad360(vector1, vector2, Direction.Clockwise);
		var actual = float.IsNaN(actualAngle);
		Assert.That(actual, Is.True);
	}
	
	private static IEnumerable<TestCaseData> SignedAngleDeg360TestsParameters()
	{
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(1.0f, 0.0f), Direction.Clockwise, 0.0f);
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(0.0f, 1.0f), Direction.Clockwise, 270.0f);
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(-1.0f, 0.0f), Direction.Clockwise, 180.0f);
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(0.0f, -1.0f), Direction.Clockwise, 90.0f);
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(0.70710677f, 0.70710677f), Direction.Clockwise, 315.0f);
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(0.70710677f, -0.70710677f), Direction.Clockwise, 45.0f);
		
		yield return new TestCaseData(new Vector2(0.0f, 1.0f), new Vector2(1.0f, 0.0f), Direction.Clockwise, 90.0f);
		yield return new TestCaseData(new Vector2(-1.0f, 0.0f), new Vector2(1.0f, 0.0f), Direction.Clockwise, 180.0f);
		yield return new TestCaseData(new Vector2(0.0f, -1.0f), new Vector2(1.0f, 0.0f), Direction.Clockwise, 270.0f);
		yield return new TestCaseData(new Vector2(2.0f, 0.0f), new Vector2(0.0f, 2.0f), Direction.Clockwise, 270.0f);
		yield return new TestCaseData(new Vector2(0.70710677f, 0.70710677f), new Vector2(1.0f, 0.0f), Direction.Clockwise, 45.0f);
		yield return new TestCaseData(new Vector2(0.70710677f, -0.70710677f), new Vector2(1.0f, 0.0f), Direction.Clockwise, 315.0f);
		
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(1.0f, 0.0f), Direction.Counterclockwise, 0.0f);
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(0.0f, 1.0f), Direction.Counterclockwise, -90.0f);
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(-1.0f, 0.0f), Direction.Counterclockwise, -180.0f);
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(0.0f, -1.0f), Direction.Counterclockwise, -270.0f);
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(0.70710677f, 0.70710677f), Direction.Counterclockwise, -45.0f);
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(0.70710677f, -0.70710677f), Direction.Counterclockwise, -315.0f);
		
		yield return new TestCaseData(new Vector2(0.0f, 1.0f), new Vector2(1.0f, 0.0f), Direction.Counterclockwise, -270.0f);
		yield return new TestCaseData(new Vector2(-1.0f, 0.0f), new Vector2(1.0f, 0.0f), Direction.Counterclockwise, -180.0f);
		yield return new TestCaseData(new Vector2(0.0f, -1.0f), new Vector2(1.0f, 0.0f), Direction.Counterclockwise, -90.0f);
		yield return new TestCaseData(new Vector2(2.0f, 0.0f), new Vector2(0.0f, 2.0f), Direction.Counterclockwise, -90.0f);
		yield return new TestCaseData(new Vector2(0.70710677f, 0.70710677f), new Vector2(1.0f, 0.0f), Direction.Counterclockwise, -315.0f);
		yield return new TestCaseData(new Vector2(0.70710677f, -0.70710677f), new Vector2(1.0f, 0.0f), Direction.Counterclockwise, -45.0f);
	}
	
	[Test, TestCaseSource(nameof(SignedAngleDeg360TestsParameters))]
	public void SignedAngleDeg360Tests(Vector2 vector1, Vector2 vector2, Direction direction, float expectedAngle)
	{
		var actualAngle = Vector2Utils.SignedAngleDeg360(vector1, vector2, direction);
		var actual = actualAngle.EqualTo(expectedAngle, EqualityPrecision);
		Assert.That(actual, Is.True, $"{"Expected:", 9} {expectedAngle:F2}\n{"Actual:", 9} {actualAngle:F2}");
	}
	
#pragma warning disable S4144 // Methods should not have identical implementations
	private static IEnumerable<TestCaseData> SignedAngleDeg360SpecialCasesTestsParameters()
	{
		yield return new TestCaseData(new Vector2(float.NaN, 0.0f), new Vector2(0.0f, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, float.NaN), new Vector2(0.0f, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(float.NaN, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(0.0f, float.NaN));
		
		yield return new TestCaseData(new Vector2(float.PositiveInfinity, 0.0f), new Vector2(0.0f, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, float.PositiveInfinity), new Vector2(0.0f, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(float.PositiveInfinity, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(0.0f, float.PositiveInfinity));
		
		yield return new TestCaseData(new Vector2(float.NegativeInfinity, 0.0f), new Vector2(0.0f, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, float.NegativeInfinity), new Vector2(0.0f, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(float.NegativeInfinity, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(0.0f, float.NegativeInfinity));
	}
#pragma warning restore S4144 // Methods should not have identical implementations
	
	[Test, TestCaseSource(nameof(SignedAngleDeg360SpecialCasesTestsParameters))]
	public void SignedAngleDeg360SpecialCasesTests(Vector2 vector1, Vector2 vector2)
	{
		var actualAngle = Vector2Utils.SignedAngleDeg360(vector1, vector2, Direction.Clockwise);
		var actual = float.IsNaN(actualAngle);
		Assert.That(actual, Is.True);
	}
	
	private static IEnumerable<TestCaseData> AngleRad360TestsParameters()
	{
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(1.0f, 0.0f), Direction.Clockwise, 0.0f);
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(0.0f, 1.0f), Direction.Clockwise, MathF.PI * 3.0f / 2.0f);
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(-1.0f, 0.0f), Direction.Clockwise, MathF.PI);
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(0.0f, -1.0f), Direction.Clockwise, MathF.PI / 2.0f);
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(0.70710677f, 0.70710677f), Direction.Clockwise, MathF.PI * 3.5f / 2.0f);
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(0.70710677f, -0.70710677f), Direction.Clockwise, MathF.PI / 4.0f);
		
		yield return new TestCaseData(new Vector2(0.0f, 1.0f), new Vector2(1.0f, 0.0f), Direction.Clockwise, MathF.PI / 2.0f);
		yield return new TestCaseData(new Vector2(-1.0f, 0.0f), new Vector2(1.0f, 0.0f), Direction.Clockwise, MathF.PI);
		yield return new TestCaseData(new Vector2(0.0f, -1.0f), new Vector2(1.0f, 0.0f), Direction.Clockwise, MathF.PI * 3.0f / 2.0f);
		yield return new TestCaseData(new Vector2(2.0f, 0.0f), new Vector2(0.0f, 2.0f), Direction.Clockwise, MathF.PI * 3.0f / 2.0f);
		yield return new TestCaseData(new Vector2(0.70710677f, 0.70710677f), new Vector2(1.0f, 0.0f), Direction.Clockwise, MathF.PI / 4.0f);
		yield return new TestCaseData(new Vector2(0.70710677f, -0.70710677f), new Vector2(1.0f, 0.0f), Direction.Clockwise, MathF.PI * 3.5f / 2.0f);
		
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(1.0f, 0.0f), Direction.Counterclockwise, 0.0f);
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(0.0f, 1.0f), Direction.Counterclockwise, MathF.PI / 2.0f);
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(-1.0f, 0.0f), Direction.Counterclockwise, MathF.PI);
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(0.0f, -1.0f), Direction.Counterclockwise, MathF.PI * 3.0f / 2.0f);
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(0.70710677f, 0.70710677f), Direction.Counterclockwise, MathF.PI / 4.0f);
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(0.70710677f, -0.70710677f), Direction.Counterclockwise, MathF.PI * 3.5f / 2.0f);
		
		yield return new TestCaseData(new Vector2(0.0f, 1.0f), new Vector2(1.0f, 0.0f), Direction.Counterclockwise, MathF.PI * 3.0f / 2.0f);
		yield return new TestCaseData(new Vector2(-1.0f, 0.0f), new Vector2(1.0f, 0.0f), Direction.Counterclockwise, MathF.PI);
		yield return new TestCaseData(new Vector2(0.0f, -1.0f), new Vector2(1.0f, 0.0f), Direction.Counterclockwise, MathF.PI / 2.0f);
		yield return new TestCaseData(new Vector2(2.0f, 0.0f), new Vector2(0.0f, 2.0f), Direction.Counterclockwise, MathF.PI / 2.0f);
		yield return new TestCaseData(new Vector2(0.70710677f, 0.70710677f), new Vector2(1.0f, 0.0f), Direction.Counterclockwise, MathF.PI * 3.5f / 2.0f);
		yield return new TestCaseData(new Vector2(0.70710677f, -0.70710677f), new Vector2(1.0f, 0.0f), Direction.Counterclockwise, MathF.PI / 4.0f);
	}
	
	[Test, TestCaseSource(nameof(AngleRad360TestsParameters))]
	public void AngleRad360Tests(Vector2 vector1, Vector2 vector2, Direction direction, float expectedAngle)
	{
		var actualAngle = Vector2Utils.AngleRad360(vector1, vector2, direction);
		var actual = actualAngle.EqualTo(expectedAngle, EqualityPrecision);
		Assert.That(actual, Is.True, $"{"Expected:", 9} {expectedAngle:F2}\n{"Actual:", 9} {actualAngle:F2}");
	}
	
#pragma warning disable S4144 // Methods should not have identical implementations
	private static IEnumerable<TestCaseData> AngleRad360SpecialCasesTestsParameters()
	{
		yield return new TestCaseData(new Vector2(float.NaN, 0.0f), new Vector2(0.0f, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, float.NaN), new Vector2(0.0f, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(float.NaN, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(0.0f, float.NaN));
		
		yield return new TestCaseData(new Vector2(float.PositiveInfinity, 0.0f), new Vector2(0.0f, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, float.PositiveInfinity), new Vector2(0.0f, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(float.PositiveInfinity, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(0.0f, float.PositiveInfinity));
		
		yield return new TestCaseData(new Vector2(float.NegativeInfinity, 0.0f), new Vector2(0.0f, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, float.NegativeInfinity), new Vector2(0.0f, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(float.NegativeInfinity, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(0.0f, float.NegativeInfinity));
	}
#pragma warning restore S4144 // Methods should not have identical implementations
	
	[Test, TestCaseSource(nameof(AngleRad360SpecialCasesTestsParameters))]
	public void AngleRad360SpecialCasesTests(Vector2 vector1, Vector2 vector2)
	{
		var actualAngle = Vector2Utils.AngleRad360(vector1, vector2, Direction.Clockwise);
		var actual = float.IsNaN(actualAngle);
		Assert.That(actual, Is.True);
	}
	
	private static IEnumerable<TestCaseData> AngleDeg360TestsParameters()
	{
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(1.0f, 0.0f), Direction.Clockwise, 0.0f);
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(0.0f, 1.0f), Direction.Clockwise, 270.0f);
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(-1.0f, 0.0f), Direction.Clockwise, 180.0f);
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(0.0f, -1.0f), Direction.Clockwise, 90.0f);
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(0.70710677f, 0.70710677f), Direction.Clockwise, 315.0f);
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(0.70710677f, -0.70710677f), Direction.Clockwise, 45.0f);
		
		yield return new TestCaseData(new Vector2(0.0f, 1.0f), new Vector2(1.0f, 0.0f), Direction.Clockwise, 90.0f);
		yield return new TestCaseData(new Vector2(-1.0f, 0.0f), new Vector2(1.0f, 0.0f), Direction.Clockwise, 180.0f);
		yield return new TestCaseData(new Vector2(0.0f, -1.0f), new Vector2(1.0f, 0.0f), Direction.Clockwise, 270.0f);
		yield return new TestCaseData(new Vector2(2.0f, 0.0f), new Vector2(0.0f, 2.0f), Direction.Clockwise, 270.0f);
		yield return new TestCaseData(new Vector2(0.70710677f, 0.70710677f), new Vector2(1.0f, 0.0f), Direction.Clockwise, 45.0f);
		yield return new TestCaseData(new Vector2(0.70710677f, -0.70710677f), new Vector2(1.0f, 0.0f), Direction.Clockwise, 315.0f);
		
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(1.0f, 0.0f), Direction.Counterclockwise, 0.0f);
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(0.0f, 1.0f), Direction.Counterclockwise, 90.0f);
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(-1.0f, 0.0f), Direction.Counterclockwise, 180.0f);
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(0.0f, -1.0f), Direction.Counterclockwise, 270.0f);
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(0.70710677f, 0.70710677f), Direction.Counterclockwise, 45.0f);
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(0.70710677f, -0.70710677f), Direction.Counterclockwise, 315.0f);
		
		yield return new TestCaseData(new Vector2(0.0f, 1.0f), new Vector2(1.0f, 0.0f), Direction.Counterclockwise, 270.0f);
		yield return new TestCaseData(new Vector2(-1.0f, 0.0f), new Vector2(1.0f, 0.0f), Direction.Counterclockwise, 180.0f);
		yield return new TestCaseData(new Vector2(0.0f, -1.0f), new Vector2(1.0f, 0.0f), Direction.Counterclockwise, 90.0f);
		yield return new TestCaseData(new Vector2(2.0f, 0.0f), new Vector2(0.0f, 2.0f), Direction.Counterclockwise, 90.0f);
		yield return new TestCaseData(new Vector2(0.70710677f, 0.70710677f), new Vector2(1.0f, 0.0f), Direction.Counterclockwise, 315.0f);
		yield return new TestCaseData(new Vector2(0.70710677f, -0.70710677f), new Vector2(1.0f, 0.0f), Direction.Counterclockwise, 45.0f);
	}
	
	[Test, TestCaseSource(nameof(AngleDeg360TestsParameters))]
	public void AngleDeg360Tests(Vector2 vector1, Vector2 vector2, Direction direction, float expectedAngle)
	{
		var actualAngle = Vector2Utils.AngleDeg360(vector1, vector2, direction);
		var actual = actualAngle.EqualTo(expectedAngle, EqualityPrecision);
		Assert.That(actual, Is.True, $"{"Expected:", 9} {expectedAngle:F2}\n{"Actual:", 9} {actualAngle:F2}");
	}
	
#pragma warning disable S4144 // Methods should not have identical implementations
	private static IEnumerable<TestCaseData> AngleDeg360SpecialCasesTestsParameters()
	{
		yield return new TestCaseData(new Vector2(float.NaN, 0.0f), new Vector2(0.0f, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, float.NaN), new Vector2(0.0f, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(float.NaN, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(0.0f, float.NaN));
		
		yield return new TestCaseData(new Vector2(float.PositiveInfinity, 0.0f), new Vector2(0.0f, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, float.PositiveInfinity), new Vector2(0.0f, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(float.PositiveInfinity, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(0.0f, float.PositiveInfinity));
		
		yield return new TestCaseData(new Vector2(float.NegativeInfinity, 0.0f), new Vector2(0.0f, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, float.NegativeInfinity), new Vector2(0.0f, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(float.NegativeInfinity, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(0.0f, float.NegativeInfinity));
	}
#pragma warning restore S4144 // Methods should not have identical implementations
	
	[Test, TestCaseSource(nameof(AngleDeg360SpecialCasesTestsParameters))]
	public void AngleDeg360SpecialCasesTests(Vector2 vector1, Vector2 vector2)
	{
		var actualAngle = Vector2Utils.AngleDeg360(vector1, vector2, Direction.Clockwise);
		var actual = float.IsNaN(actualAngle);
		Assert.That(actual, Is.True);
	}
	
	private static IEnumerable<TestCaseData> IsParallelTestsParameters()
	{
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(1.0f, 0.0f)).Returns(true);
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(-1.0f, 0.0f)).Returns(true);
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(2.0f, 0.0f)).Returns(true);
		yield return new TestCaseData(new Vector2(0.70710677f, 0.70710677f), new Vector2(0.70710677f * 2.0f, 0.70710677f * 2.0f)).Returns(true);
		yield return new TestCaseData(new Vector2(0.70710677f, 0.70710677f), new Vector2(0.70710677f, 0.70710677f)).Returns(true);
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(1.0f, 0.001f)).Returns(true);
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(1.0f, 0.002f)).Returns(false);
	}
	
	[Test, TestCaseSource(nameof(IsParallelTestsParameters))]
	public bool IsParallelTests(Vector2 vector1, Vector2 vector2)
	{
		return Vector2Utils.IsParallel(vector1, vector2);
	}
	
	private static IEnumerable<TestCaseData> IsParallelSpecialTestsParameters()
	{
		yield return new TestCaseData(new Vector2(float.NaN, 0.0f), new Vector2(0.0f, 0.0f)).Returns(false);
		yield return new TestCaseData(new Vector2(0.0f, float.NaN), new Vector2(0.0f, 0.0f)).Returns(false);
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(float.NaN, 0.0f)).Returns(false);
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(0.0f, float.NaN)).Returns(false);
		
		yield return new TestCaseData(new Vector2(float.PositiveInfinity, 0.0f), new Vector2(0.0f, 0.0f)).Returns(false);
		yield return new TestCaseData(new Vector2(0.0f, float.PositiveInfinity), new Vector2(0.0f, 0.0f)).Returns(false);
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(float.PositiveInfinity, 0.0f)).Returns(false);
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(0.0f, float.PositiveInfinity)).Returns(false);
		
		yield return new TestCaseData(new Vector2(float.NegativeInfinity, 0.0f), new Vector2(0.0f, 0.0f)).Returns(false);
		yield return new TestCaseData(new Vector2(0.0f, float.NegativeInfinity), new Vector2(0.0f, 0.0f)).Returns(false);
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(float.NegativeInfinity, 0.0f)).Returns(false);
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(0.0f, float.NegativeInfinity)).Returns(false);
		
		yield return new TestCaseData(new Vector2(float.NaN, 0.0f), new Vector2(float.NaN, 0.0f)).Returns(false);
		yield return new TestCaseData(new Vector2(1.0f, float.NaN), new Vector2(1.0f, float.NaN)).Returns(false);
		yield return new TestCaseData(new Vector2(float.NaN, float.NaN), new Vector2(float.NaN, float.NaN)).Returns(false);
		
		yield return new TestCaseData(new Vector2(float.PositiveInfinity, 0.0f), new Vector2(float.PositiveInfinity, 0.0f)).Returns(false);
		yield return new TestCaseData(new Vector2(1.0f, float.PositiveInfinity), new Vector2(1.0f, float.PositiveInfinity)).Returns(false);
		yield return new TestCaseData(new Vector2(float.PositiveInfinity, float.PositiveInfinity), new Vector2(float.PositiveInfinity, float.PositiveInfinity)).Returns(false);
		
		yield return new TestCaseData(new Vector2(float.NegativeInfinity, 0.0f), new Vector2(float.NegativeInfinity, 0.0f)).Returns(false);
		yield return new TestCaseData(new Vector2(1.0f, float.NegativeInfinity), new Vector2(1.0f, float.NegativeInfinity)).Returns(false);
		yield return new TestCaseData(new Vector2(float.NegativeInfinity, float.NegativeInfinity), new Vector2(float.NegativeInfinity, float.NegativeInfinity)).Returns(false);
	}
	
	[Test, TestCaseSource(nameof(IsParallelSpecialTestsParameters))]
	public bool IsParallelSpecialTests(Vector2 vector1, Vector2 vector2)
	{
		return Vector2Utils.IsParallel(vector1, vector2);
	}
	
	private static IEnumerable<TestCaseData> IsParallelToleranceTestsParameters()
	{
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(1.0f, 0.0f), 0.00001f).Returns(true);
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(-1.0f, 0.0f), 0.00001f).Returns(true);
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(2.0f, 0.0f), 0.00001f).Returns(true);
		yield return new TestCaseData(new Vector2(0.70710677f, 0.70710677f), new Vector2(0.70710677f * 2.0f, 0.70710677f * 2.0f), 0.00001f).Returns(true);
		yield return new TestCaseData(new Vector2(0.70710677f, 0.70710677f), new Vector2(0.70710677f, 0.70710677f), 0.00001f).Returns(true);
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(1.0f, 0.005f), 0.00001f).Returns(false);
		yield return new TestCaseData(new Vector2(1.0f, 0.0f), new Vector2(1.0f, 0.005f), 0.01f).Returns(false);
	}
	
	[Test, TestCaseSource(nameof(IsParallelToleranceTestsParameters))]
	public bool IsParallelToleranceTests(Vector2 vector1, Vector2 vector2, float tolerance)
	{
		return Vector2Utils.IsParallel(vector1, vector2, tolerance);
	}
	
#pragma warning disable S4144 // Methods should not have identical implementations
	private static IEnumerable<TestCaseData> IsParallelToleranceSpecialTestsParameters()
	{
		yield return new TestCaseData(new Vector2(float.NaN, 0.0f), new Vector2(0.0f, 0.0f)).Returns(false);
		yield return new TestCaseData(new Vector2(0.0f, float.NaN), new Vector2(0.0f, 0.0f)).Returns(false);
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(float.NaN, 0.0f)).Returns(false);
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(0.0f, float.NaN)).Returns(false);
		
		yield return new TestCaseData(new Vector2(float.PositiveInfinity, 0.0f), new Vector2(0.0f, 0.0f)).Returns(false);
		yield return new TestCaseData(new Vector2(0.0f, float.PositiveInfinity), new Vector2(0.0f, 0.0f)).Returns(false);
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(float.PositiveInfinity, 0.0f)).Returns(false);
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(0.0f, float.PositiveInfinity)).Returns(false);
		
		yield return new TestCaseData(new Vector2(float.NegativeInfinity, 0.0f), new Vector2(0.0f, 0.0f)).Returns(false);
		yield return new TestCaseData(new Vector2(0.0f, float.NegativeInfinity), new Vector2(0.0f, 0.0f)).Returns(false);
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(float.NegativeInfinity, 0.0f)).Returns(false);
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(0.0f, float.NegativeInfinity)).Returns(false);
		
		yield return new TestCaseData(new Vector2(float.NaN, 0.0f), new Vector2(float.NaN, 0.0f)).Returns(false);
		yield return new TestCaseData(new Vector2(1.0f, float.NaN), new Vector2(1.0f, float.NaN)).Returns(false);
		yield return new TestCaseData(new Vector2(float.NaN, float.NaN), new Vector2(float.NaN, float.NaN)).Returns(false);
		
		yield return new TestCaseData(new Vector2(float.PositiveInfinity, 0.0f), new Vector2(float.PositiveInfinity, 0.0f)).Returns(false);
		yield return new TestCaseData(new Vector2(1.0f, float.PositiveInfinity), new Vector2(1.0f, float.PositiveInfinity)).Returns(false);
		yield return new TestCaseData(new Vector2(float.PositiveInfinity, float.PositiveInfinity), new Vector2(float.PositiveInfinity, float.PositiveInfinity)).Returns(false);
		
		yield return new TestCaseData(new Vector2(float.NegativeInfinity, 0.0f), new Vector2(float.NegativeInfinity, 0.0f)).Returns(false);
		yield return new TestCaseData(new Vector2(1.0f, float.NegativeInfinity), new Vector2(1.0f, float.NegativeInfinity)).Returns(false);
		yield return new TestCaseData(new Vector2(float.NegativeInfinity, float.NegativeInfinity), new Vector2(float.NegativeInfinity, float.NegativeInfinity)).Returns(false);
	}
#pragma warning restore S4144 // Methods should not have identical implementations
	
	[Test, TestCaseSource(nameof(IsParallelToleranceSpecialTestsParameters))]
	public bool IsParallelToleranceSpecialTests(Vector2 vector1, Vector2 vector2)
	{
		return Vector2Utils.IsParallel(vector1, vector2, 1.0f);
	}
	
	private static IEnumerable<TestCaseData> PointProjectionOnLineTestsParameters()
	{
		yield return new TestCaseData(new Vector2(5.0f, 5.0f), new Vector2(0.0f, 0.0f), new Vector2(0.0f, 10.0f), new Vector2(0.0f, 5.0f));
		yield return new TestCaseData(new Vector2(-5.0f, 5.0f), new Vector2(0.0f, 0.0f), new Vector2(0.0f, 10.0f), new Vector2(0.0f, 5.0f));
		yield return new TestCaseData(new Vector2(0.0f, 5.0f), new Vector2(0.0f, 0.0f), new Vector2(0.0f, 10.0f), new Vector2(0.0f, 5.0f));
		yield return new TestCaseData(new Vector2(15.0f, 15.0f), new Vector2(10.0f, 10.0f), new Vector2(20.0f, 20.0f), new Vector2(15.0f, 15.0f));
		
		yield return new TestCaseData(new Vector2(0.0f, 30.0f), new Vector2(10.0f, 10.0f), new Vector2(20.0f, 20.0f), new Vector2(15.0f, 15.0f));
		yield return new TestCaseData(new Vector2(0.0f, 39.99f), new Vector2(10.0f, 10.0f), new Vector2(20.0f, 20.0f), new Vector2(19.995f, 19.995f));
		yield return new TestCaseData(new Vector2(0.0f, 40.0f), new Vector2(10.0f, 10.0f), new Vector2(20.0f, 20.0f), new Vector2(20.0f, 20.0f));
		yield return new TestCaseData(new Vector2(0.0f, 40.01f), new Vector2(10.0f, 10.0f), new Vector2(20.0f, 20.0f), new Vector2(20.005f, 20.005f));
		
		yield return new TestCaseData(new Vector2(30.0f, 0.0f), new Vector2(10.0f, 10.0f), new Vector2(20.0f, 20.0f), new Vector2(15.0f, 15.0f));
		yield return new TestCaseData(new Vector2(19.99f, 0.0f), new Vector2(10.0f, 10.0f), new Vector2(20.0f, 20.0f), new Vector2(9.995f, 9.995f));
		yield return new TestCaseData(new Vector2(20.0f, 0.0f), new Vector2(10.0f, 10.0f), new Vector2(20.0f, 20.0f), new Vector2(10.0f, 10.0f));
		yield return new TestCaseData(new Vector2(20.01f, 0.0f), new Vector2(10.0f, 10.0f), new Vector2(20.0f, 20.0f), new Vector2(10.005f, 10.005f));
	}
	
	[Test, TestCaseSource(nameof(PointProjectionOnLineTestsParameters))]
	public void PointProjectionOnLineTests(Vector2 point, Vector2 linePoint1, Vector2 linePoint2, Vector2 expectedProjection)
	{
		var isProject = Vector2Utils.PointProjectionOnLine(out var actualProjection, point, linePoint1, linePoint2);
		var actual = actualProjection.EqualTo(expectedProjection);
        Assert.Multiple(() =>
        {
            Assert.That(actual, Is.True, $"{"Expected:",9} {expectedProjection:F6}\n{"Actual:",9} {actualProjection:F6}");
            Assert.That(isProject, Is.True);
        });
    }
	
	private static IEnumerable<TestCaseData> PointProjectionOnLineSpecialTestsParameters()
	{
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(0.0f, 0.0f), new Vector2(0.0f, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(0.0f, 0.0f), new Vector2(0.0f, 0.0f));
		
		yield return new TestCaseData(new Vector2(float.NaN, 0.0f), new Vector2(10.0f, 10.0f), new Vector2(20.0f, 20.0f));
		yield return new TestCaseData(new Vector2(0.0f, float.NaN), new Vector2(10.0f, 10.0f), new Vector2(20.0f, 20.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(float.NaN, 10.0f), new Vector2(20.0f, 20.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(10.0f, float.NaN), new Vector2(20.0f, 20.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(10.0f, 10.0f), new Vector2(float.NaN, 20.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(10.0f, 10.0f), new Vector2(20.0f, float.NaN));
		
		yield return new TestCaseData(new Vector2(float.PositiveInfinity, 0.0f), new Vector2(10.0f, 10.0f), new Vector2(20.0f, 20.0f));
		yield return new TestCaseData(new Vector2(0.0f, float.PositiveInfinity), new Vector2(10.0f, 10.0f), new Vector2(20.0f, 20.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(float.PositiveInfinity, 10.0f), new Vector2(20.0f, 20.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(10.0f, float.PositiveInfinity), new Vector2(20.0f, 20.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(10.0f, 10.0f), new Vector2(float.PositiveInfinity, 20.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(10.0f, 10.0f), new Vector2(20.0f, float.PositiveInfinity));
		
		yield return new TestCaseData(new Vector2(float.NegativeInfinity, 0.0f), new Vector2(10.0f, 10.0f), new Vector2(20.0f, 20.0f));
		yield return new TestCaseData(new Vector2(0.0f, float.NegativeInfinity), new Vector2(10.0f, 10.0f), new Vector2(20.0f, 20.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(float.NegativeInfinity, 10.0f), new Vector2(20.0f, 20.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(10.0f, float.NegativeInfinity), new Vector2(20.0f, 20.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(10.0f, 10.0f), new Vector2(float.NegativeInfinity, 20.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(10.0f, 10.0f), new Vector2(20.0f, float.NegativeInfinity));
	}
	
	[Test, TestCaseSource(nameof(PointProjectionOnLineSpecialTestsParameters))]
	public void PointProjectionOnLineSpecialTests(Vector2 point, Vector2 linePoint1, Vector2 linePoint2)
	{
		var isProject = Vector2Utils.PointProjectionOnLine(out var actualProjection, point, linePoint1, linePoint2);
		var actual = Vector2Utils.IsNaN(actualProjection);
        Assert.Multiple(() =>
        {
            Assert.That(actual, Is.True, $"{"Expected:",9} {new Vector2(float.NaN, float.NaN):F6}\n{"Actual:",9} {actualProjection:F6}");
            Assert.That(isProject, Is.False);
        });
    }
	
	private static IEnumerable<TestCaseData> PointProjectionOnLineSegmentTestsParameters()
	{
		yield return new TestCaseData(new Vector2(5.0f, 5.0f), new Vector2(0.0f, 0.0f), new Vector2(0.0f, 10.0f), new Vector2(0.0f, 5.0f));
		yield return new TestCaseData(new Vector2(-5.0f, 5.0f), new Vector2(0.0f, 0.0f), new Vector2(0.0f, 10.0f), new Vector2(0.0f, 5.0f));
		yield return new TestCaseData(new Vector2(0.0f, 5.0f), new Vector2(0.0f, 0.0f), new Vector2(0.0f, 10.0f), new Vector2(0.0f, 5.0f));
		yield return new TestCaseData(new Vector2(15.0f, 15.0f), new Vector2(10.0f, 10.0f), new Vector2(20.0f, 20.0f), new Vector2(15.0f, 15.0f));
		
		yield return new TestCaseData(new Vector2(0.0f, 30.0f), new Vector2(10.0f, 10.0f), new Vector2(20.0f, 20.0f), new Vector2(15.0f, 15.0f));
		yield return new TestCaseData(new Vector2(0.0f, 39.99f), new Vector2(10.0f, 10.0f), new Vector2(20.0f, 20.0f), new Vector2(19.995f, 19.995f));
		yield return new TestCaseData(new Vector2(0.0f, 40.0f), new Vector2(10.0f, 10.0f), new Vector2(20.0f, 20.0f), new Vector2(20.0f, 20.0f));
		
		yield return new TestCaseData(new Vector2(30.0f, 0.0f), new Vector2(10.0f, 10.0f), new Vector2(20.0f, 20.0f), new Vector2(15.0f, 15.0f));
		yield return new TestCaseData(new Vector2(20.0f, 0.0f), new Vector2(10.0f, 10.0f), new Vector2(20.0f, 20.0f), new Vector2(10.0f, 10.0f));
		yield return new TestCaseData(new Vector2(20.01f, 0.0f), new Vector2(10.0f, 10.0f), new Vector2(20.0f, 20.0f), new Vector2(10.005f, 10.005f));
	}
	
	[Test, TestCaseSource(nameof(PointProjectionOnLineSegmentTestsParameters))]
	public void PointProjectionOnLineSegmentTests(Vector2 point, Vector2 linePoint1, Vector2 linePoint2, Vector2 expectedProjection)
	{
		var isProject = Vector2Utils.PointProjectionOnLineSegment(out var actualProjection, point, linePoint1, linePoint2);
		var actual = actualProjection!.Value.EqualTo(expectedProjection);
        Assert.Multiple(() =>
        {
            Assert.That(actual, Is.True, $"{"Expected:",9} {expectedProjection:F6}\n{"Actual:",9} {actualProjection:F6}");
            Assert.That(isProject, Is.True);
        });
    }
	
	private static IEnumerable<TestCaseData> PointProjectionOnLineSegmentIsNullTestsParameters()
	{
		yield return new TestCaseData(new Vector2(0.0f, 40.01f), new Vector2(10.0f, 10.0f), new Vector2(20.0f, 20.0f), new Vector2(20.005f, 20.005f));
		yield return new TestCaseData(new Vector2(19.99f, 0.0f), new Vector2(10.0f, 10.0f), new Vector2(20.0f, 20.0f), new Vector2(9.995f, 9.995f));
	}
	
	[Test, TestCaseSource(nameof(PointProjectionOnLineSegmentIsNullTestsParameters))]
	public void PointProjectionOnLineSegmentIsNullTests(Vector2 point, Vector2 linePoint1, Vector2 linePoint2, Vector2 expectedProjection)
	{
		var isProject = Vector2Utils.PointProjectionOnLineSegment(out var actualProjection, point, linePoint1, linePoint2);
        Assert.Multiple(() =>
        {
            Assert.That(actualProjection, Is.Null);
            Assert.That(isProject, Is.False);
        });
    }
	
#pragma warning disable S4144 // Methods should not have identical implementations
	private static IEnumerable<TestCaseData> PointProjectionOnLineSegmentSpecialTestsParameters()
	{
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(0.0f, 0.0f), new Vector2(0.0f, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(0.0f, 0.0f), new Vector2(0.0f, 0.0f));
		
		yield return new TestCaseData(new Vector2(float.NaN, 0.0f), new Vector2(10.0f, 10.0f), new Vector2(20.0f, 20.0f));
		yield return new TestCaseData(new Vector2(0.0f, float.NaN), new Vector2(10.0f, 10.0f), new Vector2(20.0f, 20.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(float.NaN, 10.0f), new Vector2(20.0f, 20.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(10.0f, float.NaN), new Vector2(20.0f, 20.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(10.0f, 10.0f), new Vector2(float.NaN, 20.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(10.0f, 10.0f), new Vector2(20.0f, float.NaN));
		
		yield return new TestCaseData(new Vector2(float.PositiveInfinity, 0.0f), new Vector2(10.0f, 10.0f), new Vector2(20.0f, 20.0f));
		yield return new TestCaseData(new Vector2(0.0f, float.PositiveInfinity), new Vector2(10.0f, 10.0f), new Vector2(20.0f, 20.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(float.PositiveInfinity, 10.0f), new Vector2(20.0f, 20.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(10.0f, float.PositiveInfinity), new Vector2(20.0f, 20.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(10.0f, 10.0f), new Vector2(float.PositiveInfinity, 20.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(10.0f, 10.0f), new Vector2(20.0f, float.PositiveInfinity));
		
		yield return new TestCaseData(new Vector2(float.NegativeInfinity, 0.0f), new Vector2(10.0f, 10.0f), new Vector2(20.0f, 20.0f));
		yield return new TestCaseData(new Vector2(0.0f, float.NegativeInfinity), new Vector2(10.0f, 10.0f), new Vector2(20.0f, 20.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(float.NegativeInfinity, 10.0f), new Vector2(20.0f, 20.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(10.0f, float.NegativeInfinity), new Vector2(20.0f, 20.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(10.0f, 10.0f), new Vector2(float.NegativeInfinity, 20.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(10.0f, 10.0f), new Vector2(20.0f, float.NegativeInfinity));
	}
#pragma warning restore S4144 // Methods should not have identical implementations
	
	[Test, TestCaseSource(nameof(PointProjectionOnLineSegmentSpecialTestsParameters))]
	public void PointProjectionOnLineSegmentSpecialTests(Vector2 point, Vector2 linePoint1, Vector2 linePoint2)
	{
		var isProject = Vector2Utils.PointProjectionOnLineSegment(out var actualProjection, point, linePoint1, linePoint2);
		var actual = Vector2Utils.IsNaN(actualProjection!.Value);
        Assert.Multiple(() =>
        {
            Assert.That(actual, Is.True, $"{"Expected:",9} {new Vector2(float.NaN, float.NaN):F6}\n{"Actual:",9} {actualProjection:F6}");
            Assert.That(isProject, Is.False);
        });
    }
	
	private static IEnumerable<TestCaseData> PerpendicularTestsParameters()
	{
		yield return new TestCaseData(new Vector2(0.0f, 1.0f), new Vector2(1.0f, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(0.0f, 0.0f));
		yield return new TestCaseData(new Vector2(0.70710677f, 0.70710677f), new Vector2(0.70710677f, -0.70710677f));
	}
	
	[Test, TestCaseSource(nameof(PerpendicularTestsParameters))]
	public void PerpendicularTests(Vector2 vector, Vector2 expectedVector)
	{
		var actualVector = Vector2Utils.Perpendicular(vector);
		var actual = actualVector.EqualTo(expectedVector);
		Assert.That(actual, Is.True, $"{"Expected:",9} {expectedVector:F6}\n{"Actual:",9} {actualVector:F6}");
	}
	
	private static IEnumerable<TestCaseData> PerpendicularSpecialTestsParameters()
	{
		yield return new TestCaseData(new Vector2(float.NaN, 0.70710677f));
		yield return new TestCaseData(new Vector2(0.70710677f, float.NaN));
		yield return new TestCaseData(new Vector2(float.PositiveInfinity, 0.70710677f));
		yield return new TestCaseData(new Vector2(0.70710677f, float.PositiveInfinity));
		yield return new TestCaseData(new Vector2(float.NegativeInfinity, 0.70710677f));
		yield return new TestCaseData(new Vector2(0.70710677f, float.NegativeInfinity));
	}
	
	[Test, TestCaseSource(nameof(PerpendicularSpecialTestsParameters))]
	public void PerpendicularSpecialTests(Vector2 vector)
	{
		var actualVector = Vector2Utils.Perpendicular(vector);
		var actual = Vector2Utils.IsNaN(actualVector);
		Assert.That(actual, Is.True, $"{"Expected:",9} {new Vector2(float.NaN, float.NaN):F6}\n{"Actual:",9} {actualVector:F6}");
	}
	
	private static IEnumerable<TestCaseData> PerpendicularDirectionTestsParameters()
	{
		yield return new TestCaseData(new Vector2(0.0f, 1.0f), Direction.Clockwise, new Vector2(1.0f, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), Direction.Clockwise, new Vector2(0.0f, 0.0f));
		yield return new TestCaseData(new Vector2(0.70710677f, 0.70710677f), Direction.Clockwise, new Vector2(0.70710677f, -0.70710677f));
		
		yield return new TestCaseData(new Vector2(0.0f, 1.0f), Direction.Counterclockwise, new Vector2(-1.0f, 0.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), Direction.Counterclockwise, new Vector2(0.0f, 0.0f));
		yield return new TestCaseData(new Vector2(0.70710677f, 0.70710677f), Direction.Counterclockwise, new Vector2(-0.70710677f, 0.70710677f));
	}
	
	[Test, TestCaseSource(nameof(PerpendicularDirectionTestsParameters))]
	public void PerpendicularDirectionTests(Vector2 vector, Direction direction, Vector2 expectedVector)
	{
		var actualVector = Vector2Utils.Perpendicular(vector, direction);
		var actual = actualVector.EqualTo(expectedVector);
		Assert.That(actual, Is.True, $"{"Expected:",9} {expectedVector:F6}\n{"Actual:",9} {actualVector:F6}");
	}
	
#pragma warning disable S4144 // Methods should not have identical implementations
	private static IEnumerable<TestCaseData> PerpendicularDirectionSpecialTestsParameters()
	{
		yield return new TestCaseData(new Vector2(float.NaN, 0.70710677f));
		yield return new TestCaseData(new Vector2(0.70710677f, float.NaN));
		yield return new TestCaseData(new Vector2(float.PositiveInfinity, 0.70710677f));
		yield return new TestCaseData(new Vector2(0.70710677f, float.PositiveInfinity));
		yield return new TestCaseData(new Vector2(float.NegativeInfinity, 0.70710677f));
		yield return new TestCaseData(new Vector2(0.70710677f, float.NegativeInfinity));
	}
#pragma warning restore S4144 // Methods should not have identical implementations
	
	[Test, TestCaseSource(nameof(PerpendicularDirectionSpecialTestsParameters))]
	public void PerpendicularDirectionSpecialTests(Vector2 vector)
	{
		var actualVector = Vector2Utils.Perpendicular(vector, Direction.Clockwise);
		var actual = Vector2Utils.IsNaN(actualVector);
		Assert.That(actual, Is.True, $"{"Expected:",9} {new Vector2(float.NaN, float.NaN):F6}\n{"Actual:",9} {actualVector:F6}");
	}
	
	private static IEnumerable<TestCaseData> ExtendToTestsParameters()
	{
		yield return new TestCaseData(new Vector2(5.0f, 5.0f), 2.0f, new Vector2(0.70710677f * 2.0f, 0.70710677f * 2.0f));
		yield return new TestCaseData(new Vector2(5.0f, 5.0f), 0.0f, new Vector2(0.0f, 0.0f));
		yield return new TestCaseData(new Vector2(5.0f, 5.0f), -2.0f, new Vector2(-0.70710677f * 2.0f, -0.70710677f * 2.0f));
	}
	
	[Test, TestCaseSource(nameof(ExtendToTestsParameters))]
	public void ExtendToTests(Vector2 vector, float value, Vector2 expectedVector)
	{
		var actualVector = Vector2Utils.ExtendTo(vector, value);
		var actual = actualVector.EqualTo(expectedVector);
		Assert.That(actual, Is.True, $"{"Expected:",9} {expectedVector:F6}\n{"Actual:",9} {actualVector:F6}");
	}
	
	private static IEnumerable<TestCaseData> ExtendToSpecialTestsParameters()
	{
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), 2.5f);
		
		yield return new TestCaseData(new Vector2(float.NaN, 0.70710677f), 0.0f);
		yield return new TestCaseData(new Vector2(0.70710677f, float.NaN), 0.0f);
		yield return new TestCaseData(new Vector2(0.70710677f, 0.70710677f), float.NaN);
		
		yield return new TestCaseData(new Vector2(float.PositiveInfinity, 0.70710677f), 0.0f);
		yield return new TestCaseData(new Vector2(0.70710677f, float.PositiveInfinity), 0.0f);
		yield return new TestCaseData(new Vector2(0.70710677f, 0.70710677f), float.PositiveInfinity);
		
		yield return new TestCaseData(new Vector2(float.NegativeInfinity, 0.70710677f), 0.0f);
		yield return new TestCaseData(new Vector2(0.70710677f, float.NegativeInfinity), 0.0f);
		yield return new TestCaseData(new Vector2(0.70710677f, 0.70710677f), float.NegativeInfinity);
	}
	
	[Test, TestCaseSource(nameof(ExtendToSpecialTestsParameters))]
	public void ExtendToSpecialTests(Vector2 vector, float value)
	{
		var actualVector = Vector2Utils.ExtendTo(vector, value);
		var actual = Vector2Utils.IsNaN(actualVector);
		Assert.That(actual, Is.True, $"{"Expected:",9} {new Vector2(float.NaN, float.NaN):F6}\n{"Actual:",9} {actualVector:F6}");
	}
	
	private static IEnumerable<TestCaseData> ExtendToVectorTestsParameters()
	{
		yield return new TestCaseData(new Vector2(5.0f, 5.0f), new Vector2(10.0f, 10.0f), 2.0f, new Vector2(0.70710677f * 2.0f + 5.0f, 0.70710677f * 2.0f + 5.0f));
		yield return new TestCaseData(new Vector2(5.0f, 5.0f), new Vector2(10.0f, 10.0f), 0.0f, new Vector2(5.0f, 5.0f));
		yield return new TestCaseData(new Vector2(5.0f, 5.0f), new Vector2(10.0f, 10.0f), -2.0f, new Vector2(-0.70710677f * 2.0f + 5.0f, -0.70710677f * 2.0f + 5.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(5.0f, 5.0f), 2.0f, new Vector2(0.70710677f * 2.0f, 0.70710677f * 2.0f));
	}
	
	[Test, TestCaseSource(nameof(ExtendToVectorTestsParameters))]
	public void ExtendToVectorTests(Vector2 vector1, Vector2 vector2, float value, Vector2 expectedVector)
	{
		var actualVector = Vector2Utils.ExtendTo(vector1, vector2, value);
		var actual = actualVector.EqualTo(expectedVector);
		Assert.That(actual, Is.True, $"{"Expected:",9} {expectedVector:F6}\n{"Actual:",9} {actualVector:F6}");
	}
	
	private static IEnumerable<TestCaseData> ExtendToVectorSpecialTestsParameters()
	{
		yield return new TestCaseData(new Vector2(float.NaN, 0.70710677f), new Vector2(0.70710677f, 0.70710677f), 0.0f);
		yield return new TestCaseData(new Vector2(0.70710677f, float.NaN), new Vector2(0.70710677f, 0.70710677f), 0.0f);
		yield return new TestCaseData(new Vector2(0.70710677f, 0.70710677f), new Vector2(float.NaN, 0.70710677f), 0.0f);
		yield return new TestCaseData(new Vector2(0.70710677f, 0.70710677f), new Vector2(0.70710677f, float.NaN), 0.0f);
		yield return new TestCaseData(new Vector2(0.70710677f, 0.70710677f), new Vector2(0.70710677f, 0.70710677f), float.NaN);
		
		yield return new TestCaseData(new Vector2(float.PositiveInfinity, 0.70710677f), new Vector2(0.70710677f, 0.70710677f), 0.0f);
		yield return new TestCaseData(new Vector2(0.70710677f, float.PositiveInfinity), new Vector2(0.70710677f, 0.70710677f), 0.0f);
		yield return new TestCaseData(new Vector2(0.70710677f, 0.70710677f), new Vector2(float.PositiveInfinity, 0.70710677f), 0.0f);
		yield return new TestCaseData(new Vector2(0.70710677f, 0.70710677f), new Vector2(0.70710677f, float.PositiveInfinity), 0.0f);
		yield return new TestCaseData(new Vector2(0.70710677f, 0.70710677f), new Vector2(0.70710677f, 0.70710677f), float.PositiveInfinity);
		
		yield return new TestCaseData(new Vector2(float.NegativeInfinity, 0.70710677f), new Vector2(0.70710677f, 0.70710677f), 0.0f);
		yield return new TestCaseData(new Vector2(0.70710677f, float.NegativeInfinity), new Vector2(0.70710677f, 0.70710677f), 0.0f);
		yield return new TestCaseData(new Vector2(0.70710677f, 0.70710677f), new Vector2(float.NegativeInfinity, 0.70710677f), 0.0f);
		yield return new TestCaseData(new Vector2(0.70710677f, 0.70710677f), new Vector2(0.70710677f, float.NegativeInfinity), 0.0f);
		yield return new TestCaseData(new Vector2(0.70710677f, 0.70710677f), new Vector2(0.70710677f, 0.70710677f), float.NegativeInfinity);
	}
	
	[Test, TestCaseSource(nameof(ExtendToVectorSpecialTestsParameters))]
	public void ExtendToVectorSpecialTests(Vector2 vector1, Vector2 vector2, float value)
	{
		var actualVector = Vector2Utils.ExtendTo(vector1, vector2, value);
		var actual = Vector2Utils.IsNaN(actualVector);
		Assert.That(actual, Is.True, $"{"Expected:",9} {new Vector2(float.NaN, float.NaN):F6}\n{"Actual:",9} {actualVector:F6}");
	}
	
	private static IEnumerable<TestCaseData> ExtendByTestsParameters()
	{
		yield return new TestCaseData(new Vector2(5.0f, 5.0f), 2.0f, new Vector2(0.70710677f * 2.0f + 5.0f, 0.70710677f * 2.0f + 5.0f));
		yield return new TestCaseData(new Vector2(5.0f, 5.0f), 0.0f, new Vector2(5.0f, 5.0f));
		yield return new TestCaseData(new Vector2(5.0f, 5.0f), -2.0f, new Vector2(-0.70710677f * 2.0f + 5.0f, -0.70710677f * 2.0f + 5.0f));
	}
	
	[Test, TestCaseSource(nameof(ExtendByTestsParameters))]
	public void ExtendByTests(Vector2 vector, float value, Vector2 expectedVector)
	{
		var actualVector = Vector2Utils.ExtendBy(vector, value);
		var actual = actualVector.EqualTo(expectedVector);
		Assert.That(actual, Is.True, $"{"Expected:",9} {expectedVector:F6}\n{"Actual:",9} {actualVector:F6}");
	}
	
#pragma warning disable S4144 // Methods should not have identical implementations
	private static IEnumerable<TestCaseData> ExtendBySpecialTestsParameters()
	{
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), 2.5f);
		
		yield return new TestCaseData(new Vector2(float.NaN, 0.70710677f), 0.0f);
		yield return new TestCaseData(new Vector2(0.70710677f, float.NaN), 0.0f);
		yield return new TestCaseData(new Vector2(0.70710677f, 0.70710677f), float.NaN);
		
		yield return new TestCaseData(new Vector2(float.PositiveInfinity, 0.70710677f), 0.0f);
		yield return new TestCaseData(new Vector2(0.70710677f, float.PositiveInfinity), 0.0f);
		yield return new TestCaseData(new Vector2(0.70710677f, 0.70710677f), float.PositiveInfinity);
		
		yield return new TestCaseData(new Vector2(float.NegativeInfinity, 0.70710677f), 0.0f);
		yield return new TestCaseData(new Vector2(0.70710677f, float.NegativeInfinity), 0.0f);
		yield return new TestCaseData(new Vector2(0.70710677f, 0.70710677f), float.NegativeInfinity);
	}
#pragma warning restore S4144 // Methods should not have identical implementations
	
	[Test, TestCaseSource(nameof(ExtendBySpecialTestsParameters))]
	public void ExtendBySpecialTests(Vector2 vector, float value)
	{
		var actualVector = Vector2Utils.ExtendBy(vector, value);
		var actual = Vector2Utils.IsNaN(actualVector);
		Assert.That(actual, Is.True, $"{"Expected:",9} {new Vector2(float.NaN, float.NaN):F6}\n{"Actual:",9} {actualVector:F6}");
	}
	
	private static IEnumerable<TestCaseData> ExtendByVectorTestsParameters()
	{
		yield return new TestCaseData(new Vector2(5.0f, 5.0f), new Vector2(10.0f, 10.0f), 2.0f, new Vector2(0.70710677f * 2.0f + 10.0f, 0.70710677f * 2.0f + 10.0f));
		yield return new TestCaseData(new Vector2(5.0f, 5.0f), new Vector2(10.0f, 10.0f), 0.0f, new Vector2(10.0f, 10.0f));
		yield return new TestCaseData(new Vector2(5.0f, 5.0f), new Vector2(10.0f, 10.0f), -2.0f, new Vector2(-0.70710677f * 2.0f + 10.0f, -0.70710677f * 2.0f + 10.0f));
		yield return new TestCaseData(new Vector2(0.0f, 0.0f), new Vector2(5.0f, 5.0f), 2.0f, new Vector2(0.70710677f * 2.0f + 5.0f, 0.70710677f * 2.0f + 5.0f));
	}
	
	[Test, TestCaseSource(nameof(ExtendByVectorTestsParameters))]
	public void ExtendByVectorTests(Vector2 vector1, Vector2 vector2, float value, Vector2 expectedVector)
	{
		var actualVector = Vector2Utils.ExtendBy(vector1, vector2, value);
		var actual = actualVector.EqualTo(expectedVector);
		Assert.That(actual, Is.True, $"{"Expected:",9} {expectedVector:F6}\n{"Actual:",9} {actualVector:F6}");
	}
	
#pragma warning disable S4144 // Methods should not have identical implementations
	private static IEnumerable<TestCaseData> ExtendByVectorSpecialTestsParameters()
	{
		yield return new TestCaseData(new Vector2(float.NaN, 0.70710677f), new Vector2(0.70710677f, 0.70710677f), 0.0f);
		yield return new TestCaseData(new Vector2(0.70710677f, float.NaN), new Vector2(0.70710677f, 0.70710677f), 0.0f);
		yield return new TestCaseData(new Vector2(0.70710677f, 0.70710677f), new Vector2(float.NaN, 0.70710677f), 0.0f);
		yield return new TestCaseData(new Vector2(0.70710677f, 0.70710677f), new Vector2(0.70710677f, float.NaN), 0.0f);
		yield return new TestCaseData(new Vector2(0.70710677f, 0.70710677f), new Vector2(0.70710677f, 0.70710677f), float.NaN);
		
		yield return new TestCaseData(new Vector2(float.PositiveInfinity, 0.70710677f), new Vector2(0.70710677f, 0.70710677f), 0.0f);
		yield return new TestCaseData(new Vector2(0.70710677f, float.PositiveInfinity), new Vector2(0.70710677f, 0.70710677f), 0.0f);
		yield return new TestCaseData(new Vector2(0.70710677f, 0.70710677f), new Vector2(float.PositiveInfinity, 0.70710677f), 0.0f);
		yield return new TestCaseData(new Vector2(0.70710677f, 0.70710677f), new Vector2(0.70710677f, float.PositiveInfinity), 0.0f);
		yield return new TestCaseData(new Vector2(0.70710677f, 0.70710677f), new Vector2(0.70710677f, 0.70710677f), float.PositiveInfinity);
		
		yield return new TestCaseData(new Vector2(float.NegativeInfinity, 0.70710677f), new Vector2(0.70710677f, 0.70710677f), 0.0f);
		yield return new TestCaseData(new Vector2(0.70710677f, float.NegativeInfinity), new Vector2(0.70710677f, 0.70710677f), 0.0f);
		yield return new TestCaseData(new Vector2(0.70710677f, 0.70710677f), new Vector2(float.NegativeInfinity, 0.70710677f), 0.0f);
		yield return new TestCaseData(new Vector2(0.70710677f, 0.70710677f), new Vector2(0.70710677f, float.NegativeInfinity), 0.0f);
		yield return new TestCaseData(new Vector2(0.70710677f, 0.70710677f), new Vector2(0.70710677f, 0.70710677f), float.NegativeInfinity);
	}
#pragma warning restore S4144 // Methods should not have identical implementations
	
	[Test, TestCaseSource(nameof(ExtendByVectorSpecialTestsParameters))]
	public void ExtendByVectorSpecialTests(Vector2 vector1, Vector2 vector2, float value)
	{
		var actualVector = Vector2Utils.ExtendBy(vector1, vector2, value);
		var actual = Vector2Utils.IsNaN(actualVector);
		Assert.That(actual, Is.True, $"{"Expected:",9} {new Vector2(float.NaN, float.NaN):F6}\n{"Actual:",9} {actualVector:F6}");
	}
}