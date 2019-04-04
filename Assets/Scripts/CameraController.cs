using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	private Transform target;
	public bool clamp;
	public Vector2 clampX, clampY;

	// Array of all the cameras.
	public GameObject[] cameras;
	[HideInInspector] public static int currentCamera; // This is the only active camera.
	public Vector3[] initialCameraLocation; // Store initial camera positions.
	public Vector3[] currentCameraLocation; // Stores the current camera positions.
	[SerializeField] private float targetDistance;
	private float cameraRange = 5f; // Switches camera if within this range.

	// Speed at which the camera follows the player.
	private float smoothSpeed = 5f;

	// Camera angle.
	private float cameraAngle = 20f;
	private float angleClose = 10f;

	// Camera rotation.
	private Transform fromRot;
	private Transform toRot;
	private float rotCountClose = 0.0f;
	private float rotCountNormal = 0.0f;

	// Distance from player to camera.
	private float yOffset = 2f;
	private float yClose = 1f;
	private float yNormal = 2f;

	private float zOffset = -1f;
	private float zClose = -1.7f;
	private float zNormal = 1f;

	private void Start()
	{
		target = GameObject.FindGameObjectWithTag("Player").transform;

		// Store initial camera positions.
		initialCameraLocation = new Vector3[cameras.Length];
		CameraSpawnLocation();

		// Store current camera positions.
		currentCameraLocation = new Vector3[cameras.Length];

		// Starts game with main camera.
		currentCamera = 0;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space)) currentCamera = 1;

		zOffset = PickupInteraction.isInteracting ? zClose : zNormal;
		yOffset = PickupInteraction.isInteracting ? yClose : yNormal;
	}

	private void FixedUpdate()
	{
		CameraCurrentLocation();
		Follow();
	}

	private void Follow() // Handles camera movement.
	{
		//Vector3 cameraPos = new Vector3(target.position.x, target.position.y + yOffset, target.position.z + zOffset);
		//Vector3 cameraPos = new Vector3(target.position.x, target.position.y + yOffset, 0 + zOffset);
		//Vector3 offset = new Vector3(target.position.x, target.position.y + yOffset, zOffset);

		// Position.
		Vector3 cameraPos = new Vector3(target.position.x, target.position.y + yOffset, zOffset);
		Vector3 cameraClose = new Vector3(target.position.x, target.position.y + yClose, zClose);

		// Rotation.
		Vector3 cameraRot = new Vector3(cameraAngle, 0, 0);
		Quaternion cameraCloseRot = new Quaternion(angleClose, 0, 0, 0);

		if (clamp)
		{
			//currentCamera.transform.position = new Vector3(Mathf.Clamp(smoothedPos.x, clampX.x, clampY.y), Mathf.Clamp(smoothedPos.y, clampX.x, clampY.y), smoothedPos.z);
		}
		else
		{
			for(int i = 0; i < cameras.Length; i++)
			{
				//cameraPos.z = initialCameraLocation[i].z;
				cameras[i].transform.eulerAngles = cameraRot;
				cameras[i].SetActive(false);

				if (i == currentCamera)
				{
					cameras[i].SetActive(true);
					cameras[i].transform.position = Vector3.Lerp(cameras[i].transform.position, cameraPos, smoothSpeed * Time.deltaTime);
					// Rotation.
					if (PickupInteraction.isInteracting)
					{
						rotCountNormal = 0;
						fromRot = cameras[i].transform;
						toRot = target.transform;
						cameras[i].transform.rotation = Quaternion.Slerp(fromRot.rotation, toRot.rotation, rotCountClose);
						rotCountClose += Time.deltaTime;
					}

					if (!PickupInteraction.isInteracting)
					{
						rotCountClose = 0;
						fromRot = cameras[i].transform;
						toRot = target.transform;
						cameras[i].transform.rotation = Quaternion.Slerp(toRot.rotation, fromRot.rotation, rotCountNormal);
						rotCountNormal += Time.deltaTime;
					}
				}
			}
		}
	}

	private void CameraSpawnLocation() // Initial location of cameras.
	{
		if (cameras.Length > 0)
		{
			for (int i = 0; i < cameras.Length; i++)
			{
				initialCameraLocation[i] = cameras[i].transform.position;
			}
		}
	}

	private void CameraCurrentLocation() // Current location of all cameras.
	{
		if (cameras.Length > 0)
		{
			for (int i = 0; i < cameras.Length; i++)
			{
				currentCameraLocation[i] = cameras[i].transform.position;
			}
		}
	}

}
