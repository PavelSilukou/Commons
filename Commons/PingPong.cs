using JetBrains.Annotations;

namespace Commons
{
	[PublicAPI]
	public class PingPong
	{
		private float _t;
		private readonly float _min;
		private readonly float _max;

		public PingPong(float min, float max)
		{
			_t = 0.0f;
			_min = min;
			_max = max;
		}

		public PingPong(float t, float min, float max)
		{
			_t = t;
			_min = min;
			_max = max;
		}

		public float Next(float deltaT)
		{
			_t += deltaT;
			return MathFUtils.PingPong(_t, _min, _max);
		}
	}
}