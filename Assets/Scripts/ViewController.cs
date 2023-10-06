using NaughtyAttributes;
using UnityEngine;

public class ViewController : MonoBehaviour
{
	[SerializeField] Camera playerCamera;
	[SerializeField] Transform lookTarget;
	[SerializeField] Vector2 cameraRotationLimit = new Vector2(100, 100);
	[SerializeField] Vector2 rotationSpeed = new Vector2(1, 1);
	[Foldout("FPS")] [SerializeField] Vector3 FPSPlayerCameraLocalPosition = Vector3.zero;
	[Foldout("FPS")] [SerializeField] Vector3 FPSLookTargetLocalPosition = Vector3.up * 0.75f;
	[Foldout("TPS")] [SerializeField] Vector3 TPSPlayerCameraLocalPosition = new Vector3(0, -0.6f, -2f);
	[Foldout("TPS")] [SerializeField] Vector3 TPSLookTargetLocalPosition = Vector3.up;
	[SerializeField] KeyCode switchViewButton = KeyCode.Y;
	bool isTPS = true;

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

		if(Input.GetKeyDown(switchViewButton))
		{
			if(isTPS)
			{
				playerCamera.transform.localPosition = TPSPlayerCameraLocalPosition;
				lookTarget.transform.localPosition = TPSLookTargetLocalPosition;
			}
			else
			{
				playerCamera.transform.localPosition = FPSPlayerCameraLocalPosition;
				lookTarget.transform.localPosition = FPSLookTargetLocalPosition;
			}

			isTPS = !isTPS;
		}
	}
}
