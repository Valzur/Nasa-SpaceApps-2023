using UnityEngine;

namespace InventorySystem
{
	public class Item : ScriptableObject
	{
		[SerializeField] Sprite icon;
		[SerializeField] string name;
	}
}