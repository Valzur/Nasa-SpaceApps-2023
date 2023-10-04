using System.Linq;
using NaughtyAttributes;
using UnityEngine;

namespace DialogueSystem
{
	public class DialogueSpeaker : ScriptableObject
	{
		public static DialogueSpeaker[] All { get; private set; }
		public string Name;
		public Sprite Image;
	
		public static implicit operator DialogueSpeaker(DialogueSpeakerReference dialogueSpeakerReference) => All.First((dialogueSpeaker) => dialogueSpeaker.Name == dialogueSpeakerReference.DialogueSpeakerName);

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		static void Init() => All = Resources.LoadAll<DialogueSpeaker>("Dialogues/Speakers");
	}

	public struct DialogueSpeakerReference
	{
		[Dropdown("GetDialogueSpeakerNameList")] public string DialogueSpeakerName;

#if UNITY_EDITOR
		public System.Collections.Generic.List<string> GetDialogueSpeakerNameList()
		{
			System.Collections.Generic.List<string> list = new();

			list = DialogueSpeaker.All.Select((dialogueSpeaker) => dialogueSpeaker.Name).ToList();

			return list;
		}
#endif
	}
}