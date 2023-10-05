using UnityEngine;

namespace InventorySystem
{
	[CreateAssetMenu]
	public class PlaceableItem : ItemData
	{
		[SerializeField] GameObject prefab;
		public override void Interact()
		{
			Consume();
			// Place that prefab
		}
	}
}