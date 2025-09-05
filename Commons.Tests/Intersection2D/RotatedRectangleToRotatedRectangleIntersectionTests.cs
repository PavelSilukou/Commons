using System.Numerics;
using Commons.Intersection2D;
using Commons.Intersection2D.ShapeCreators;

namespace Commons.Tests.Intersection2D;

public class RotatedRectangleToRotatedRectangleIntersectionTests
{
	private static IEnumerable<TestCaseData> IsRotatedRectangleToRotatedRectangleIntersectTestsParameters()
	{
		var rects1 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(50.0f, 30.0f), new Vector2(30.0f, 30.0f),
			new Vector2(60.0f, 40.0f), new Vector2(80.0f, 40.0f), new Vector2(80.0f, 30.0f), new Vector2(60.0f, 30.0f)
		};
		var rects2 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(50.0f, 30.0f), new Vector2(30.0f, 30.0f),
			new Vector2(30.0f, 60.0f), new Vector2(50.0f, 60.0f), new Vector2(50.0f, 50.0f), new Vector2(30.0f, 50.0f)
		};
		var rects3 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(50.0f, 30.0f), new Vector2(30.0f, 30.0f),
			new Vector2(50.0f, 40.0f), new Vector2(70.0f, 40.0f), new Vector2(70.0f, 30.0f), new Vector2(50.0f, 30.0f)
		};
		var rects4 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(50.0f, 30.0f), new Vector2(30.0f, 30.0f),
			new Vector2(30.0f, 50.0f), new Vector2(50.0f, 50.0f), new Vector2(50.0f, 40.0f), new Vector2(30.0f, 40.0f)
		};
		var rects5 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(50.0f, 30.0f), new Vector2(30.0f, 30.0f),
			new Vector2(50.0f, 30.0f), new Vector2(70.0f, 30.0f), new Vector2(70.0f, 20.0f), new Vector2(50.0f, 20.0f)
		};
		var rects6 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(50.0f, 30.0f), new Vector2(30.0f, 30.0f),
			new Vector2(50.0f, 50.0f), new Vector2(70.0f, 50.0f), new Vector2(70.0f, 40.0f), new Vector2(50.0f, 40.0f)
		};
		var rects7 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(50.0f, 30.0f), new Vector2(30.0f, 30.0f),
			new Vector2(30.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(50.0f, 30.0f), new Vector2(30.0f, 30.0f)
		};
		var rects8 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(50.0f, 30.0f), new Vector2(30.0f, 30.0f),
			new Vector2(35.0f, 40.0f), new Vector2(55.0f, 40.0f), new Vector2(55.0f, 30.0f), new Vector2(35.0f, 30.0f)
		};
		var rects9 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(50.0f, 30.0f), new Vector2(30.0f, 30.0f),
			new Vector2(30.0f, 45.0f), new Vector2(50.0f, 45.0f), new Vector2(50.0f, 35.0f), new Vector2(30.0f, 35.0f)
		};
		var rects10 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(50.0f, 30.0f), new Vector2(30.0f, 30.0f),
			new Vector2(32.0f, 38.0f), new Vector2(48.0f, 38.0f), new Vector2(48.0f, 32.0f), new Vector2(32.0f, 32.0f)
		};
		var rects11 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(50.0f, 30.0f), new Vector2(30.0f, 30.0f),
			new Vector2(35.0f, 35.0f), new Vector2(55.0f, 35.0f), new Vector2(55.0f, 25.0f), new Vector2(35.0f, 25.0f)
		};
		var rects12 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(50.0f, 30.0f), new Vector2(30.0f, 30.0f),
			new Vector2(35.0f, 45.0f), new Vector2(55.0f, 45.0f), new Vector2(55.0f, 35.0f), new Vector2(35.0f, 35.0f)
		};
		var rects13 = new[] { 
			new Vector2(60.0f, 40.0f), new Vector2(80.0f, 40.0f), new Vector2(80.0f, 30.0f), new Vector2(60.0f, 30.0f),
			new Vector2(30.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(50.0f, 30.0f), new Vector2(30.0f, 30.0f)
		};
		var rects14 = new[] { 
			new Vector2(30.0f, 60.0f), new Vector2(50.0f, 60.0f), new Vector2(50.0f, 50.0f), new Vector2(30.0f, 50.0f),
			new Vector2(30.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(50.0f, 30.0f), new Vector2(30.0f, 30.0f)
		};
		var rects15 = new[] { 
			new Vector2(50.0f, 40.0f), new Vector2(70.0f, 40.0f), new Vector2(70.0f, 30.0f), new Vector2(50.0f, 30.0f),
			new Vector2(30.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(50.0f, 30.0f), new Vector2(30.0f, 30.0f)
		};
		var rects16 = new[] { 
			new Vector2(30.0f, 50.0f), new Vector2(50.0f, 50.0f), new Vector2(50.0f, 40.0f), new Vector2(30.0f, 40.0f),
			new Vector2(30.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(50.0f, 30.0f), new Vector2(30.0f, 30.0f)
		};
		var rects17 = new[] { 
			new Vector2(50.0f, 30.0f), new Vector2(70.0f, 30.0f), new Vector2(70.0f, 20.0f), new Vector2(50.0f, 20.0f),
			new Vector2(30.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(50.0f, 30.0f), new Vector2(30.0f, 30.0f)
		};
		var rects18 = new[] { 
			new Vector2(50.0f, 50.0f), new Vector2(70.0f, 50.0f), new Vector2(70.0f, 40.0f), new Vector2(50.0f, 40.0f),
			new Vector2(30.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(50.0f, 30.0f), new Vector2(30.0f, 30.0f)
		};
		var rects19 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(50.0f, 30.0f), new Vector2(30.0f, 30.0f),
			new Vector2(30.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(50.0f, 30.0f), new Vector2(30.0f, 30.0f)
		};
		var rects20 = new[] { 
			new Vector2(35.0f, 40.0f), new Vector2(55.0f, 40.0f), new Vector2(55.0f, 30.0f), new Vector2(35.0f, 30.0f),
			new Vector2(30.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(50.0f, 30.0f), new Vector2(30.0f, 30.0f)
		};
		var rects21 = new[] { 
			new Vector2(30.0f, 45.0f), new Vector2(50.0f, 45.0f), new Vector2(50.0f, 35.0f), new Vector2(30.0f, 35.0f),
			new Vector2(30.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(50.0f, 30.0f), new Vector2(30.0f, 30.0f)
		};
		var rects22 = new[] { 
			new Vector2(32.0f, 38.0f), new Vector2(48.0f, 38.0f), new Vector2(48.0f, 32.0f), new Vector2(32.0f, 32.0f),
			new Vector2(30.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(50.0f, 30.0f), new Vector2(30.0f, 30.0f)
		};
		var rects23 = new[] { 
			new Vector2(35.0f, 35.0f), new Vector2(55.0f, 35.0f), new Vector2(55.0f, 25.0f), new Vector2(35.0f, 25.0f),
			new Vector2(30.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(50.0f, 30.0f), new Vector2(30.0f, 30.0f)
		};
		var rects24 = new[] { 
			new Vector2(35.0f, 45.0f), new Vector2(55.0f, 45.0f), new Vector2(55.0f, 35.0f), new Vector2(35.0f, 35.0f),
			new Vector2(30.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(50.0f, 30.0f), new Vector2(30.0f, 30.0f)
		};
		var rects25 = new[] { 
			new Vector2(-40.0f, -30.0f), new Vector2(-20.0f, -30.0f), new Vector2(-20.0f, -40.0f), new Vector2(-40.0f, -40.0f),
			new Vector2(-70.0f, -30.0f), new Vector2(-50.0f, -30.0f), new Vector2(-50.0f, -40.0f), new Vector2(-70.0f, -40.0f)
		};
		var rects26 = new[] { 
			new Vector2(-40.0f, -30.0f), new Vector2(-20.0f, -30.0f), new Vector2(-20.0f, -40.0f), new Vector2(-40.0f, -40.0f),
			new Vector2(-45.0f, -25.0f), new Vector2(-25.0f, -25.0f), new Vector2(-25.0f, -35.0f), new Vector2(-45.0f, -35.0f)
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
	
	[Test, TestCaseSource(nameof(IsRotatedRectangleToRotatedRectangleIntersectTestsParameters))]
	public bool IsRotatedRectangleToRotatedRectangleIntersectTests(Vector2[] rects)
	{
		var intersection = new Intersection();
		var rotatedRectangle1 = RotatedRectangleCreator.TryCreate(rects[0], rects[1], rects[2], rects[3]);
		var rotatedRectangle2 = RotatedRectangleCreator.TryCreate(rects[4], rects[5], rects[6], rects[7]);
		var isIntersect = intersection.IsIntersect(rotatedRectangle1, rotatedRectangle2);
		return isIntersect;
	}
	
	[Test, TestCaseSource(nameof(IsRotatedRectangleToRotatedRectangleIntersectTestsParameters))]
	public bool IsRotatedRectangleToRotatedRectangleIntersect2Tests(Vector2[] rects)
	{
		var newRects = rects.Select(rect => Vector2Utils.RotateDeg(rect, 42.5f)).ToArray();
		var intersection = new Intersection();
		var rotatedRectangle1 = RotatedRectangleCreator.TryCreate(newRects[0], newRects[1], newRects[2], newRects[3]);
		var rotatedRectangle2 = RotatedRectangleCreator.TryCreate(newRects[4], newRects[5], newRects[6], newRects[7]);
		var isIntersect = intersection.IsIntersect(rotatedRectangle1, rotatedRectangle2);
		return isIntersect;
	}
	
	private static IEnumerable<TestCaseData> IsRotatedRectangleToRotatedRectangleIntersect2TestsParameters()
	{
		var rects1 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(50.0f, 30.0f), new Vector2(30.0f, 30.0f), // rect
			new Vector2(35.0f, 35.0f), new Vector2(35.0f, 35.0f), new Vector2(35.0f, 25.0f), new Vector2(35.0f, 25.0f)  // line segment
		};
		var rects2 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(50.0f, 30.0f), new Vector2(30.0f, 30.0f), // rect
			new Vector2(25.0f, 35.0f), new Vector2(25.0f, 35.0f), new Vector2(25.0f, 25.0f), new Vector2(25.0f, 25.0f)  // line segment
		};
		var rects3 = new[] { 
			new Vector2(30.0f, 30.0f), new Vector2(50.0f, 30.0f), new Vector2(50.0f, 30.0f), new Vector2(30.0f, 30.0f), // line segment
			new Vector2(35.0f, 35.0f), new Vector2(35.0f, 35.0f), new Vector2(35.0f, 25.0f), new Vector2(35.0f, 25.0f)  // line segment
		};
		var rects4 = new[] { 
			new Vector2(30.0f, 30.0f), new Vector2(50.0f, 30.0f), new Vector2(50.0f, 30.0f), new Vector2(30.0f, 30.0f), // line segment
			new Vector2(25.0f, 35.0f), new Vector2(25.0f, 35.0f), new Vector2(25.0f, 25.0f), new Vector2(25.0f, 25.0f)  // line segment
		};
		var rects5 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(50.0f, 30.0f), new Vector2(30.0f, 30.0f), // rect
			new Vector2(40.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 40.0f)  // point
		};
		var rects6 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(50.0f, 30.0f), new Vector2(30.0f, 30.0f), // rect
			new Vector2(20.0f, 20.0f), new Vector2(20.0f, 20.0f), new Vector2(20.0f, 20.0f), new Vector2(20.0f, 20.0f)  // point
		};
		var rects7 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(30.0f, 40.0f), // line segment
			new Vector2(40.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 40.0f)  // point
		};
		var rects8 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(30.0f, 40.0f), // line segment
			new Vector2(20.0f, 40.0f), new Vector2(20.0f, 40.0f), new Vector2(20.0f, 20.0f), new Vector2(20.0f, 20.0f)  // point
		};
		var rects9 = new[] { 
			new Vector2(40.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 40.0f), // point
			new Vector2(40.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 40.0f)  // point
		};
		var rects10 = new[] { 
			new Vector2(20.0f, 20.0f), new Vector2(20.0f, 20.0f), new Vector2(20.0f, 20.0f), new Vector2(20.0f, 20.0f), // point
			new Vector2(40.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 40.0f)  // point
		};
		var rects11 = new[] { 
			new Vector2(35.0f, 35.0f), new Vector2(35.0f, 35.0f), new Vector2(35.0f, 25.0f), new Vector2(35.0f, 25.0f), // line segment
			new Vector2(30.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(50.0f, 30.0f), new Vector2(30.0f, 30.0f)  // rect
		};
		var rects12 = new[] { 
			new Vector2(25.0f, 35.0f), new Vector2(25.0f, 35.0f), new Vector2(25.0f, 25.0f), new Vector2(25.0f, 25.0f), // line segment
			new Vector2(30.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(50.0f, 30.0f), new Vector2(30.0f, 30.0f)  // rect
		};
		var rects13 = new[] { 
			new Vector2(40.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 40.0f), // point
			new Vector2(30.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(50.0f, 30.0f), new Vector2(30.0f, 30.0f)  // rect
		};
		var rects14 = new[] { 
			new Vector2(20.0f, 20.0f), new Vector2(20.0f, 20.0f), new Vector2(20.0f, 20.0f), new Vector2(20.0f, 20.0f), // point
			new Vector2(30.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(50.0f, 30.0f), new Vector2(30.0f, 30.0f)  // rect
		};
		var rects15 = new[] { 
			new Vector2(40.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 40.0f), // point
			new Vector2(30.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(30.0f, 40.0f)  // line segment
		};
		var rects16 = new[] { 
			new Vector2(20.0f, 20.0f), new Vector2(20.0f, 20.0f), new Vector2(20.0f, 20.0f), new Vector2(20.0f, 20.0f), // point
			new Vector2(30.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(30.0f, 40.0f)  // line segment
		};
		// rhombus
		var rects17 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(50.0f, 30.0f), new Vector2(30.0f, 30.0f),
			new Vector2(40.0f, 20.0f), new Vector2(45.0f, 35.0f), new Vector2(40.0f, 50.0f), new Vector2(35.0f, 35.0f)
		};
		var rects18 = new[] { 
			new Vector2(40.0f, 20.0f), new Vector2(45.0f, 35.0f), new Vector2(40.0f, 50.0f), new Vector2(35.0f, 35.0f),
			new Vector2(30.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(50.0f, 30.0f), new Vector2(30.0f, 30.0f)
		};
		// parallelogram
		var rects19 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(50.0f, 30.0f), new Vector2(30.0f, 30.0f),
			new Vector2(30.0f, 50.0f), new Vector2(50.0f, 50.0f), new Vector2(40.0f, 20.0f), new Vector2(20.0f, 20.0f)
		};
		var rects20 = new[] { 
			new Vector2(30.0f, 50.0f), new Vector2(50.0f, 50.0f), new Vector2(40.0f, 20.0f), new Vector2(20.0f, 20.0f),
			new Vector2(30.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(50.0f, 30.0f), new Vector2(30.0f, 30.0f)
		};
		// convex quadrilateral
		var rects21 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(50.0f, 30.0f), new Vector2(30.0f, 30.0f),
			new Vector2(30.0f, 50.0f), new Vector2(40.0f, 50.0f), new Vector2(55.0f, 15.0f), new Vector2(20.0f, 20.0f)
		};
		var rects22 = new[] { 
			new Vector2(30.0f, 50.0f), new Vector2(40.0f, 50.0f), new Vector2(55.0f, 15.0f), new Vector2(20.0f, 20.0f),
			new Vector2(30.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(50.0f, 30.0f), new Vector2(30.0f, 30.0f)
		};
		// complex quadrilateral
		var rects23 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(50.0f, 30.0f), new Vector2(30.0f, 30.0f),
			new Vector2(30.0f, 50.0f), new Vector2(40.0f, 20.0f), new Vector2(50.0f, 50.0f), new Vector2(20.0f, 20.0f)
		};
		var rects24 = new[] { 
			new Vector2(30.0f, 50.0f), new Vector2(40.0f, 20.0f), new Vector2(50.0f, 50.0f), new Vector2(20.0f, 20.0f),
			new Vector2(30.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(50.0f, 30.0f), new Vector2(30.0f, 30.0f)
		};
		// concave quadrilateral
		var rects25 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(50.0f, 30.0f), new Vector2(30.0f, 30.0f),
			new Vector2(30.0f, 50.0f), new Vector2(35.0f, 35.0f), new Vector2(55.0f, 15.0f), new Vector2(20.0f, 20.0f)
		};
		var rects26 = new[] { 
			new Vector2(30.0f, 50.0f), new Vector2(35.0f, 35.0f), new Vector2(55.0f, 15.0f), new Vector2(20.0f, 20.0f),
			new Vector2(30.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(50.0f, 30.0f), new Vector2(30.0f, 30.0f)
		};
		// 3 collinear points
		var rects27 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(50.0f, 30.0f), new Vector2(30.0f, 30.0f),
			new Vector2(40.0f, 20.0f), new Vector2(40.0f, 35.0f), new Vector2(40.0f, 50.0f), new Vector2(35.0f, 35.0f)
		};
		var rects28 = new[] { 
			new Vector2(40.0f, 20.0f), new Vector2(40.0f, 35.0f), new Vector2(40.0f, 50.0f), new Vector2(35.0f, 35.0f),
			new Vector2(30.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(50.0f, 30.0f), new Vector2(30.0f, 30.0f)
		};
		// 4 collinear points
		var rects29 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(50.0f, 30.0f), new Vector2(30.0f, 30.0f),
			new Vector2(30.0f, 35.0f), new Vector2(50.0f, 35.0f), new Vector2(40.0f, 35.0f), new Vector2(20.0f, 35.0f)
		};
		var rects30 = new[] { 
			new Vector2(30.0f, 35.0f), new Vector2(50.0f, 35.0f), new Vector2(40.0f, 35.0f), new Vector2(20.0f, 35.0f),
			new Vector2(30.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(50.0f, 30.0f), new Vector2(30.0f, 30.0f)
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
		yield return new TestCaseData(rects17).Returns(true);
		yield return new TestCaseData(rects18).Returns(true);
		yield return new TestCaseData(rects19).Returns(true);
		yield return new TestCaseData(rects20).Returns(true);
		yield return new TestCaseData(rects21).Returns(true);
		yield return new TestCaseData(rects22).Returns(true);
		yield return new TestCaseData(rects23).Returns(true);
		yield return new TestCaseData(rects24).Returns(true);
		yield return new TestCaseData(rects25).Returns(true);
		yield return new TestCaseData(rects26).Returns(true);
		yield return new TestCaseData(rects27).Returns(true);
		yield return new TestCaseData(rects28).Returns(true);
		yield return new TestCaseData(rects29).Returns(true);
		yield return new TestCaseData(rects30).Returns(true);
	}
	
	[Test, TestCaseSource(nameof(IsRotatedRectangleToRotatedRectangleIntersect2TestsParameters))]
	public bool IsRotatedRectangleToRotatedRectangleIntersectDoesNotValidate3Tests(Vector2[] rects)
	{
		var newRects = rects.Select(rect => Vector2Utils.RotateDeg(rect, 42.5f)).ToArray();
		var isIntersect = false;
		Assert.DoesNotThrow(
			() =>
			{
				var intersection = new Intersection();
				var rotatedRectangle1 = RotatedRectangleCreator.TryCreate(newRects[0], newRects[1], newRects[2], newRects[3]);
				var rotatedRectangle2 = RotatedRectangleCreator.TryCreate(newRects[4], newRects[5], newRects[6], newRects[7]);
				isIntersect = intersection.IsIntersect(rotatedRectangle1, rotatedRectangle2);
			});
		return isIntersect;
	}
	
	private static IEnumerable<TestCaseData> IsRotatedRectangleToRotatedRectangleIntersectSpecialTestsParameters()
	{
		var argsSpecial1 = new[] { 
			new Vector2(float.NaN, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 30.0f), new Vector2(30.0f, 30.0f),
			new Vector2(35.0f, 35.0f), new Vector2(45.0f, 35.0f), new Vector2(45.0f, 25.0f), new Vector2(35.0f, 25.0f)
		};
		var argsSpecial2 = new[] { 
			new Vector2(30.0f, float.NaN), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 30.0f), new Vector2(30.0f, 30.0f),
			new Vector2(35.0f, 35.0f), new Vector2(45.0f, 35.0f), new Vector2(45.0f, 25.0f), new Vector2(35.0f, 25.0f)
		};
		var argsSpecial3 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(float.NaN, 40.0f), new Vector2(40.0f, 30.0f), new Vector2(30.0f, 30.0f),
			new Vector2(35.0f, 35.0f), new Vector2(45.0f, 35.0f), new Vector2(45.0f, 25.0f), new Vector2(35.0f, 25.0f)
		};
		var argsSpecial4 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(40.0f, float.NaN), new Vector2(40.0f, 30.0f), new Vector2(30.0f, 30.0f),
			new Vector2(35.0f, 35.0f), new Vector2(45.0f, 35.0f), new Vector2(45.0f, 25.0f), new Vector2(35.0f, 25.0f)
		};
		var argsSpecial5 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(float.NaN, 30.0f), new Vector2(30.0f, 30.0f),
			new Vector2(35.0f, 35.0f), new Vector2(45.0f, 35.0f), new Vector2(45.0f, 25.0f), new Vector2(35.0f, 25.0f)
		};
		var argsSpecial6 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, float.NaN), new Vector2(30.0f, 30.0f),
			new Vector2(35.0f, 35.0f), new Vector2(45.0f, 35.0f), new Vector2(45.0f, 25.0f), new Vector2(35.0f, 25.0f)
		};
		var argsSpecial7 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 30.0f), new Vector2(float.NaN, 30.0f),
			new Vector2(35.0f, 35.0f), new Vector2(45.0f, 35.0f), new Vector2(45.0f, 25.0f), new Vector2(35.0f, 25.0f)
		};
		var argsSpecial8 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 30.0f), new Vector2(30.0f, float.NaN),
			new Vector2(35.0f, 35.0f), new Vector2(45.0f, 35.0f), new Vector2(45.0f, 25.0f), new Vector2(35.0f, 25.0f)
		};
		var argsSpecial9 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 30.0f), new Vector2(30.0f, 30.0f),
			new Vector2(float.NaN, 35.0f), new Vector2(45.0f, 35.0f), new Vector2(45.0f, 25.0f), new Vector2(35.0f, 25.0f)
		};
		var argsSpecial10 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 30.0f), new Vector2(30.0f, 30.0f),
			new Vector2(35.0f, float.NaN), new Vector2(45.0f, 35.0f), new Vector2(45.0f, 25.0f), new Vector2(35.0f, 25.0f)
		};
		var argsSpecial11 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 30.0f), new Vector2(30.0f, 30.0f),
			new Vector2(35.0f, 35.0f), new Vector2(float.NaN, 35.0f), new Vector2(45.0f, 25.0f), new Vector2(35.0f, 25.0f)
		};
		var argsSpecial12 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 30.0f), new Vector2(30.0f, 30.0f),
			new Vector2(35.0f, 35.0f), new Vector2(45.0f, float.NaN), new Vector2(45.0f, 25.0f), new Vector2(35.0f, 25.0f)
		};
		var argsSpecial13 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 30.0f), new Vector2(30.0f, 30.0f),
			new Vector2(35.0f, 35.0f), new Vector2(45.0f, 35.0f), new Vector2(float.NaN, 25.0f), new Vector2(35.0f, 25.0f)
		};
		var argsSpecial14 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 30.0f), new Vector2(30.0f, 30.0f),
			new Vector2(35.0f, 35.0f), new Vector2(45.0f, 35.0f), new Vector2(45.0f, float.NaN), new Vector2(35.0f, 25.0f)
		};
		var argsSpecial15 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 30.0f), new Vector2(30.0f, 30.0f),
			new Vector2(35.0f, 35.0f), new Vector2(45.0f, 35.0f), new Vector2(45.0f, 25.0f), new Vector2(float.NaN, 25.0f)
		};
		var argsSpecial16 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 30.0f), new Vector2(30.0f, 30.0f),
			new Vector2(35.0f, 35.0f), new Vector2(45.0f, 35.0f), new Vector2(45.0f, 25.0f), new Vector2(35.0f, float.NaN)
		};
		
		var argsSpecial17 = new[] { 
			new Vector2(float.NaN, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 30.0f), new Vector2(30.0f, 30.0f),
			new Vector2(35.0f, 35.0f), new Vector2(45.0f, 35.0f), new Vector2(45.0f, 25.0f), new Vector2(35.0f, 25.0f)
		};
		var argsSpecial18 = new[] { 
			new Vector2(30.0f, float.NaN), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 30.0f), new Vector2(30.0f, 30.0f),
			new Vector2(35.0f, 35.0f), new Vector2(45.0f, 35.0f), new Vector2(45.0f, 25.0f), new Vector2(35.0f, 25.0f)
		};
		var argsSpecial19 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(float.NaN, 40.0f), new Vector2(40.0f, 30.0f), new Vector2(30.0f, 30.0f),
			new Vector2(35.0f, 35.0f), new Vector2(45.0f, 35.0f), new Vector2(45.0f, 25.0f), new Vector2(35.0f, 25.0f)
		};
		var argsSpecial20 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(40.0f, float.NaN), new Vector2(40.0f, 30.0f), new Vector2(30.0f, 30.0f),
			new Vector2(35.0f, 35.0f), new Vector2(45.0f, 35.0f), new Vector2(45.0f, 25.0f), new Vector2(35.0f, 25.0f)
		};
		var argsSpecial21 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(float.NaN, 30.0f), new Vector2(30.0f, 30.0f),
			new Vector2(35.0f, 35.0f), new Vector2(45.0f, 35.0f), new Vector2(45.0f, 25.0f), new Vector2(35.0f, 25.0f)
		};
		var argsSpecial22 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, float.NaN), new Vector2(30.0f, 30.0f),
			new Vector2(35.0f, 35.0f), new Vector2(45.0f, 35.0f), new Vector2(45.0f, 25.0f), new Vector2(35.0f, 25.0f)
		};
		var argsSpecial23 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 30.0f), new Vector2(float.NaN, 30.0f),
			new Vector2(35.0f, 35.0f), new Vector2(45.0f, 35.0f), new Vector2(45.0f, 25.0f), new Vector2(35.0f, 25.0f)
		};
		var argsSpecial24 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 30.0f), new Vector2(30.0f, float.NaN),
			new Vector2(35.0f, 35.0f), new Vector2(45.0f, 35.0f), new Vector2(45.0f, 25.0f), new Vector2(35.0f, 25.0f)
		};
		var argsSpecial25 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 30.0f), new Vector2(30.0f, 30.0f),
			new Vector2(float.NaN, 35.0f), new Vector2(45.0f, 35.0f), new Vector2(45.0f, 25.0f), new Vector2(35.0f, 25.0f)
		};
		var argsSpecial26 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 30.0f), new Vector2(30.0f, 30.0f),
			new Vector2(35.0f, float.NaN), new Vector2(45.0f, 35.0f), new Vector2(45.0f, 25.0f), new Vector2(35.0f, 25.0f)
		};
		var argsSpecial27 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 30.0f), new Vector2(30.0f, 30.0f),
			new Vector2(35.0f, 35.0f), new Vector2(float.NaN, 35.0f), new Vector2(45.0f, 25.0f), new Vector2(35.0f, 25.0f)
		};
		var argsSpecial28 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 30.0f), new Vector2(30.0f, 30.0f),
			new Vector2(35.0f, 35.0f), new Vector2(45.0f, float.NaN), new Vector2(45.0f, 25.0f), new Vector2(35.0f, 25.0f)
		};
		var argsSpecial29 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 30.0f), new Vector2(30.0f, 30.0f),
			new Vector2(35.0f, 35.0f), new Vector2(45.0f, 35.0f), new Vector2(float.NaN, 25.0f), new Vector2(35.0f, 25.0f)
		};
		var argsSpecial30 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 30.0f), new Vector2(30.0f, 30.0f),
			new Vector2(35.0f, 35.0f), new Vector2(45.0f, 35.0f), new Vector2(45.0f, float.NaN), new Vector2(35.0f, 25.0f)
		};
		var argsSpecial31 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 30.0f), new Vector2(30.0f, 30.0f),
			new Vector2(35.0f, 35.0f), new Vector2(45.0f, 35.0f), new Vector2(45.0f, 25.0f), new Vector2(float.NaN, 25.0f)
		};
		var argsSpecial32 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 30.0f), new Vector2(30.0f, 30.0f),
			new Vector2(35.0f, 35.0f), new Vector2(45.0f, 35.0f), new Vector2(45.0f, 25.0f), new Vector2(35.0f, float.NaN)
		};
		
		var argsSpecial33 = new[] { 
			new Vector2(float.NaN, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 30.0f), new Vector2(30.0f, 30.0f),
			new Vector2(35.0f, 35.0f), new Vector2(45.0f, 35.0f), new Vector2(45.0f, 25.0f), new Vector2(35.0f, 25.0f)
		};
		var argsSpecial34 = new[] { 
			new Vector2(30.0f, float.NaN), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 30.0f), new Vector2(30.0f, 30.0f),
			new Vector2(35.0f, 35.0f), new Vector2(45.0f, 35.0f), new Vector2(45.0f, 25.0f), new Vector2(35.0f, 25.0f)
		};
		var argsSpecial35 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(float.NaN, 40.0f), new Vector2(40.0f, 30.0f), new Vector2(30.0f, 30.0f),
			new Vector2(35.0f, 35.0f), new Vector2(45.0f, 35.0f), new Vector2(45.0f, 25.0f), new Vector2(35.0f, 25.0f)
		};
		var argsSpecial36 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(40.0f, float.NaN), new Vector2(40.0f, 30.0f), new Vector2(30.0f, 30.0f),
			new Vector2(35.0f, 35.0f), new Vector2(45.0f, 35.0f), new Vector2(45.0f, 25.0f), new Vector2(35.0f, 25.0f)
		};
		var argsSpecial37 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(float.NaN, 30.0f), new Vector2(30.0f, 30.0f),
			new Vector2(35.0f, 35.0f), new Vector2(45.0f, 35.0f), new Vector2(45.0f, 25.0f), new Vector2(35.0f, 25.0f)
		};
		var argsSpecial38 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, float.NaN), new Vector2(30.0f, 30.0f),
			new Vector2(35.0f, 35.0f), new Vector2(45.0f, 35.0f), new Vector2(45.0f, 25.0f), new Vector2(35.0f, 25.0f)
		};
		var argsSpecial39 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 30.0f), new Vector2(float.NaN, 30.0f),
			new Vector2(35.0f, 35.0f), new Vector2(45.0f, 35.0f), new Vector2(45.0f, 25.0f), new Vector2(35.0f, 25.0f)
		};
		var argsSpecial40 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 30.0f), new Vector2(30.0f, float.NaN),
			new Vector2(35.0f, 35.0f), new Vector2(45.0f, 35.0f), new Vector2(45.0f, 25.0f), new Vector2(35.0f, 25.0f)
		};
		var argsSpecial41 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 30.0f), new Vector2(30.0f, 30.0f),
			new Vector2(float.NaN, 35.0f), new Vector2(45.0f, 35.0f), new Vector2(45.0f, 25.0f), new Vector2(35.0f, 25.0f)
		};
		var argsSpecial42 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 30.0f), new Vector2(30.0f, 30.0f),
			new Vector2(35.0f, float.NaN), new Vector2(45.0f, 35.0f), new Vector2(45.0f, 25.0f), new Vector2(35.0f, 25.0f)
		};
		var argsSpecial43 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 30.0f), new Vector2(30.0f, 30.0f),
			new Vector2(35.0f, 35.0f), new Vector2(float.NaN, 35.0f), new Vector2(45.0f, 25.0f), new Vector2(35.0f, 25.0f)
		};
		var argsSpecial44 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 30.0f), new Vector2(30.0f, 30.0f),
			new Vector2(35.0f, 35.0f), new Vector2(45.0f, float.NaN), new Vector2(45.0f, 25.0f), new Vector2(35.0f, 25.0f)
		};
		var argsSpecial45 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 30.0f), new Vector2(30.0f, 30.0f),
			new Vector2(35.0f, 35.0f), new Vector2(45.0f, 35.0f), new Vector2(float.NaN, 25.0f), new Vector2(35.0f, 25.0f)
		};
		var argsSpecial46 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 30.0f), new Vector2(30.0f, 30.0f),
			new Vector2(35.0f, 35.0f), new Vector2(45.0f, 35.0f), new Vector2(45.0f, float.NaN), new Vector2(35.0f, 25.0f)
		};
		var argsSpecial47 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 30.0f), new Vector2(30.0f, 30.0f),
			new Vector2(35.0f, 35.0f), new Vector2(45.0f, 35.0f), new Vector2(45.0f, 25.0f), new Vector2(float.NaN, 25.0f)
		};
		var argsSpecial48 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 30.0f), new Vector2(30.0f, 30.0f),
			new Vector2(35.0f, 35.0f), new Vector2(45.0f, 35.0f), new Vector2(45.0f, 25.0f), new Vector2(35.0f, float.NaN)
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
		yield return new TestCaseData(argsSpecial25);
		yield return new TestCaseData(argsSpecial26);
		yield return new TestCaseData(argsSpecial27);
		yield return new TestCaseData(argsSpecial28);
		yield return new TestCaseData(argsSpecial29);
		yield return new TestCaseData(argsSpecial30);
		yield return new TestCaseData(argsSpecial31);
		yield return new TestCaseData(argsSpecial32);
		yield return new TestCaseData(argsSpecial33);
		yield return new TestCaseData(argsSpecial34);
		yield return new TestCaseData(argsSpecial35);
		yield return new TestCaseData(argsSpecial36);
		yield return new TestCaseData(argsSpecial37);
		yield return new TestCaseData(argsSpecial38);
		yield return new TestCaseData(argsSpecial39);
		yield return new TestCaseData(argsSpecial40);
		yield return new TestCaseData(argsSpecial41);
		yield return new TestCaseData(argsSpecial42);
		yield return new TestCaseData(argsSpecial43);
		yield return new TestCaseData(argsSpecial44);
		yield return new TestCaseData(argsSpecial45);
		yield return new TestCaseData(argsSpecial46);
		yield return new TestCaseData(argsSpecial47);
		yield return new TestCaseData(argsSpecial48);
	}
	
	[Test, TestCaseSource(nameof(IsRotatedRectangleToRotatedRectangleIntersectSpecialTestsParameters))]
	public void IsRotatedRectangleToRotatedRectangleIntersectSpecialTests(Vector2[] rects)
	{
		var newRects = rects.Select(rect => Vector2Utils.RotateDeg(rect, 42.5f)).ToArray();
		Assert.DoesNotThrow(
			() =>
			{
				var intersection = new Intersection();
				var rotatedRectangle1 = RotatedRectangleCreator.TryCreate(newRects[0], newRects[1], newRects[2], newRects[3]);
				var rotatedRectangle2 = RotatedRectangleCreator.TryCreate(newRects[4], newRects[5], newRects[6], newRects[7]);
				intersection.IsIntersect(rotatedRectangle1, rotatedRectangle2);
			});
	}
}