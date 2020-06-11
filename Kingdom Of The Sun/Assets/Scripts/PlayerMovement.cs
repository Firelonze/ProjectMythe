using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	private float speed = 2f;
	private float gravity = -19.62f;
	[SerializeField] private CharacterController controller;
    private float timer;
    private bool canAttack;
    
	private float jumpHeight = 0.5f;
    private AnimationHandler1 animationHandler;

	public Transform groundCheck;
	private float groundDistance = 0.4f;
	public LayerMask groundMask;
	private bool isGrounded;

	Vector3 velocity;
	void Start()
	{
        animationHandler = GetComponent<AnimationHandler1>();
		controller = GetComponent<CharacterController>();
	}

	void Update()
	{
        
        timer += Time.deltaTime;
        if(timer > 1.5f)
        {
            canAttack = true;
        }
        movement();
        if (Input.GetMouseButtonDown(0)) 
        {
            animationHandler.setAnimation(3);
            timer = 0;
            canAttack = false;
            StartCoroutine(AnimationFix());

        }
    }

    void movement()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -0f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if(x > 0 || z > 0)
        {
            animationHandler.setAnimation(2);
            StartCoroutine(AnimationFix());
        }

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    private IEnumerator AnimationFix()
    {
        yield return new WaitForSeconds(0.2f);
        animationHandler.setAnimation(100);
    }
}

