using System;
using UnityEngine;

namespace InventorySystem
{
	[Serializable]
	public class Inventory
	{
		readonly Item[] StarterItems = {};
		public Action OnItemsChanged;
		[field:SerializeField] public Item[] Items { get; private set; }
		public Inventory(int size)
		{
			Items = new Item[size];
			for (int i = 0; i < Items.Length; i++)
			{
				Items[i] = Item.Empty;
			}

			foreach (var item in StarterItems)
			{
				TryInsert(item);
			}
		}

		public bool TryInsert(Item item, int index = -1)
		{
			if(index == -1)
			{
				index = FirstEmptySlot(item);

				if(index == -1)
				{
					Debug.Log("No Empty Slots");
					return false;
				}
			}

			if(Items[index] != Item.Empty)
			{
				Items[index].Count += item.Count;
			}
			else
			{
				Items[index] = item;
			}

			
			OnItemsChanged?.Invoke();
			return true;
		}
	
		public void RemoveItem(Item item)
		{
			for (int itemIndex = 0; itemIndex < Items.Length; itemIndex++)
			{
				if(Items[itemIndex] == item)
				{
					RemoveItem(itemIndex);
					return;
				}
			}
		}

		public void RemoveItem(int index)
		{
			Items[index].Count--;
			if(Items[index].Count <= 0)
			{
				Items[index] = Item.Empty;
			}

			OnItemsChanged?.Invoke();
		}


		int FirstEmptySlot(Item item)
		{
			for (int i = 0; i < Items.Length; i++)
			{
				if(Items[i] == item || Items[i] == Item.Empty)
				{
					return i;
				}
			}

			return -1;
		}
	}
}
