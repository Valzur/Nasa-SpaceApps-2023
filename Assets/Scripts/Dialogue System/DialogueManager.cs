using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystem
{
	public class DialogueManager : MonoBehaviour
	{
		static DialogueManager instance;
		[SerializeField] GameObject gfxParent;
		[SerializeField] Button skipButton;
		[SerializeField] Button doneButton;
		[SerializeField] Image imageComponent;
		[SerializeField] Image speakerImageComponent;
		[SerializeField] TMP_Text speakerNameTextComponent;
		[SerializeField] TMP_Text speakerMessageTextComponent;
		int currentPartIndex = 0;
		Dialogue currentDialogue = null;

		void Awake()
		{
			instance = this;
			instance.gfxParent.SetActive(false);
		}

		public static void View(DialogueReference dialogueReference)
		{
			if(instance.currentDialogue != null)
			{
				return;
			}

			instance.gfxParent.SetActive(true);
			instance.currentDialogue = dialogueReference;
			instance.currentPartIndex = 0;
			instance.SetupCurrentPart();
		}

		public void SkipPart()
		{
			currentPartIndex++;
			instance.SetupCurrentPart();
		}

		public void Finish() => gfxParent.SetActive(false);

		void SetupCurrentPart()
		{
			skipButton.gameObject.SetActive(currentPartIndex != currentDialogue.DialogueID.Length);
			doneButton.gameObject.SetActive(currentPartIndex == currentDialogue.DialogueID.Length);
			imageComponent.sprite = currentDialogue.DialogueParts[currentPartIndex].Image;
			imageComponent.gameObject.SetActive(currentDialogue.DialogueParts[currentPartIndex].Image);
			speakerImageComponent.sprite = currentDialogue.DialogueParts[currentPartIndex].Image;
			speakerNameTextComponent.text = currentDialogue.DialogueParts[currentPartIndex].DialogueSpeaker.Name;
			speakerMessageTextComponent.text = currentDialogue.DialogueParts[currentPartIndex].Message;
		}
	}
}