using System.Numerics;
using Commons.Math2D;

namespace Commons.Tests.Intersection.D2;

// ReSharper disable PossibleMultipleEnumeration
public partial class Intersection2DUtilsTests
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
		var rects27 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(50.0f, 30.0f), new Vector2(30.0f, 30.0f),
			new Vector2(35.0f, 35.0f), new Vector2(35.0f, 35.0f), new Vector2(35.0f, 25.0f), new Vector2(35.0f, 25.0f)
		};
		var rects28 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(50.0f, 30.0f), new Vector2(30.0f, 30.0f),
			new Vector2(25.0f, 35.0f), new Vector2(25.0f, 35.0f), new Vector2(25.0f, 25.0f), new Vector2(25.0f, 25.0f)
		};
		var rects29 = new[] { 
			new Vector2(30.0f, 30.0f), new Vector2(50.0f, 30.0f), new Vector2(50.0f, 30.0f), new Vector2(30.0f, 30.0f),
			new Vector2(35.0f, 35.0f), new Vector2(35.0f, 35.0f), new Vector2(35.0f, 25.0f), new Vector2(35.0f, 25.0f)
		};
		var rects30 = new[] { 
			new Vector2(30.0f, 30.0f), new Vector2(50.0f, 30.0f), new Vector2(50.0f, 30.0f), new Vector2(30.0f, 30.0f),
			new Vector2(25.0f, 35.0f), new Vector2(25.0f, 35.0f), new Vector2(25.0f, 25.0f), new Vector2(25.0f, 25.0f)
		};
		var rects31 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(50.0f, 30.0f), new Vector2(30.0f, 30.0f),
			new Vector2(40.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 40.0f)
		};
		var rects32 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(50.0f, 30.0f), new Vector2(30.0f, 30.0f),
			new Vector2(20.0f, 20.0f), new Vector2(20.0f, 20.0f), new Vector2(20.0f, 20.0f), new Vector2(20.0f, 20.0f)
		};
		var rects33 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(30.0f, 40.0f),
			new Vector2(40.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 40.0f)
		};
		var rects34 = new[] { 
			new Vector2(30.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(30.0f, 40.0f),
			new Vector2(20.0f, 40.0f), new Vector2(20.0f, 40.0f), new Vector2(20.0f, 20.0f), new Vector2(20.0f, 20.0f)
		};
		var rects35 = new[] { 
			new Vector2(40.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 40.0f),
			new Vector2(40.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 40.0f)
		};
		var rects36 = new[] { 
			new Vector2(20.0f, 20.0f), new Vector2(20.0f, 20.0f), new Vector2(20.0f, 20.0f), new Vector2(20.0f, 20.0f),
			new Vector2(40.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 40.0f)
		};
		var rects37 = new[] { 
			new Vector2(35.0f, 35.0f), new Vector2(35.0f, 35.0f), new Vector2(35.0f, 25.0f), new Vector2(35.0f, 25.0f),
			new Vector2(30.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(50.0f, 30.0f), new Vector2(30.0f, 30.0f)
		};
		var rects38 = new[] { 
			new Vector2(25.0f, 35.0f), new Vector2(25.0f, 35.0f), new Vector2(25.0f, 25.0f), new Vector2(25.0f, 25.0f),
			new Vector2(30.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(50.0f, 30.0f), new Vector2(30.0f, 30.0f)
		};
		var rects39 = new[] { 
			new Vector2(40.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 40.0f),
			new Vector2(30.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(50.0f, 30.0f), new Vector2(30.0f, 30.0f)
		};
		var rects40 = new[] { 
			new Vector2(20.0f, 20.0f), new Vector2(20.0f, 20.0f), new Vector2(20.0f, 20.0f), new Vector2(20.0f, 20.0f),
			new Vector2(30.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(50.0f, 30.0f), new Vector2(30.0f, 30.0f)
		};
		var rects41 = new[] { 
			new Vector2(40.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 40.0f), new Vector2(40.0f, 40.0f),
			new Vector2(30.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(30.0f, 40.0f)
		};
		var rects42 = new[] { 
			new Vector2(20.0f, 20.0f), new Vector2(20.0f, 20.0f), new Vector2(20.0f, 20.0f), new Vector2(20.0f, 20.0f),
			new Vector2(30.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(50.0f, 40.0f), new Vector2(30.0f, 40.0f)
		};
		
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
		yield return new TestCaseData(argsSpecial25).Returns(false);
		yield return new TestCaseData(argsSpecial26).Returns(false);
		yield return new TestCaseData(argsSpecial27).Returns(false);
		yield return new TestCaseData(argsSpecial28).Returns(false);
		yield return new TestCaseData(argsSpecial29).Returns(false);
		yield return new TestCaseData(argsSpecial30).Returns(false);
		yield return new TestCaseData(argsSpecial31).Returns(false);
		yield return new TestCaseData(argsSpecial32).Returns(false);
		
		yield return new TestCaseData(argsSpecial33).Returns(false);
		yield return new TestCaseData(argsSpecial34).Returns(false);
		yield return new TestCaseData(argsSpecial35).Returns(false);
		yield return new TestCaseData(argsSpecial36).Returns(false);
		yield return new TestCaseData(argsSpecial37).Returns(false);
		yield return new TestCaseData(argsSpecial38).Returns(false);
		yield return new TestCaseData(argsSpecial39).Returns(false);
		yield return new TestCaseData(argsSpecial40).Returns(false);
		yield return new TestCaseData(argsSpecial41).Returns(false);
		yield return new TestCaseData(argsSpecial42).Returns(false);
		yield return new TestCaseData(argsSpecial43).Returns(false);
		yield return new TestCaseData(argsSpecial44).Returns(false);
		yield return new TestCaseData(argsSpecial45).Returns(false);
		yield return new TestCaseData(argsSpecial46).Returns(false);
		yield return new TestCaseData(argsSpecial47).Returns(false);
		yield return new TestCaseData(argsSpecial48).Returns(false);
	}
	
	[Test, TestCaseSource(nameof(IsRotatedRectangleToRotatedRectangleIntersectTestsParameters))]
	public bool IsRotatedRectangleToRotatedRectangleIntersectTests_ReturnsTrue(Vector2[] rects)
	{
		return Intersection2DUtils.IsRotatedRectangleToRotatedRectangleIntersect(
			rects[0], rects[1], rects[2], rects[3],
			rects[4], rects[5], rects[6], rects[7]
		);
	}
	
	[Test, TestCaseSource(nameof(IsRotatedRectangleToRotatedRectangleIntersectTestsParameters))]
	public bool IsRotatedRectangleToRotatedRectangleIntersectTests_RotatedRectangles_ReturnsTrue(Vector2[] rects)
	{
		var newRects = rects.Select(rect => Vector2Utils.RotateDeg(rect, 42.5f)).ToArray();
		return Intersection2DUtils.IsRotatedRectangleToRotatedRectangleIntersect(
			newRects[0], newRects[1], newRects[2], newRects[3],
			newRects[4], newRects[5], newRects[6], newRects[7]
		);
	}
	
	[Test, TestCaseSource(nameof(IsRotatedRectangleToRotatedRectangleIntersectTestsParameters))]
	public bool IsRotatedRectangleToRotatedRectangleIntersectTests2_ReturnsTrue(Vector2[] rects)
	{
		var rect1 = new[] { rects[0], rects[1], rects[2], rects[3] };
		var rect2 = new[] { rects[4], rects[5], rects[6], rects[7] };
		return Intersection2DUtils.IsRotatedRectangleToRotatedRectangleIntersect(rect1, rect2);
	}
	
	[Test, TestCaseSource(nameof(IsRotatedRectangleToRotatedRectangleIntersectTestsParameters))]
	public bool IsRotatedRectangleToRotatedRectangleIntersectTests2_RotatedRectangles_ReturnsTrue(Vector2[] rects)
	{
		var newRects = rects.Select(rect => Vector2Utils.RotateDeg(rect, 42.5f)).ToArray();
		var newRect1 = new[] { newRects[0], newRects[1], newRects[2], newRects[3] };
		var newRect2 = new[] { newRects[4], newRects[5], newRects[6], newRects[7] };
		return Intersection2DUtils.IsRotatedRectangleToRotatedRectangleIntersect(newRect1, newRect2);
	}
}