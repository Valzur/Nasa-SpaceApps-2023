using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(NavMeshAgent))]
public class Motor : MonoBehaviour
{
	[field:SerializeField] public float Speed { get; private set; } = 10f;
	[SerializeField] float jumpForce = 1f;
	NavMeshAgent navMeshAgent;
	Rigidbody rigidbody;
	bool isJumping;
	public event Action OnJump;
	public event Action OnLand;
	public Vector3 CurrentMoveOffset{ get; private set; }

	void Awake()
	{
		rigidbody = GetComponent<Rigidbody>();
		navMeshAgent = GetComponent<NavMeshAgent>();
	}

	void LateUpdate()
	{
		navMeshAgent.Move(CurrentMoveOffset);
		CurrentMoveOffset = Vector3.zero;
	}

	#region Public API
	public void Move(Vector3 direction, float speedMultiplier = 1f) => CurrentMoveOffset = direction.normalized * Speed * speedMultiplier;

	public void Jump()
	{
		if(isJumping)
		{
			return;
		}

		isJumping = true;
		OnJump?.Invoke();
		rigidbody.AddForce(jumpForce * Vector3.up);
	}
	#endregion

	[Button] void TestJump() => Jump();
	[Button] void TestWalkForward() => Move(transform.forward);

	void OnCollisionEnter(Collision collision)
	{
		if(!isJumping)
		{
			return;
		}

		List<ContactPoint> contactPoints = new();
		collision.GetContacts(contactPoints);
		foreach (var contactPoint in contactPoints)
		{
			if(contactPoint.point.y > transform.position.y)
			{
				return;
			}
		}

		isJumping = false;

		OnLand?.Invoke();
	}
}
