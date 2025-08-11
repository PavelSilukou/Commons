using Commons.Intersection2D;
using Commons.Intersection2D.Shapes;

namespace Commons.Tests.Intersection2D;

public class RectangleToRectangleIntersectionTests
{
	private static IEnumerable<TestCaseData> IsRectangleToRectangleIntersectTestsParameters()
	{
		var rects1 = new[] { 
			30.0f, 40.0f, 50.0f, 30.0f,
			60.0f, 40.0f, 80.0f, 30.0f
		};
		var rects2 = new[] { 
			30.0f, 40.0f, 50.0f, 30.0f,
			30.0f, 60.0f, 50.0f, 50.0f
		};
		var rects3 = new[] { 
			30.0f, 40.0f, 50.0f, 30.0f,
			50.0f, 40.0f, 70.0f, 30.0f
		};
		var rects4 = new[] { 
			30.0f, 40.0f, 50.0f, 30.0f,
			30.0f, 50.0f, 50.0f, 40.0f
		};
		var rects5 = new[] { 
			30.0f, 40.0f, 50.0f, 30.0f,
			50.0f, 30.0f, 70.0f, 20.0f
		};
		var rects6 = new[] { 
			30.0f, 40.0f, 50.0f, 30.0f,
			50.0f, 50.0f, 70.0f, 40.0f
		};
		var rects7 = new[] { 
			30.0f, 40.0f, 50.0f, 30.0f,
			30.0f, 40.0f, 50.0f, 30.0f
		};
		var rects8 = new[] { 
			30.0f, 40.0f, 50.0f, 30.0f,
			35.0f, 40.0f, 55.0f, 30.0f
		};
		var rects9 = new[] { 
			30.0f, 40.0f, 50.0f, 30.0f,
			30.0f, 45.0f, 50.0f, 35.0f
		};
		var rects10 = new[] { 
			30.0f, 40.0f, 50.0f, 30.0f,
			32.0f, 38.0f, 48.0f, 32.0f
		};
		var rects11 = new[] { 
			30.0f, 40.0f, 50.0f, 30.0f,
			35.0f, 35.0f, 55.0f, 25.0f
		};
		var rects12 = new[] { 
			30.0f, 40.0f, 50.0f, 30.0f,
			35.0f, 45.0f, 55.0f, 35.0f
		};
		var rects13 = new[] { 
			60.0f, 40.0f, 80.0f, 30.0f,
			30.0f, 40.0f, 50.0f, 30.0f
		};
		var rects14 = new[] { 
			30.0f, 60.0f, 50.0f, 50.0f,
			30.0f, 40.0f, 50.0f, 30.0f
		};
		var rects15 = new[] { 
			50.0f, 40.0f, 70.0f, 30.0f,
			30.0f, 40.0f, 50.0f, 30.0f
		};
		var rects16 = new[] { 
			30.0f, 50.0f, 50.0f, 40.0f,
			30.0f, 40.0f, 50.0f, 30.0f
		};
		var rects17 = new[] { 
			50.0f, 30.0f, 70.0f, 20.0f,
			30.0f, 40.0f, 50.0f, 30.0f
		};
		var rects18 = new[] { 
			50.0f, 50.0f, 70.0f, 40.0f,
			30.0f, 40.0f, 50.0f, 30.0f
		};
		var rects19 = new[] { 
			30.0f, 40.0f, 50.0f, 30.0f,
			30.0f, 40.0f, 50.0f, 30.0f
		};
		var rects20 = new[] { 
			35.0f, 40.0f, 55.0f, 30.0f,
			30.0f, 40.0f, 50.0f, 30.0f
		};
		var rects21 = new[] { 
			30.0f, 45.0f, 50.0f, 35.0f,
			30.0f, 40.0f, 50.0f, 30.0f
		};
		var rects22 = new[] { 
			32.0f, 38.0f, 48.0f, 32.0f,
			30.0f, 40.0f, 50.0f, 30.0f
		};
		var rects23 = new[] { 
			35.0f, 35.0f, 55.0f, 25.0f,
			30.0f, 40.0f, 50.0f, 30.0f
		};
		var rects24 = new[] { 
			35.0f, 45.0f, 55.0f, 35.0f,
			30.0f, 40.0f, 50.0f, 30.0f
		};
		var rects25 = new[] { 
			-30.0f, -30.0f, -10.0f, -40.0f,
			-60.0f, -30.0f, -40.0f, -40.0f
		};
		var rects26 = new[] { 
			-30.0f, -30.0f, -10.0f, -40.0f,
			-45.0f, -25.0f, -25.0f, -35.0f
		};
		
		yield return new TestCaseData(rects1).Returns(false);
		yield return new TestCaseData(rects2).Returns(false);
		yield return new TestCaseData(rects3).Returns(true);
		yield return new TestCaseData(rects4).Returns(true);
		yield return new TestCaseData(rects5).Returns(true);
		yield return new TestCaseData(rects6).Returns(true);
		yield return new TestCaseData(rects7).Returns(true);
		yield return new TestCaseData(rects8).Returns(true);
		yield return new TestCaseData(rects9).Returns(true);
		yield return new TestCaseData(rects10).Returns(false);
		yield return new TestCaseData(rects11).Returns(true);
		yield return new TestCaseData(rects12).Returns(true);
		yield return new TestCaseData(rects13).Returns(false);
		yield return new TestCaseData(rects14).Returns(false);
		yield return new TestCaseData(rects15).Returns(true);
		yield return new TestCaseData(rects16).Returns(true);
		yield return new TestCaseData(rects17).Returns(true);
		yield return new TestCaseData(rects18).Returns(true);
		yield return new TestCaseData(rects19).Returns(true);
		yield return new TestCaseData(rects20).Returns(true);
		yield return new TestCaseData(rects21).Returns(true);
		yield return new TestCaseData(rects22).Returns(false);
		yield return new TestCaseData(rects23).Returns(true);
		yield return new TestCaseData(rects24).Returns(true);
		yield return new TestCaseData(rects25).Returns(false);
		yield return new TestCaseData(rects26).Returns(true);
	}
	
