using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public Transform target; // Drag the target to follow in the inspector.
	public bool clamp;
	public Vector2 clampX, clampY;

	// Speed at which the camera follows the player.
	private float smoothSpeed = 2f;

	// Distance from player to camera.
	private float yOffset = 3f;
	private float zOffset = -5f;

	private void Start()
	{
		// Rotate camera.
		transform.eulerAngles = new Vector3(30, 0, 0);
	}

	private void FixedUpdate()
	{
		Follow();
	}

	private void Follow() // Handles camera distance.
	{
		Vector3 offset = new Vector3(0, yOffset, zOffset);
		Vector3 desiredPos = target.position + offset;
		Vector3 cameraPos = new Vector3(target.position.x, target.position.y + yOffset, target.position.z + zOffset);
		Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed * Time.deltaTime);

		if (clamp)
		{
			transform.position = new Vector3(Mathf.Clamp(smoothedPos.x, clampX.x, clampY.y), Mathf.Clamp(smoothedPos.y, clampX.x, clampY.y), smoothedPos.z);
		}
		else
		{
			transform.position = cameraPos;
		}
	}
}
