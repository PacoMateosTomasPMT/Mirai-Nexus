using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallRun : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;

    [SerializeField] private LayerMask wallMask;
    [SerializeField] private Transform rightWallCheck;
    [SerializeField] private Transform leftWallCheck;

    [SerializeField] private float wallDistance = 0.4f;

    [SerializeField] private bool isWalled;
    private void Update()
    {
        isWalled = Physics.CheckSphere(rightWallCheck.position, wallDistance, wallMask) || Physics.CheckSphere(leftWallCheck.position, wallDistance, wallMask);

        if (isWalled)
        {
            print("Is walled");

            rb.useGravity = false;
        }
        else
        {
            rb.useGravity = true;
        }
    }
}
