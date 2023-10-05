using System;
using UnityEngine;

namespace InventorySystem
{
	[CreateAssetMenu]
	public class ItemData : ScriptableObject
	{
		public Sprite icon;
		public string name;

		public virtual void Interact(){}
        protected void Consume() => PlayerActor.Instance.PlayerInventory.RemoveItem(new Item(this));
    }
}