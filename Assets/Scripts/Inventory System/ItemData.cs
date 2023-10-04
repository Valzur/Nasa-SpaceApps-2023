using System;
using UnityEngine;

namespace InventorySystem
{
	[CreateAssetMenu]
	public class ItemData : ScriptableObject
	{
		public Sprite icon;
		public string name;
		public Action Consume;

		public virtual void Interact(){}
	}
}