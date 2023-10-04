namespace QuestSystem
{
	public static class QuestManager
	{
		public static Quest Current { get; private set; } = null;

		public static bool CanTakeQuest() => Current == null;

		public static void TakeQuest(QuestReference questReference)
		{
			if(!CanTakeQuest())
			{
				return;
			}

			Current = questReference;
		}

		public static void CompleteQuest()
		{
			if(Current == null)
			{
				return;
			}

			Current.OnQuestFinished();
			Current = null;
		}
	}


}