using InventorySystem;
using UnityEngine;

public class PlayerActor : Actor
{
	public static PlayerActor Instance;
	[field:SerializeField] public Inventory PlayerInventory { get; private set; }

	protected override void Awake()
	{
		base.Awake();
		PlayerInventory = new(40);
		Instance = this;
	}
}
