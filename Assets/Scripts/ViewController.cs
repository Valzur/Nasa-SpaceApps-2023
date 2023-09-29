using UnityEngine;

public class ViewController : MonoBehaviour
{
	[SerializeField] Camera playerCamera;
	[SerializeField] Transform lookTarget;
	[SerializeField] Vector2 cameraRotationLimit = new Vector2(100, 100);
	[SerializeField] Vector2 rotationSpeed = new Vector2(1, 1);

	void Awake()
	{
		playerCamera.transform.LookAt(lookTarget);
		playerCamera.transform.localEulerAngles = new Vector3(playerCamera.transform.localEulerAngles.x, 0, 0);
	}

	void Update()
	{
		transform.localEulerAngles += new Vector3(0, Input.GetAxis("Mouse X") * rotationSpeed.x);
		lookTarget.transform.localEulerAngles += new Vector3( - Input.GetAxis("Mouse Y") * rotationSpeed.y, 0);

		float xAngle = lookTarget.transform.localEulerAngles.x;
		if (xAngle < 0f)
		{
			xAngle = 360 + xAngle;
		}

        if (xAngle > 180f)
		{
			xAngle = Mathf.Max(xAngle, 360 + cameraRotationLimit.x);
		}
		else
		{
			xAngle = Mathf.Min(xAngle, cameraRotationLimit.y);
		}

		lookTarget.transform.localEulerAngles = new Vector3(xAngle, lookTarget.transform.localEulerAngles.y, lookTarget.transform.localEulerAngles.z);
	}
}
