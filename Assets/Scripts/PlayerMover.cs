using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerMover : MonoBehaviour
{
	[SerializeField] float speed = 1f;
	[SerializeField] float runningSpeedMultiplier = 2;
	[SerializeField] float jumpStrength = 100f;
	Rigidbody rigidbody;
	Animator animator;
	bool isJumping = false;

	void Awake()
	{
		animator = GetComponent<Animator>();
		rigidbody = GetComponent<Rigidbody>();
	}

	void Update()
	{
		bool isRunning = Input.GetKey(KeyCode.LeftShift);
		Vector3 movementDirectionInlocalSpace = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		float speedMultiplier = isRunning? runningSpeedMultiplier : 1;
		Vector3 movementVelocityInlocalSpace = movementDirectionInlocalSpace * speed * speedMultiplier;
		transform.position += transform.TransformVector(movementVelocityInlocalSpace) * Time.deltaTime;
		animator.SetFloat("SpeedX", movementVelocityInlocalSpace.x);
		animator.SetFloat("SpeedY", movementVelocityInlocalSpace.z);
		animator.SetBool("isRunning", isRunning);
		animator.SetBool("isMoving", movementVelocityInlocalSpace != Vector3.zero);

		if(Input.GetKeyDown(KeyCode.Space) && !isJumping)
		{
			animator.SetTrigger("Jump");
			animator.SetBool("isJumping", true);
			rigidbody.AddForce(Vector3.up * jumpStrength);
			isJumping = true;
		}
	}

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

		animator.SetBool("isJumping", false);
		isJumping = false;
	}
}
