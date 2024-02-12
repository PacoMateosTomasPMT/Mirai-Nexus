using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpulseSkill : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform playerDirection;
    [SerializeField] private bool canImpulse;

    [Header("Numbers")]
    [SerializeField] private float impulseStrength;
    [SerializeField] private float impulseTime;
    [SerializeField] private float impulseCountdown;
    private void Start()
    {
        canImpulse = true;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && canImpulse == true)
        {
            ImpulseStart();

            canImpulse = false;

            impulseCountdown = impulseTime;
        }

        if (impulseCountdown >= 0)
        {
            impulseCountdown -= Time.deltaTime;

            if (impulseCountdown <= 0)
            {
                canImpulse = true;
            }
        }
    }
    void ImpulseStart()
    {
        rb.AddForce(-transform.forward * impulseStrength);
    }
}
