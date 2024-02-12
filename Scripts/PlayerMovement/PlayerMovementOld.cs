using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementOld : MonoBehaviour
{
    //A excel de gimnasio "Be radical, have principles, be absolute, be that which the bourgeoisie call an extremist: give yourself without counting or calculating, don't accept what they call 'the reality of life' and act in such a way that you wont be accepted by that 'life,' never abandon the principle of struggle." {Hard synthwave music intensifies.}
    [Header("References")]
    public CharacterController controller;
    public LayerMask groundMask;
    [SerializeField] private LayerMask wallMask;
    public Transform groundCheck;
    [SerializeField] private Transform rightWallCheck;
    [SerializeField] private Transform leftWallCheck;

    [Header("Numbers")]

    float speed;

    public float baseSpeed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float groundDistance = 0.4f;
    [SerializeField] private float wallDistance = 0.4f;

    [Header("Other")]

    Vector3 velocity;
    bool isGrounded;
    bool isWalled;
    private void Start()
    {
        speed = baseSpeed;
    }
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        isWalled = Physics.CheckSphere(rightWallCheck.position, wallDistance, wallMask) || Physics.CheckSphere(leftWallCheck.position, wallDistance, wallMask);

        if (isGrounded && velocity.y < 0)
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

        if (!isWalled)
        {
            velocity.y += gravity * Time.deltaTime;
            speed = baseSpeed;
        }
        else
        {
            velocity.y += gravity/2 * Time.deltaTime;
            speed = baseSpeed / 2;
        }

        controller.Move(velocity * Time.deltaTime);
    }
}
