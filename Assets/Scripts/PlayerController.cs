using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	// Movement.
	public float moveSpeed;
	//private float moveSpeed;
	private float horizontalMove, verticalMove;
	private bool diagonal;
	private Vector3 movement;

	// Components.
	private Rigidbody rb;

	// Animations.
	private bool isIdle;

	void Start() // Assign starting values.
	{
		// Components.
		rb = GetComponent<Rigidbody>();

		// Stats.
	}

	void Update()
	{
		PlayerMovement();
	}

	private void PlayerMovement() // Handles movement controls.
	{

		if (Input.GetAxis("Horizontal") != 0)
		{
			horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeed;
			movement = new Vector3(horizontalMove, rb.velocity.y, rb.velocity.z);
			rb.velocity = Vector3.Lerp(rb.velocity, movement, 15 * Time.deltaTime);
		}

		if (Input.GetAxis("Horizontal") == 0)
		{
			Vector3 standStill = new Vector3(0, rb.velocity.y, rb.velocity.z);
			rb.velocity = Vector3.Lerp(rb.velocity, standStill, 30 * Time.deltaTime);
		}
	}

	private void MovingDiagonal() // Checks if player is walking on both the X and Z axis. If so, slows movement.
	{
		diagonal = horizontalMove != 0 && verticalMove != 0;
		moveSpeed = !diagonal ? 5f : 3.5f;
	}
}
