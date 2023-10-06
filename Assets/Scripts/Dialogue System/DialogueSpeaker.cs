using System;
using System.Linq;
using NaughtyAttributes;
using UnityEngine;

namespace DialogueSystem
{
	[CreateAssetMenu]
	public class DialogueSpeaker : ScriptableObject
	{
		public static DialogueSpeaker[] All { get; private set; }
		public string Name;
		public Sprite Image;
	
		public static implicit operator DialogueSpeaker(DialogueSpeakerReference dialogueSpeakerReference) => All.First((dialogueSpeaker) => dialogueSpeaker.Name == dialogueSpeakerReference.Name);

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		public static void Init() => All = Resources.LoadAll<DialogueSpeaker>("Dialogue Speakers");
	}

	[Serializable]
	public class DialogueSpeakerReference
	{
		[Dropdown("GetDialogueSpeakerNameList")] public string Name;

#if UNITY_EDITOR
		public System.Collections.Generic.List<string> GetDialogueSpeakerNameList()
		{
			if(DialogueSpeaker.All == null)
			{
				DialogueSpeaker.Init();
			}

			System.Collections.Generic.List<string> list = new();

			list = DialogueSpeaker.All.Select((dialogueSpeaker) => dialogueSpeaker.Name).ToList();

			return list;
		}
#endif
	}
}