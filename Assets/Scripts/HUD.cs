using UnityEngine;

public class HUD : MonoBehaviour
{
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
	static void Init()
	{
		GameObject hudPrefab = Resources.Load<GameObject>("HUD");
	}
}
