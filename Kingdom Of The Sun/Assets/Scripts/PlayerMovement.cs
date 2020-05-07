using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private float speed = 5f;
	private float gravity = -19.62f;
	private CharacterController controller;
	private float jumpHeight = 2f;

	public Transform groundCheck;
	private float groundDistance = 0.4f;
	public LayerMask groundMask;
	private bool isGrounded;

	Vector3 velocity;
	void Start()
	{
		controller = GetComponent<CharacterController>();
	}

	void Update()
	{
		isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

		if (isGrounded && velocity.y < 0) 
		{
			velocity.y = -0f;
		}

		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");

		Vector3 move = transform.right * x + transform.forward * z;

		controller.Move(move * speed * Time.deltaTime);

		if (Input.GetButtonDown("Jump") && isGrounded) 
		{
			velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
		}

		velocity.y += gravity * Time.deltaTime;

		controller.Move(velocity * Time.deltaTime);
	}
}
