using System;
using UnityEngine;

namespace InventorySystem
{
	[Serializable]
	public struct Item
	{
		public readonly static Item Empty;
		public ItemData data;
		public int Count;

		static Item()
		{
			Empty = new()
			{
				data = ScriptableObject.CreateInstance<ItemData>(),
				Count = 0,
			};
		}

		public Item(ItemData itemData)
		{
			data = itemData;
			Count = 1;
		}

		public void Interact() => data.Interact();

		public static bool operator ==(Item a, Item b) => a.data == b.data;
		public static bool operator !=(Item a, Item b) => a.data != b.data;
	}

}