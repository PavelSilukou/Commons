using System.Diagnostics;

namespace Commons.Tests;

public class Tests
{
	[Test]
	public void Test()
	{
		
	}
	
	[Test]
	public void PerfTest()
	{
		var times = 100000;
		
		CalcElapsedTime(() =>
		{
			
		}, times);
		
		Assert.Pass();
		
	}

	private static void CalcElapsedTime(Action action, int times = 1)
	{
		var timer = new Stopwatch();
		timer.Start();
		for (var i = 0; i < times; i++)
		{
			action();
		}
		timer.Stop();
		var timeTaken = timer.ElapsedMilliseconds;
		Console.WriteLine(timeTaken);
	}
}