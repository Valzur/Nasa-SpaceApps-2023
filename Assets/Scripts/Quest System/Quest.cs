using System;
using System.Linq;
using DialogueSystem;
using NaughtyAttributes;
using UnityEngine;

namespace QuestSystem
{
	public abstract class Quest
	{
		public static Quest[] All { get; private set; }
		public abstract string Name { get; }
		public virtual DialogueReference InitalDialogue
		{
			get
			{
				return DialogueReference.None;
			}
		}

		public virtual DialogueReference FinalDialogue
		{
			get
			{
				return DialogueReference.None;
			}
		}

		public virtual void OnQuestStarted(){}
		public virtual void OnQuestFinished(){}

		public static implicit operator Quest(QuestReference questReference) => All.First((quest) => quest.Name == questReference.QuestName);

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		public static void Init()
		{
			All = typeof(Quest).Assembly.GetTypes()
				.Where((type) => !type.IsAbstract && type.IsSubclassOf(typeof(Quest)))
				.Select((type) => Activator.CreateInstance(type) as Quest)
				.ToArray();
		}
	}

	[Serializable]
	public struct QuestReference
	{
		[Dropdown("GetQuestList")] public string QuestName;

#if UNITY_EDITOR
		public System.Collections.Generic.List<string> GetQuestList()
		{
			if(Quest.All == null)
			{
				Quest.Init();
			}

			System.Collections.Generic.List<string> list = new();

			list = Quest.All.Select((quest) => quest.Name).ToList();

			return list;
		}
#endif
	}
}