using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]

    public CharacterController controller;
    public LayerMask groundMask;
    public Transform groundCheck;

    [Header("Numbers")]

    float speed;

    public float baseSpeed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float groundDistance = 0.4f;
    public float dashForce;
    public float dashTime;

    [Header("Other")]

    Vector3 velocity;
    bool isGrounded;

    bool canDash;

    [Header("Headbob")]

    public Animator headBobing;
    private void Start()
    {
        canDash = true;

        speed = baseSpeed;
    }
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        //Dash

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash == true)
        {
            StartCoroutine(DashCorutine());

            canDash = false;
            StartCoroutine(DashCooldown());
        }

        //Headbobing

        //Forward bobing
        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            headBobing.SetBool("isForward", true);
        }
        else
        {
            headBobing.SetBool("isForward", false);
        }

        //Backwards bobing
        if(Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            headBobing.SetBool("isBackward", true);
        }
        else
        {
            headBobing.SetBool("isBackward", false);
        }

        //Left bobing
        if (Input.GetKey(KeyCode.A))
        {
            headBobing.SetBool("isLeft", true);
        }
        else
        {
            headBobing.SetBool("isLeft", false);
        }

        //Right bobing
        if (Input.GetKey(KeyCode.D))
        {
            headBobing.SetBool("isRight", true);
        }
        else
        {
            headBobing.SetBool("isRight", false);
        }
    }
    IEnumerator DashCorutine()
    {
        float startTime = Time.time;

        while(Time.time < startTime + dashTime)
        {
            speed = dashForce;

            yield return null;
        }

        speed = baseSpeed;
    }

    IEnumerator DashCooldown()
    {
        yield return new WaitForSeconds(1);

        print("Dash Ready");

        canDash = true;
    }
}
