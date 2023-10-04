using UnityEngine;
using NaughtyAttributes;
using System;

public class Actor : MonoBehaviour
{
	[SerializeField] int maxHealth;
	[SerializeField][ReadOnly] float _currentHealth;
	public float CurrentHealth
	{
		get
		{
			return _currentHealth;
		}

		private set
		{
			_currentHealth = value;
			OnHealthChanged?.Invoke(value);
		}
	}

	[SerializeField] float oxygenRateOfConsumption;
	[SerializeField] float baseOxygenCapacity;
	[SerializeField] float baseRadiationResistance;
#region Events
	public event Action<float> OnDamageTaken;
	public event Action<float> OnHealthChanged;
	public event Action OnDeath;
#endregion

	protected virtual void Awake()
	{
		CurrentHealth = maxHealth;
	}

	public void Damage(float amount)
	{
		CurrentHealth = Mathf.Min(0, CurrentHealth - amount);
		OnDamageTaken?.Invoke(amount);
		if(CurrentHealth <= 0)
		{
			OnDeath?.Invoke();
		}
	}

	public void Radiate()
	{
		
	}
}
