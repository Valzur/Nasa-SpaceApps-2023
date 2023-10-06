using System.Collections;
using System.Collections.Generic;
using ResourcesSystem;
using UnityEngine;

public class OxygenHealthAffector : MonoBehaviour
{
	const float DAMAGE_PER_SECOND = 1;

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
	static void Init()
	{
		GameObject affectorGameObject = new();
		affectorGameObject.AddComponent<OxygenHealthAffector>();
		DontDestroyOnLoad(affectorGameObject);
	}

	void Update()
	{
		if(ResourcesSystem.Resources.CountOf(Resource.Oxygen) != 0)
		{
			return;
		}

		PlayerActor.Instance.Damage(DAMAGE_PER_SECOND * Time.deltaTime);
	}
}
