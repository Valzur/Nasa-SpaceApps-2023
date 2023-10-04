using InventorySystem;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIItemSlot : MonoBehaviour, IPointerDownHandler
{
	[SerializeField] Image itemImage;
	[SerializeField] TMPro.TMP_Text countText;
	Item boundItem;

	public void Bind(Item item)
	{
		boundItem = item;
		itemImage.sprite = item.data.icon;
		countText.gameObject.SetActive(item.Count != 0);
		countText.text = item.Count.ToString();
	}

	public void RemoveItem()
	{
		itemImage.sprite = null;
		countText.text = string.Empty;
		boundItem = default;
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		if(eventData.button != PointerEventData.InputButton.Right)
		{
			return;
		}

		boundItem.Interact();
	}
}
