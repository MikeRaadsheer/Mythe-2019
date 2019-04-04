using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			CameraController.currentCamera = 1;
		}
	}
}
