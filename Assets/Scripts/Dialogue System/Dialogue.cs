using System.Linq;
using NaughtyAttributes;
using UnityEngine;

namespace DialogueSystem
{
	public class Dialogue : ScriptableObject
	{
		public static Dialogue[] All { get; private set; }
		public string DialogueID;
		public DialoguePart[] DialogueParts;

		public static implicit operator Dialogue(DialogueReference dialogueReference) => All.First((dialogue) => dialogue.DialogueID == dialogueReference.DialogueID);
		
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		static void Init() => All = Resources.LoadAll<Dialogue>("Dialogues");
	}

	public struct DialogueReference
	{
		[Dropdown("GetDialogueIDList")] public string DialogueID;

#if UNITY_EDITOR
		public System.Collections.Generic.List<string> GetDialogueIDList()
		{
			System.Collections.Generic.List<string> list = new();

			list = Dialogue.All.Select((dialogue) => dialogue.DialogueID).ToList();

			return list;
		}
#endif
    }
}