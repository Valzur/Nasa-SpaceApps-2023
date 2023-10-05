using System;
using ResourcesSystem;
using UnityEngine;

public class Habitat : MonoBehaviour
{
	[SerializeField] float rateOfMethaneConsumption = 0.01f;
	[SerializeField] float rateOfTemperatureLoss = -1f;

	public float currentTemperature = 26;


	void Update()
	{
		if(ResourcesSystem.Resources.CountOf(Resource.Methane) <= 0)
		{
			currentTemperature = Math.Clamp(currentTemperature - rateOfTemperatureLoss * Time.deltaTime, -179f, 26f);
			return;
		}

		currentTemperature = 26f;
		ResourcesSystem.Resources.Consume(Resource.Methane, - rateOfMethaneConsumption * Time.deltaTime);
	}

	void OnTriggerStay(Collider other)
	{
		if(currentTemperature >= 0)
		{
			return;
		}

		if(!other.TryGetComponent(out PlayerActor playerActor))
		{
			playerActor.Damage(currentTemperature * Time.deltaTime / 10);
			return;
		}
	}
}
