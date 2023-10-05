using UnityEngine;

public class HUD : MonoBehaviour
{
	public static HUD Instance;

	void Awake() => Instance = this;
}
