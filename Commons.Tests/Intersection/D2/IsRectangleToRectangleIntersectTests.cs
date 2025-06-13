using Commons.Math2D;

namespace Commons.Tests.Intersection.D2;

// ReSharper disable PossibleMultipleEnumeration
public partial class Intersection2DUtilsTests
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
		var rects27 = new[] { 
			30.0f, 40.0f, 50.0f, 30.0f,
			35.0f, 35.0f, 35.0f, 25.0f
		};
		var rects28 = new[] { 
			30.0f, 40.0f, 50.0f, 30.0f,
			25.0f, 35.0f, 25.0f, 25.0f
		};
		var rects29 = new[] { 
			30.0f, 30.0f, 50.0f, 30.0f,
			35.0f, 35.0f, 35.0f, 25.0f
		};
		var rects30 = new[] { 
			30.0f, 30.0f, 50.0f, 30.0f,
			25.0f, 35.0f, 25.0f, 25.0f
		};
		var rects31 = new[] { 
			30.0f, 40.0f, 50.0f, 30.0f,
			40.0f, 40.0f, 40.0f, 40.0f
		};
		var rects32 = new[] { 
			30.0f, 40.0f, 50.0f, 30.0f,
			20.0f, 20.0f, 20.0f, 20.0f
		};
		var rects33 = new[] { 
			30.0f, 40.0f, 50.0f, 40.0f,
			40.0f, 40.0f, 40.0f, 40.0f
		};
		var rects34 = new[] { 
			30.0f, 40.0f, 50.0f, 40.0f,
			20.0f, 20.0f, 20.0f, 20.0f
		};
		var rects35 = new[] { 
			40.0f, 40.0f, 40.0f, 40.0f,
			40.0f, 40.0f, 40.0f, 40.0f
		};
		var rects36 = new[] { 
			20.0f, 20.0f, 20.0f, 20.0f,
			40.0f, 40.0f, 40.0f, 40.0f
		};
		var rects37 = new[] { 
			35.0f, 35.0f, 35.0f, 25.0f,
			30.0f, 40.0f, 50.0f, 30.0f
		};
		var rects38 = new[] { 
			25.0f, 35.0f, 25.0f, 25.0f,
			30.0f, 40.0f, 50.0f, 30.0f
		};
		var rects39 = new[] { 
			40.0f, 40.0f, 40.0f, 40.0f,
			30.0f, 40.0f, 50.0f, 30.0f
		};
		var rects40 = new[] { 
			20.0f, 20.0f, 20.0f, 20.0f,
			30.0f, 40.0f, 50.0f, 30.0f
		};
		var rects41 = new[] { 
			40.0f, 40.0f, 40.0f, 40.0f,
			30.0f, 40.0f, 50.0f, 40.0f
		};
		var rects42 = new[] { 
			20.0f, 20.0f, 20.0f, 20.0f,
			30.0f, 40.0f, 50.0f, 40.0f
		};
		
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
		yield return new TestCaseData(rects27).Returns(true);
		yield return new TestCaseData(rects28).Returns(false);
		yield return new TestCaseData(rects29).Returns(true);
		yield return new TestCaseData(rects30).Returns(false);
		yield return new TestCaseData(rects31).Returns(false);
		yield return new TestCaseData(rects32).Returns(false);
		yield return new TestCaseData(rects33).Returns(false);
		yield return new TestCaseData(rects34).Returns(false);
		yield return new TestCaseData(rects35).Returns(false);
		yield return new TestCaseData(rects36).Returns(false);
		yield return new TestCaseData(rects37).Returns(true);
		yield return new TestCaseData(rects38).Returns(false);
		yield return new TestCaseData(rects39).Returns(false);
		yield return new TestCaseData(rects40).Returns(false);
		yield return new TestCaseData(rects41).Returns(false);
		yield return new TestCaseData(rects42).Returns(false);
		
		yield return new TestCaseData(argsSpecial1).Returns(false);
		yield return new TestCaseData(argsSpecial2).Returns(false);
		yield return new TestCaseData(argsSpecial3).Returns(false);
		yield return new TestCaseData(argsSpecial4).Returns(false);
		yield return new TestCaseData(argsSpecial5).Returns(false);
		yield return new TestCaseData(argsSpecial6).Returns(false);
		yield return new TestCaseData(argsSpecial7).Returns(false);
		yield return new TestCaseData(argsSpecial8).Returns(false);
		
		yield return new TestCaseData(argsSpecial9).Returns(false);
		yield return new TestCaseData(argsSpecial10).Returns(false);
		yield return new TestCaseData(argsSpecial11).Returns(false);
		yield return new TestCaseData(argsSpecial12).Returns(false);
		yield return new TestCaseData(argsSpecial13).Returns(false);
		yield return new TestCaseData(argsSpecial14).Returns(false);
		yield return new TestCaseData(argsSpecial15).Returns(false);
		yield return new TestCaseData(argsSpecial16).Returns(false);
		
		yield return new TestCaseData(argsSpecial17).Returns(false);
		yield return new TestCaseData(argsSpecial18).Returns(false);
		yield return new TestCaseData(argsSpecial19).Returns(false);
		yield return new TestCaseData(argsSpecial20).Returns(false);
		yield return new TestCaseData(argsSpecial21).Returns(false);
		yield return new TestCaseData(argsSpecial22).Returns(false);
		yield return new TestCaseData(argsSpecial23).Returns(false);
		yield return new TestCaseData(argsSpecial24).Returns(false);
	}
	
	[Test, TestCaseSource(nameof(IsRectangleToRectangleIntersectTestsParameters))]
	public bool IsRectangleToRectangleIntersectTests_ReturnsTrue(float[] rects)
	{
		return Intersection2DUtils.IsRectangleToRectangleIntersect(
			rects[0], rects[1], rects[2], rects[3],
			rects[4], rects[5], rects[6], rects[7]
		);
	}
}