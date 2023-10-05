using System;
using System.Linq;
using NaughtyAttributes;
using UnityEngine;

namespace DialogueSystem
{
	[CreateAssetMenu]
	public class Dialogue : ScriptableObject
	{
		public static Dialogue[] All { get; private set; }
		public string DialogueID;
		public DialoguePart[] DialogueParts;

		public static implicit operator Dialogue(DialogueReference dialogueReference) => All.First((dialogue) => dialogue.DialogueID == dialogueReference.DialogueID);
		
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		public static void Init() => All = Resources.LoadAll<Dialogue>("Dialogues");
	}

	[Serializable]
	public struct DialogueReference
	{
		public static readonly DialogueReference None;
		[Dropdown("GetDialogueIDList")] public string DialogueID;

#if UNITY_EDITOR
		public System.Collections.Generic.List<string> GetDialogueIDList()
		{
			if(Dialogue.All == null)
			{
				Dialogue.Init();
			}

			System.Collections.Generic.List<string> list = new();

			list = Dialogue.All.Select((dialogue) => dialogue.DialogueID).ToList();

			return list;
		}
#endif
    }
}