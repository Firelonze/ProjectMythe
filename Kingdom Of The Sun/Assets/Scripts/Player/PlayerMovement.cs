using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int curWeapon = 0;
    private bool roll = false;
    private bool isCrouched = false;
    private float speed = 3f;
    private float gravity = -19.62f;
    [SerializeField] private CharacterController controller;
    private float timer;
    private bool canAttack;

    public GameObject camera;

    [SerializeField] private PlayerSpeedTracker st;

    private float jumpHeight = 0.5f;
    private AnimationHandler animationHandler;

    public Transform groundCheck;
    private float groundDistance = 0.4f;
    public LayerMask groundMask;
    private bool isGrounded;

    private int curAttack;

    public Vector3 velocity;
    void Start()
    {
        curAttack = 2;
        st = GetComponent<PlayerSpeedTracker>();
        animationHandler = GetComponent<AnimationHandler>();
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 0.8f)
        {
            canAttack = true;
        }

        movement();

        if (Input.GetMouseButtonDown(0) && canAttack)
        {
            timer = 0;
            canAttack = false;
            switch(curWeapon)
            {
                case 0:
                    animationHandler.setAnimation(curAttack);
                    curAttack++;
                    if (curAttack > 4)
                    {
                        curAttack = 2;
                    }
                    StartCoroutine(AnimationFix());
                    break;

                case 1:
                    animationHandler.setAnimation(5);
                    break;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            animationHandler.PlayAnim("pick_sword");
            curWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            animationHandler.PlayAnim("pick_gun");
            curWeapon = 1;
        }
    }

    void movement()
    {
        //isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -0f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if(Input.GetKeyDown(KeyCode.LeftControl) && !roll)
        {
            StartCoroutine(Dodge());
        }

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            speed = 1f;
            switch(curWeapon)
            {
                //crouch walking
                case 0:
                    animationHandler.setAnimation(44);
                    break;
                case 1:
                    animationHandler.setAnimation(8);
                    break;
            }
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            //crouching
            switch (curWeapon)
            {
                case 0:
                    animationHandler.setAnimation(11);

                    break;
                case 1:
                    animationHandler.setAnimation(7);
                    break;
            }
        }
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            //Walking
            speed = 3f;
            switch (curWeapon)
            {
                case 0:
                    animationHandler.setAnimation(1);

                    break;
                case 1:
                    animationHandler.setAnimation(45);
                    break;
            }
        }
        else
        {
            //idle
            switch (curWeapon)
            {
                case 0:
                    animationHandler.setAnimation(101);

                    break;
                case 1:
                    animationHandler.setAnimation(102);
                    break;
            }
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
        GetComponentInChildren<PlayerCameraMovement>().enabled = false;
        GetComponent<PlayerTurn>().enabled = false;
        speed = 10;
        switch (curWeapon)
        {
            case 0:
                animationHandler.PlayAnim("sword_roll");
                roll = true;
                break;

            case 1:
                animationHandler.PlayAnim("gun_roll");
                roll = true;
                break;
        }
        
        yield return new WaitForSeconds(animationHandler.getAnimationClipLength());
        speed = 5;
        roll = false;
        GetComponentInChildren<PlayerCameraMovement>().enabled = true;
        GetComponent<PlayerTurn>().enabled = true;
    }

    //This is retarded but i have not time right now to do it cleaner
    IEnumerator AnimationFix()
    {
        yield return new WaitForSeconds(0.1f);

        animationHandler.setAnimation(101);
    }
}