	[Test, TestCaseSource(nameof(IsRectangleToRectangleIntersectTestsParameters))]
	public bool IsRectangleToRectangleIntersectTests(float[] rects)
	{
		var intersection = new Intersection();
		var rectangle1 = new CRectangle(rects[0], rects[1], rects[2], rects[3]);
		var rectangle2 = new CRectangle(rects[4], rects[5], rects[6], rects[7]);
		var isIntersect = intersection.IsIntersect(rectangle1, rectangle2);
		return isIntersect;
	}
	
	private static IEnumerable<TestCaseData> IsRectangleToRectangleIntersect2TestsParameters()
	{
		var rects1 = new[] { 
			30.0f, 40.0f, 50.0f, 30.0f, // rect
			35.0f, 35.0f, 35.0f, 25.0f  // line segment
		};
		var rects2 = new[] { 
			30.0f, 40.0f, 50.0f, 30.0f, // rect
			25.0f, 35.0f, 25.0f, 25.0f  // line segment
		};
		var rects3 = new[] { 
			30.0f, 30.0f, 50.0f, 30.0f, // line segment
			35.0f, 35.0f, 35.0f, 25.0f  // line segment
		};
		var rects4 = new[] { 
			30.0f, 30.0f, 50.0f, 30.0f, // line segment
			25.0f, 35.0f, 25.0f, 25.0f  // line segment
		};
		var rects5 = new[] { 
			30.0f, 40.0f, 50.0f, 30.0f, // rect
			40.0f, 40.0f, 40.0f, 40.0f  // point
		};
		var rects6 = new[] { 
			30.0f, 40.0f, 50.0f, 30.0f, // rect
			20.0f, 20.0f, 20.0f, 20.0f  // point
		};
		var rects7 = new[] { 
			30.0f, 40.0f, 50.0f, 40.0f, // line segment
			40.0f, 40.0f, 40.0f, 40.0f  // point
		};
		var rects8 = new[] { 
			30.0f, 40.0f, 50.0f, 40.0f, // line segment
			20.0f, 20.0f, 20.0f, 20.0f  // point
		};
		var rects9 = new[] { 
			40.0f, 40.0f, 40.0f, 40.0f, // point
			40.0f, 40.0f, 40.0f, 40.0f  // point
		};
		var rects10 = new[] { 
			20.0f, 20.0f, 20.0f, 20.0f, // point
			40.0f, 40.0f, 40.0f, 40.0f  // point
		};
		var rects11 = new[] { 
			35.0f, 35.0f, 35.0f, 25.0f, // line segment
			30.0f, 40.0f, 50.0f, 30.0f  // rect
		};
		var rects12 = new[] { 
			25.0f, 35.0f, 25.0f, 25.0f, // line segment
			30.0f, 40.0f, 50.0f, 30.0f  // rect
		};
		var rects13 = new[] { 
			40.0f, 40.0f, 40.0f, 40.0f, // point
			30.0f, 40.0f, 50.0f, 30.0f  // rect
		};
		var rects14 = new[] { 
			20.0f, 20.0f, 20.0f, 20.0f, // point
			30.0f, 40.0f, 50.0f, 30.0f  // rect
		};
		var rects15 = new[] { 
			40.0f, 40.0f, 40.0f, 40.0f, // point
			30.0f, 40.0f, 50.0f, 40.0f  // line segment
		};
		var rects16 = new[] { 
			20.0f, 20.0f, 20.0f, 20.0f, // point
			30.0f, 40.0f, 50.0f, 40.0f  // line segment
		};
		
		yield return new TestCaseData(rects1).Returns(true);
		yield return new TestCaseData(rects2).Returns(false);
		yield return new TestCaseData(rects3).Returns(true);
		yield return new TestCaseData(rects4).Returns(false);
		yield return new TestCaseData(rects5).Returns(false);
		yield return new TestCaseData(rects6).Returns(false);
		yield return new TestCaseData(rects7).Returns(false);
		yield return new TestCaseData(rects8).Returns(false);
		yield return new TestCaseData(rects9).Returns(false);
		yield return new TestCaseData(rects10).Returns(false);
		yield return new TestCaseData(rects11).Returns(true);
		yield return new TestCaseData(rects12).Returns(false);
		yield return new TestCaseData(rects13).Returns(false);
		yield return new TestCaseData(rects14).Returns(false);
		yield return new TestCaseData(rects15).Returns(false);
		yield return new TestCaseData(rects16).Returns(false);
	}
	
