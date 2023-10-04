using System;
using UnityEngine;

namespace DialogueSystem
{
	[Serializable]
	public struct DialoguePart
	{
		public DialogueSpeaker DialogueSpeaker;
		public string Message;
		public Sprite Image;
	}
}