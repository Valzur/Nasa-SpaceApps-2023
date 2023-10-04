using System;
using System.Collections.Generic;

namespace ResourcesSystem
{
	public static class Resources
	{
		readonly static Dictionary<Resource, float> Starter = new(){  };
		static Dictionary<Resource, float> current;
		public static Action<Resource, float, float> OnResourceValueChanged;

		static Resources()
		{
			current = new();
			for (int i = 0; i < Enum.GetNames(typeof(Resource)).Length; i++)
			{
				current[(Resource)i] = 0;
			}

			foreach (var item in Starter)
			{
				current[item.Key] = item.Value;
			}
		}

		public static float CountOf(Resource resource) => current[resource];
		public static void Consume(Resource resource, float amount)
		{
			float oldValue = current[resource];
			current[resource] -= amount;
			OnResourceValueChanged?.Invoke(resource, oldValue, current[resource]);
		}

		public static void Add(Resource resource, float amount)
		{
			float oldValue = current[resource];
			current[resource] += amount;
			OnResourceValueChanged?.Invoke(resource, oldValue, current[resource]);
		}
	}
}