
using UnityEngine;

namespace InventorySystem
{
	[System.Serializable]
	public class Inventory
	{
		[SerializeField] Item[] items;
		public Inventory(int size)
		{
			items = new Item[size];
		}

		public void Move(int originalItemPosition, int targetItemPosition)
		{
			items[targetItemPosition] = items[originalItemPosition];
			items[originalItemPosition] = null;
		}
	}
}