	[Test, TestCaseSource(nameof(IsRectangleToRectangleIntersect2TestsParameters))]
	public bool IsRectangleToRectangleIntersect2Tests(float[] rects)
	{
		var isIntersect = false;
		Assert.DoesNotThrow(
			() =>
			{
				var intersection = new Intersection();
				var rectangle1 = new CRectangle(rects[0], rects[1], rects[2], rects[3]);
				var rectangle2 = new CRectangle(rects[4], rects[5], rects[6], rects[7]);
				isIntersect = intersection.IsIntersect(rectangle1, rectangle2);
			});
		return isIntersect;
	}
	
	private static IEnumerable<TestCaseData> IsRectangleToRectangleIntersectSpecialTestsParameters()
	{
		var argsSpecial1 = new[] { 
			float.NaN, 40.0f, 40.0f, 30.0f,
			35.0f, 35.0f, 45.0f, 25.0f
		};
		var argsSpecial2 = new[] { 
			30.0f, float.NaN, 40.0f, 30.0f,
			35.0f, 35.0f, 45.0f, 25.0f
		};
		var argsSpecial3 = new[] { 
			30.0f, 40.0f, float.NaN, 30.0f,
			35.0f, 35.0f, 45.0f, 25.0f
		};
		var argsSpecial4 = new[] { 
			30.0f, 40.0f, 40.0f, float.NaN,
			35.0f, 35.0f, 45.0f, 25.0f
		};
		var argsSpecial5 = new[] { 
			30.0f, 40.0f, 40.0f, 30.0f,
			float.NaN, 35.0f, 45.0f, 25.0f
		};
		var argsSpecial6 = new[] { 
			30.0f, 40.0f, 40.0f, 30.0f,
			35.0f, float.NaN, 45.0f, 25.0f
		};
		var argsSpecial7 = new[] { 
			30.0f, 40.0f, 40.0f, 30.0f,
			35.0f, 35.0f, float.NaN, 25.0f
		};
		var argsSpecial8 = new[] { 
			30.0f, 40.0f, 40.0f, 30.0f,
			35.0f, 35.0f, 45.0f, float.NaN
		};
		
		var argsSpecial9 = new[] { 
			float.PositiveInfinity, 40.0f, 40.0f, 30.0f,
			35.0f, 35.0f, 45.0f, 25.0f
		};
		var argsSpecial10 = new[] { 
			30.0f, float.PositiveInfinity, 40.0f, 30.0f,
			35.0f, 35.0f, 45.0f, 25.0f
		};
		var argsSpecial11 = new[] { 
			30.0f, 40.0f, float.PositiveInfinity, 30.0f,
			35.0f, 35.0f, 45.0f, 25.0f
		};
		var argsSpecial12 = new[] { 
			30.0f, 40.0f, 40.0f, float.PositiveInfinity,
			35.0f, 35.0f, 45.0f, 25.0f
		};
		var argsSpecial13 = new[] { 
			30.0f, 40.0f, 40.0f, 30.0f,
			float.PositiveInfinity, 35.0f, 45.0f, 25.0f
		};
		var argsSpecial14 = new[] { 
			30.0f, 40.0f, 40.0f, 30.0f,
			35.0f, float.PositiveInfinity, 45.0f, 25.0f
		};
		var argsSpecial15 = new[] { 
			30.0f, 40.0f, 40.0f, 30.0f,
			35.0f, 35.0f, float.PositiveInfinity, 25.0f
		};
		var argsSpecial16 = new[] { 
			30.0f, 40.0f, 40.0f, 30.0f,
			35.0f, 35.0f, 45.0f, float.PositiveInfinity
		};
		
		var argsSpecial17 = new[] { 
			float.NegativeInfinity, 40.0f, 40.0f, 30.0f,
			35.0f, 35.0f, 45.0f, 25.0f
		};
		var argsSpecial18 = new[] { 
			30.0f, float.NegativeInfinity, 40.0f, 30.0f,
			35.0f, 35.0f, 45.0f, 25.0f
		};
		var argsSpecial19 = new[] { 
			30.0f, 40.0f, float.NegativeInfinity, 30.0f,
			35.0f, 35.0f, 45.0f, 25.0f
		};
		var argsSpecial20 = new[] { 
			30.0f, 40.0f, 40.0f, float.NegativeInfinity,
			35.0f, 35.0f, 45.0f, 25.0f
		};
		var argsSpecial21 = new[] { 
			30.0f, 40.0f, 40.0f, 30.0f,
			float.NegativeInfinity, 35.0f, 45.0f, 25.0f
		};
		var argsSpecial22 = new[] { 
			30.0f, 40.0f, 40.0f, 30.0f,
			35.0f, float.NegativeInfinity, 45.0f, 25.0f
		};
		var argsSpecial23 = new[] { 
			30.0f, 40.0f, 40.0f, 30.0f,
			35.0f, 35.0f, float.NegativeInfinity, 25.0f
		};
		var argsSpecial24 = new[] { 
			30.0f, 40.0f, 40.0f, 30.0f,
			35.0f, 35.0f, 45.0f, float.NegativeInfinity
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
	
	[Test, TestCaseSource(nameof(IsRectangleToRectangleIntersectSpecialTestsParameters))]
	public void IsRectangleToRectangleIntersectSpecialTests(float[] rects)
	{
		Assert.DoesNotThrow(
			() =>
			{
				var intersection = new Intersection();
				var rectangle1 = new CRectangle(rects[0], rects[1], rects[2], rects[3]);
				var rectangle2 = new CRectangle(rects[4], rects[5], rects[6], rects[7]);
				intersection.IsIntersect(rectangle1, rectangle2);
			});
	}
}