using ResourcesSystem;
using TMPro;
using UnityEngine;

public class SingleResourceUI : MonoBehaviour
{
	[SerializeField] TMP_Text resourceNameText;
	[SerializeField] TMP_Text valueText;
	Resource boundResource;
	public void Bind(Resource resource)
	{
		boundResource = resource;
        ResourcesSystem.Resources.OnResourceValueChanged += OnResourcesChanged;
		UpdateUI();
	}

	void OnDestroy() => ResourcesSystem.Resources.OnResourceValueChanged -= OnResourcesChanged;

	void OnResourcesChanged(Resource ___, float __, float _) => UpdateUI();

	void UpdateUI()
	{
		resourceNameText.text = $"{boundResource}: ";
		valueText.text = $"{ResourcesSystem.Resources.CountOf(boundResource)}";
	}
}
