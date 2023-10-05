using DialogueSystem;
using UnityEngine;

public class QuestMonitor : Interactable
{
	[SerializeField] DialogueReference availableDialogue = new(){ DialogueID = "None" };
	[SerializeField] GameObject greenLightObject;

	public void OnMouseEnter() => greenLightObject.SetActive(true);
	public void OnMouseExit() => greenLightObject.SetActive(false);

	protected override void OnInteract()
	{
		base.OnInteract();
		DialogueManager.View(availableDialogue);
	}

}
