using JetBrains.Annotations;

namespace Commons
{
	[PublicAPI]
	public class Singleton<T> where T : new()
	{
		private static T _instance = default!;

		protected Singleton()
		{
		}

#pragma warning disable S2955 // Generic parameters not constrained to reference types should not be compared to "null"
		public static T Instance()
		{
			if (_instance == null)
			{
				_instance = new T();
			}

			return _instance;
		}
	}
#pragma warning restore S2955 // Generic parameters not constrained to reference types should not be compared to "null"
}