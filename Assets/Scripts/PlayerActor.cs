using InventorySystem;
using UnityEngine;

public class PlayerActor : Actor
{
	public static PlayerActor Instance;
	[field:SerializeField] Inventory playerInventory;

	protected override void Awake()
	{
		base.Awake();
		playerInventory = new(40);
		Instance = this;
	}
}
