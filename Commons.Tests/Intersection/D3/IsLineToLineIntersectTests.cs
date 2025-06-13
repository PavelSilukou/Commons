using System.Numerics;
using Commons.Math3D;

namespace Commons.Tests.Intersection.D3;

public partial class Intersection3DUtilsTests
{
	private static IEnumerable<TestCaseData> IsLineToLineIntersectTestsParameters()
	{
		var args1 = new object?[] { new Vector3(10.0f, 10.0f, 0.0f), new Vector3(20.0f, 20.0f, 0.0f), new Vector3(10.0f, 20.0f, 0.0f), new Vector3(20.0f, 10.0f, 0.0f) };
		var args2 = new object?[] { new Vector3(10.0f, 10.0f, 0.0f), new Vector3(20.0f, 20.0f, 0.0f), new Vector3(50.0f, 10.0f, 0.0f), new Vector3(40.0f, 20.0f, 0.0f) };
		var args3 = new object?[] { new Vector3(10.0f, 10.0f, 0.0f), new Vector3(10.0f, 20.0f, 0.0f), new Vector3(30.0f, 30.0f, 0.0f), new Vector3(30.0f, 40.0f, 0.0f) };
		var args4 = new object?[] { new Vector3(10.0f, 10.0f, 0.0f), new Vector3(10.0f, 20.0f, 0.0f), new Vector3(10.0f, 10.0f, 0.0f), new Vector3(10.0f, 20.0f, 0.0f) };

		(bool, Vector3?) returns1 = (true, new Vector3(15.0f, 15.0f, 0.0f));
		(bool, Vector3?) returns2 = (true, new Vector3(30.0f, 30.0f, 0.0f));
		(bool, Vector3?) returns3 = (false, null);

		yield return new TestCaseData(args1).Returns(returns1);
		yield return new TestCaseData(args2).Returns(returns2);
		yield return new TestCaseData(args3).Returns(returns3);
		yield return new TestCaseData(args4).Returns(returns3);
	}
	
	[Test, TestCaseSource(nameof(IsLineToLineIntersectTestsParameters))]
	public (bool, Vector3?) IsLineToLineIntersectTests(
		Vector3 point1,
		Vector3 point2,
		Vector3 point3,
		Vector3 point4
	)
	{
		var isIntersect = Intersection3DUtils.IsLineToLineIntersect(
			out var intersectionPoint, 
			point1, 
			point2, 
			point3, 
			point4
		);

		return (isIntersect, intersectionPoint);
	}
}