using System;
using UnityEngine;

namespace DialogueSystem
{
	[Serializable]
	public struct DialoguePart
	{
		public DialogueSpeakerReference DialogueSpeaker;
		public string Message;
		public Sprite Image;
	}
}