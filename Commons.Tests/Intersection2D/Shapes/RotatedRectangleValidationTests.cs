using System.Numerics;
using CShapes = Commons.Intersection2D.Shapes;

namespace Commons.Tests.Intersection2D.Shapes;

public class RotatedRectangleValidationTests
{
	private static IEnumerable<TestCaseData> DoesNotThrowTestsParameters()
	{
		var rect1 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(50.0f, 30.0f), new Vector2(30.0f, 30.0f)
		};
		var rect2 = new[] { 
			new Vector2(-50.0f, -30.0f), new Vector2(-30.0f, -30.0f), new Vector2(-30.0f, -40.0f), new Vector2(-50.0f, -40.0f)
		};
		
		yield return new TestCaseData(rect1);
		yield return new TestCaseData(rect2);
	}
	
	[Test, TestCaseSource(nameof(DoesNotThrowTestsParameters))]
	public void DoesNotThrowTests(Vector2[] rect)
	{
		Assert.DoesNotThrow(() => CShapes.ValidateAndCreateRotatedRectangle(rect[0], rect[1], rect[2], rect[3]));
	}
	
	[Test, TestCaseSource(nameof(DoesNotThrowTestsParameters))]
	public void DoesNotThrowRotatedTests(Vector2[] rect)
	{
		var newRect = rect.Select(r => Vector2Utils.RotateDeg(r, 42.5f)).ToArray();
		Assert.DoesNotThrow(() => CShapes.ValidateAndCreateRotatedRectangle(newRect[0], newRect[1], newRect[2], newRect[3]));
	}
	
	private static IEnumerable<TestCaseData> AssertThrowTestsParameters()
	{
		var rect1 = new[] { 
			new Vector2(35.0f, 35.0f), new Vector2(35.0f, 35.0f), new Vector2(35.0f, 25.0f), new Vector2(35.0f, 25.0f)  // line segment
		};
		var rect2 = new[] { 
			new Vector2(40.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 40.0f)  // point
		};
		// rhombus
		var rect3 = new[] { 
			new Vector2(40.0f, 20.0f), new Vector2(45.0f, 35.0f), new Vector2(40.0f, 50.0f), new Vector2(35.0f, 35.0f)
		};
		// parallelogram
		var rect4 = new[] { 
			new Vector2(30.0f, 50.0f), new Vector2(50.0f, 50.0f), new Vector2(40.0f, 20.0f), new Vector2(20.0f, 20.0f)
		};
		// convex quadrilateral
		var rect5 = new[] { 
			new Vector2(30.0f, 50.0f), new Vector2(50.0f, 50.0f), new Vector2(55.0f, 15.0f), new Vector2(20.0f, 20.0f)
		};
		// complex quadrilateral
		var rect6 = new[] { 
			new Vector2(30.0f, 50.0f), new Vector2(40.0f, 20.0f), new Vector2(50.0f, 50.0f), new Vector2(20.0f, 20.0f)
		};
		// concave quadrilateral
		var rect7 = new[] { 
			new Vector2(30.0f, 50.0f), new Vector2(35.0f, 30.0f), new Vector2(55.0f, 15.0f), new Vector2(20.0f, 20.0f)
		};
		// 3 collinear points
		var rect8 = new[] { 
			new Vector2(40.0f, 20.0f), new Vector2(40.0f, 35.0f), new Vector2(40.0f, 50.0f), new Vector2(35.0f, 35.0f)
		};
		// 4 collinear points
		var rect9 = new[] { 
			new Vector2(30.0f, 20.0f), new Vector2(50.0f, 20.0f), new Vector2(40.0f, 20.0f), new Vector2(20.0f, 20.0f)
		};
		
		yield return new TestCaseData(rect1);
		yield return new TestCaseData(rect2);
		yield return new TestCaseData(rect3);
		yield return new TestCaseData(rect4);
		yield return new TestCaseData(rect5);
		yield return new TestCaseData(rect6);
		yield return new TestCaseData(rect7);
		yield return new TestCaseData(rect8);
		yield return new TestCaseData(rect9);
		
		var argsSpecial1 = new[] { 
			new Vector2(float.NaN, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 30.0f), new Vector2(30.0f, 30.0f)
		};
		var argsSpecial2 = new[] { 
			new Vector2(30.0f, float.NaN), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 30.0f), new Vector2(30.0f, 30.0f)
		};
		var argsSpecial3 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(float.NaN, 40.0f), new Vector2(40.0f, 30.0f), new Vector2(30.0f, 30.0f)
		};
		var argsSpecial4 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(40.0f, float.NaN), new Vector2(40.0f, 30.0f), new Vector2(30.0f, 30.0f)
		};
		var argsSpecial5 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(float.NaN, 30.0f), new Vector2(30.0f, 30.0f)
		};
		var argsSpecial6 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, float.NaN), new Vector2(30.0f, 30.0f)
		};
		var argsSpecial7 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 30.0f), new Vector2(float.NaN, 30.0f)
		};
		var argsSpecial8 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 30.0f), new Vector2(30.0f, float.NaN)
		};
		var argsSpecial9 = new[] { 
			new Vector2(float.NaN, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 30.0f), new Vector2(30.0f, 30.0f)
		};
		var argsSpecial10 = new[] { 
			new Vector2(30.0f, float.NaN), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 30.0f), new Vector2(30.0f, 30.0f)
		};
		var argsSpecial11 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(float.NaN, 40.0f), new Vector2(40.0f, 30.0f), new Vector2(30.0f, 30.0f)
		};
		var argsSpecial12 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(40.0f, float.NaN), new Vector2(40.0f, 30.0f), new Vector2(30.0f, 30.0f)
		};
		var argsSpecial13 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(float.NaN, 30.0f), new Vector2(30.0f, 30.0f)
		};
		var argsSpecial14 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, float.NaN), new Vector2(30.0f, 30.0f)
		};
		var argsSpecial15 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 30.0f), new Vector2(float.NaN, 30.0f)
		};
		var argsSpecial16 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 30.0f), new Vector2(30.0f, float.NaN)
		};
		var argsSpecial17 = new[] { 
			new Vector2(float.NaN, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 30.0f), new Vector2(30.0f, 30.0f)
		};
		var argsSpecial18 = new[] { 
			new Vector2(30.0f, float.NaN), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 30.0f), new Vector2(30.0f, 30.0f)
		};
		var argsSpecial19 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(float.NaN, 40.0f), new Vector2(40.0f, 30.0f), new Vector2(30.0f, 30.0f)
		};
		var argsSpecial20 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(40.0f, float.NaN), new Vector2(40.0f, 30.0f), new Vector2(30.0f, 30.0f)
		};
		var argsSpecial21 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(float.NaN, 30.0f), new Vector2(30.0f, 30.0f)
		};
		var argsSpecial22 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, float.NaN), new Vector2(30.0f, 30.0f)
		};
		var argsSpecial23 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 30.0f), new Vector2(float.NaN, 30.0f)
		};
		var argsSpecial24 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 30.0f), new Vector2(30.0f, float.NaN)
		};
		
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
		yield return new TestCaseData(argsSpecial19);
		yield return new TestCaseData(argsSpecial20);
		yield return new TestCaseData(argsSpecial21);
		yield return new TestCaseData(argsSpecial22);
		yield return new TestCaseData(argsSpecial23);
		yield return new TestCaseData(argsSpecial24);
	}
	
	[Test, TestCaseSource(nameof(AssertThrowTestsParameters))]
	public void AssertThrowTests(Vector2[] rect)
	{
		var exception = Assert.Throws<ArithmeticException>(() => CShapes.ValidateAndCreateRotatedRectangle(rect[0], rect[1], rect[2], rect[3]));
		Assert.That(exception.Source, Is.EqualTo("Commons.Intersection2D"));
	}
	
	[Test, TestCaseSource(nameof(AssertThrowTestsParameters))]
	public void AssertThrowRotatedTests(Vector2[] rect)
	{
		var newRect = rect.Select(r => Vector2Utils.RotateDeg(r, 42.5f)).ToArray();
		var exception = Assert.Throws<ArithmeticException>(() => CShapes.ValidateAndCreateRotatedRectangle(newRect[0], newRect[1], newRect[2], newRect[3]));
		Assert.That(exception.Source, Is.EqualTo("Commons.Intersection2D"));
	}
}