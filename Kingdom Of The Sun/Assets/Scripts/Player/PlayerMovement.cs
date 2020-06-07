using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool roll = false; 
    private float speed = 2f;
    private float gravity = -19.62f;
    [SerializeField] private CharacterController controller;
    private float timer;
    private bool canAttack;

    [SerializeField] private PlayerSpeedTracker st;

    private float jumpHeight = 0.5f;
    private AnimationHandler animationHandler;

    public Transform groundCheck;
    private float groundDistance = 0.4f;
    public LayerMask groundMask;
    private bool isGrounded;

    public Vector3 velocity;
    void Start()
    {
        animationHandler = GetComponent<AnimationHandler>();
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {

        }

        timer += Time.deltaTime;
        if (timer > 1.5f)
        {
            canAttack = true;
        }
        movement();
        if (Input.GetMouseButtonDown(0))
        {
            timer = 0;
            canAttack = false;
            animationHandler.setAnimation(4);
        }
        if (Input.GetKeyDown(KeyCode.LeftControl) && !roll)
        {
            roll = true;
            StartCoroutine(Dodge());
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if(st.GetSpeed() >= 0)
            {
                animationHandler.setAnimation(12);
            }
            else
            {
                animationHandler.setAnimation(11);
            }
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

        if (x > 0 || z > 0)
        {
            animationHandler.setAnimation(11);
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

    IEnumerator Dodge()
    {
        speed = 10;
        animationHandler.setAnimation(6);
        yield return new WaitForSeconds(1);
        speed = 5;
        roll = false;
    }
}

