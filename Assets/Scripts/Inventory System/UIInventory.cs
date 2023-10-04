using System;
using InventorySystem;
using NaughtyAttributes;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
	[SerializeField] Transform slotsParent;
	[SerializeField] UIItemSlot itemSlotPrefab;
	Inventory playerInventory;
	UIItemSlot[] slots;

	void Start()
	{
		playerInventory = PlayerActor.Instance.PlayerInventory;

		playerInventory.OnItemsChanged += UpdateInventoryUI;

		InitializeSlots();
		UpdateInventoryUI();
	}

	void OnDestroy() => playerInventory.OnItemsChanged -= UpdateInventoryUI;

	void InitializeSlots()
	{
		slots = new UIItemSlot[playerInventory.Items.Length];
		for(int index = 0; index < playerInventory.Items.Length; index++)
		{
			UIItemSlot slot = Instantiate(itemSlotPrefab, slotsParent);
			slots[index] = slot;
		}
	}

	void UpdateInventoryUI()
	{
		for(int index = 0; index < playerInventory.Items.Length; index++)
		{
			slots[index].Bind(playerInventory.Items[index]);
		}
	}


#if UNITY_EDITOR
	static ItemData item1Data;

	[Button]
	void AddItem1()
	{
		if(item1Data == null)
		{
			item1Data = ScriptableObject.CreateInstance<ItemData>();
			item1Data.name = "Item 1";
		}

		bool isInserted = playerInventory.TryInsert(new Item(item1Data));
		Debug.Log($"Insertion: {isInserted}");
	}

	[Button]
	void AddRandomItem()
	{
		ItemData randomItemData = ScriptableObject.CreateInstance<ItemData>();
		randomItemData.name = "random";
		bool isInserted = playerInventory.TryInsert(new Item(randomItemData));
		Debug.Log($"Insertion: {isInserted}");
	}
#endif
}
